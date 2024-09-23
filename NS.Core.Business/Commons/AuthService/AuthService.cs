using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Business.MailService;
using NS.Core.Commons;
using NS.Core.Commons.CustomException;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.TaiKhoanResponse;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace NS.Core.Business
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly bool _isNeedConfirmEmail;

        public AuthService(AppDbContext context, IMailService mailService, IConfiguration configuration)
        {
            _context = context;
            _mailService= mailService;
            _configuration = configuration;

            var emailConfig = _configuration.GetSection(Constants.EmailConstants.SEND_VERIFICATION_EMAIL).Value!;
            if (emailConfig != null) _isNeedConfirmEmail = bool.Parse(emailConfig);
        }

        public async Task<LoginResponseModel> Login(SignInData data)
        {
            try
            {
                data.Email.EmailValid();
                data.MatKhau.PasswordValid();

                TaiKhoan taiKhoan = await GetTaiKhoanByEmail(data.Email);
                //
                if (!taiKhoan.IsActive) throw new Exception(Constants.ExceptionMessage.EMAIL_NOT_ACTIVATED);

                bool isValidPassword = data.MatKhau.IsPasswordValid(taiKhoan.MatKhau);

                if (!isValidPassword) throw new InvalidException(nameof(TaiKhoan.MatKhau));

                var roles = string.Join(";", taiKhoan.DanhSachQuyen.Select(e => (int)e.MaQuyen));

                var token = GenerateToken(data.Email, roles);

                return new LoginResponseModel { Token = token, UserData = TaiKhoanResponseModel.Mapping(taiKhoan) };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Register(RegisterData data, string origin)
        {
            try
            {
                data.Email.EmailValid();
                data.MatKhau.PasswordValid();
                if (data.SoDienThoai != null) data.SoDienThoai.PhoneNumberValid();

                await EmailExisted(data.Email);

                data.MatKhau = data.MatKhau.HashPassword();

                var taiKhoan = data.Mapping(_isNeedConfirmEmail);

                _context.TaiKhoan.Add(taiKhoan);

                if (_isNeedConfirmEmail)
                {
                    var xacThucTaiKhoan = XacThucTaiKhoan.CreateXacThucTaiKhoanDangKy(taiKhoan);

                    _context.XacThucTaiKhoan.Add(xacThucTaiKhoan);

                    await SendMail(taiKhoan.Email, xacThucTaiKhoan.Id, Constants.MailMessage.LINK_VERIFY_EMAIL, origin, Enums.EmailCode.XacThucTaiKhoan);
                };

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task VerifyEmail(Guid guid)
        {
            var xacThucTaiKhoan = await _context.XacThucTaiKhoan
                .Include(e => e.TaiKhoan)
                .Where(e => e.Id == guid
                            && e.LoaiXacThucTaiKhoan == Enums.LoaiXacThucTaiKhoan.DangKy)
                .FirstOrDefaultAsync();

            if (xacThucTaiKhoan == null) throw new NotFoundException(nameof(xacThucTaiKhoan.Id));
            if (xacThucTaiKhoan.IsDeleted) throw new Exception(Constants.ExceptionMessage.VERIFIED);
            if (DateTime.Compare(xacThucTaiKhoan.NgayHetHan, DateTime.Now) < 0) throw new Exception(Constants.ExceptionMessage.EXPIRATION_TIME);

            //set active taikhoan
            xacThucTaiKhoan.TaiKhoan.IsActive = true;
            xacThucTaiKhoan.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task ForgotPassword(ForgotPasswordModel model, string origin)
        {
            var taiKhoan = await GetTaiKhoanByEmail(model.Email);

            var xacThucTaiKhoan = await _context.XacThucTaiKhoan
                .Where(e => e.TaiKhoanId == taiKhoan.Id
                            && !e.IsDeleted
                            && e.LoaiXacThucTaiKhoan == Enums.LoaiXacThucTaiKhoan.DatLaiMatKhau)
                .FirstOrDefaultAsync();

            if (xacThucTaiKhoan != null) xacThucTaiKhoan.IsDeleted = true;

            xacThucTaiKhoan = XacThucTaiKhoan.CreateXacThucTaiKhoanQuenMatKhau(taiKhoan);

            _context.XacThucTaiKhoan.Add(xacThucTaiKhoan);

            await SendMail(model.Email, xacThucTaiKhoan.Id, Constants.MailMessage.LINK_FORGOT_PASSWORD, origin, Enums.EmailCode.XacThucQuenMatKhau);

            await _context.SaveChangesAsync();
        }


        public async Task ChangePassword(ChangePasswordData data)
        {
            try
            {x
                var xacThucTaiKhoan = await _context.XacThucTaiKhoan
                    .Include(e => e.TaiKhoan)
                    .Where(e => e.Id == data.Key
                                && !e.IsDeleted
                                && e.LoaiXacThucTaiKhoan == Enums.LoaiXacThucTaiKhoan.DatLaiMatKhau)
                    .FirstOrDefaultAsync();

                if (xacThucTaiKhoan == null) throw new NotFoundException(nameof(xacThucTaiKhoan.Id));
                if (DateTime.Compare(xacThucTaiKhoan.NgayHetHan, DateTime.Now) < 0) throw new Exception(Constants.ExceptionMessage.EXPIRATION_TIME);

                data.MatKhau.PasswordValid();

                xacThucTaiKhoan.TaiKhoan.MatKhau = data.MatKhau.HashPassword();
                xacThucTaiKhoan.IsDeleted = true;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task EmailExisted(string emailAddress)
        {
            bool isEmailExisted = await _context.TaiKhoan
                .Where(e => e.Email == emailAddress.ToLower())
                .AnyAsync();

            if (isEmailExisted) throw new ExistException(nameof(TaiKhoan.Email));
        }

        public async Task<TaiKhoan> GetTaiKhoanByEmail(string emailAddress)
        {
            TaiKhoan? taiKhoan = await _context.TaiKhoan
                .Include(e => e.DanhSachQuyen)
                .Where(e => e.Email == emailAddress && !e.IsDeleted)
                .FirstOrDefaultAsync();

            if (taiKhoan is null) throw new NotFoundException(nameof(TaiKhoan.Email));

            return taiKhoan;
        }

        public string GenerateToken(string email, string roles)
        {
            try
            {
                List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Email, email), new Claim(ClaimTypes.Role, roles) };

                SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        _configuration.GetSection(Constants.AppSettingKeys.AUTH_SECRET).Value!));

                SigningCredentials credential = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: credential);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public RoleTaiKhoan DecodeToken(string token)
        {
            try
            {
                const string EMAIL = "emailaddress";
                const string ROLES = "role";

                byte[] key = Encoding.ASCII.GetBytes(_configuration.GetSection(Constants.AppSettingKeys.AUTH_SECRET).Value!);

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                TokenValidationParameters validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                };

                ClaimsPrincipal claims = handler.ValidateToken(token, validations, out var tokenSecure);

                var claimEmail = claims.FindFirst(c => c.Type.Contains(EMAIL));
                var claimRoles = claims.FindFirst(c => c.Type.Contains(ROLES));

                return new RoleTaiKhoan
                {
                    Email = claimEmail.Value,
                    DanhSachPhanQuyen = claimRoles.Value.Split(";").Select(e => (Enums.DanhSachPhanQuyen)int.Parse(e)).ToArray()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new InvalidException(nameof(token));
            }
        }

        //
        private async Task SendMail(string email, Guid key, string constantLink, string origin, Enums.EmailCode emailType)
        {
            var caiDatEmail = await _context.CaiDatEmail
                .Where(e => e.Code == emailType && !e.IsDeleted)
                .FirstOrDefaultAsync();

            if (caiDatEmail == null) throw new NotFoundException(nameof(CaiDatEmail));
            if(!caiDatEmail.NoiDung.Contains(Constants.MailMessage.TICK_LINK)) 
                throw new NotFoundException(nameof(Constants.MailMessage.TICK_LINK));

            var link = string.Format(constantLink, origin, key);

            var caiDatEmailToSendMail = new CaiDatEmail
            {
                TieuDe = caiDatEmail.TieuDe,
                NoiDung = caiDatEmail.NoiDung.Replace(Constants.MailMessage.TICK_LINK, link)
            };

            await _mailService.SendEmailAsync(email, caiDatEmailToSendMail);
        }

    }
}

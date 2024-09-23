using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business
{
    public class ThongTinTruongService : IThongTinTruongServices
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ThongTinTruongService> _logger;
        private readonly IConfiguration _config;

        public ThongTinTruongService(AppDbContext context, ILogger<ThongTinTruongService> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }


        public async Task UpdateThongTinTruong(ThongTinTruongReqModel input)
        {
            var config = await _context.ThongTinTruong.FirstOrDefaultAsync();
            if (config is null)
                throw new Exception(Constants.ExceptionMessage.ITEM_NOT_FOUND);
            config.ViTri = input.ViTri;
            config.TenTruong = input.TenTruong;
            config.MoTa = input.MoTa;
            config.DiaChi = input.DiaChi;
            config.SoDienThoai = input.SoDienThoai;
            config.ThoiGianLamViec = input.ThoiGianLamViec;
            config.Email = input.Email;
            config.SoDienThoaiTuyenSinh = input.SoDienThoaiTuyenSinh;
            config.EmailTuyenSinh = input.EmailTuyenSinh;
            config.Facebook = input.Facebook;
            config.YouTube = input.YouTube;
            _context.ThongTinTruong.Update(config);
            await _context.SaveChangesAsync();
        }
        public async Task<ThongTinTruongResModel> GetFooter()
        {
            var footer = await _context.ThongTinTruong.Select(x => new ThongTinTruongResModel
            {
                DiaChi = x.DiaChi,
                MoTa = x.MoTa,
                Email = x.Email,
                EmailTuyenSinh = x.EmailTuyenSinh,
                Facebook = x.Facebook,
                SoDienThoai = x.SoDienThoai,
                SoDienThoaiTuyenSinh = x.SoDienThoaiTuyenSinh,
                TenTruong = x.TenTruong,
                ThoiGianLamViec = x.ThoiGianLamViec,
                ViTri = x.ViTri,
                YouTube = x.YouTube,
            }).FirstOrDefaultAsync();
            return footer;
        }
    }
}

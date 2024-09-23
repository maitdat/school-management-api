using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Commons.CustomException;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.TaiKhoanService
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly AppDbContext _context;

        public TaiKhoanService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<TaiKhoanResponseModel> GetDetail(long id)
        {
            try
            {
                TaiKhoan taiKhoan = await GetById(id);
                return TaiKhoanResponseModel.Mapping(taiKhoan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        
        public async Task<BasePaginationResponseModel<TaiKhoanResponseModel>> GetAll(BasePaginationRequestModel userParams)
        {
            try
            {
                IQueryable<TaiKhoan> query = _context.TaiKhoan
                    .Where(e=>!e.IsDeleted)
                    .AsQueryable();

                ApplySearch(userParams, ref query);
                query = query.OrderByDescending(e => e.NgayCapNhat);

                int totalItems = 0;

                query = query.ApplyPaging(userParams.PageNo, userParams.PageSize, out totalItems);

                List<TaiKhoanResponseModel> result = await query
                    .Select(e => TaiKhoanResponseModel.Mapping(e))
                    .ToListAsync();

                return new BasePaginationResponseModel<TaiKhoanResponseModel>(userParams.PageNo, userParams.PageSize, result, totalItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task CreateOrUpdate(CreateOrUpdateTaiKhoanModel model)
        {
            try
            {
                TaiKhoan taiKhoan = model.Id>0 ?  await GetById(model.Id) : new TaiKhoan();

                model.Email.Trim().EmailValid();
                if (!model.SoDienThoai.IsNullOrEmpty()) model.SoDienThoai.PhoneNumberValid();
                if (!model.MatKhau.IsNullOrEmpty()) model.MatKhau.PasswordValid();

                bool isEmailExisted = await _context.TaiKhoan
                    .Where(e => e.Email == model.Email)
                    .AnyAsync();

                if (isEmailExisted && model.Email != taiKhoan.Email) throw new ExistException(nameof(TaiKhoan.Email));

                model.CreateOrUpdate(ref taiKhoan);

                _context.TaiKhoan.Update(taiKhoan);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        
        public async Task Delete(long id)
        {
            try
            {
                TaiKhoan taiKhoan = await GetById(id);
                taiKhoan.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        private async Task<TaiKhoan> GetById(long id)
        {
            try
            {
                IQueryable<TaiKhoan> taiKhoanQuery = _context.TaiKhoan
                    .Include(e=>e.DanhSachQuyen)
                    .Where(e => e.Id == id)
                    .AsQueryable();

                if (taiKhoanQuery.IsNullOrEmpty()) throw new NotFoundException(nameof(TaiKhoan.Id));

                return await taiKhoanQuery.FirstAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        
        private void ApplySearch(BasePaginationRequestModel userParams, ref IQueryable<TaiKhoan> query)
        {
            string keyword = userParams.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword)) query = query
                    .Where(e => EF.Functions.Collate(e.HoTen, "SQL_Latin1_General_CP1_CI_AI").Contains(keyword)
                    || e.Email.ToLower().Contains(keyword)
                    || e.SoDienThoai.ToLower().Contains(keyword));
        }

    }
}

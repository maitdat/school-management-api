using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.ThanhVienHoiDongService
{
    public class ThanhVienHoiDongService : IThanhVienHoiDong
    {
        private readonly AppDbContext _appDbContext;

        public ThanhVienHoiDongService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<ThanhVienHoiDong> GetById(long id)
        {
            IQueryable<ThanhVienHoiDong> query = _appDbContext.ThanhVienHoiDong
                .Include(x => x.HoiDongKhaoThi)
                .Where(e => e.Id == id && !e.IsDeleted);

            if (query.IsNullOrEmpty()) throw new NotFoundException(nameof(ThanhVienHoiDong.Id));

            return await query.FirstAsync();
        }
        public async Task<ThanhVienHoiDongResponseModel> GetDetail(long id)
        {
            try
            {
                ThanhVienHoiDong thanhVienHoiDong = await GetById(id);

                return ThanhVienHoiDongResponseModel.Mapping(thanhVienHoiDong);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<List<HoiDongKhaoThiDropdownModel>> GetHoiDongKhaoThiDropdown()
        {
            List<HoiDongKhaoThiDropdownModel> result = await _appDbContext.HoiDongKhaoThi
                .Where(e => !e.IsDeleted).Select(e => HoiDongKhaoThiDropdownModel.Mapping(e))
                .ToListAsync();
            return result;
        }
        public async Task<BasePaginationResponseModel<ThanhVienHoiDongResponseModel>> GetAllByHoiDongKhaoThiId(ThanhVienHoiDongParams paramsModel)
        {
            try
            {
                IQueryable<ThanhVienHoiDong> query = _appDbContext.ThanhVienHoiDong
                    .Include(e => e.HoiDongKhaoThi)
                    .Where(e => !e.IsDeleted)
                    .AsQueryable();

                ApplySearch(paramsModel, ref query);
                ApplyFilter(paramsModel, ref query);
                ApplySortBy(paramsModel, ref query);

                int totalItems = 0;

                query = query.ApplyPaging(paramsModel.PageNo, paramsModel.PageSize, out totalItems);

                List<ThanhVienHoiDongResponseModel> result = await query
                    .Select(e => ThanhVienHoiDongResponseModel.Mapping(e))
                    .ToListAsync();

                int totalPages = (int)Math.Ceiling((double)totalItems / paramsModel.PageSize);

                return new BasePaginationResponseModel<ThanhVienHoiDongResponseModel>(paramsModel.PageNo, paramsModel.PageSize, result, totalItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task Create(CreateThanhVienHoiDongModel model)
        {
            try
            {
                await GetHoiDongKhaoThiById(model.HoiDongKhaoThiId);

                typeof(Enums.QuyenKhaoThi).IsDefineEnum(model.QuyenKhaoThi);

                _appDbContext.Add(model.Mapping());
                await _appDbContext.SaveChangesAsync();

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task Update(UpdateThanhVienHoiDongModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.MatKhau)) model.MatKhau.Trim().PasswordValid();
                model.TaiKhoan.Trim().EmailValid();

                ThanhVienHoiDong thanhVienHoiDong = await GetById(model.Id);
                await GetHoiDongKhaoThiById(model.HoiDongKhaoThiId);

                typeof(Enums.QuyenKhaoThi).IsDefineEnum(model.QuyenKhaoThi);

                model.Update(ref thanhVienHoiDong);

                _appDbContext.Update(thanhVienHoiDong);
                await _appDbContext.SaveChangesAsync();
                return;
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
                ThanhVienHoiDong thanhVienHoiDong = await GetById(id);
                thanhVienHoiDong.IsDeleted = true;

                _appDbContext.Update(thanhVienHoiDong);
                await _appDbContext.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        //
        private void ApplySortBy(ThanhVienHoiDongParams paramsModel, ref IQueryable<ThanhVienHoiDong> query)
        {
            if (!string.IsNullOrEmpty(paramsModel.SortBy) && paramsModel.SortBy == "thoiGianMo")
            {
                query = query.OrderByDescending(e => e.ThoiGianMo);
            }
            else if (!string.IsNullOrEmpty(paramsModel.SortBy) && paramsModel.SortBy == "thoiGianDong")
            {
                query = query.OrderByDescending(e => e.ThoiGianDong);
            }
            else
            {
                query = query.OrderByDescending(e => e.Id);
            }
        }
        private void ApplySearch(ThanhVienHoiDongParams paramsModel, ref IQueryable<ThanhVienHoiDong> query)
        {
            string keyword = paramsModel.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword)) query = query
                    .Where(e => e.TaiKhoan.Contains(keyword));
        }
        private void ApplyFilter(ThanhVienHoiDongParams paramsModel, ref IQueryable<ThanhVienHoiDong> query)
        {
            if (paramsModel.HoiDongKhaoThiId > 0)
            {
                query = query.Where(e => e.HoiDongKhaoThiId == paramsModel.HoiDongKhaoThiId);
            }

            if (paramsModel.QuyenKhaoThi != null)
            {
                query = query.Where(e => e.QuyenKhaoThi == paramsModel.QuyenKhaoThi);
            }

            if (paramsModel.Status.HasValue)
            {
                query = query
                   .Where(e => e.DangKichHoat == paramsModel.Status);
            }

            if (paramsModel.DateCloseFrom != DateTime.MinValue)
                query = query.Where(e => paramsModel.DateCloseFrom <= e.ThoiGianDong);

            if (paramsModel.DateCloseTo != DateTime.MinValue)
                query = query.Where(e => paramsModel.DateCloseTo >= e.ThoiGianDong);

            if (paramsModel.DateOpenFrom != DateTime.MinValue)
                query = query.Where(e => paramsModel.DateOpenFrom <= e.ThoiGianMo);

            if (paramsModel.DateOpenTo != DateTime.MinValue)
                query = query.Where(e => paramsModel.DateOpenTo >= e.ThoiGianMo);
        }

        private async Task<HoiDongKhaoThi> GetHoiDongKhaoThiById(long id)
        {
            HoiDongKhaoThi hoiDongKhaoThi = await _appDbContext.HoiDongKhaoThi
                .Where(e => e.Id == id & !e.IsDeleted)
                .FirstOrDefaultAsync();

            if (hoiDongKhaoThi is null) throw new NotFoundException(nameof(HoiDongKhaoThi));
            return hoiDongKhaoThi;
        }
    }
}

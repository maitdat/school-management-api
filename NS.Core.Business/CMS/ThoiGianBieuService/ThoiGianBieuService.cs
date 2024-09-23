using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.ThoiGianBieuRequestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LandingPage;
using NS.Core.Commons.CustomException;

namespace NS.Core.Business.ThoiGianBieuService
{
    public class ThoiGianBieuService : IThoiGianBieuService
    {
        private readonly AppDbContext _context;

        public ThoiGianBieuService(AppDbContext dbcontext)
        {
            _context = dbcontext;
        }

        //AddChange
        public async Task AddChangeThoiGianBieu(CreateOrUpdateThoiGianBieuRequestModel model)
        {
            _context.ThoiGianBieu.Update(model.Mapping());
            await _context.SaveChangesAsync();
        }

        public async Task AddChangeLoaiSuKien(CreateOrUpDateLoaiSuKienRequestModel model)
        {
            _context.LoaiSuKien.Update(model.Mapping());
            await _context.SaveChangesAsync();
        }

        public async Task AddChangeLichSuKien(CreateOrUpdateLichSuKienRequestModel model)
        {
            _context.LichSuKien.Update(model.Mapping());
            await _context.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteLichSuKien(long id)
        {
            var entity = await _context.LichSuKien
                .Where(e => e.Id == id && !e.IsDeleted)
                .FirstOrDefaultAsync();

            // if (entity == null) throw new InvalidException(nameof(LichSuKien.Id));

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteThoiGianBieu(long id)
        {
            var entity = await _context.ThoiGianBieu
                .Where(e => e.Id == id && !e.IsDeleted)
                .FirstOrDefaultAsync();

            if (entity == null) throw new InvalidException(nameof(ThoiGianBieu.Id));

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLoaiSuKien(long id)
        {
            var entity = await _context.LoaiSuKien
                .Where(e => e.Id == id && !e.IsDeleted)
                .FirstOrDefaultAsync();

            if (entity == null) throw new InvalidException(nameof(LoaiSuKienModel.Id));

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }


        //GetById
        public async Task<LoaiSuKienResponseModel> GetLoaiSuKienById(long id)
        {
            var resutl = await _context.LoaiSuKien
                .GetAvailableByIdQueryable(id)
                .Select(x => new LoaiSuKienResponseModel
                {
                    Id = x.Id,
                    LoaiSuKien = x.LoaiSuKien,
                    LoaiSuKienTiengAnh = x.LoaiSuKienTiengAnh,
                    Mau = x.Color
                })
                .FirstOrDefaultAsync();
            return resutl;
        }

        public async Task<ThoiGianBieuResponseModel> GetThoiGianBieuById(long id)
        {
            var resutl = await _context.ThoiGianBieu
                .GetAvailableByIdQueryable(id)
                .Select(x => ThoiGianBieuResponseModel.Mapping(x))
                .FirstOrDefaultAsync();
            return resutl;
        }

        public async Task<LichSuKienResponseDetail> GetLichSuKienById(long id)
        {
            var resutl = await _context.LichSuKien
                .GetAvailableByIdQueryable(id)
                .Select(x => new LichSuKienResponseDetail
                {
                    Id = x.Id,
                    NgayBatDau = x.NgayBatDau,
                    NgayKetThuc = x.NgayKetThuc,
                    LoaiSuKien = x.LoaiSuKien.Id,
                    LoaiSuKienTiengAnh = x.LoaiSuKien.LoaiSuKienTiengAnh,
                    TenSuKien = x.TenSuKien,
                    TenSuKienTiengAnh = x.TenSuKienTiengAnh,
                    Color = x.LoaiSuKien.Color,
                })
                .FirstOrDefaultAsync();
            return resutl;
        }

        //GetAll
        public async Task<List<LoaiSuKienResponseModel>> GetAllLoaiSuKien()
        {
            var resutl = await _context.LoaiSuKien
                .Where(c => c.IsDeleted == false)
                .Select(x => new LoaiSuKienResponseModel
                {
                    Id = x.Id,
                    LoaiSuKien = x.LoaiSuKien,
                    LoaiSuKienTiengAnh = x.LoaiSuKienTiengAnh,
                    Mau = x.Color
                })
                .OrderByDescending(x => x.Id)
                .ToListAsync();
            return resutl;
        }

        public Task<BasePaginationResponseModel<LichSuKienResponseModel>> GetAllLichSuKien(
            LichSuKienRequestModel model)
        {
            var resutl = _context.LichSuKien
                    .Include(e => e.LoaiSuKien)
                    .Where(c => c.IsDeleted == false && c.LoaiSuKien.IsDeleted == false)
                ;

            ApplySearch(model, ref resutl);
            ApplyFilter(model, ref resutl);

            resutl = resutl.OrderByDescending(e => e.NgayBatDau);

            var lichSuKienList = resutl
                .Select(x => LichSuKienResponseModel.Mapping(x))
                .ApplyPaging(model.PageNo, model.PageSize, out var totalItem)
                .ToList();

            return Task.FromResult(
                new BasePaginationResponseModel<LichSuKienResponseModel>(model.PageNo, model.PageSize, lichSuKienList,
                    totalItem));
        }

        public async Task<BasePaginationResponseModel<ThoiGianBieuResponseModel>> GetAllThoiGianBieu(
            ThoiGianBieuRequestModel model)
        {
            var query = _context.ThoiGianBieu
                .Where(c => c.IsDeleted == false
                            && c.CaHoc == model.CaHoc)
                .AsQueryable();

            int totalItems = 0;

            query = query.ApplyPaging(model.PageNo, model.PageSize, out totalItems);
            
            int totalPages = (int)Math.Ceiling((double)totalItems / model.PageSize);
            
            var result = await query.Select(e => ThoiGianBieuResponseModel.Mapping(e)).ToListAsync();
            
            return new BasePaginationResponseModel<ThoiGianBieuResponseModel>(model.PageNo, model.PageSize, result,
                totalItems);
        }

        private void ApplySearch(LichSuKienRequestModel model, ref IQueryable<LichSuKien> query)
        {
            string keyword = model.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword))
                query = query
                    .Where(e => EF.Functions
                        .Collate(e.TenSuKien, "SQL_Latin1_General_CP1_CI_AI")
                        .Contains(model.Keyword.Trim())
                    );
        }

        private void ApplyFilter(LichSuKienRequestModel model, ref IQueryable<LichSuKien> query)
        {
            if (model.LoaiSuKien != null)
            {
                query = query.Where(e => e.LoaiSuKienId == model.LoaiSuKien);
            }

            if (model.TuNgay > DateTime.MinValue)
                query = query.Where(e => model.TuNgay <= e.NgayBatDau);

            if (model.DenNgay < DateTime.MaxValue)
                query = query.Where(e => model.DenNgay >= e.NgayKetThuc);
        }
    }
}
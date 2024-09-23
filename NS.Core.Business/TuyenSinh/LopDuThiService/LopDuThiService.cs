using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.LopDuThi;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LopDuThi;
using System.Linq;

namespace NS.Core.Business.LopDuThiService
{
    public class LopDuThiService : ILopDuThiService
    {
        private readonly AppDbContext _context;

        public LopDuThiService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(long id)
        {
            var lopDuThi = await GetByIdAvailable(id);
            lopDuThi.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<LopDuThiResponseModel> GetById(long id)
        {
            try
            {
                var lopDuThi = LopDuThiResponseModel.Mapping(await GetByIdAvailable(id));
                return lopDuThi;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<LopDuThi> GetByIdAvailable(long id)
        {
            try
            {
                var query = _context.LopDuThi
                    .Include(e => e.ThoiGianThi)
                    .Include(e => e.GiaoVienTrongThi)
                    .ThenInclude(e => e.ThanhVienHoiDong)
                    .Where(e => e.Id == id)
                    .AsQueryable();
                if (query.IsNullOrEmpty()) throw new NotFoundException(nameof(LopDuThi.Id));

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BasePaginationResponseModel<LopDuThiResponseModel>> GetAll(BasePaginationRequestModel model)
        {
            try
            {
                var queryable = _context.LopDuThi
                    .Include(e => e.ThoiGianThi)
                    .Include(e => e.GiaoVienTrongThi)
                    .ThenInclude(e => e.ThanhVienHoiDong)
                    .Where(e => !e.IsDeleted);

                if (!model.Keyword.IsNullOrEmpty())
                {
                    queryable = queryable.Where(e => e.TenLop.Contains(model.Keyword.ToLower()));
                }

                var lopDuThiList = queryable
                    .ApplyPaging(model.PageNo, model.PageSize, out var totalItem)
                    .Select(e => LopDuThiResponseModel.Mapping(e))
                    .ToList();

                return await Task.FromResult(new BasePaginationResponseModel<LopDuThiResponseModel>(model.PageNo, model.PageSize, lopDuThiList, totalItem));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AddChange(CreateAndUpdateLopDuThiRequestModel model)
        {
            try
            {
                var lopDuThi = await _context.LopDuThi
                    .Include(e => e.GiaoVienTrongThi)
                    .Where(e => e.Id == model.Id && !e.IsDeleted)
                    .FirstOrDefaultAsync()
                    ?? new LopDuThi();

                var giaoVienTrongThi = _context.ThanhVienHoiDong
                                     .Where(e => model.GiaoVienTrongThi == e.Id);

                if (giaoVienTrongThi == null) throw new NotFoundException(nameof(model.GiaoVienTrongThi));

                if (!lopDuThi.GiaoVienTrongThi.IsNullOrEmpty())
                {
                    var giaoVienChinh = lopDuThi.GiaoVienTrongThi.Where(e => e.LaGiaoVienChinh).FirstOrDefault();
                    _context.GiaoVienTrongThi.Remove(giaoVienChinh);
                }

                _context.LopDuThi.Update(model.Mapping(lopDuThi));

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<BasePaginationResponseModel<ThanhVienHoiDongForDropdownResponModel>> GetAllThanhVienHoiDong(GetAllThanhVienHoiDongRequestModel model)
        {
            try
            {
                var query = _context.ThanhVienHoiDong
                    .Include(e => e.GiaoVienTrongThi)
                    .AsQueryable();

                if (model.KyTuyenSinhId > 0) query = query
                        .Where(e => e.GiaoVienTrongThi.LopDuThiId == null
                        && e.HoiDongKhaoThi.KyTuyenSinhId == model.KyTuyenSinhId);

                if (model.LopDuThiId > 0) query = query.Where(e => e.GiaoVienTrongThi.LopDuThiId == model.LopDuThiId);

                var thanhVienHoiDongList = await query
                    .Select(e => ThanhVienHoiDongForDropdownResponModel.Mapping(e))
                    .ToListAsync();

                return new BasePaginationResponseModel<ThanhVienHoiDongForDropdownResponModel>(1, 1, thanhVienHoiDongList, thanhVienHoiDongList.Count);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AddGiaoVien(AddGiaoVienToLopDuThiRequestModel model)
        {
            var lopDuThi = await _context.LopDuThi
                .Where(e => e.Id == model.LopDuThiId
                && !e.IsDeleted)
                .FirstOrDefaultAsync();

            var thanhVienHoiDongList = await _context.ThanhVienHoiDong
                .Where(e => model.GiaoVienTrongThi.Any(g => g == e.Id)
                && !e.IsDeleted)
                .ToListAsync();

            if (lopDuThi == null) throw new NotFoundException(nameof(LopDuThi));
            if (thanhVienHoiDongList.Count != model.GiaoVienTrongThi.Length)
                throw new NotFoundException(nameof(GiaoVienTrongThi));

            _context.GiaoVienTrongThi
                .AddRange(model.GiaoVienTrongThi.Select(e => new GiaoVienTrongThi
                {
                    LaGiaoVienChinh = false,
                    ThanhVienHoiDongId = e,
                    LopDuThiId = model.LopDuThiId,
                }));

            await _context.SaveChangesAsync();
        }

        public Task DeleteGiaoVien(long id)
        {
            throw new NotImplementedException();
        }
    }

}


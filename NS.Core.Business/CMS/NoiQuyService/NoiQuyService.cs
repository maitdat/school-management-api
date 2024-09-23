using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.NoiQuyRequest;
using NS.Core.Models.ResponseModels.NoiQuy;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.NoiQuyService
{
    public class NoiQuyService:INoiQuyService
    {
        private readonly AppDbContext _context;
        public NoiQuyService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateNoiQuy(CreateOrUpdateNoiQuyRequest data)
        {
            try
            {
                CaiDatChiTiet newNoiQuy = new CaiDatChiTiet()
                {
                    MoTa = data.NoiDung,
                    TieuDe = data.TenNoiQuy,
                    CaiDatTongTheId = data.LoaiNoiQuyId,
                    MoTaTiengAnh = data.NoiDungTiengAnh,
                    TieuDeTiengAnh = data.TenNoiQuyTiengAnh,
                };
                _context.CaiDatChiTiet.Add(newNoiQuy);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(data.LoaiNoiQuyId)));
            }
        }
        public async Task UpdateNoiQuy(long id, CreateOrUpdateNoiQuyRequest data)
        {
            try
            {
                CaiDatChiTiet updateNoiQuy = _context.CaiDatChiTiet.Where(x => x.Id == id).FirstOrDefault();
                updateNoiQuy.MoTa = data.NoiDung;
                updateNoiQuy.TieuDe = data.TenNoiQuy;
                updateNoiQuy.CaiDatTongTheId = data.LoaiNoiQuyId;
                updateNoiQuy.MoTaTiengAnh = data.NoiDungTiengAnh;
                updateNoiQuy.TieuDeTiengAnh = data.TenNoiQuyTiengAnh;
                _context.CaiDatChiTiet.Update(updateNoiQuy);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(data)));
            }
        }
        public async Task DeleteNoiQuy(long id)
        {
            CaiDatChiTiet deleteNoiQuy = _context.CaiDatChiTiet.Where(x => x.Id == id).FirstOrDefault();
            _context.CaiDatChiTiet.Remove(deleteNoiQuy);
            await _context.SaveChangesAsync();
        }
        public async Task<BasePaginationResponseModel<NoiQuyResponseModel>> GetPageNoiQuy(GetPagedNoiQuyRequest page)
        {
            var result = _context.CaiDatChiTiet.Select(x => new NoiQuyResponseModel
            {
                Id = x.Id,
                LoaiNoiQuy = x.CaiDatTongThe.TieuDe,
                NoiDung = x.MoTa,
                TenNoiQuy = x.TieuDe,
                NoiDungTiengAnh = x.MoTaTiengAnh,
                TenNoiQuyTiengAnh = x.TieuDeTiengAnh,
                LoaiNoiQuyId = x.CaiDatTongTheId
            });
            var keyword = page.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(record =>
                    record.TenNoiQuy.ToLower().Contains(keyword)
                    || record.NoiDung.ToLower().Contains(keyword));
            }
            if (page.LoaiNoiQuyId.HasValue)
            {
                result = result.Where(record => record.LoaiNoiQuyId == page.LoaiNoiQuyId.Value);
            }
            var paging = result.ApplyPaging(page.PageNo, page.PageSize).ToList();
            return new BasePaginationResponseModel<NoiQuyResponseModel>(page.PageNo, page.PageSize, paging, result.Count());
        }
        public async Task<NoiQuyResponseModel> GetById(long id)
        {
            var noiQuy = GetAll().Where(x => x.Id == id).Select(x => new NoiQuyResponseModel()
            {
                Id = x.Id,
                LoaiNoiQuy = x.CaiDatTongThe.TieuDe,
                NoiDung = x.MoTa,
                TenNoiQuy = x.TieuDe,
                NoiDungTiengAnh = x.MoTaTiengAnh,
                TenNoiQuyTiengAnh = x.TieuDeTiengAnh,
                LoaiNoiQuyId = x.CaiDatTongTheId
            }).FirstOrDefault();

            if (noiQuy == null)
                throw new(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(CaiDatTongThe.Id)));
            return noiQuy;

        }
        public IQueryable<CaiDatChiTiet> GetAll()
        {
            return _context.CaiDatChiTiet.AsQueryable();
        }
    }
}

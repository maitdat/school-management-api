using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.CaiDatTrang;
using NS.Core.Models.ResponseModels.CaiDat;


namespace NS.Core.Business.CaiDatTrang
{
    public class CaiDatTrangService : ICaiDatTrangService
    {
        private readonly AppDbContext _dbContext;
        public CaiDatTrangService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
 
        public async Task SuaTrang(long id, TrangRequestModel trangDataDto)
        {
            var trang = _dbContext.Trang
                .Include(t => t.CaiDatTongThe)
                .ThenInclude(cdt => cdt.CaiDatChiTiet)
                .FirstOrDefault(x => x.Id == id);

            if (trang == null)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(Trang.Id)));
            }
            else
            {
                trang.TenTrang = trangDataDto.TenTrang;

                foreach (var caiDatTongTheDto in trangDataDto.CaiDatTongThe)
                {
                    var caiDatTongThe = trang.CaiDatTongThe.Where(y => y.Id == caiDatTongTheDto.Id).First();

                    if (caiDatTongThe != null)
                    {
                        caiDatTongThe.TieuDe = caiDatTongTheDto.TieuDe;
                        caiDatTongThe.TieuDeTiengAnh = caiDatTongTheDto.TieuDeTiengAnh;
                        caiDatTongThe.Mota = caiDatTongTheDto.Mota;
                        caiDatTongThe.MotaTiengAnh = caiDatTongTheDto.MotaTiengAnh;
                        caiDatTongThe.Link = caiDatTongTheDto.Link;

                        foreach (var caiDatChiTietDto in caiDatTongTheDto.CaiDatChiTiet)
                        {
                            var caiDatChiTiet = caiDatTongThe.CaiDatChiTiet.Where(z => z.Id == caiDatChiTietDto.Id).First();

                            if (caiDatChiTiet != null)
                            {
                                caiDatChiTiet.TieuDe = caiDatChiTietDto.TieuDe;
                                caiDatChiTiet.TieuDeTiengAnh = caiDatChiTietDto.TieuDeTiengAnh;
                                caiDatChiTiet.MoTa = caiDatChiTietDto.MoTa;
                                caiDatChiTiet.MoTaTiengAnh = caiDatChiTietDto.MoTaTiengAnh;
                                caiDatChiTiet.Link = caiDatChiTietDto.Link;
                                caiDatChiTiet.Icon = caiDatChiTietDto.Icon;
                                caiDatChiTiet.LinkAnh = caiDatChiTietDto.LinkAnh;
                            }
                        }
                    }
                }
            }

            await _dbContext.SaveChangesAsync();
        }
  

        public async Task<TrangResponse> GetTrangById(long id)
        {

            var query = _dbContext.Trang.Where(t => t.Id == id && !t.IsDeleted);
            if (query == null) throw new NotFoundException(nameof(Trang.Id));
            var result = await query.SelectMany(x => x.CaiDatTongThe)
             .Select(x => new CaiDatTongTheResponseModel
             {
                 Id = x.Id,
                 TrangId = x.TrangId,
                 TieuDe = x.TieuDe,
                 TieuDeTiengAnh = x.TieuDeTiengAnh,
                 Mota = x.Mota,
                 MotaTiengAnh = x.MotaTiengAnh,
                 Link = x.Link,
                 CaiDatChiTiet = x.CaiDatChiTiet.Select(z => new CaiDatChiTietResponseModel
                 {
                     Id = z.Id,
                     CaiDatTongTheId = z.CaiDatTongTheId,
                     TieuDe = z.TieuDe,
                     TieuDeTiengAnh = z.TieuDeTiengAnh,
                     MoTa = z.MoTa,
                     MoTaTiengAnh = z.MoTaTiengAnh,
                     Link = z.Link,
                     Icon = z.Icon,
                     LinkAnh = z.LinkAnh
                 })
             })
             .ToListAsync();

            return new TrangResponse
            {
                Id = query.First().Id,
                TenTrang = query.First().TenTrang,
                CaiDatTongThe = result
            };
        }

        public async Task ThemCaiDatChiTiet(CreateCaiDatChiTietRequestModel caiDatChiTietDto,long caiDatTongTheId)
        {
            if (_dbContext.CaiDatTongThe.Where(x => x.Id == caiDatTongTheId).FirstOrDefault() == null) ;
            var obj = new CaiDatChiTiet()
            {
                Id = caiDatChiTietDto.Id,
                CaiDatTongTheId = caiDatTongTheId,
                TieuDe = caiDatChiTietDto.TieuDe,
                TieuDeTiengAnh = caiDatChiTietDto.TieuDeTiengAnh,
                MoTa = caiDatChiTietDto.MoTa,
                MoTaTiengAnh = caiDatChiTietDto.MoTaTiengAnh,
                Link = caiDatChiTietDto.Link,
                Icon = caiDatChiTietDto.Icon,
                LinkAnh = caiDatChiTietDto.LinkAnh
            };
            _dbContext.CaiDatChiTiet.Add(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task XoaCaiDatChiTiet(long id)
        {
            var obj = await _dbContext.CaiDatChiTiet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (obj == null)
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(CaiDatChiTiet.Id)));
            _dbContext.CaiDatChiTiet.Remove(obj);
            _dbContext.SaveChanges();
        }

        public async Task<CaiDatTongTheResponseModel> GetCaiDatTongTheById(long id)
        {
            var obj = await _dbContext.CaiDatTongThe.Where(x=>x.Id == id).FirstOrDefaultAsync(); 
            if(obj == null)
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(CaiDatTongThe.Id)));
            obj.CaiDatChiTiet = _dbContext.CaiDatChiTiet.Where(x=>x.CaiDatTongTheId == id).ToList();
            return new CaiDatTongTheResponseModel()
            {
                Id = obj.Id,
                TrangId = obj.TrangId,
                TieuDe = obj.TieuDe,
                TieuDeTiengAnh = obj.TieuDeTiengAnh,
                Mota = obj.Mota,
                MotaTiengAnh = obj.MotaTiengAnh,
                Link = obj.Link,
                CaiDatChiTiet = obj.CaiDatChiTiet.Select(z => new CaiDatChiTietResponseModel
                {
                    Id = z.Id,
                    CaiDatTongTheId = z.CaiDatTongTheId,
                    TieuDe = z.TieuDe,
                    TieuDeTiengAnh = z.TieuDeTiengAnh,
                    MoTa = z.MoTa,
                    MoTaTiengAnh = z.MoTaTiengAnh,
                    Link = z.Link,
                    Icon = z.Icon,
                    LinkAnh = z.LinkAnh
                })
            };
        }

    }
}


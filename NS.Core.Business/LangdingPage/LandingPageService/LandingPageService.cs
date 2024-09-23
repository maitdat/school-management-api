using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.ResponseModels.LandingPage;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.LandingPageService
{
    public class LandingPageService : ILandingPage
    {
        private readonly AppDbContext _appDbContext;

        public LandingPageService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<LandingPageResponseModel> GetDetail(long id)
        {
            try
            {
                //if (id == (long)DanhSachTrangTinh.TrangChu)
                //{
                //    return GenerateFakeTrangChu();
                //}
                IQueryable<Trang> trang = _appDbContext.Trang.Where(e => e.Id == id);
                if (trang.IsNullOrEmpty()) throw new NotFoundException(nameof(Trang.Id));

                var data = trang.Select(c => new LandingPageResponseModel
                {
                    TenTrang = c.TenTrang,
                    Id = c.Id,
                    CaiDatTongThe = c.CaiDatTongThe.Select(x => new CaiDatTongThe
                    {
                        TrangId = x.TrangId,
                        TieuDe = x.TieuDe,
                        TieuDeTiengAnh = x.TieuDeTiengAnh,
                        Mota = x.Mota,
                        MotaTiengAnh = x.MotaTiengAnh,
                        Link = x.Link,
                        FileId = x.FileId,
                        ThuTu = x.ThuTu,
                        LinkAnh = x.LinkAnh,
                        CaiDatChiTiet = x.CaiDatChiTiet.Select(z => new CaiDatChiTiet
                        {
                            CaiDatTongTheId = z.CaiDatTongTheId,
                            FileId = z.FileId,
                            TieuDe = z.TieuDe,
                            TieuDeTiengAnh = z.TieuDeTiengAnh,
                            MoTa = z.MoTa,
                            MoTaTiengAnh = z.MoTaTiengAnh,
                            Link = z.Link,
                            Icon = z.Icon,
                            LinkAnh = z.LinkAnh,
                            ThuTu = z.ThuTu,
                            File = _appDbContext.FileUpload.Where(f => f.Id == z.FileId).FirstOrDefault()
                        }).OrderBy(o => o.ThuTu).ToList()
                    }).OrderBy(o => o.ThuTu).ToList()
                }).First();


                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        

        public async Task<ThoiGianBieuPageResponseModel> GetThoiGianBieu()
        {
            try
            {
                List<ThoiGianBieuResponseModel> thoiGianBieuList = await _appDbContext.ThoiGianBieu
                    .Where(e => !e.IsDeleted)
                    .Select(e => ThoiGianBieuResponseModel.Mapping(e))
                    .ToListAsync();


                List<LichSuKien> lichSuKienList = await _appDbContext.LichSuKien
                    .Where(e => !e.IsDeleted)
                    .Include(e => e.LoaiSuKien)
                    .ToListAsync();

                List<LoaiSuKienResponseModel> loaiSuKienList = await _appDbContext.LoaiSuKien
                    .Where(e => !e.IsDeleted)
                    .Select(e => LoaiSuKienResponseModel.Mapping(e))
                    .ToListAsync();

                return ThoiGianBieuPageResponseModel.Mapping(thoiGianBieuList, lichSuKienList, loaiSuKienList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}

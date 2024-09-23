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

        private LandingPageResponseModel GenerateFakeTrangChu()
        {
            return new LandingPageResponseModel
            {
                TenTrang = "Trang chủ",
                Id = (long)DanhSachTrangTinh.TrangChu,
                CaiDatTongThe = new List<CaiDatTongThe>
                {
                    new CaiDatTongThe
                    {
                        CaiDatChiTiet = new List<CaiDatChiTiet>
                        {
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/069CB778-25BB-4112-A927-F442FFE30E9A.png",
                                Link = "/thong-tin-tuyen-sinh",
                                TieuDe = "Thông tin tuyển sinh 2023"
                            },
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/AA43AEA5-3504-4C89-AF2B-D859BD6B570D.JPG",
                            },
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/4E635465-AC1A-4FF3-A15B-986C2392AD01.jpg",
                            },
                        }
                    },
                    new CaiDatTongThe
                    {
                        CaiDatChiTiet = new List<CaiDatChiTiet>
                        {
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg",
                            },
                        }
                    },
                    new CaiDatTongThe
                    {
                        CaiDatChiTiet = new List<CaiDatChiTiet>
                        {
                            new CaiDatChiTiet
                            {
                                TieuDe = "<p>Trường tiểu học Nguyễn Siêu</p><p><span style=\"font-size:20px;\"><strong>Ngôi trường</strong></span></p><p><span style=\"font-size:20px;\"><strong>hiện đại, vươn tầm quốc tế</strong></span></p>",
                                MoTa = "<p>Trường Tiểu học Nguyễn Siêu là một trường dân lập tọa lạc tại Hà Nội, Việt Nam. Trường được thành lập vào ngày 31/3/1993 theo quyết định số 2860 của UBND Thành phố Hà Nội. Ngôi trường được đặt tên theo danh nhân Việt Nam nổi tiếng Nguyễn Văn Siêu</p>",
                                LinkAnh = "/imgs/TrangChu/0246D6AF-C51A-4578-99DB-9CAC42E0902C.jpg",
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "<p>\"Vì hạnh phúc gia đình - Vì tiến bộ xã hội<br>Thầy mẫu mực- Trò chăm ngoan học giỏi\"</p>",
                                LinkAnh = "/imgs/TrangChu/6DE94FF7-E57D-4F77-9D85-1C70F372DFB1.jpg",
                            },
                        }
                    },
                    new CaiDatTongThe
                    {
                        CaiDatChiTiet = new List<CaiDatChiTiet>
                        {
                            new CaiDatChiTiet
                            {
                                TieuDe = "<p>Trường tiểu học Nguyễn Siêu</p><p><span style=\"font-size:20px;\"><strong>Ngôi trường</strong></span></p><p><span style=\"font-size:20px;\"><strong>hiện đại, vươn tầm quốc tế</strong></span></p>",
                                MoTa = "<p>Trường Tiểu học Nguyễn Siêu là một trường dân lập tọa lạc tại Hà Nội, Việt Nam. Trường được thành lập vào ngày 31/3/1993 theo quyết định số 2860 của UBND Thành phố Hà Nội. Ngôi trường được đặt tên theo danh nhân Việt Nam nổi tiếng Nguyễn Văn Siêu</p>",
                                LinkAnh = "/imgs/TrangChu/0246D6AF-C51A-4578-99DB-9CAC42E0902C.jpg",
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "<p>\"Vì hạnh phúc gia đình - Vì tiến bộ xã hội<br>Thầy mẫu mực- Trò chăm ngoan học giỏi\"</p>",
                                LinkAnh = "/imgs/TrangChu/6DE94FF7-E57D-4F77-9D85-1C70F372DFB1.jpg",
                            },
                        }
                    },
                    new CaiDatTongThe
                    {
                        LinkAnh = "/imgs/TrangChu/6DE94FF7-E57D-4F77-9D85-1C70F372DFB1.jpg",
                        CaiDatChiTiet = new List<CaiDatChiTiet>
                        {
                            new CaiDatChiTiet
                            {
                                TieuDe = "1292",
                                MoTa = "học sinh",
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "10+",
                                MoTa = "năm hoạt động",
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "100%",
                                MoTa = "chương trình cambridge",
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "10+",
                                MoTa = "năm hoạt động",
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "10+",
                                MoTa = "năm hoạt động",
                            },
                        }
                    },
                    new CaiDatTongThe
                    {
                        TieuDe = "Thành tích của các con",
                        Mota = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque mattis, sapien aliquet dictum egestas, lorem felis sagittis leo, vel interdum ante magna non est. Duis hendrerit lobortis lacus eget semper. Nulla mollis luctus erat et tempus. In sed velit aliquam, egestas lacus quis, vulputate mauris. Proin vitae leo dolor. Donec mattis massa in egestas varius. Curabitur tortor nisl, aliquam ac efficitur ac, ullamcorper in ipsum.</p>",
                        Link = "https://google.com",
                        LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg",
                        CaiDatChiTiet = new List<CaiDatChiTiet>
                        {
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                            new CaiDatChiTiet
                            {
                                TieuDe = "Trần Thị Tiểu Vy",
                                MoTa = "Đạt danh hiệu học sinh xuất sắc nhất khối 2 - Quý I",
                                LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg"
                            },
                        }
                    },
                    new CaiDatTongThe
                    {
                        CaiDatChiTiet = new List<CaiDatChiTiet>
                        {
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/D14E5A3A-1B5A-4BF7-99DC-4D264104E7A2.png"
                            },
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/1193C8AB-041E-485A-A4DD-2045DBB249F6.png"
                            },
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/ABE85469-972C-4C44-A86A-EA54EA4F62BB.png"
                            },
                            new CaiDatChiTiet
                            {
                                LinkAnh = "/imgs/TrangChu/51A5B36F-EB37-4E54-B214-F6B0718E6804.png"
                            },
                        }
                    }
                }
            };
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

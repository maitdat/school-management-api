using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models
{
    public partial class DataSeeding
    {
        private static void SeedTrangTinh(AppDbContext dbContext, IConfiguration config)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                var allPages = GenerateTrang();
                var addedPages = dbContext.Trang.Select(c => c.Id).ToList();
                var nonAddedPages = allPages.Where(c => !addedPages.Contains(c.Id));
                dbContext.Trang.AddRange(nonAddedPages);
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Trang ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Trang OFF");

                ICollection<CaiDatTongThe> pageConfig;
                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.AnToanHocDuong).Any())
                {
                    pageConfig = SeedAnToanHocDuong(dbContext, config);
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.TrangChu).Any())
                {
                    pageConfig = SeedCaiDatTrangChu(dbContext);
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.GocTruyenThong).Any())
                {
                    pageConfig = SeedCaiDatGocTruyenThong();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.ChuongTrinhHoc).Any())
                {
                    pageConfig = SeedCaiDatChuongTrinhHoc();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                SeedSwiperImage(dbContext);
                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.CoSoVatChat).Any())
                {
                    pageConfig = SeedCaiDatCoSoVatChat(dbContext, config);
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.TongQuan).Any())
                {
                    pageConfig = SeedCaiDatTongQuan();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.PhuongThucDayHoc).Any())
                {
                    pageConfig = SeedCaiDatPhuongThucDayHoc();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.NoiQuy).Any())
                {
                    pageConfig = SeedCaiDatNoiQuy();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.ThongTinTuyenSinh).Any())
                {
                    pageConfig = SeedCaiDatThongTinTuyenSinh();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.QuyDinhNhapHoc).Any())
                {
                    pageConfig = SeedCaiDatQuyDinhNhapHoc();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.BanTru).Any())
                {
                    pageConfig = SeedCaiDatBanTru();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.TuVanTamLy).Any())
                {
                    pageConfig = SeedCaiDatTuVanTamLy();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.CauLacBo).Any())
                {
                    pageConfig = SeedCaiDatCauLacBo();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.HoiDongTruong).Any())
                {
                    pageConfig = SeedCaiDatHoiDongTruong();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.BanGiamHieu).Any())
                {
                    pageConfig = SeedCaiDatBanGiamHieu();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.DoiNguGiaoVien).Any())
                {
                    pageConfig = SeedCaiDatDoiNguGiaoVien();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.LienHe).Any())
                {
                    pageConfig = SeedCaiDatLienHe();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                if (!dbContext.CaiDatTongThe.Where(record => record.TrangId == (int)DanhSachTrangTinh.AnToanHocDuong).Any())
                {
                    pageConfig = SeedCaiDatAnToanHocDuong();
                    dbContext.CaiDatTongThe.AddRange(pageConfig);
                    dbContext.SaveChanges();
                }

                transaction.Commit();
            }
        }

        private static List<FileUpload> SeedBannerTrangChu(AppDbContext dbContext)
        {
            var files = new List<FileUpload>
            {
                new FileUpload
                {
                    FileName = Guid.Parse("069CB778-25BB-4112-A927-F442FFE30E9A"),
                    FilePath = "imgs/TrangChu/069CB778-25BB-4112-A927-F442FFE30E9A.png",
                    FileType = FileType.Image,
                    OriginName = "imgTrangChu.png"
                },
                new FileUpload
                {
                    FileName = Guid.Parse("0246D6AF-C51A-4578-99DB-9CAC42E0902C"),
                    FilePath = "imgs/TrangChu/0246D6AF-C51A-4578-99DB-9CAC42E0902C.jpg",
                    FileType = FileType.Image,
                    OriginName = "truyenThong1.jpg"
                },
                new FileUpload
                {
                    FileName = Guid.Parse("6227B939-3397-44C9-AE2C-51CCE3A10B27"),
                    FilePath = "imgs/TrangChu/6227B939-3397-44C9-AE2C-51CCE3A10B27.jpg",
                    FileType = FileType.Image,
                    OriginName = "truyenThong2.jpg"
                },
                new FileUpload
                {
                    FileName = Guid.Parse("4E635465-AC1A-4FF3-A15B-986C2392AD01"),
                    FilePath = "imgs/TrangChu/4E635465-AC1A-4FF3-A15B-986C2392AD01.jpg",
                    FileType = FileType.Image,
                    OriginName = "truyenThong3.jpg"
                },
                new FileUpload
                {
                    FileName = Guid.Parse("7777918F-4CA8-4B4F-8808-1119FFCFC1D2"),
                    FilePath = "imgs/TrangChu/7777918F-4CA8-4B4F-8808-1119FFCFC1D2.mp4",
                    FileType = FileType.Video,
                    OriginName = "bg.mp4"
                },
            };
            dbContext.FileUpload.AddRange(files);
            dbContext.SaveChanges();
            return files;
        }

        private static void SeedSwiperImage(AppDbContext context)
        {
            if (!context.CoSoVatChat.Any())
            {
                context.CoSoVatChat.Add(new CoSoVatChat
                {
                    HienThi = true,
                    TenDiaDiem = "Tổng thể",
                    ChiTietCoSoVatChat = new List<ChiTietCoSoVatChat>
                    {
                        new ChiTietCoSoVatChat
                        {
                            HienThi = true,
                            LoaiMedia = LoaiMedia.Anh,
                            LinkAnh = "/imgs/CoSoVatChat/10CCA414-9BDB-4C69-9820-5024D4632C14.jpg",
                        },
                        new ChiTietCoSoVatChat
                        {
                            HienThi = true,
                            LoaiMedia = LoaiMedia.Anh,
                            LinkAnh = "/imgs/CoSoVatChat/3F5E70DB-AE20-4390-9151-EF8D6F496317.jpg",
                        },
                        new ChiTietCoSoVatChat
                        {
                            HienThi = true,
                            LoaiMedia = LoaiMedia.Anh,
                            LinkAnh = "/imgs/CoSoVatChat/8D96EF35-8932-43AF-B6B2-A62F7B228E01.jpg",
                        },
                        new ChiTietCoSoVatChat
                        {
                            HienThi = true,
                            LoaiMedia = LoaiMedia.Anh,
                            LinkAnh = "/imgs/CoSoVatChat/70364CCE-B253-46D2-876D-6DC13BCDF825.jpg",
                        },
                        new ChiTietCoSoVatChat
                        {
                            HienThi = true,
                            LoaiMedia = LoaiMedia.Anh,
                            LinkAnh = "/imgs/CoSoVatChat/7832787E-562D-4FF8-9284-C51AFE96723F.jpg",
                        },
                        new ChiTietCoSoVatChat
                        {
                            HienThi = true,
                            LoaiMedia = LoaiMedia.Anh,
                            LinkAnh = "/imgs/CoSoVatChat/CADE98C8-3E25-4BBC-9980-AD2AB75E9303.jpg",
                        },
                        new ChiTietCoSoVatChat
                        {
                            HienThi = true,
                            LoaiMedia = LoaiMedia.Anh,
                            LinkAnh = "/imgs/CoSoVatChat/E25A3EBD-F604-4358-8963-B46A57A7A9B0.jpg",
                        },
                    }
                });
                context.SaveChanges();
            }
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatAnToanHocDuong()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Chính sách bảo vệ trẻ em",
                    Mota = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer laoreet sed lorem non egestas. Cras condimentum posuere varius. Aliquam molestie neque eget ante tristique, vitae egestas ligula sollicitudin. In hac habitasse platea dictumst. Maecenas lorem libero, elementum nec arcu tincidunt, rhoncus rutrum turpis. Vivamus nec urna libero. Maecenas pulvinar finibus ultrices. Quisque venenatis nibh a odio dictum tempus. Aliquam at sapien dapibus, vestibulum eros accumsan, vulputate arcu. Fusce quis mattis sem, quis porta ante. Nulla in porta erat. Donec a feugiat leo, vitae dictum nisl.</p><p>Donec tempor dui sed sem accumsan, eu fermentum diam condimentum. Fusce sit amet euismod orci. In id tortor et lorem feugiat elementum. Ut nec pretium metus. Pellentesque pulvinar nisi quis viverra imperdiet. Phasellus pulvinar, mauris id tempus elementum, velit purus ultrices massa, in porta justo augue ac magna. Proin feugiat sem ex. Fusce non quam quam. Proin quam tortor, porttitor eu maximus eget, accumsan non nunc. Nam pellentesque mauris sit amet ultricies convallis. Suspendisse hendrerit tellus sit amet magna finibus luctus. Donec non tristique sem.</p><p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque nibh velit, tristique sed sodales non, blandit et tellus. Nunc eros odio, condimentum ac tincidunt a, consequat a ligula. Nullam venenatis arcu ut faucibus suscipit. Sed vehicula eu ex vitae lacinia. Sed gravida sapien et gravida congue. In et congue augue. Praesent finibus nulla neque, a efficitur urna aliquet ut. Sed aliquam ultrices pharetra. Maecenas nec libero lacinia, mollis sem quis, hendrerit odio. Donec venenatis consequat erat id fermentum.</p><p>Suspendisse ultricies, mi in lobortis pulvinar, lacus turpis gravida neque, nec laoreet sapien massa non diam. Sed a sem vitae eros posuere mollis sit amet non dui. Donec purus odio, ultrices non sapien sit amet, porta porttitor magna. Sed vel nisi malesuada, dignissim neque et, consequat sapien. Proin eu justo metus. Ut orci arcu, placerat a libero ut, congue vestibulum eros. Nullam nec finibus dui, vulputate dapibus diam. Vivamus id fringilla velit. Ut lorem ligula, facilisis sit amet ante eget, commodo interdum diam. Vivamus eget mi viverra, hendrerit augue sit amet, mollis enim. Donec fringilla diam aliquam, malesuada tortor sed, blandit risus.</p><p>Mauris vehicula faucibus faucibus. Etiam venenatis tortor vel orci dapibus, at efficitur nibh condimentum. Integer sed neque nec mi facilisis laoreet congue sed orci. Quisque aliquam purus tellus, porttitor bibendum urna aliquet sit amet. Mauris ac odio a eros faucibus viverra non id tellus. Praesent dapibus, mi vel scelerisque tincidunt, ex nunc rutrum elit, sed suscipit velit ligula non neque. Integer in faucibus leo.</p>"
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Quy định xử lý cáo buộc về xâm hại trẻ em",
                    Mota = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer laoreet sed lorem non egestas. Cras condimentum posuere varius. Aliquam molestie neque eget ante tristique, vitae egestas ligula sollicitudin. In hac habitasse platea dictumst. Maecenas lorem libero, elementum nec arcu tincidunt, rhoncus rutrum turpis. Vivamus nec urna libero. Maecenas pulvinar finibus ultrices. Quisque venenatis nibh a odio dictum tempus. Aliquam at sapien dapibus, vestibulum eros accumsan, vulputate arcu. Fusce quis mattis sem, quis porta ante. Nulla in porta erat. Donec a feugiat leo, vitae dictum nisl.</p><p>Donec tempor dui sed sem accumsan, eu fermentum diam condimentum. Fusce sit amet euismod orci. In id tortor et lorem feugiat elementum. Ut nec pretium metus. Pellentesque pulvinar nisi quis viverra imperdiet. Phasellus pulvinar, mauris id tempus elementum, velit purus ultrices massa, in porta justo augue ac magna. Proin feugiat sem ex. Fusce non quam quam. Proin quam tortor, porttitor eu maximus eget, accumsan non nunc. Nam pellentesque mauris sit amet ultricies convallis. Suspendisse hendrerit tellus sit amet magna finibus luctus. Donec non tristique sem.</p><p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque nibh velit, tristique sed sodales non, blandit et tellus. Nunc eros odio, condimentum ac tincidunt a, consequat a ligula. Nullam venenatis arcu ut faucibus suscipit. Sed vehicula eu ex vitae lacinia. Sed gravida sapien et gravida congue. In et congue augue. Praesent finibus nulla neque, a efficitur urna aliquet ut. Sed aliquam ultrices pharetra. Maecenas nec libero lacinia, mollis sem quis, hendrerit odio. Donec venenatis consequat erat id fermentum.</p><p>Suspendisse ultricies, mi in lobortis pulvinar, lacus turpis gravida neque, nec laoreet sapien massa non diam. Sed a sem vitae eros posuere mollis sit amet non dui. Donec purus odio, ultrices non sapien sit amet, porta porttitor magna. Sed vel nisi malesuada, dignissim neque et, consequat sapien. Proin eu justo metus. Ut orci arcu, placerat a libero ut, congue vestibulum eros. Nullam nec finibus dui, vulputate dapibus diam. Vivamus id fringilla velit. Ut lorem ligula, facilisis sit amet ante eget, commodo interdum diam. Vivamus eget mi viverra, hendrerit augue sit amet, mollis enim. Donec fringilla diam aliquam, malesuada tortor sed, blandit risus.</p><p>Mauris vehicula faucibus faucibus. Etiam venenatis tortor vel orci dapibus, at efficitur nibh condimentum. Integer sed neque nec mi facilisis laoreet congue sed orci. Quisque aliquam purus tellus, porttitor bibendum urna aliquet sit amet. Mauris ac odio a eros faucibus viverra non id tellus. Praesent dapibus, mi vel scelerisque tincidunt, ex nunc rutrum elit, sed suscipit velit ligula non neque. Integer in faucibus leo.</p>"
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Quy định về việc tiếp xúc thân thể với học sinh",
                    Mota = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer laoreet sed lorem non egestas. Cras condimentum posuere varius. Aliquam molestie neque eget ante tristique, vitae egestas ligula sollicitudin. In hac habitasse platea dictumst. Maecenas lorem libero, elementum nec arcu tincidunt, rhoncus rutrum turpis. Vivamus nec urna libero. Maecenas pulvinar finibus ultrices. Quisque venenatis nibh a odio dictum tempus. Aliquam at sapien dapibus, vestibulum eros accumsan, vulputate arcu. Fusce quis mattis sem, quis porta ante. Nulla in porta erat. Donec a feugiat leo, vitae dictum nisl.</p><p>Donec tempor dui sed sem accumsan, eu fermentum diam condimentum. Fusce sit amet euismod orci. In id tortor et lorem feugiat elementum. Ut nec pretium metus. Pellentesque pulvinar nisi quis viverra imperdiet. Phasellus pulvinar, mauris id tempus elementum, velit purus ultrices massa, in porta justo augue ac magna. Proin feugiat sem ex. Fusce non quam quam. Proin quam tortor, porttitor eu maximus eget, accumsan non nunc. Nam pellentesque mauris sit amet ultricies convallis. Suspendisse hendrerit tellus sit amet magna finibus luctus. Donec non tristique sem.</p><p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque nibh velit, tristique sed sodales non, blandit et tellus. Nunc eros odio, condimentum ac tincidunt a, consequat a ligula. Nullam venenatis arcu ut faucibus suscipit. Sed vehicula eu ex vitae lacinia. Sed gravida sapien et gravida congue. In et congue augue. Praesent finibus nulla neque, a efficitur urna aliquet ut. Sed aliquam ultrices pharetra. Maecenas nec libero lacinia, mollis sem quis, hendrerit odio. Donec venenatis consequat erat id fermentum.</p><p>Suspendisse ultricies, mi in lobortis pulvinar, lacus turpis gravida neque, nec laoreet sapien massa non diam. Sed a sem vitae eros posuere mollis sit amet non dui. Donec purus odio, ultrices non sapien sit amet, porta porttitor magna. Sed vel nisi malesuada, dignissim neque et, consequat sapien. Proin eu justo metus. Ut orci arcu, placerat a libero ut, congue vestibulum eros. Nullam nec finibus dui, vulputate dapibus diam. Vivamus id fringilla velit. Ut lorem ligula, facilisis sit amet ante eget, commodo interdum diam. Vivamus eget mi viverra, hendrerit augue sit amet, mollis enim. Donec fringilla diam aliquam, malesuada tortor sed, blandit risus.</p><p>Mauris vehicula faucibus faucibus. Etiam venenatis tortor vel orci dapibus, at efficitur nibh condimentum. Integer sed neque nec mi facilisis laoreet congue sed orci. Quisque aliquam purus tellus, porttitor bibendum urna aliquet sit amet. Mauris ac odio a eros faucibus viverra non id tellus. Praesent dapibus, mi vel scelerisque tincidunt, ex nunc rutrum elit, sed suscipit velit ligula non neque. Integer in faucibus leo.</p>"
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Chính sách an toàn trên môi trường mạng",
                    Mota = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer laoreet sed lorem non egestas. Cras condimentum posuere varius. Aliquam molestie neque eget ante tristique, vitae egestas ligula sollicitudin. In hac habitasse platea dictumst. Maecenas lorem libero, elementum nec arcu tincidunt, rhoncus rutrum turpis. Vivamus nec urna libero. Maecenas pulvinar finibus ultrices. Quisque venenatis nibh a odio dictum tempus. Aliquam at sapien dapibus, vestibulum eros accumsan, vulputate arcu. Fusce quis mattis sem, quis porta ante. Nulla in porta erat. Donec a feugiat leo, vitae dictum nisl.</p><p>Donec tempor dui sed sem accumsan, eu fermentum diam condimentum. Fusce sit amet euismod orci. In id tortor et lorem feugiat elementum. Ut nec pretium metus. Pellentesque pulvinar nisi quis viverra imperdiet. Phasellus pulvinar, mauris id tempus elementum, velit purus ultrices massa, in porta justo augue ac magna. Proin feugiat sem ex. Fusce non quam quam. Proin quam tortor, porttitor eu maximus eget, accumsan non nunc. Nam pellentesque mauris sit amet ultricies convallis. Suspendisse hendrerit tellus sit amet magna finibus luctus. Donec non tristique sem.</p><p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque nibh velit, tristique sed sodales non, blandit et tellus. Nunc eros odio, condimentum ac tincidunt a, consequat a ligula. Nullam venenatis arcu ut faucibus suscipit. Sed vehicula eu ex vitae lacinia. Sed gravida sapien et gravida congue. In et congue augue. Praesent finibus nulla neque, a efficitur urna aliquet ut. Sed aliquam ultrices pharetra. Maecenas nec libero lacinia, mollis sem quis, hendrerit odio. Donec venenatis consequat erat id fermentum.</p><p>Suspendisse ultricies, mi in lobortis pulvinar, lacus turpis gravida neque, nec laoreet sapien massa non diam. Sed a sem vitae eros posuere mollis sit amet non dui. Donec purus odio, ultrices non sapien sit amet, porta porttitor magna. Sed vel nisi malesuada, dignissim neque et, consequat sapien. Proin eu justo metus. Ut orci arcu, placerat a libero ut, congue vestibulum eros. Nullam nec finibus dui, vulputate dapibus diam. Vivamus id fringilla velit. Ut lorem ligula, facilisis sit amet ante eget, commodo interdum diam. Vivamus eget mi viverra, hendrerit augue sit amet, mollis enim. Donec fringilla diam aliquam, malesuada tortor sed, blandit risus.</p><p>Mauris vehicula faucibus faucibus. Etiam venenatis tortor vel orci dapibus, at efficitur nibh condimentum. Integer sed neque nec mi facilisis laoreet congue sed orci. Quisque aliquam purus tellus, porttitor bibendum urna aliquet sit amet. Mauris ac odio a eros faucibus viverra non id tellus. Praesent dapibus, mi vel scelerisque tincidunt, ex nunc rutrum elit, sed suscipit velit ligula non neque. Integer in faucibus leo.</p>"
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Quy định chống bạo lực, bắt nạt",
                    Mota = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer laoreet sed lorem non egestas. Cras condimentum posuere varius. Aliquam molestie neque eget ante tristique, vitae egestas ligula sollicitudin. In hac habitasse platea dictumst. Maecenas lorem libero, elementum nec arcu tincidunt, rhoncus rutrum turpis. Vivamus nec urna libero. Maecenas pulvinar finibus ultrices. Quisque venenatis nibh a odio dictum tempus. Aliquam at sapien dapibus, vestibulum eros accumsan, vulputate arcu. Fusce quis mattis sem, quis porta ante. Nulla in porta erat. Donec a feugiat leo, vitae dictum nisl.</p><p>Donec tempor dui sed sem accumsan, eu fermentum diam condimentum. Fusce sit amet euismod orci. In id tortor et lorem feugiat elementum. Ut nec pretium metus. Pellentesque pulvinar nisi quis viverra imperdiet. Phasellus pulvinar, mauris id tempus elementum, velit purus ultrices massa, in porta justo augue ac magna. Proin feugiat sem ex. Fusce non quam quam. Proin quam tortor, porttitor eu maximus eget, accumsan non nunc. Nam pellentesque mauris sit amet ultricies convallis. Suspendisse hendrerit tellus sit amet magna finibus luctus. Donec non tristique sem.</p><p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque nibh velit, tristique sed sodales non, blandit et tellus. Nunc eros odio, condimentum ac tincidunt a, consequat a ligula. Nullam venenatis arcu ut faucibus suscipit. Sed vehicula eu ex vitae lacinia. Sed gravida sapien et gravida congue. In et congue augue. Praesent finibus nulla neque, a efficitur urna aliquet ut. Sed aliquam ultrices pharetra. Maecenas nec libero lacinia, mollis sem quis, hendrerit odio. Donec venenatis consequat erat id fermentum.</p><p>Suspendisse ultricies, mi in lobortis pulvinar, lacus turpis gravida neque, nec laoreet sapien massa non diam. Sed a sem vitae eros posuere mollis sit amet non dui. Donec purus odio, ultrices non sapien sit amet, porta porttitor magna. Sed vel nisi malesuada, dignissim neque et, consequat sapien. Proin eu justo metus. Ut orci arcu, placerat a libero ut, congue vestibulum eros. Nullam nec finibus dui, vulputate dapibus diam. Vivamus id fringilla velit. Ut lorem ligula, facilisis sit amet ante eget, commodo interdum diam. Vivamus eget mi viverra, hendrerit augue sit amet, mollis enim. Donec fringilla diam aliquam, malesuada tortor sed, blandit risus.</p><p>Mauris vehicula faucibus faucibus. Etiam venenatis tortor vel orci dapibus, at efficitur nibh condimentum. Integer sed neque nec mi facilisis laoreet congue sed orci. Quisque aliquam purus tellus, porttitor bibendum urna aliquet sit amet. Mauris ac odio a eros faucibus viverra non id tellus. Praesent dapibus, mi vel scelerisque tincidunt, ex nunc rutrum elit, sed suscipit velit ligula non neque. Integer in faucibus leo.</p>"
                },
            };
        }

        private static Trang[] GenerateTrang()
        {
            var result = new List<Trang>()
            {
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.TrangChu,
                    TenTrang = "Trang chủ",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.ChuongTrinhHoc,
                    TenTrang = "Chương trình học",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.CoSoVatChat,
                    TenTrang = "Cơ sở vật chất",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.GocTruyenThong,
                    TenTrang = "Góc truyền thông",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.TinTucSuKien,
                    TenTrang = "Tin tức & Sự kiện",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.TongQuan,
                    TenTrang = "Tổng quan",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.PhuongThucDayHoc,
                    TenTrang = "Phương thức dạy học",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.ThoiGianBieu_LichNamHoc,
                    TenTrang = "Thời gian biểu",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.NoiQuy,
                    TenTrang = "Nội quy",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.ThongTinTuyenSinh,
                    TenTrang = "Thông tin tuyển sinh",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.QuyDinhNhapHoc,
                    TenTrang = "Quy định nhập học",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.HocPhi,
                    TenTrang = "Học phí",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.LienHe,
                    TenTrang = "Liên hệ",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.BanTru,
                    TenTrang = "Thực đơn",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.TuVanTamLy,
                    TenTrang = "Tư vấn tâm lý",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.CoCauToChuc,
                    TenTrang = "Cơ cấu tổ chức",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.CauLacBo,
                    TenTrang = "Câu lạc bộ",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.HoiDongTruong,
                    TenTrang = "Hội đồng trường",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.BanGiamHieu,
                    TenTrang = "Ban Giám  hiệu",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.DoiNguGiaoVien,
                    TenTrang = "Đội ngũ giáo viên",
                },
                new Trang
                {
                    Id = (int)DanhSachTrangTinh.AnToanHocDuong,
                    TenTrang = "An toàn học đường",
                },
            };
            return result.ToArray();
        }


        private static ICollection<CaiDatTongThe> SeedCaiDatDoiNguGiaoVien()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.DoiNguGiaoVien,
                    TieuDe = "Đội ngũ giáo viên",
                    Mota = "Giáo viên Nguyễn Siêu là những người học tập suốt đời và không ngừng rèn luyện, học tập để phát triển chuyên môn vì tình yêu lớn với nghề \"trồng người\". Nhà trường luôn khuyến khích và tạo điều kiện để các cán bộ, giáo viên, nhân viên được học tập, nâng cao trình độ ở các bậc học cao hơn. Mỗi thầy cô giáo phát triển đều đóng góp cho sự phát triển của học sinh, đóng góp cho sự phát triển của nhà trường và xã hội. Bởi thế, công tác đào tạo, phát triển đội ngũ luôn nằm trong chiến lược phát triển của Trường Nguyễn Siêu và được đưa vào danh sách các nhiệm vụ trọng tâm của mỗi năm học."
                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatBanGiamHieu()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.BanGiamHieu,
                    TieuDe = "Ban Giám hiệu",
                    Mota = "Giáo viên Nguyễn Siêu là những người học tập suốt đời và không ngừng rèn luyện, học tập để phát triển chuyên môn vì tình yêu lớn với nghề \"trồng người\". Nhà trường luôn khuyến khích và tạo điều kiện để các cán bộ, giáo viên, nhân viên được học tập, nâng cao trình độ ở các bậc học cao hơn. Mỗi thầy cô giáo phát triển đều đóng góp cho sự phát triển của học sinh, đóng góp cho sự phát triển của nhà trường và xã hội. Bởi thế, công tác đào tạo, phát triển đội ngũ luôn nằm trong chiến lược phát triển của Trường Nguyễn Siêu và được đưa vào danh sách các nhiệm vụ trọng tâm của mỗi năm học."
                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatHoiDongTruong()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.HoiDongTruong,
                    TieuDe = "Hội đồng trường",
                    Mota = "Giáo viên Nguyễn Siêu là những người học tập suốt đời và không ngừng rèn luyện, học tập để phát triển chuyên môn vì tình yêu lớn với nghề \"trồng người\". Nhà trường luôn khuyến khích và tạo điều kiện để các cán bộ, giáo viên, nhân viên được học tập, nâng cao trình độ ở các bậc học cao hơn. Mỗi thầy cô giáo phát triển đều đóng góp cho sự phát triển của học sinh, đóng góp cho sự phát triển của nhà trường và xã hội. Bởi thế, công tác đào tạo, phát triển đội ngũ luôn nằm trong chiến lược phát triển của Trường Nguyễn Siêu và được đưa vào danh sách các nhiệm vụ trọng tâm của mỗi năm học."
                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatCauLacBo()
        {
            return new List<CaiDatTongThe> {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.CauLacBo,
                    TieuDe = "Bóng rổ",
                    TieuDeTiengAnh = "Basketball",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Số buổi học",
                            MoTa = "1 buổi/tuần",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Học phí (VNĐ)",
                            MoTa = "2,800,000",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thời gian",
                            MoTa = "16h00 - 17h15",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thông tin CLB",
                            MoTa = "Bóng rổ là bộ môn thể thao giúp trẻ phát triển toàn diện. Tham gia câu lạc bộ bóng rổ, trẻ sẽ phát triển kỹ năng cơ bản như ném, bắt bóng và chạy, tạo nền tảng vững chắc cho sự phát triển thể chất. Đồng thời, đây sẽ là cơ hội cho trẻ rèn luyện tính kiên nhẫn, sự tập trung và kỷ luật. Ngoài ra, môn bóng rổ giúp trẻ học cách làm việc nhóm, tạo ra môi trường gắn kết và phát triển kỹ năng giao tiếp. Tất cả những lợi ích này không chỉ giúp trẻ phát triển thể chất mà còn tạo ra những nền tảng quý báu cho sự phát triển toàn diện trong tương lai.",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/051078e1-8f24-48c5-a524-912e532a9942.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/e0b4c9f2-618f-46f3-bf9a-2734da095029.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/786ebd6b-bf27-4759-856f-6ab9ed32d3a3.jpg"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.CauLacBo,
                    TieuDe = "Cờ vua",
                    TieuDeTiengAnh = "Chess",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Số buổi học",
                            MoTa = "1 buổi/tuần",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Học phí (VNĐ)",
                            MoTa = "2,800,000",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thời gian",
                            MoTa = "16h00 - 17h15",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thông tin CLB",
                            MoTa = "Cờ vua là môn thể thao trí tuệ giúp học sinh kích thích sự linh hoạt trong tư duy, phát triển khả năng tính toán và logic. Bên cạnh đó, bộ môn cờ vua còn giúp trẻ rèn luyện tính độc lập trong xử lý tình huống và phát triển bản lĩnh đương đầu với khó khăn.",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/051078e1-8f24-48c5-a524-912e532a9942.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/e0b4c9f2-618f-46f3-bf9a-2734da095029.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/786ebd6b-bf27-4759-856f-6ab9ed32d3a3.jpg"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.CauLacBo,
                    TieuDe = "Võ thuật",
                    TieuDeTiengAnh = "Kungfu",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Số buổi học",
                            MoTa = "1 buổi/tuần",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Học phí (VNĐ)",
                            MoTa = "2,800,000",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thời gian",
                            MoTa = "16h00 - 17h15",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thông tin CLB",
                            MoTa = "Võ thuật là bộ môn đem lại nhiều lợi ích cho các con học sinh. Không chỉ giúp các con tăng cường sức khỏe, dẻo dai hơn và tránh các bệnh vặt, võ thuật còn giúp phát triển khả năng tập trung và sự kiên nhẫn.",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/c7b6a3b6-ec3a-4bff-8a89-06559265468e.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/254be0c8-f6c2-44a9-9c1a-e9ff20f3064e.jpg"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.CauLacBo,
                    TieuDe = "Nhảy hiện đại",
                    TieuDeTiengAnh = "Dance",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Số buổi học",
                            MoTa = "1 buổi/tuần",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Học phí (VNĐ)",
                            MoTa = "2,800,000",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thời gian",
                            MoTa = "16h00 - 17h15",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thông tin CLB",
                            MoTa = "Bộ môn nhảy hiện đại là sân chơi bổ ích cho các học sinh tiểu học tại trường chúng ta. Các em sẽ phát triển sự linh hoạt, tăng cường sức khỏe và sự phối hợp giữa thể chất và tinh thần. Bên cạnh việc rèn luyện kỹ năng nhảy, bộ môn này còn giúp trẻ phát triển sự tự tin, khả năng tập trung và kiên nhẫn. Việc học nhảy hiện đại không chỉ mang lại niềm vui thích, mà còn giúp trẻ rèn luyện sự cởi mở trong giao tiếp và tạo ra một môi trường thú vị để thể hiện bản thân.",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/0e10bd01-2bf4-4918-8e69-1d954826244b.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/cf5507ce-3e35-4a95-a2d2-ccf89777db2b.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/209b9968-d1ec-46a2-91e7-3bedf9ad6b9a.jpg"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.CauLacBo,
                    TieuDe = "Mỹ thuật",
                    TieuDeTiengAnh = "Art",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Số buổi học",
                            MoTa = "1 buổi/tuần",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Học phí (VNĐ)",
                            MoTa = "2,800,000",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thời gian",
                            MoTa = "16h00 - 17h15",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thông tin CLB",
                            MoTa = "Mĩ thuật là bộ môn truyền cảm hứng vô tận cho học sinh, giúp phát triển óc sáng tạo, khả năng thẩm mỹ, rèn luyện tinh thần kiên nhẫn và sự tỉ mỉ. Bộ môn mĩ thuật còn giúp trẻ phát triển khả năng thể hiện cảm xúc và thấu hiểu sâu hơn về môi trường xung quanh. Đồng thời, việc tham gia vào câu lạc bộ mĩ thuật còn giúp trẻ xây dựng tình bạn và học hỏi kỹ năng giao tiếp thông qua việc chia sẻ ý tưởng và ý kiến với nhau.",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/769e261e-0cb7-4be0-b3c7-39ad3c34c4f5.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/f6e1a8e7-b70f-4982-b5cb-599d1c9bc8d3.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/55371cf4-306f-4ef9-84fa-0d6ae10763e3.jpg"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.CauLacBo,
                    TieuDe = "Robotic",
                    TieuDeTiengAnh = "Robotic",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Số buổi học",
                            MoTa = "1 buổi/tuần",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Học phí (VNĐ)",
                            MoTa = "2,800,000",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thời gian",
                            MoTa = "16h00 - 17h15",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thông tin CLB",
                            MoTa = "Bộ môn lập trình robot là một hành trình thú vị giúp học sinh tiểu học khám phá thế giới công nghệ. Tham gia câu lạc bộ lập trình robot, các em sẽ phát triển tư duy logic, khả năng giải quyết vấn đề và kỹ năng hợp tác trong nhóm. Qua việc tạo ra và điều khiển robot, trẻ sẽ rèn luyện sự kiên nhẫn, sáng tạo và khả năng tưởng tượng. Đồng thời, bộ môn này còn giúp trẻ xây dựng nền tảng vững chắc cho hiểu biết về khoa học và công nghệ, từ đó kích thúc sự ham muốn tìm hiểu và phát triển trong tương lai.",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/dcd8f7a8-7142-46ad-966a-8d5ec85ea8b0.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/3a785761-63fe-43d7-9f4d-bdd342d50e30.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/ccb26ac4-4148-4451-b562-a6c19be58f54.jpg"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.CauLacBo,
                    TieuDe = "In 3D",
                    TieuDeTiengAnh = "3D Printing",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Số buổi học",
                            MoTa = "1 buổi/tuần",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Học phí (VNĐ)",
                            MoTa = "3,000,000",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thời gian",
                            MoTa = "16h00 - 17h15",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Thông tin CLB",
                            MoTa = "In 3D là một bộ môn giúp các con phát triển về tư duy sáng tạo, thiết kế và khả năng thẩm mĩ cao. Việc thể hiện ý tưởng trực quan trên máy tính và chạm tay vào quá trình sản xuất sẽ kích thích sự ham muốn khám phá và phát triển của trẻ, từ bây giờ cho đến tương lai.",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 28 28\" fill=\"none\">"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/5bf808f5-ea99-4a5f-a2fb-7757489a9913.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/6d4d3503-a815-4fb5-8908-f3cb41f1d6cb.jpg"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/ChuongTrinhHoc/CauLacBo/095a5d1b-6048-40f4-8c8a-c18e3b045f1e.jpg"
                        },
                    }
                },
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatCoCauToChuc()
        {
            // NOTE: ko seed data
            return new List<CaiDatTongThe>();
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatTuVanTamLy()
        {
            return new List<CaiDatTongThe>()
            {
                new CaiDatTongThe
                {
                    TieuDe = "",
                    TrangId = (long)DanhSachTrangTinh.TuVanTamLy,
                    Mota = "<p>Mỗi học sinh ở Nguyễn Siêu luôn được thấu hiểu và tạo mọi điều kiện để không chỉ đạt được thành công trong học tập mà còn có một tinh thần khỏe mạnh và một trái tim kiên cường. Trưởng thành là một hành trình dài đan xen giữa những thành công và thất bại, hạnh phúc và lo lắng. Tư vấn tâm lí học đường là một trong những hoạt động được xây dựng với mong muốn đồng hành và chia sẻ với học sinh trong hành trình không ít khó khăn và thách thức này.</p><p>Là những người cha, người mẹ thứ hai ở trường, chúng tôi cố gắng thấu hiểu và chia sẻ những khó khăn trong quá trình nuôi dạy con của các bậc CMHS. Thật khó khăn khi các con lớn lên không giống những gì chúng ta tưởng tượng. Hoạt động tư vấn tâm lí học đường cũng là một trong những nơi để gia đình và nhà trường cùng trao đổi những băn khoăn, khúc mắc trong quá trình làm cha mẹ, cùng nhau trở thành những “người bạn” thật sự của con ở trường và ở nhà.</p>",
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.TuVanTamLy,
                    TieuDe = "chuyên viên tâm lý đồng hành cùng ai?",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Đồng hành với học sinh",
                            MoTa = "Khám phá các đặc điểm tâm lí, xu hướng tính cách của bản thân.    Thấu hiểu những sự thay đổi về thể chất và tâm lí lứa tuổi.    Xây dựng các mối quan hệ (với cha mẹ, thầy cô, tình bạn,…) lành mạnh và tích cực.    Đương đầu với các khó khăn trong quá trình học tập và trưởng thành liên quan đến: nhận thức, cảm xúc, hành vi, định hướng giá trị và hiện thực hóa bản thân…    Làm mạnh bản thân thông qua việc nâng cao các kỹ năng giao tiếp, kiểm soát cảm xúc, quản lí căng thẳng..., nhận diện các vấn đề tâm lí của bản thân và tìm được giải pháp phù hợp.  Học sinh sẽ đăng ký tham vấn thông qua GVCN"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Đồng hành với cha mẹ hs",
                            MoTa = "Thấu hiểu các đặc điểm tâm lí, nhu cầu, xu hướng tính cách của con theo các giai đoạn phát triển chung và sự phát triển riêng biệt.     Làm bạn cùng con trên cơ sở các nguyên tắc của khoa học tâm lí.     Cùng con đương đầu với các khó khăn trong quá trình học tập và trưởng thành.    Kết nối HS và CMHS với các chuyên gia hoặc cơ sở hỗ trợ tâm lí uy tín trong trường hợp gia đình có nhu cầu.",
                            Link = "https://www.google.com/"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "Đồng hành GV & nhà trường",
                            MoTa = "Thấu hiểu sự phát triển tâm lí và những nhu cầu phát triển của học sinh.</p><p>Tư vấn các phương pháp và lộ trình học tập phù hợp với đặc điểm tâm lí và xu hướng tích cách của cá nhân học sinh. </p><p>Xây dựng môi trường môi trường học đường an toàn và lành mạnh.</p><p>Tìm kiếm các chiến lược hỗ trợ hiệu quả cho những học sinh gặp khó khăn tâm lí trong lớp học.",
                            Link = "https://www.google.com/"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.TuVanTamLy,
                    TieuDe = "ĐỘI NGŨ CHUYÊN VIÊN",
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.TuVanTamLy,
                    TieuDe = "CÁCH THỨC LIÊN HỆ",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            MoTa = "Cách 1: Đăng ký theo đường link: https://form.jotform.com/210481521339450"
                        },
                        new CaiDatChiTiet {
                            MoTa = "Cách 2: Email về hộp thư: tamlyhocduong@nguyensieu.edu.vn",
                        },
                        new CaiDatChiTiet {
                            MoTa = "Cách 3: Gặp trực tiếp chuyên viên tâm lý tại Phòng Tư vấn học đường (tầng 4, nhà H, trường Nguyễn Siêu).",
                        },
                        new CaiDatChiTiet {
                            MoTa = "Cách 4: Liên hệ thông qua GVCN",
                        },
                    }
                },
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatBanTru()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.BanTru,
                    TieuDe = "tổng quan",
                    Mota = "<p><strong>Công tác bán trú</strong><br>Để đảm bảo sức khỏe cho học sinh, hướng tới mục tiêu phát triển toàn diện, Trường Nguyễn Siêu đầu tư xây dựng mô hình bán trú khoa học và thân thiện.<br><br>Trường có bếp ăn tập thể với trang thiết bị hiện đại, thiết kế theo quy trình bếp một chiều, tổ chức khoa học, hợp vệ sinh, thực đơn phong phú, đa dạng, đảm bảo đủ, cân bằng dinh dưỡng và vệ sinh an toàn thực phẩm. Nhà cung ứng thực phẩm cho CB,GV&amp;HS Nguyễn Siêu là Công ty CP Rau an toàn thuộc Công ty Đầu tư và Phát triển nông nghiệp Hà Nội (HADICO). Thực đơn được đăng tải hàng tuần trên cổng thông tin điện tử chính thức của nhà trường. Hệ thống phòng ăn đảm bảo diện tích, có bàn ghế, đồ dùng đầy đủ và 100% học sinh, CB-GV-NV ăn trưa bằng khay ăn cá nhân. Với Tiểu học, ngoài bữa ăn chính, học sinh được phục vụ một bữa ăn phụ vào đầu giờ chiều. Ngoài ra, nhà trường còn phục vụ thêm bữa sáng (có trả phí) cho những học sinh có nhu cầu. 100% các lớp dùng nước uống Lavie.<br><br>Tháng 12/2022, đại diện Ban Giám hiệu nhà trường và bộ phận Nhà bếp đã tiến hành đợt kiểm tra, giám sát định kỳ tại các cơ sở cung ứng thực phẩm cho nhà trường, đảm bảo tuyệt đối về vấn đề vệ sinh an toàn thực phẩm, nâng cao hơn nữa chất lượng bữa ăn nói riêng và công tác chăm sóc sức khoẻ nói chung cho học sinh, cán bộ, giáo viên, nhân viên toàn trường.</p><figure class=\"image\"><img src=\"/imgs/BaiViet/e183bbb2-6083-411f-a72f-09cc0add89ae.png\"></figure><p>&nbsp;</p><figure class=\"image\"><img src=\"/imgs/BaiViet/978a7cd3-ddef-4f26-a2a3-c9caea737a2f.png\"></figure><p>&nbsp;</p><figure class=\"image\"><img src=\"/imgs/BaiViet/632bc701-e9bd-49ff-8f70-f7ce927ff1da.png\"></figure><p><strong>Phòng ngủ </strong>của học sinh được bố trí riêng biệt dành cho học sinh nam và học sinh nữ (đối với THCS &amp; THPT). Các phòng ngủ đều có trang bị đệm cá nhân, máy điều hoà nhiệt độ, quạt thông gió, đủ hệ thống cửa kính đảm bảo ấm về mùa đông, mát về mùa hè, có đủ ánh sáng, tủ để giày dép, tủ đựng đồ cá nhân. Giờ ăn, ngủ, giờ ra chơi của học sinh được quản lý bởi GVCN và lực lượng hỗ trợ với tinh thần trách nhiệm, sự tận tụy, nhiệt tình.<br><br><strong>Y tế học đường:</strong> Phòng Y tế có đầy đủ trang thiết bị cho việc sơ cứu ban đầu cùng các nhân viên giàu kinh nghiệm, trực trong suốt quá trình học sinh có mặt ở trường. Mỗi năm, học sinh được khám sức khỏe định kỳ 2 lần và có Sổ theo dõi sức khỏe cá nhân. Bảo hiểm Y tế của học sinh được thực hiện theo đúng quy định của Luật bảo hiểm y tế năm 2014 (học sinh, sinh viên là đối tượng tham gia bảo hiểm y tế bắt buộc).</p>"
                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatLienHe()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.LienHe,
                    TieuDe = "",
                    Mota = "<p><strong>Cổng thông tin điện tử - Điều khoản và điều kiện</strong><br><br>Nhà trường rất hoan nghênh các phản hồi và khuyến khích sự trao đổi thông tin giữa quý phụ huynh và giáo viên. Mọi thắc mắc hoặc khiếu nại phải được thông qua cổng thông tin trực tuyến Trường Nguyễn Siêu. Điều này sẽ giúp nhà trường theo dõi, nắm bắt được các phản hồi và đảm bảo sự liên lạc đến đúng người và đúng lúc.<br><br><strong>Quy trình khiếu nại</strong><br><br>Bước 1: Hoàn thiện mẫu online<br>Mọi đơn liên lạc sẽ được chuyển trực tiếp đến hiệu trưởng và những người có liên quan. Vui lòng kiểm tra mục thư rác nếu không nhận được xác nhận, sau đó liên lạc với điều phối viên liên lạc qua điện thoại hoặc email.<br>Email: CommunicationsPortal@nguyensieu.edu.vn<br>Điện thoại: 024 3784 4889<br>Nhà trường có thể yêu cầu gặp phụ huynh để thu thập thêm thông tin và tiến hành xử lí như ở Bước 2.<br><br>Bước 2: Tiến hành xử lí<br>Bao gồm những bước sau:<br>· Chuyển yêu cầu đến người có trách nhiệm và tiến hành bước 3.<br>· Phỏng vấn những người có liên quan.<br>· Ghi chép tất cả các cuộc họp/phỏng vấn liên quan.<br><br>Bước 3: Phản hồi<br>Nhà trường sẽ đưa ra văn bản phản hồi trong vòng 15 ngày kể từ ngày nhận thông tin.<br>Nếu nhà trường không đưa ra được phản hồi kịp thời hạn quy định thì phụ huynh sẽ nhận được cập nhật và thông báo.<br><br>Bước 4: Tiếp tục quá trình xử lí<br>Nếu phụ huynh không nhận được thông tin phản hồi sau thời gian quy định hoặc chưa hài lòng với phản hồi từ phía nhà trường, xin vui lòng liên hệ với nhà trường qua điện thoại hoặc email.<br><br>Các trường hợp ngoại lệ<br>Quy trình này được áp dụng để xử lí những thắc mắc liên quan đến các loại hình dịch vụ và chương trình học tập của trường Nguyễn Siêu, không giải quyết những khiếu nại liên quan đến pháp luật, cụ thể là:<br><br>...<br><br><strong>Khiếu nại không hợp lí</strong><br><br>Tải chính sách xử lí thắc mắc hoặc khiếu nại của trường Nguyễn Siêu (bản đầy đủ) TẠI ĐÂY<br>Khi một khiếu nại đã được giải quyết một cách trọn vẹn theo đúng quy trình của nhà trường, khiếu nại đó sẽ không được xử lí lại trừ khi có những sự việc mới phát sinh. Nếu người khiếu nại vẫn tiếp tục gửi đơn, Hiệu trưởng sẽ viết thư giải thích vấn đề đã được giải quyết và vì thế sự việc sẽ được đóng lại.<br><br>Các khiếu nại không hợp lí bao gồm:<br>· Người khiếu nại từ chối làm theo các quy trình của nhà trường.<br>· Người khiếu nại thay đổi ý kiến khi cuộc điều tra được tiến hành.<br>· Người khiếu nại có mong muốn không thực tế.<br>· Người khiếu nại đưa ra yêu cầu đòi hỏi quá nhiều thời gian để xử lí và cố ý làm gia tăng mức độ nghiêm trọng của vấn đề.<br>· Người khiếu nại có hành vi khiếm nhã.</p>"
                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatHocPhi()
        {
            // NOTE: ko seed data
            return new List<CaiDatTongThe>();
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatQuyDinhNhapHoc()
        {
            return new List<CaiDatTongThe> {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.QuyDinhNhapHoc,
                    TieuDe = "QUY ĐỊNH NHẬP HỌC",
                    Mota = "(Ban hành theo Quyết định số 06-2022/QĐ-HĐT ngày 20/10/2022 của Hội đồng trường Trường Tiểu học Nguyễn Siêu)",
                    Link = "https://nguyensieu.edu.vn/FilesUpload/files/2022-2023-TuyenSinh/QUY%20%C4%90%E1%BB%8ANH%20NH%E1%BA%ACP%20H%E1%BB%8CC.pdf"
                },
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatThongTinTuyenSinh()
        {
            return new List<CaiDatTongThe> {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.ThongTinTuyenSinh,
                    TieuDe = "THÔNG TIN TUYỂN SINH",
                    Mota = "<p>Năm học 2023-2024, Trường Tiểu học Nguyễn Siêu bước sang năm học thứ 19 thực hiện chương trình Chất lượng cao và năm học thứ 11 giảng dạy chương trình Song ngữ Quốc tế liên thông theo chuẩn hệ Cambridge.</p><p>Những kết quả tốt đẹp mà nhà trường đạt được chính là nhờ sự nỗ lực không ngừng của toàn thể cán bộ, giáo viên, nhân viên, học sinh và sự đồng hành, tin tưởng củacha mẹ học sinh, hướng tới một môi trường giáo dục song ngữ hàng đầu, chuẩn bị hành trang cho công dân thế kỷ XXI trong thời đại 4.0.</p>",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "ĐĂNG KÝ TUYỂN SINH ĐẦU CẤP - LỚP 1",
                            MoTa = "<ol><li><strong>Thông tin TS: </strong><a href=\"google.com\">Thông tin tuyển sinh</a></li><li><strong>Ngày hội Open day:</strong> 11/02/2023. Đăng ký <a href=\"google.com\">Tại đây</a></li><li><strong>Hội thảo tư vấn tuyển sinh:</strong> 20/02/2023. Đăng ký <a href=\"google.com\">Tại đây</a></li><li><strong>Thời gian bắt đầu đăng ký trực tuyến:</strong> 20/02/2023</li></ol>"
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "ĐĂNG KÝ TUYỂN SINH BỔ SUNG - LỚP 2, 3, 4, 5",
                            MoTa = "<p><strong>Thời gian bắt đầu đăng ký trực tuyến: 31/5/2023</strong></p><p>(Thông tin đăng ký sẽ vào Danh sách chờ. Nhà trường sẽ chủ động liên lạc khi có chỉ tiêu)</p>"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.ThongTinTuyenSinh,
                    TieuDe = "ĐIỀU KIỆN DỰ TUYỂN",
                    Mota = "<ul><li>Học sinh có năm sinh theo đúng độ tuổi quy định của Bộ Giáo dục &amp; Đào tạo.</li><li>Nguyện vọng của gia đình và năng lực của học sinh phù hợp với định hướng, mục tiêu giáo dục và đào tạo của nhà trường.</li><li>Học sinh có đủ <a href=\"https://www.nguyensieu.edu.vn/FilesUpload/files/Tuyensinh.jpg?zarsrc=410&amp;utm_source=zalo&amp;utm_medium=zalo&amp;utm_campaign=zalo\">sức khỏe</a><a href=\"http://nguyensieu.edu.vn/FilesUpload/files/YCNLTS.pdf\"> </a>và năng lực học tập <a href=\"https://www.nguyensieu.edu.vn/chuong-trinh-hoc.html\">chương trình nhà trường</a> (chương trình Việt Nam và chương trình Quốc tế).- Học sinh có học lực Khá/ Hoàn thành trở lên (các năm học trước, trừ HS dự tuyển lớp 1), hạnh kiểm Tốt.- Học sinh có trình độ tiếng Anh phù hợp với yêu cầu, mục tiêu của chương trình nhà trường. (Quý phụ huynh vui lòng tham khảo <a href=\"google.com\"><strong>TẠI ĐÂY</strong></a></li><li>Cha mẹ học sinh (CMHS) hoặc người được ủy quyền hợp lệ là người chịu trách nhiệm đăng kí dự tuyển cho con và chấp nhận<a href=\"https://www.nguyensieu.edu.vn/FilesUpload/files/Qui%20%c4%91%e1%bb%8bnh%20nh%e1%ba%adp%20h%e1%bb%8dc%202021-2022_final.pdf\"> </a><a href=\"https://nguyensieu.edu.vn/tuyen-sinh/quy-dinh-nhap-hoc.html\">Quy định nhập học</a> của nhà trường.</li></ul>",
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.ThongTinTuyenSinh,
                    TieuDe = "ĐĂNG KÝ DỰ TUYỂN",
                    Mota = "<p><strong>100% học sinh</strong> có nguyện vọng dự tuyển vào trường hoặc chuyển mô hình học tập (nếu đang là HS Nguyễn Siêu) <strong>bắt buộc</strong> đăng kí trên hệ thống đăng ký trực tuyến của trường. <strong>Ban tuyển sinh sẽ hướng dẫn các bước tiếp theo qua tài khoản sau khi CMHS đăng kí thành công. Thời gian bắt đầu mở link đăng kí: trong giờ hành chính.</strong></p><p>Hệ thống sẽ tự động chuyển hồ sơ sang danh sách <strong>Chờ dự tuyển</strong> khi đã đủ số lượng hồ sơ đăng kí.</p><p>CMHS có nguyện vọng tham dự hội thảo tư vấn tuyển sinh vui lòng đăng kí <a href=\"google.com\"><strong>TẠI ĐÂY</strong></a></p><p>Hướng dẫn cập nhật lại thông tin khi hồ sơ không lệ, xin xem <a href=\"google.com\"><strong>TẠI ĐÂY</strong></a></p><p>&nbsp;</p><p><strong>Hồ sơ chuẩn bị đăng ký online gồm</strong>:</p><ul><li>Lớp 1: ảnh 3x4 nền trắng + bản chụp giấy khai sinh</li><li>Lớp 2-12: ảnh 3x4 nền trắng + kết quả học tập và rèn luyện các năm học trước (bao gồm cả thành tích hoặc chứng chỉ tiếng Anh quốc tế - nếu có)</li></ul>",
                },

            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatNoiQuy()
        {
            return new List<CaiDatTongThe>{
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.NoiQuy,
                    CaiDatChiTiet=  new List<CaiDatChiTiet>{
                        new CaiDatChiTiet
                        {
                            TieuDe= "Ra vào trường, lớp",
                            MoTa= "<p>Học sinh đi học đúng giờ</p><p>Học sinh nghỉ học và nghỉ các hoạt động tập thể do nhà trường tổ chức phải có đơn xin phép của cha mẹ học sinh (CMHS) và có lí do chính đáng. CMHS xin phép nghỉ học trên hệ thống vnEdu, nếu học sinh nghỉ từ 3 ngày trở lên, CMHS viết Đơn xin phép gửi trực tiếp hoặc gửi email cho giáo viên chủ nhiệm (GVCN). GVCN có trách nhiệm báo cáo lên Ban Giám hiệu.</p><p>Học sinh đau ốm cần xuống phòng y tế nhà trường, y tế báo cho GVCN để xác nhận.</p><p>Trong thời gian đến trường, học sinh không ra ngoài khu vực trường. Trường hợp có việc thực sự cần thiết phải ra ngoài cổng trường phải xin phép GVCN, và có giấy cho phép ra ngoài trường.</p>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "KỶ LUẬT VÀ HỌC TẬP",
                            MoTa= "<ul><li>&nbsp;Học sinh đến lớp phải mang đầy đủ sách vở, đồ dùng học tập và chuẩn bị bài theo quy định của bộ môn.</li><li>Trong giờ học ngồi đúng vị trí, tập trung nghe giảng, tích cực tham gia các hoạt động theo sự hướng dẫn của giáo viên.</li><li>Học sinh tham gia dự đầy đủ các hoạt động giáo dục toàn diện, các kỳ kiểm tra do nhà trường tổ chức với thái độ nghiêm túc và trung thực.</li><li>Giữa hai tiết học (5 phút) học sinh hạn chế ra khỏi lớp học. Giờ ra chơi 15 phút học sinh có thể xuống ăn sáng tại căng tin. Trong mọi trường hợp học sinh tuyệt đối không được mang đồ ăn lên lớp.</li></ul>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "TÁC PHONG VÀ BẢO VỆ TÀI SẢN",
                            MoTa= " <p>&nbsp;Học sinh đi học phải mặc đồng phục theo quy định của nhà trường. Học sinh đến trường phải để tóc gọn gàng, không nhuộm màu, không cắt tóc, vuốt keo tạo kiểu dáng không phù hợp với học sinh; không đeo khuyên tai (đối với nam sinh); không sơn móng tay, móng chân; tô son môi; không mang tư trang và các đồ dùng khác không phục vụ cho học tập đến trường.</p><p>Học sinh thực hiện tốt Nếp Nguyễn Siêu và 8 giá trị cốt lõi của trường Nguyễn Siêu ở mọi lúc, mọi nơi.</p><p>Có ý thức bảo vệ tốt trang thiết bị và cơ sở vật chất của nhà trường.</p>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "SỬ DỤNG CÔNG NGHỆ THÔNG TIN VÀ TRUYỀN THÔNG",
                            MoTa= " <ul><li>Nghiêm túc chấp hành \"Quy định về sử dụng thiết bị có trách nhiệm” (RUP) của nhà trường.</li><li>Khi sử dụng mạng xã hội</li><li>Tuyệt đối không được dùng những ngôn từ, biểu tượng, cách viết tắt phản cảm, thiếu văn hóa. Phải sử dụng ngôn ngữ trong sáng, thuần Việt.<br>Tuyệt đối không dùng mạng xã hội để chỉ trích, xúc phạm, bêu xấu bất cứ ai hoặc đưa thông tin cá nhân của người khác khi chưa được phép.<br>Chỉ bình luận hoặc thể hiện trạng thái cảm xúc của mình với người khác khi đã đọc kĩ nội dung. Cần phải biết đấu tranh, bày tỏ quan điểm trước những bình luận có nội dung xấu hoặc không lành mạnh. Khi viết bình luận phải rõ ràng, phải cân nhắc kĩ trước khi thể hiện trạng thái cảm xúc hoặc đưa thông tin cá nhân lên mạng.</li></ul>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "HÀNH VI HỌC SINH KHÔNG ĐƯỢC LÀM",
                            MoTa= " <ul><li>Xúc phạm nhân phẩm, danh dự, xâm phạm thân thể giáo viên, cán bộ, nhân viên của nhà trường, người khác và học sinh khác.</li><li>Gian lận trong học tập, kiểm tra, thi cử, tuyển sinh.</li><li>Sử dụng điện thoại di động trong thời gian ở trường; hút thuốc, thuốc lá điện tử; uống rượu, bia và sử dụng các chất kích thích khác.</li><li>Đánh nhau, gây rối trật tự, an ninh trong nhà trường và nơi công cộng.</li><li>Lưu hành, sử dụng các ấn phẩm độc hại, đồi truỵ; đưa thông tin không lành mạnh lên mạng; chơi các trò chơi mang tính kích động bạo lực, tình dục; tham gia các tệ nạn xã hội.</li></ul>",
                        }
                    },
                    TieuDe= "Nội quy học sinh",
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.NoiQuy,
                    TieuDe= "Nội quy ô tô",
                    CaiDatChiTiet= new List<CaiDatChiTiet>{
                        new CaiDatChiTiet
                        {
                            TieuDe= "QUY ĐỊNH SỬ DỤNG DỊCH VỤ Ô TÔ ĐƯA ĐÓN HỌC SINH",
                            MoTa= "<p>1. Cha mẹ học sinh làm đơn tự nguyện đăng kí cho con đi ô tô của công ty vận tải và cá nhân do nhà trường thay mặt cha mẹ học sinh kí hợp đồng.</p><p>2. Học sinh có mặt tại điểm đón trước giờ xe chạy ít nhất 5 phút. Xe chỉ phục vụ theo đúng giờ đưa đón chung của nhà trường trên tuyến xe mà cha mẹ học sinh đăng kí, không có giá trị cho các tuyến xe khác. Học sinh phải xuống xếp hàng ra xe ô tô để đi về đúng giờ quy định, nếu ra muộn học sinh phải tự túc phương tiện đi về.</p><p>3. Cha mẹ học sinh đưa và đón con đúng giờ, đúng điểm; nếu đến muộn giờ đã định, gia đình tự chịu trách nhiệm về việc đưa đón con đến trường - về nhà.</p><p>4. Cha mẹ học sinh phối hợp chặt chẽ với giáo viên chủ nhiệm và giáo viên phụ trách xe ô tô giáo dục con chấp hành tốt luật an toàn giao thông, những quy định của các công ty vận tải và nội quy của trường về việc đi ô tô (khi xe dừng hẳn mới được lên xuống xe; khi xe chạy, xe dừng, không thò đầu, đưa tay ra ngoài cửa xe; không đùa nghịch trên xe và tại các điểm đưa đón; không vứt rác ra xe hoặc xuống đường phố, không dùng bất kỳ loại bút, sơn, vật nhọn..vẽ, kẻ lên thành ghế, kính, thân xe; khi học sinh nghỉ học, nghỉ đi xe ô tô, gia đình phải thông báo tới giáo viên chủ nhiệm và quản lý xe,...). Tuân thủ sự điều hành của giáo viên phụ trách xe về mọi mặt.</p><p>5. Xe ô tô đưa đón tại nhà chỉ đón ở mặt đường chính (nếu đường 2 chiều chỉ đón hoặc trả theo một chiều thuận). Tại các điểm không có giáo viên đón trả, cha mẹ học sinh phải hoàn toàn chịu trách nhiệm về sự an toàn của con.</p><p>6. Tiền đi xe ô tô theo giá của các công ty vận tải, nộp cùng với học phí theo phương thức nộp học phí. Khi không còn nhu cầu cho con đi ô tô, cha mẹ học sinh phải làm đơn xin ngừng và nộp trước 1 tháng. Phí đi ô tô được làm tròn tháng kể từ ngày học sinh dừng sử dụng dịch vụ.</p><p>7. Cha mẹ học sinh cần lưu số điện thoại của giáo viên phụ trách xe, lái xe và giáo viên chủ nhiệm, đồng thời thông báo số điện thoại di động, điện thoại nhà riêng cho giáo viên phụ trách xe để liên hệ khi cần thiết.</p><p>8. Mọi sự cố về xe và hành khách (học sinh, giáo viên) đi trên xe do công ty vận tải và các cá nhân đã kí hợp đông với nhà trường hoàn toàn chịu trách nhiệm theo luật pháp quy định về bảo hiểm hành khách.</p><p>9. Học sinh chỉ được đi trên 1 xe và nhà trường không đáp ứng trường hợp đi ô tô 1 chiều. Học sinh phải có thẻ mới được lên, xuống xe ô tô.</p><p>10. Học sinh và cha mẹ học sinh có nhiệm vụ chấp hành đầy đủ những quy định trên, nếu có những vi phạm làm ảnh hưởng đến học sinh khác, đến nhà trường, đặc biệt là ảnh hưởng đến việc đảm bảo an toàn cho học sinh, nhà trường có thể tạm dừng hoặc từ chối cung cấp dịch vụ đi xe ô tô.</p>",
                        }
                    },

                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.NoiQuy,
                    TieuDe= "",
                    CaiDatChiTiet= new List<CaiDatChiTiet>{
                        new CaiDatChiTiet
                            {
                                MoTa= "Học sinh vi phạm nội quy sẽ bị xử lí kỷ luật theo điều lệ trường có nhiều cấp học của Bộ Giáo dục và Đào tạo và theo quy định trong Sổ tay\r\n          học sinh của Nhà trường.",
                                Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"26\" viewBox=\"0 0 28 26\" fill=\"none\">\r\n  <path d=\"M13.5844 3.61016C13.6719 3.4625 13.8305 3.375 14 3.375C14.1695 3.375 14.3281 3.4625 14.4156 3.61016L25.2602 21.4219C25.3367 21.5477 25.375 21.6898 25.375 21.832C25.375 22.2695 25.0195 22.625 24.582 22.625H3.41797C2.98047 22.625 2.625 22.2695 2.625 21.832C2.625 21.6844 2.66328 21.5422 2.73984 21.4219L13.5844 3.61016ZM11.3422 2.24297L0.497656 20.0547C0.169531 20.5906 0 21.2031 0 21.832C0 23.7188 1.53125 25.25 3.41797 25.25H24.582C26.4688 25.25 28 23.7188 28 21.832C28 21.2031 27.825 20.5906 27.5023 20.0547L16.6578 2.24297C16.0945 1.31875 15.0883 0.75 14 0.75C12.9117 0.75 11.9055 1.31875 11.3422 2.24297ZM15.75 19.125C15.75 18.6609 15.5656 18.2158 15.2374 17.8876C14.9092 17.5594 14.4641 17.375 14 17.375C13.5359 17.375 13.0908 17.5594 12.7626 17.8876C12.4344 18.2158 12.25 18.6609 12.25 19.125C12.25 19.5891 12.4344 20.0342 12.7626 20.3624C13.0908 20.6906 13.5359 20.875 14 20.875C14.4641 20.875 14.9092 20.6906 15.2374 20.3624C15.5656 20.0342 15.75 19.5891 15.75 19.125ZM15.3125 9.0625C15.3125 8.33516 14.7273 7.75 14 7.75C13.2727 7.75 12.6875 8.33516 12.6875 9.0625V14.3125C12.6875 15.0398 13.2727 15.625 14 15.625C14.7273 15.625 15.3125 15.0398 15.3125 14.3125V9.0625Z\" fill=\"#F05A22\"/>\r\n</svg><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"26\" viewBox=\"0 0 28 26\" fill=\"none\">\r\n  <path d=\"M13.5844 3.61016C13.6719 3.4625 13.8305 3.375 14 3.375C14.1695 3.375 14.3281 3.4625 14.4156 3.61016L25.2602 21.4219C25.3367 21.5477 25.375 21.6898 25.375 21.832C25.375 22.2695 25.0195 22.625 24.582 22.625H3.41797C2.98047 22.625 2.625 22.2695 2.625 21.832C2.625 21.6844 2.66328 21.5422 2.73984 21.4219L13.5844 3.61016ZM11.3422 2.24297L0.497656 20.0547C0.169531 20.5906 0 21.2031 0 21.832C0 23.7188 1.53125 25.25 3.41797 25.25H24.582C26.4688 25.25 28 23.7188 28 21.832C28 21.2031 27.825 20.5906 27.5023 20.0547L16.6578 2.24297C16.0945 1.31875 15.0883 0.75 14 0.75C12.9117 0.75 11.9055 1.31875 11.3422 2.24297ZM15.75 19.125C15.75 18.6609 15.5656 18.2158 15.2374 17.8876C14.9092 17.5594 14.4641 17.375 14 17.375C13.5359 17.375 13.0908 17.5594 12.7626 17.8876C12.4344 18.2158 12.25 18.6609 12.25 19.125C12.25 19.5891 12.4344 20.0342 12.7626 20.3624C13.0908 20.6906 13.5359 20.875 14 20.875C14.4641 20.875 14.9092 20.6906 15.2374 20.3624C15.5656 20.0342 15.75 19.5891 15.75 19.125ZM15.3125 9.0625C15.3125 8.33516 14.7273 7.75 14 7.75C13.2727 7.75 12.6875 8.33516 12.6875 9.0625V14.3125C12.6875 15.0398 13.2727 15.625 14 15.625C14.7273 15.625 15.3125 15.0398 15.3125 14.3125V9.0625Z\" fill=\"#F05A22\"/>\r\n</svg>"
                            },
                            new CaiDatChiTiet
                            {
                                MoTa= "Mọi ý kiến phản ánh, đóng góp, cha mẹ học sinh có thể liên hệ trực\r\n          tiếp qua các kênh thông tin sau (vào giờ hành chính các ngày làm việc\r\n trong tuần):",
                            },
                            new CaiDatChiTiet
                            {

                                MoTa= "02437844889",
                                Icon="<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 20 20\" fill=\"none\">\r\n  <g clip-path=\"url(#clip0_518_7099)\">\r\n    <path d=\"M14.6771 10.7477C14.0366 10.4743 13.2946 10.654 12.8532 11.1929L11.5566 12.7786C9.76003 11.7358 8.26029 10.2361 7.2175 8.4395L8.79926 7.14676C9.33823 6.70543 9.52179 5.96337 9.24449 5.32286L7.36982 0.948615C7.0769 0.261234 6.33875 -0.121512 5.6084 0.0347108L1.23416 0.972048C0.515536 1.12437 0 1.76097 0 2.49913C0 11.7436 7.16673 19.3126 16.2472 19.9531C16.4229 19.9648 16.6026 19.9766 16.7822 19.9844C16.7822 19.9844 16.7822 19.9844 16.7862 19.9844C17.0244 19.9922 17.2587 20 17.5009 20C18.239 20 18.8756 19.4845 19.028 18.7658L19.9653 14.3916C20.1215 13.6613 19.7388 12.9231 19.0514 12.6302L14.6771 10.7555V10.7477ZM17.4853 18.7463C8.51805 18.7385 1.24978 11.4702 1.24978 2.49913C1.24978 2.35072 1.35133 2.22574 1.49583 2.19449L5.87008 1.25716C6.01458 1.22591 6.16299 1.30402 6.22158 1.44072L8.09625 5.81496C8.15093 5.94384 8.11578 6.09225 8.00642 6.17818L6.42076 7.47483C5.94819 7.86148 5.82321 8.53714 6.13175 9.0683C7.28389 11.0562 8.93986 12.7122 10.9239 13.8604C11.455 14.169 12.1307 14.044 12.5174 13.5714L13.814 11.9858C13.9038 11.8764 14.0523 11.8413 14.1772 11.8959L18.5515 13.7706C18.6882 13.8292 18.7663 13.9776 18.735 14.1221L17.7977 18.4964C17.7665 18.6409 17.6376 18.7424 17.4931 18.7424C17.4892 18.7424 17.4853 18.7424 17.4813 18.7424L17.4853 18.7463Z\" fill=\"#F05A22\"/>\r\n  </g>\r\n  <defs>\r\n    <clipPath id=\"clip0_518_7099\">\r\n      <rect width=\"20\" height=\"20\" fill=\"white\"/>\r\n    </clipPath>\r\n  </defs>\r\n</svg>"
                            },
                            new CaiDatChiTiet
                            {

                                MoTa= "Info@thnguyensieu.edu.vn",
                                Icon="<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 20 20\" fill=\"none\">\r\n  <path d=\"M2.5 3.75C1.80859 3.75 1.25 4.30859 1.25 5V6.55859L8.89062 12.1602C9.55078 12.6445 10.4492 12.6445 11.1094 12.1602L18.75 6.55859V5C18.75 4.30859 18.1914 3.75 17.5 3.75H2.5ZM1.25 8.10938V15C1.25 15.6914 1.80859 16.25 2.5 16.25H17.5C18.1914 16.25 18.75 15.6914 18.75 15V8.10938L11.8477 13.168C10.7461 13.9727 9.25 13.9727 8.15234 13.168L1.25 8.10938ZM0 5C0 3.62109 1.12109 2.5 2.5 2.5H17.5C18.8789 2.5 20 3.62109 20 5V15C20 16.3789 18.8789 17.5 17.5 17.5H2.5C1.12109 17.5 0 16.3789 0 15V5Z\" fill=\"#F05A22\"/>\r\n</svg>"
                            }
                    },

                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatThoiGianBieu_LichNamHoc()
        {
            // NOTE: ko seed data
            return new List<CaiDatTongThe>();
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatPhuongThucDayHoc()
        {
            return new List<CaiDatTongThe>()
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.PhuongThucDayHoc,
                    CaiDatChiTiet = new List<CaiDatChiTiet>{
                        new CaiDatChiTiet
                        {
                            TieuDe= "Tổ Chức",
                            TieuDeTiengAnh= "organization",
                            MoTa= "<p><strong>Tổ chức dạy học và quản lí bán trú</strong> từ lớp 1 đến lớp 5 trong đó GVCN là “người mẹ thứ hai”, định hướng giúp các con lĩnh hội kiến thức và tư vấn, chăm sóc học sinh 2 buổi/ngày.&nbsp;</p>",
                            LinkAnh= "/imgs/PhuongThucDayHoc/4058CC49-2CDC-4C18-82BD-41AB583201CC.png",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Lớp Học",
                            MoTa= "<p><strong>Lớp học</strong> có sĩ số ít (&lt;=30HS/lớp) để GV có điều kiện dạy học nhóm, quan tâm chăm sóc HS theo quan điểm “không bỏ rơi học sinh nào”.&nbsp;</p>",
                            LinkAnh= "/imgs/PhuongThucDayHoc/B21380A5-B931-48D3-9764-D236890D5300.png",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Chương Trình Học",
                            MoTa= "<p><strong>Chương trình học</strong> đa mục tiêu, phát triển dạy học song ngữ, hình thức tổ chức dạy học hiện đại, phong phú: phân hoá theo trình độ, dạy học tích hợp, dạy học ngoài trời, trải nghiệm, thực hành tại phòng thí nghiệm đạt chuẩn quốc tế, đẩy mạnh giao lưu hợp tác, ứng dụng CNTT, giáo dục kĩ năng sống theo 08 giá trị cốt lõi của Trường.</p>",
                            LinkAnh= "/imgs/PhuongThucDayHoc/88F25BC4-5C45-437A-B162-490A567DDFC5.png",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Đội ngũ GV",
                            MoTa= "<p><strong>Đội ngũ GV Việt Nam, GV nước ngoài</strong> đạt chuẩn và trên chuẩn, tâm huyết, yêu nghề, được đào tạo nâng cao trình độ, nghiệp vụ hàng năm.&nbsp;</p>",
                            LinkAnh= "/imgs/PhuongThucDayHoc/CD8296EF-EC23-40CA-B8E2-C2643F899728.jpg",
                        },
                    },
                    TieuDe = "Phương Thức dạy hoc",
                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatTongQuan()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.TongQuan,
                    TieuDe = "GIỚI THIỆU CHUNG",
                    Mota = "<p>&nbsp; &nbsp; &nbsp; &nbsp;Kế thừa tư tưởng “Đạo học không lối tắt, nhà tranh lắm người tài” của nhà giáo Nguyễn Văn Siêu, thực hiện lời dạy của Bác Hồ “Vì lợi ích mười năm thì phải trồng cây, vì lợi ích trăm năm thì phải trồng người”, ngày 31/3/1993, nhà giáo ưu tú Nguyễn Trọng Vĩnh – Chủ tịch hội đồng quản trị THCS &amp;THPT Nguyễn Siêu và nhà giáo Dương Thị Thịnh - Nguyên chủ tịch Hội đồng trường Tiểu học Nguyễn Siêu đã sáng lập nên ngôi trường <strong>Tiểu học Nguyễn Siêu</strong>. Trải qua gần 30 năm xây dựng và phát triển, trường Nguyễn Siêu ngày càng khang trang, hiện đại và thành công trong việc phát triển mô hình trường chất lượng cao ngoài công lập đầu tiên của Thủ đô Hà Nội và từng bước trở thành trường song ngữ Quốc tế Cambridge. Ở nơi đây, tập thể cán bộ, giáo viên, nhân viên nhà trường không ngừng nỗ lực sáng tạo, tìm tòi đổi mới phương pháp và hình thức tổ chức dạy học để không những dẫn dắt, định hướng cho học sinh lĩnh hội tri thức mà còn tích cực lan tỏa lẽ sống tốt đẹp đến các con học sinh. &nbsp;</p></p>",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TongQuan/B78D5297-B9EC-44C0-8DA1-F3FCBA7E8856.png"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TongQuan/202A4068-6A8C-499A-8422-7E9EB15C75E3.png"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TongQuan/EEC4957B-D4DA-4F13-BE9E-65F4753DF9BA.png"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TongQuan/37B0A246-1682-4FAB-8C77-C151D016A109.png"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TongQuan/286D20B6-AA1D-44CE-96DA-9CD9FC0B7D68.png"
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TongQuan/4198A910-1D65-40A9-A705-8648717F1B90.png"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.TongQuan,
                    TieuDe = "TẦM NHÌN - SỨ MỆNH - GIÁ TRỊ CỐT LÕI",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "<p>TẦM NHÌN</p><p>Khơi dậy tiềm năng thật sự của bạn</p>",
                            MoTa = "<p>Phấn đấu xây dựng Trường Nguyễn Siêu trở thành ngôi trường song ngữ hàng đầu tại Việt Nam, đáp ứng các tiêu chuẩn giáo dục phổ thông quốc tế; cung cấp chương trình giáo dục đẳng cấp thế giới song vẫn luôn gìn giữ và phát huy các giá trị truyền thống của Việt Nam. Chương trình giáo dục hướng tới cam kết và đảm bảo cho học sinh được trang bị một cách tốt nhất để có thể khẳng định vị thế và chỗ đứng của bản thân trên trường quốc tế - một thế giới ngày càng phát triển về phạm vi kết nối và toàn cầu hoá.&nbsp;</p>",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"58\" height=\"61\" viewBox=\"0 0 58 61\" fill=\"none\">    <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M21.2574 2.18299C10.5638 2.18299 1.8949 10.8519 1.8949 21.5455C1.8949 32.2392 10.5638 40.9081 21.2574 40.9081C31.9511 40.9081 40.62 32.2392 40.62 21.5455C40.62 10.8519 31.9511 2.18299 21.2574 2.18299ZM0 21.5455C0 9.80537 9.51728 0.288086 21.2574 0.288086C32.9976 0.288086 42.5149 9.80537 42.5149 21.5455C42.5149 26.9636 40.4879 31.9083 37.1508 35.6625L41.5574 40.8448C42.4428 40.6578 43.401 40.949 44.0274 41.6855L56.6674 56.5155C57.5674 57.5855 57.4374 59.1955 56.3774 60.1055C55.3074 61.0155 53.6974 60.8856 52.7874 59.8156L40.1474 44.9855C39.3911 44.0962 39.3532 42.8339 39.9763 41.9105L35.8242 37.0275C32.0195 40.6086 26.8947 42.803 21.2574 42.803C9.51728 42.803 0 33.2857 0 21.5455ZM21.0374 19.2033C19.6313 19.2033 18.4945 20.3402 18.4945 21.7462C18.4945 23.1523 19.6313 24.2891 21.0374 24.2891C22.4434 24.2891 23.5803 23.1523 23.5803 21.7462C23.5803 20.3402 22.4434 19.2033 21.0374 19.2033ZM17.1403 21.7462C17.1403 19.5923 18.8834 17.8491 21.0374 17.8491C23.1913 17.8491 24.9345 19.5923 24.9345 21.7462C24.9345 23.9002 23.1913 25.6433 21.0374 25.6433C18.8834 25.6433 17.1403 23.9002 17.1403 21.7462ZM21.0384 15.8779C24.3726 15.8731 27.3549 16.5755 29.4776 17.6801C31.6348 18.8025 32.7257 20.2306 32.7257 21.6162C32.7257 22.9962 31.6358 24.4219 29.4776 25.5449C27.3545 26.6496 24.3718 27.3545 21.0374 27.3545C17.703 27.3545 14.7203 26.6496 12.5971 25.5449C10.439 24.4219 9.34909 22.9962 9.34909 21.6162C9.34909 20.2363 10.439 18.8105 12.5971 17.6876C14.7203 16.5828 17.703 15.8779 21.0374 15.8779L21.0384 15.8779ZM34.1491 21.6162C34.1491 19.4319 32.4649 17.6299 30.1346 16.4174C27.77 15.187 24.5525 14.4495 21.0369 14.4545H21.0374V15.1662L21.0363 14.4545C17.5212 14.4547 14.3043 15.1947 11.9401 16.4249C9.61078 17.6369 7.92569 19.4362 7.92569 21.6162C7.92569 23.7963 9.61078 25.5955 11.9401 26.8076C14.3045 28.0379 17.5218 28.778 21.0374 28.778C24.553 28.778 27.7703 28.0379 30.1346 26.8076C32.464 25.5955 34.1491 23.7963 34.1491 21.6162Z\" fill=\"#FFFAF5\"/>  </svg>",
                            LinkAnh = "/imgs/TongQuan/527D0825-AEED-43E4-8C1C-537A6DFA0589.jpg",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "<p>SỨ MỆNH</p><p>Nuôi dưỡng nền tảng</p>",
                            MoTa = "<p>Phát triển môi trường học tập song ngữ và đa văn hóa, nuôi dưỡng học sinh trở thành những công dân toàn cầu thấm nhuần niềm tự hào về nguồn cội, niềm biết ơn và tôn trọng sâu sắc đối với văn hóa và ngôn ngữ Việt Nam.</p>",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"62\" height=\"47\" viewBox=\"0 0 62 47\" fill=\"none\">    <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M60.8804 14.2725L49.0678 1.31733C48.945 1.1357 48.7861 1.05444 48.7528 1.03741L48.75 1.03597C48.6258 0.971837 48.5036 0.948625 48.4692 0.942086L48.4661 0.941494C48.3619 0.921539 48.2337 0.908741 48.1103 0.898996C47.8492 0.878379 47.4682 0.861307 46.9952 0.846841C46.0437 0.817747 44.6685 0.797774 43.0155 0.785732C39.7072 0.761629 35.2642 0.769152 30.8232 0.800418C26.3823 0.831683 21.9392 0.886721 18.6308 0.957777C16.9778 0.99328 15.6025 1.0329 14.6509 1.07581C14.1778 1.09715 13.7966 1.11985 13.5353 1.14447C13.4118 1.15611 13.2832 1.17094 13.1787 1.19273L13.1757 1.19336C13.141 1.20055 13.0189 1.22583 12.8954 1.29232L12.8928 1.29371C12.8596 1.31148 12.7086 1.39217 12.5903 1.5673L0.21803 15.1222C-0.0836031 15.4526 -0.0707491 15.9622 0.24716 16.2771L30.2472 45.9871C30.4058 46.1441 30.6207 46.2311 30.8439 46.2284C31.0671 46.2258 31.28 46.1338 31.4348 45.973L60.8648 15.413C61.1698 15.0963 61.1766 14.5974 60.8804 14.2725ZM3.2539 14.2705L13.7214 2.80249C13.762 2.79884 13.8067 2.79517 13.8553 2.79148L22.9483 14.1935L3.2539 14.2705ZM48.387 3.04654L58.4246 14.0549L41.143 14.1225L48.387 3.04654ZM47.0947 2.51897L40.3789 12.7872L32.3056 2.67437L46.9704 2.51497L47.0947 2.51897ZM39.696 14.1281L24.2998 14.1883L31.2547 3.55444L39.696 14.1281ZM30.2981 2.51359L17.4747 2.65305C16.7487 2.67118 16.0996 2.69014 15.5429 2.70982L23.5791 12.7867L30.2981 2.51359ZM29.0581 41.3038L12.9599 15.8462L22.4012 15.8093L29.0581 41.3038ZM26.6796 40.1063L11.7652 16.5208C11.6329 16.3115 11.628 16.0579 11.73 15.851L2.225 15.8881L26.6796 40.1063ZM35.5802 39.2637L50.651 15.7645C50.6648 15.743 50.6772 15.7211 50.6883 15.6988L58.3024 15.669L35.5802 39.2637ZM49.0612 15.7051L33.1109 40.5756L41.1345 15.7361L49.0612 15.7051ZM23.816 15.8038L39.6927 15.7417L30.9041 42.9496L23.816 15.8038Z\" fill=\"#FFFAF5\"/>  </svg>",
                            LinkAnh = "/imgs/TongQuan/085963F3-57B1-42F5-B0F7-C66AA418F471.png",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "<p>GIÁ TRỊ CỐT LÕI</p><p>Hành động từ trái tim</p>",
                            MoTa = "<p>Giá trị cốt lõi của trường là hành động từ trái tim. Trường Nguyễn Siêu định hướng phát triển trên nền tảng gồm 3 giá trị cốt lõi: Sự tôn trọng, chính trực và xuất sắc.&nbsp;</p><p>- <strong>Tôn trọng: </strong>Tôn trọng lẫn nhau, xây dựng các mối quan hệ hợp tác để cùng nhau phát triển, đối xử với người khác bằng sự tử tế. &nbsp;</p><p>- <strong>Chính trực:</strong> Hành động trung thực, minh bạch và có trách nhiệm. &nbsp;</p><p>- <strong>Xuất sắc:</strong> Quyết tâm đạt được các mục tiêu với kết quả tốt nhất, kiến tạo tương lai hạnh phúc.&nbsp;</p>",
                            Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"51\" height=\"73\" viewBox=\"0 0 51 73\" fill=\"none\">    <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M25.4109 0C23.3551 0 21.5859 1.58894 20.1165 3.97898C18.6227 6.40894 17.3031 9.87798 16.205 14.102C14.4326 20.9194 13.2106 29.8082 12.8031 39.7229C12.56 39.5897 12.2505 39.6066 12.02 39.79C2.54816 47.3286 -2.00132 60.5401 0.835478 72.3148C0.913878 72.6402 1.20906 72.8665 1.54367 72.8578C1.87828 72.8491 2.16128 72.6077 2.22263 72.2786C3.41684 65.8733 7.18564 62.0628 13.0543 58.9347C13.2595 61.9274 13.5394 64.8027 13.8844 67.5288C13.9292 67.8834 14.2308 68.1492 14.5882 68.1492H36.2336C36.5905 68.1492 36.8919 67.884 36.9373 67.5299C37.2711 64.924 37.542 62.1819 37.7438 59.3315C43.1974 62.3865 46.705 66.1416 47.8492 72.2786C47.9106 72.6077 48.1936 72.8491 48.5282 72.8578C48.8628 72.8665 49.158 72.6402 49.2364 72.3148C52.0732 60.5401 47.5237 47.3286 38.0519 39.79L38.0355 39.7774L38.0205 39.7664C37.6148 29.8341 36.3918 20.9294 34.6168 14.102C33.5187 9.87798 32.1991 6.40894 30.7052 3.97898C29.2359 1.58894 27.4666 0 25.4109 0ZM48.4178 68.9211C46.6021 63.8254 42.9032 60.4928 37.8468 57.7693C37.9867 55.4798 38.0824 53.1254 38.1309 50.7199C38.151 50.6544 38.1619 50.5848 38.1619 50.5127C38.1619 50.45 38.1537 50.3892 38.1383 50.3313C38.1578 49.2465 38.1677 48.1515 38.1677 47.0476C38.1677 45.2274 38.1405 43.4311 38.0876 41.6645C45.7174 48.2869 49.6928 58.9083 48.4178 68.9211ZM36.7279 49.809C36.7417 48.8955 36.7488 47.9748 36.7488 47.0476C36.7488 34.2925 35.4044 22.7708 33.2436 14.459C32.1617 10.2979 30.8854 6.98136 29.4965 4.72208C28.083 2.4229 26.6826 1.4189 25.4109 1.4189C24.1391 1.4189 22.7388 2.4229 21.3253 4.72208C19.9364 6.98136 18.66 10.2979 17.5782 14.459C15.4174 22.7708 14.073 34.2925 14.073 47.0476C14.073 47.9748 14.0802 48.8955 14.0943 49.809H36.7279ZM14.1217 51.2164C14.251 56.7272 14.6331 61.9556 15.215 66.7303H35.6077C36.1959 61.9562 36.5736 56.7279 36.7009 51.2164H14.1217ZM12.9662 57.5668C12.7626 54.1861 12.6541 50.6649 12.6541 47.0476C12.6541 45.0054 12.6883 42.9934 12.7547 41.0196C4.62365 47.5824 0.336833 58.5765 1.65406 68.9211C3.50025 63.7399 7.29335 60.3814 12.4809 57.6326C12.6358 57.5505 12.8075 57.5316 12.9662 57.5668ZM25.4109 13.8746C24.2537 13.8746 23.3102 14.8117 23.3102 15.9752C23.3102 17.1324 24.2473 18.0759 25.4109 18.0759C26.5681 18.0759 27.5115 17.1388 27.5115 15.9752C27.5115 14.8101 26.576 13.8746 25.4109 13.8746ZM21.8913 15.9752C21.8913 14.0249 23.4731 12.4557 25.4109 12.4557C27.3596 12.4557 28.9304 14.0265 28.9304 15.9752C28.9304 17.9255 27.3486 19.4948 25.4109 19.4948C23.4605 19.4948 21.8913 17.9129 21.8913 15.9752ZM23.3102 28.8296C23.3102 27.666 24.2537 26.7289 25.4109 26.7289C26.576 26.7289 27.5115 27.6644 27.5115 28.8296C27.5115 29.9931 26.5681 30.9302 25.4109 30.9302C24.2473 30.9302 23.3102 29.9868 23.3102 28.8296ZM25.4109 25.31C23.4731 25.31 21.8913 26.8793 21.8913 28.8296C21.8913 30.7673 23.4605 32.3491 25.4109 32.3491C27.3486 32.3491 28.9304 30.7799 28.9304 28.8296C28.9304 26.8808 27.3596 25.31 25.4109 25.31Z\" fill=\"#FFFAF5\"/>  </svg>",
                            LinkAnh = "/imgs/TongQuan/FA51AD0A-A538-468D-ADF6-1F5AC34E6AFD.png"
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.TongQuan,
                    TieuDe = "VÌ SAO CHỌN NGUYỄN SIÊU?",
                    Mota = "<p><strong>Trường Tiểu học Nguyễn Siêu</strong> là một trường dân lập tọa lạc tại <strong>Hà Nội, Việt Nam</strong>. Trường được <strong>thành lập vào ngày 31/3/1993 theo quyết định số 2860 của UBND Thành phố Hà Nội</strong>. <strong>Ngôi trường được đặt tên theo danh nhân Việt Nam nổi tiếng Nguyễn Văn Siêu</strong>. Nói về Nguyễn Siêu, từ nhỏ ông đã bộc lộ ý chí muốn thành người tài đức. Ông là người “nổi tiếng học giỏi, tung hoành văn từ cổ, không chịu gò bó theo kiểu học thời tục, tiếng tăm bắt đầu vang dậy khắp nơi, vượt qua nhiều bậc danh Nho đương thời”.( Theo Nguyễn Trọng Hợp: Bia thần đạo tại lăng Phương Đình thụy Chí Đạo, Trần Lê Sáng dịch, Tạp chí Hán Nôm, số 1/1996, tr.79.). <strong>Thầy Nguyễn Văn Siêu có câu nói nổi tiếng \" Dẫu biết tròn là khôn nhưng xin nguyện lấy vuông làm mẫu\" thể hiện ý chí tuân thủ và trân trọng những giá trị truyền thống đồng thời khát khao tìm tòi sáng tạo phát triển những giá trị mới</strong>. Lĩnh hội đạo lí này, các CB, GV,NV của trường đã nhận thấy sứ mệnh của người Nguyễn Siêu không chỉ dừng lại ở việc truyền thụ kiến thức, mà quan trọng hơn là lan tỏa lẽ sống tốt đẹp.<br><br>Trường Tiểu học Nguyễn Siêu từ lâu đã có danh tiếng về mặt học thuật, đã sản sinh ra nhiều cựu học sinh nổi tiếng.</p></p>",
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            MoTa = "<p><strong>Là ngôi trường đi đầu trong xây dựng Văn hóa nhà trường:</strong> Suốt 30 năm qua, Trường Nguyễn Siêu luôn đề cao tầm quan trọng của trường học như một \"tổ ấm\" chứa đựng tình thương và sự phát triển toàn diện cho học sinh.&nbsp;</p>",
                        },
                        new CaiDatChiTiet
                        {
                            MoTa = "<p><strong>Chương trình học đa mục tiêu:</strong> Học sinh Nguyễn Siêu được tiếp cận ba chương trình học: Chương trình của Bộ GD và ĐT Việt Nam, chương trình quốc tế Cambridge và chương trình tích hợp.</p>",
                        },
                        new CaiDatChiTiet
                        {
                            MoTa = "<p><strong>Hệ thống các hoạt động trải nghiệm đa dạng, phong phú:</strong> Các hoạt động trải nghiệm và dự án học tập đa dạng tạo cơ hội phát triển tư duy sáng tạo và khả năng giải quyết vấn đề cho học sinh.&nbsp;</p>",
                        },
                        new CaiDatChiTiet
                        {
                            MoTa = "<p><strong>Đội ngũ giáo viên đầy tâm huyết:</strong> Đội ngũ giáo viên Việt Nam có chuyên môn cao, giàu kinh nghiệm, năng động và sáng tạo, là tấm gương sáng cho học sinh học tập. Đội ngũ giáo viên nước ngoài có chất lượng, hết lòng vì học sinh thân yêu, đồng hành cùng đội ngũ giáo viên Việt Nam tạo nên một tập thể giáo viên đa văn hóa, sắc màu, góp phần hội nhập quốc tế và thu hẹp khoảng cách văn hóa.</p>",
                        },
                        new CaiDatChiTiet
                        {
                            MoTa = "<p><strong>Khuôn viên xanh thân thiện:</strong> Trường có nhiều không gian xanh, hướng tới việc xây dựng trường học thân thiện với môi trường.&nbsp;</p>",
                        },
                        new CaiDatChiTiet
                        {
                            MoTa = "<p><strong>Các Câu lạc bộ sau giờ học:</strong> Nơi phát hiện và nuôi dưỡng năng khiếu , phát triển năng lực giao tiếp - hợp tác, giải quyết vấn đề và sáng tạo.</p>",
                        },
                        new CaiDatChiTiet
                        {
                            MoTa = "<p><strong>Trường học hạnh phúc:</strong> Trường hướng tới việc giúp mỗi học sinh vượt qua khó khăn để tiến bộ mỗi ngày, đạt được sự phát triển tối ưu và hạnh phúc.&nbsp;</p>",
                        },
                        new CaiDatChiTiet
                        {
                            MoTa = "<p>Trường Tiểu học Nguyễn Siêu cam kết mang đến môi trường học tập chất lượng, đa dạng, và thúc đẩy sự phát triển toàn diện của học sinh, hình thành kỹ năng của công dân thế kỷ 21 sẵn sàng hội nhập nhưng vẫn giữ được bản sắc dân tộc.</p>",
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.TongQuan,
                    TieuDe = "NẾP NGUYỄN SIÊU",
                },
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatTinTucSuKien()
        {
            // NOTE: ko seed data
            return new List<CaiDatTongThe>();
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatGocTruyenThong()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.GocTruyenThong,
                    TieuDe = "Góc Truyền thông",
                    Mota = "Phòng Truyền thống - Trưng bày Trường Nguyễn Siêu không đơn thuần là một phần cấu thành nên hệ thống cơ sở vật chất, thực hiện nhiệm vụ giáo dục cần thiết, mà đó là một di sản vật thể - phi vật thể sống động, kể câu chuyện về lịch sử mái trường thân yêu của các thế hệ thầy và trò nhà trường.</p><p>Ngược dòng lịch sử, Phòng Truyền thống nhà trường được gom góp các tư liệu ngay từ những năm đầu thành lập và chính thức hình thành từ năm 2004 theo yêu cầu của Trường Chuẩn Quốc Gia, tới nay đã hai lần được chỉnh sửa, đổi thay, nâng cấp cùng với đà phát triển của trường."
                },
                new CaiDatTongThe
                {
                    TieuDe = "Sự kiện nổi bật",
                    TrangId = (long)DanhSachTrangTinh.GocTruyenThong,
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "Trường tiểu học Nguyễn Siêu từ góc nhìn của Chủ tịch Hội đồng trường",
                            MoTa = "QUYẾT TẬP TRUNG TRÍ TUỆ VÀ SỨC LỰC XÂY DỰNG TRƯỜNG NGUYỄN SIÊU TRỞ THÀNH NGÔI TRƯỜNG HẠNH PHÚC - PHÁT TRIỂN VỮNG BỀN",
                            Link = "/tin-tuc/11",
                            LinkAnh = "/imgs/TrangChu/24C254D3-E2DA-459B-B4D2-914469A06752.JPG",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "NGUYỄN SIÊU THỰC SỰ LÀ “NHÀ”",
                            MoTa = "Tất cả mọi thứ đều tạo nên trong tôi một môi trường mơ ước, một ngôi nhà chung của biết bao ước mơ đẹp, một mảnh kí ức trọn vẹn và một màu tươi sáng của tương lai",
                            Link = "/tin-tuc/15",
                            LinkAnh = "/imgs/TrangChu/AA43AEA5-3504-4C89-AF2B-D859BD6B570D.JPG",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "“ẤM TÌNH NGUYỄN SIÊU” QUA KÝ ỨC ",
                            MoTa = "Tâm sự của nhà giáo Dương Thị Thịnh - người sáng lập trường Nguyễn Siêu",
                            Link = "/tin-tuc/16",
                            LinkAnh = "/imgs/TrangChu/F79D24E3-8B0E-40D7-8382-C32E35FE22BB.JPG",
                        },
                    }
                },
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatCoSoVatChat(AppDbContext dbContext, IConfiguration config)
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe {
                    TrangId = (long)DanhSachTrangTinh.CoSoVatChat,
                    TieuDe = "cơ sở vật chất",
                    Mota = "<p>Trường Tiểu học Nguyễn Siêu luôn tự hào là một môi trường học tập chất lượng, nơi chú trọng sự phát triển toàn diện cho các em nhỏ. Nhà trường hiểu rằng cơ sở vật chất đóng vai trò quan trọng trong việc hỗ trợ giáo dục và sự phát triển của học sinh. Vì vậy, chúng tôi đã đẩy mạnh đầu việc xây dựng cơ sở vật chất để mang đến môi trường an toàn, hiện đại và tràn đầy cảm hứng cho các em.&nbsp;</p><p>Nhà trường trang bị các phòng học có đầy đủ bàn ghế giáo viên và học sinh. Phòng có hệ thống đèn chiếu&nbsp;sáng, cửa sổ rộng đảm bảo đủ ánh sáng theo quy chuẩn. Tất cả các phòng được lắp quạt và máy điều hòa nhiệt độ, tủ sách, ngăn đựng đồ riêng của&nbsp;mỗi học sinh, có đệm riêng cho mỗi học sinh nghỉ trưa. Nhà trường đầu tư trang thiết bị&nbsp;dạy học hiện đại như máy chiếu và màn hình; máy tính nối mạng LAN và internet, loa, bảng thông minh, bảng nam châm chống lóa. Các lớp học được tối ưu hóa không gian học tập và tạo điều kiện tốt nhất cho sự phát triển của trí tuệ và tinh thần cho các em học sinh.&nbsp;&nbsp;</p><p>Để đảm bảo sự an toàn và phát triển tốt nhất cho học sinh, trường cũng đã đầu tư mạnh vào các tiện ích và hệ thống an ninh, bao gồm các khu vực sân chơi, hệ thống camera giám sát, hệ thống chữa cháy, và các biện pháp an toàn khác.&nbsp;</p><p>Chúng tôi cam kết duy trì và nâng cao chất lượng cơ sở vật chất, tạo điều kiện thuận lợi nhất cho sự phát triển của các em học sinh, giúp các em học tập và trưởng thành một cách toàn diện.&nbsp;</p>"
                },
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatChuongTrinhHoc()
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.ChuongTrinhHoc,
                    CaiDatChiTiet=  new List<CaiDatChiTiet>{
                        new CaiDatChiTiet
                        {
                            TieuDe= "Chương trình của Bộ Giáo dục và Đào tạo Việt Nam",
                            MoTa= "<p>Theo chuẩn kiến thức kỹ năng kết hợp chương trình bổ trợ, nâng cao môn Toán. Chương trình của Bộ GDĐT gồm Chương trình GDPT 2018 (khối 1,2,3,4) và Chương trình giáo dục phổ thông hiện hành (khối 5).</p><p>&nbsp;</p><p>Chương trình hoạt động trải nghiệm môn học và tích hợp liên môn được xây dựng xuyên suốt từ khối 1 đến khối 5, trải dài từ đầu đến cuối năm học với nội dung phong phú, đa dạng, mang tính học thuật để học sinh tự đúc rút những giá trị sống. Qua đó, học sinh được tăng cường phát triển kỹ năng, phát huy năng lực cá nhân và khả năng sáng tạo trong việc vận dụng các kiến thức đã học vào giải quyết vấn đề thực tế. Các câu lạc bộ sau giờ học cũng là một loại hình hoạt động trải nghiệm tự chọn giúp phát triển toàn diện các năng lực cho học sinh.</p><p>&nbsp;</p><p><strong>Giáo dục STEM</strong> được chú trọng, góp phần hình thành và phát triển các năng lực và phẩm chất cho học sinh, tạo cơ hội để học sinh rèn luyện và phát triển tư duy, kĩ năng cần thiết của một công dân toàn cầu như tư duy phản biện, kĩ năng làm việc nhóm, kĩ năng giải quyết vấn đề và sáng tạo.</p>",
                            LinkAnh= "/imgs/ChuongTrinhHoc/E783766A-DA17-4906-B909-47114A079ADB.jpg",
                            Icon = "<svg width=\"44\" height=\"26\" viewBox=\"0 0 44 26\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">  <path d=\"M6.03499 13.8289C5.23368 14.0009 4.62705 14.7161 4.62705 15.5672C4.62705 15.9611 4.7538 16.3369 4.98922 16.6447L4.24676 21.0451C4.21507 21.2353 4.2694 21.4254 4.39163 21.5702C4.51386 21.7151 4.69493 21.8011 4.88507 21.8011H7.92733C8.11294 21.8011 8.29404 21.7196 8.41627 21.5793C8.5385 21.439 8.59734 21.2489 8.57018 21.0632L7.93639 16.4772C8.09937 16.2056 8.18538 15.8887 8.18538 15.5672C8.18538 14.9244 7.84131 14.3631 7.32974 14.0507V11.6694L11.3363 13.4079V23.354C11.3363 24.5809 12.3322 25.5768 13.5591 25.5768H31.8442C33.0711 25.5768 34.0671 24.5809 34.0671 23.354V12.7967L43.6103 8.65438C43.8548 8.54573 44.0087 8.30121 43.9996 8.03411C43.9906 7.76701 43.814 7.53158 43.5605 7.44556L21.8528 0.0346814C21.708 -0.0151172 21.554 -0.0105812 21.4137 0.0437445C13.9801 2.85963 1.77493 7.34604 0.64314 7.41395C0.339821 7.41848 0.077268 7.6312 0.0138879 7.93C-0.0494921 8.23331 0.108938 8.53668 0.389621 8.65891L6.03045 11.1081V13.8289H6.03499ZM5.65469 20.5019L6.32473 16.5452C6.36095 16.3188 6.27943 16.0879 6.10288 15.9385C5.99422 15.8479 5.93084 15.7121 5.93084 15.5672C5.93084 15.3001 6.14815 15.0829 6.41525 15.0829C6.68235 15.0829 6.89966 15.3001 6.89966 15.5672C6.89966 15.7166 6.83627 15.8208 6.78195 15.8842C6.65972 16.0246 6.60088 16.2147 6.62804 16.4003L7.19393 20.5019H5.65469ZM32.7768 23.3585C32.7768 23.8701 32.3603 24.2865 31.8487 24.2865H13.5636C13.0521 24.2865 12.6355 23.8701 12.6355 23.3585V13.9738L21.7442 17.926C21.8257 17.9622 21.9162 17.9802 22.0022 17.9802C22.0882 17.9802 22.1788 17.9622 22.2603 17.926L32.7723 13.3671V23.3585H32.7768ZM2.6215 8.21515C7.31615 6.75288 18.5842 2.51099 21.6627 1.34751L41.564 8.14276L22.0067 16.6266L9.09081 11.0221L19.9967 9.58236C20.472 9.87662 21.1828 10.0532 22.0067 10.0532C23.5098 10.0532 24.6461 9.45569 24.6461 8.65891C24.6461 7.86666 23.5143 7.26905 22.0067 7.26905C20.712 7.26905 19.6888 7.71266 19.4353 8.34646L6.78195 10.0171L2.6215 8.21515ZM20.0148 8.66334C20.0148 8.36002 20.7889 7.92093 22.0022 7.92093C23.2155 7.92093 23.9896 8.36002 23.9896 8.66334C23.9896 8.96665 23.2155 9.40585 22.0022 9.40585C20.7889 9.40585 20.0148 8.96665 20.0148 8.66334Z\" fill=\"#005BAA\"/>  </svg>  "
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Chương trình Quốc tế Cambridge",
                            MoTa= "<p>Với 03 môn cơ bản: English, Maths, Science, hướng tới kỳ thi Cambridge Primary Checkpoint môn Maths và Science cuối lớp 5. Một số chủ đề của các bộ môn kĩ năng như Cambridge Global Perspectives, Digital Literacy… được tích hợp vào các nội dung giảng dạy nhằm trang bị kĩ năng cần thiết cho người học thế kỉ 21, đồng thời hỗ trợ cho các môn học trong chương trình Cambridge.</p><p>&nbsp;</p><p><strong>Chương trình Tiếng Anh</strong> học thuật tăng cường theo Khung tham chiếu Châu Âu CEFR, chuẩn bị cho các kì thi lấy chứng chỉ tiếng Anh Cambridge như Starters, Movers, Flyers, KET, PET, FCE…</p>",
                            LinkAnh= "/imgs/ChuongTrinhHoc/3EE32B56-30BF-4DB7-B3B3-B5E9510B203B.jpg",
                            Icon = "<svg width=\"44\" height=\"30\" viewBox=\"0 0 44 30\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">  <path d=\"M43.0409 0.0429871L0.601498 10.1542C0.243622 10.24 -0.00928214 10.5646 0.000261223 10.932C0.00980459 11.3042 0.272284 11.6143 0.634932 11.6859L12.6929 14.0145L14.6016 26.0009C14.5777 26.2633 14.6828 26.5211 14.8927 26.6881C15.0836 26.836 15.327 26.8837 15.5512 26.8312C15.6419 26.8121 15.7277 26.7739 15.8089 26.7214C15.8136 26.7167 15.847 26.6977 15.8518 26.6929L23.9494 21.2483L34.3326 28.9975C34.5187 29.1359 34.7572 29.1836 34.9815 29.1312C35.0054 29.1264 35.0245 29.1216 35.0483 29.1121C35.2917 29.0309 35.4777 28.8401 35.5541 28.5968L43.9713 1.02598C43.9713 1.02121 43.9713 1.01642 43.9713 1.01165V1.00688C43.9713 1.0021 43.9761 1.0021 43.9761 0.997324C43.9857 0.954379 43.9952 0.91142 44 0.863703C44 0.858931 44 0.858922 44 0.85415C44 0.835063 44 0.820814 44 0.801727C44 0.787412 44 0.777831 44 0.763516C44 0.753973 44 0.744397 44 0.730082C44 0.720538 44 0.715743 44 0.7062C43.9952 0.672798 43.9857 0.634639 43.9761 0.601237C43.9713 0.586922 43.9713 0.577458 43.9666 0.563143C43.9666 0.558371 43.9666 0.553585 43.9618 0.548814C43.9522 0.515412 43.9332 0.482033 43.9189 0.453403C43.9141 0.44386 43.9141 0.439065 43.9093 0.429522C43.9093 0.429522 43.9093 0.429517 43.9093 0.424745C43.8998 0.400887 43.8807 0.381735 43.8664 0.357876C43.8568 0.348333 43.852 0.334102 43.8425 0.324558C43.8377 0.319787 43.8377 0.315001 43.8329 0.310229C43.8282 0.305458 43.8282 0.300672 43.8235 0.2959C43.7948 0.262499 43.7662 0.22912 43.7328 0.20049C43.728 0.195718 43.728 0.195709 43.7232 0.190937C43.7137 0.181394 43.7042 0.176599 43.6946 0.167056C43.6898 0.162284 43.6898 0.162275 43.6851 0.157503C43.6803 0.152731 43.6707 0.152722 43.6659 0.14795C43.6087 0.105005 43.5466 0.0716219 43.4798 0.0477634C43.4751 0.0477634 43.4751 0.0429871 43.4703 0.0429871C43.4035 0.0191287 43.3367 0.00954803 43.2651 0.00477634C43.2508 0.00477634 43.2365 0 43.2222 0C43.2174 0 43.2079 0 43.1983 0C43.1936 0 43.1936 0 43.1888 0C43.1554 0 43.1172 0.004781 43.0838 0.00955269C43.0695 0.0143244 43.0552 0.014329 43.0361 0.014329C43.0552 0.0429591 43.0504 0.0429871 43.0409 0.0429871C43.0457 0.0429871 43.0457 0.0429871 43.0409 0.0429871ZM16.9064 24.1018L19.1681 17.6839L21.7782 19.6308L22.6228 20.2606L16.9064 24.1018ZM34.1178 3.78403L13.2989 12.5352L4.50954 10.8413L34.1178 3.78403ZM35.0578 5.09147L18.3617 15.7561C18.3426 15.7657 18.3283 15.7848 18.314 15.7943C18.2854 15.8182 18.2568 15.8372 18.2281 15.8611C18.2138 15.8754 18.2042 15.8897 18.1899 15.9041C18.1804 15.9184 18.1661 15.9327 18.1565 15.947C18.1422 15.9661 18.1279 15.9852 18.1136 16.0042C18.0993 16.0281 18.0897 16.052 18.0754 16.0807C18.0659 16.1045 18.0516 16.1236 18.042 16.1522L15.6896 22.8326L14.2581 13.8331L35.0578 5.09147ZM41.8527 2.61487L34.3803 27.0841L20.1606 16.4671L41.8527 2.61487Z\" fill=\"#005BAA\"/>  </svg>  "
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Chương trình giáo dục tích hợp (Khối 1, 2, 3, 4)",
                            TieuDeTiengAnh= "Chương trình giáo dục tích hợp (Khối 1, 2, 3, 4) English",
                            MoTa= " <p>Chương trình tích hợp cho các bộ môn cơ bản: Toán, Khoa học, Tiếng Anh</p><p>Chương trình tích hợp cho các bộ môn kĩ năng:</p><ul><li>Môn Quan điểm toàn cầu: Được tích hợp với môn Tiếng Anh.</li><li>Các môn GDTC, Âm nhạc, Mĩ thuật - Lấy chương trình Việt Nam làm gốc, xây dựng thêm các chủ đề trong chương trình Cambridge.</li><li>Môn Tin học được tích hợp giữa chương trình Cambridge và chương trình giáo dục phổ thông 2018, được giảng dạy bắt đầu từ khối lớp 2.</li></ul>",
                            LinkAnh= "/imgs/ChuongTrinhHoc/A7A4C926-7C07-44E5-8735-3733A52FE5A9.jpg",
                            Icon = "<svg width=\"39\" height=\"40\" viewBox=\"0 0 39 40\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">  <path d=\"M19.1637 23.3361C17.3248 23.3361 15.828 21.8393 15.828 20.0004C15.828 18.1615 17.3248 16.6694 19.1637 16.6694C21.0027 16.6694 22.4995 18.1662 22.4995 20.0004C22.4995 21.8393 21.0027 23.3361 19.1637 23.3361ZM19.1637 18.3325C18.2467 18.3325 17.4959 19.0786 17.4959 20.0004C17.4959 20.9175 18.2419 21.6683 19.1637 21.6683C20.0808 21.6683 20.8316 20.9222 20.8316 20.0004C20.8316 19.0833 20.0856 18.3325 19.1637 18.3325Z\" fill=\"#005BAA\"/>  <path d=\"M19.1637 40C17.1775 40 15.4764 37.857 14.2409 33.7943C13.1147 30.0974 12.497 25.1984 12.497 20C12.497 14.8016 13.1147 9.90259 14.2409 6.20575C15.4764 2.14778 17.1775 0 19.1637 0C20.1235 0 21.0264 0.50367 21.8437 1.50153C21.9957 1.68685 22.0622 1.9292 22.0195 2.17154C21.9767 2.40913 21.8389 2.61818 21.6298 2.74172C21.1262 3.05059 20.8268 3.57803 20.8268 4.16724C20.8268 5.08432 21.5728 5.8351 22.4946 5.8351C22.68 5.8351 22.8605 5.80184 23.0363 5.74482C23.2502 5.66879 23.4878 5.68781 23.6873 5.79235C23.8869 5.89689 24.039 6.07745 24.1055 6.29603C25.2126 9.98337 25.8256 14.8539 25.8256 20.0047C25.8256 25.2031 25.2079 30.1022 24.0817 33.799C22.851 37.857 21.1499 40 19.1637 40ZM19.1637 1.66786C17.0777 1.66786 14.1649 8.64337 14.1649 20C14.1649 31.3566 17.0777 38.3321 19.1637 38.3321C21.2497 38.3321 24.1625 31.3566 24.1625 20C24.1625 15.3385 23.6541 10.9337 22.718 7.49345C22.642 7.4982 22.5707 7.50296 22.4946 7.50296C20.6557 7.50296 19.1589 6.00616 19.1589 4.172C19.1589 3.3547 19.4488 2.58494 19.9667 1.99097C19.7291 1.8009 19.4488 1.66786 19.1637 1.66786Z\" fill=\"#005BAA\"/>  <path d=\"M22.4993 7.50274C20.6604 7.50274 19.1636 6.00595 19.1636 4.17178C19.1636 2.99811 19.7623 1.93373 20.7649 1.32551C21.2876 1.00714 21.8864 0.84082 22.4993 0.84082C24.3382 0.84082 25.8303 2.33762 25.8303 4.17654C25.8303 5.5973 24.9275 6.86126 23.5827 7.32693C23.2358 7.44097 22.87 7.50274 22.4993 7.50274ZM22.4993 2.4992C22.1905 2.4992 21.8911 2.5847 21.6345 2.74151C21.1308 3.05037 20.8315 3.57781 20.8315 4.16703C20.8315 5.08411 21.5775 5.83489 22.4993 5.83489C22.6846 5.83489 22.8652 5.80162 23.041 5.7446C23.711 5.51177 24.1624 4.87979 24.1624 4.17178C24.1624 3.24995 23.4164 2.4992 22.4993 2.4992Z\" fill=\"#005BAA\"/>  <path d=\"M32.3212 32.5776C28.3725 32.5776 21.9054 29.8786 15.443 25.5356C11.1285 22.6323 7.40788 19.3868 4.97024 16.3885C2.29027 13.1003 1.45872 10.4916 2.57062 8.84276C3.2026 7.90192 4.35727 7.42676 6.01087 7.42676C9.95955 7.42676 16.4266 10.1257 22.889 14.4735C29.722 19.0685 34.8538 24.3904 35.9942 28.054C36.0275 28.1443 36.0465 28.244 36.0465 28.3486C36.0465 28.8095 35.6759 29.1801 35.215 29.1801C35.1912 29.1801 35.1674 29.1801 35.1437 29.1754C35.0914 29.1706 35.0439 29.1706 35.0011 29.1706C34.084 29.1706 33.3333 29.9166 33.3333 30.8385C33.3333 31.0428 33.3713 31.2471 33.4473 31.4372C33.5423 31.689 33.5138 31.9694 33.3665 32.1927C33.2192 32.4161 32.9769 32.5586 32.7108 32.5681C32.5825 32.5729 32.4495 32.5776 32.3212 32.5776ZM6.00612 9.08986C5.2791 9.08986 4.32876 9.20865 3.94862 9.76935C2.78445 11.5037 6.94696 17.8093 16.3696 24.1481C22.1192 28.016 28.0018 30.5914 31.6607 30.8813C31.6607 30.867 31.6607 30.848 31.6607 30.8337C31.6607 29.3275 32.6633 28.054 34.0365 27.6406C32.4922 24.3856 27.8213 19.8002 21.9481 15.8516C15.8469 11.7461 9.58892 9.08986 6.00612 9.08986Z\" fill=\"#005BAA\"/>  <path d=\"M34.9965 34.1646C33.628 34.1646 32.3783 33.3093 31.8889 32.0311C31.7416 31.6462 31.6656 31.2423 31.6656 30.8289C31.6656 28.99 33.1623 27.4932 35.0013 27.4932C35.0915 27.4932 35.1818 27.4979 35.2816 27.5074C36.9922 27.65 38.3322 29.1088 38.3322 30.8289C38.3322 32.6726 36.8354 34.1646 34.9965 34.1646ZM34.9965 29.1658C34.0794 29.1658 33.3287 29.9118 33.3287 30.8336C33.3287 31.038 33.3667 31.2423 33.4427 31.4323C33.6898 32.0691 34.3123 32.4967 34.9965 32.4967C35.9136 32.4967 36.6644 31.7507 36.6644 30.8289C36.6644 29.9688 35.9944 29.2418 35.1391 29.1705C35.0868 29.1705 35.0393 29.1658 34.9965 29.1658Z\" fill=\"#005BAA\"/>  <path d=\"M6.01098 32.5776C5.87794 32.5776 5.74964 32.5729 5.62134 32.5681C5.35525 32.5539 5.10815 32.4161 4.96085 32.1927C4.81355 31.9694 4.78504 31.689 4.88482 31.4372C4.96085 31.2424 4.99886 31.0428 4.99886 30.8385C4.99886 29.9214 4.25284 29.1706 3.33101 29.1706C3.28824 29.1706 3.24073 29.1706 3.18846 29.1754C2.91286 29.1991 2.64676 29.0851 2.47095 28.8713C2.29513 28.6575 2.24287 28.3723 2.31889 28.1062C3.42129 24.4427 8.57216 19.0922 15.4432 14.4735C21.9055 10.1257 28.3726 7.42676 32.3213 7.42676C33.9701 7.42676 35.1295 7.90192 35.7615 8.84276C36.8687 10.4916 36.0371 13.1003 33.3619 16.3885C30.9243 19.3868 27.2037 22.6323 22.8891 25.5356C16.4268 29.8786 9.95967 32.5776 6.01098 32.5776ZM4.28611 27.6406C5.65935 28.054 6.66197 29.3275 6.66197 30.8337C6.66197 30.848 6.66197 30.867 6.66197 30.8813C10.3208 30.5914 16.2034 28.016 21.953 24.1481C26.1345 21.3351 29.7268 18.2036 32.0647 15.3336C34.5071 12.3305 34.8587 10.4916 34.374 9.76935C33.9986 9.20865 33.0483 9.08986 32.3165 9.08986C28.7385 9.08986 22.4757 11.7461 16.3697 15.8516C10.5014 19.8002 5.83042 24.3856 4.28611 27.6406Z\" fill=\"#005BAA\"/>  <path d=\"M3.33096 34.1652C1.49204 34.1652 0 32.6684 0 30.8343C0 29.1141 1.33999 27.6553 3.05061 27.5128C3.15039 27.5033 3.24542 27.4985 3.33096 27.4985C5.16987 27.4985 6.66667 28.9953 6.66667 30.8343C6.66667 31.2477 6.59064 31.6515 6.44334 32.0364C5.94916 33.3099 4.69945 34.1652 3.33096 34.1652ZM3.33096 29.1664C3.28819 29.1664 3.24067 29.1664 3.18841 29.1712C2.3331 29.2424 1.6631 29.9742 1.6631 30.8295C1.6631 31.7466 2.40912 32.4974 3.33096 32.4974C4.0152 32.4974 4.63768 32.0697 4.88477 31.4329C4.9608 31.2381 4.99881 31.0386 4.99881 30.8343C4.99881 29.9172 4.25279 29.1664 3.33096 29.1664Z\" fill=\"#005BAA\"/>  </svg>  ",
                        }
                    },
                    TieuDe= "Chương trình học",
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.ChuongTrinhHoc,
                    TieuDe= "Câu lạc bộ năng khiếu",
                    CaiDatChiTiet= new List<CaiDatChiTiet>{
                        new CaiDatChiTiet
                        {
                            TieuDe= "Bóng rổ",
                            TieuDeTiengAnh= "Basketball",
                            MoTa= "Bóng rổ là bộ môn thể thao giúp trẻ phát triển toàn diện. Tham gia câu lạc bộ bóng rổ, trẻ sẽ phát triển kỹ năng cơ bản như ném, bắt bóng và chạy, tạo nền tảng vững chắc cho sự phát triển thể chất. Đồng thời, đây sẽ là cơ hội cho trẻ rèn luyện tính kiên nhẫn, sự tập trung và kỷ luật. Ngoài ra, môn bóng rổ giúp trẻ học cách làm việc nhóm, tạo ra môi trường gắn kết và phát triển kỹ năng giao tiếp. Tất cả những lợi ích này không chỉ giúp trẻ phát triển thể chất mà còn tạo ra những nền tảng quý báu cho sự phát triển toàn diện trong tương lai.",
                            Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"40\" height=\"40\" viewBox=\"0 0 40 40\" fill=\"none\">\r\n  <g clip-path=\"url(#clip0_276_2299)\">\r\n    <path d=\"M6.76562 5L13.4219 11.6562C15.1953 9.50781 16.25 6.75 16.25 3.75C16.25 2.60156 16.0938 1.49219 15.8047 0.4375C12.3906 1.17187 9.29688 2.77344 6.76562 5ZM5 6.76562C2.77344 9.29688 1.17187 12.3906 0.4375 15.8047C1.49219 16.0938 2.60156 16.25 3.75 16.25C6.75 16.25 9.50781 15.1953 11.6641 13.4297L5 6.76562ZM20 0C19.4297 0 18.8594 0.0234375 18.2969 0.0703125C18.5937 1.25 18.75 2.48437 18.75 3.75C18.75 7.44531 17.4141 10.8203 15.2031 13.4375L20 18.2344L33.2344 5C29.7031 1.89063 25.0703 0 20 0ZM3.75 18.75C2.48437 18.75 1.25 18.5937 0.0703125 18.2969C0.0234375 18.8594 0 19.4297 0 20C0 25.0703 1.89063 29.7031 5 33.2344L18.2344 20L13.4375 15.2031C10.8203 17.4141 7.44531 18.75 3.75 18.75ZM39.9297 21.7031C39.9766 21.1406 40 20.5703 40 20C40 14.9297 38.1094 10.2969 35 6.76562L21.7656 20L26.5625 24.7969C29.1719 22.5859 32.5547 21.25 36.25 21.25C37.5156 21.25 38.75 21.4062 39.9297 21.7031ZM39.5625 24.1953C38.5078 23.9063 37.3984 23.75 36.25 23.75C33.25 23.75 30.4922 24.8047 28.3359 26.5703L35 33.2344C37.2266 30.7109 38.8359 27.6172 39.5625 24.1953ZM26.5703 28.3359C24.8047 30.4922 23.75 33.25 23.75 36.25C23.75 37.3984 23.9063 38.5078 24.1953 39.5625C27.6094 38.8281 30.7031 37.2266 33.2344 35L26.5781 28.3437L26.5703 28.3359ZM24.7969 26.5625L20 21.7656L6.76562 35C10.2891 38.1094 14.9219 40 20 40C20.5703 40 21.1406 39.9766 21.7031 39.9297C21.4062 38.75 21.25 37.5156 21.25 36.25C21.25 32.5547 22.5859 29.1797 24.7969 26.5625Z\" fill=\"#005BAA\"/>\r\n  </g>\r\n  <defs>\r\n    <clipPath id=\"clip0_276_2299\">\r\n      <rect width=\"40\" height=\"40\" fill=\"white\"/>\r\n    </clipPath>\r\n  </defs>\r\n</svg>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Cờ vua",
                            TieuDeTiengAnh= "Chess",
                            MoTa= "Cờ vua là môn thể thao trí tuệ giúp học sinh kích thích sự linh hoạt trong tư duy, phát triển khả năng tính toán và logic. Bên cạnh đó, bộ môn cờ vua còn giúp trẻ rèn luyện tính độc lập trong xử lý tình huống và phát triển bản lĩnh đương đầu với khó khăn.",
                            Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" height=\"1em\" viewBox=\"0 0 512 512\"><!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d=\"M144 16c0-8.8-7.2-16-16-16s-16 7.2-16 16V32H96c-8.8 0-16 7.2-16 16s7.2 16 16 16h16V96H60.2C49.1 96 40 105.1 40 116.2c0 2.5 .5 4.9 1.3 7.3L73.8 208H72c-13.3 0-24 10.7-24 24s10.7 24 24 24h4L60 384H196L180 256h4c13.3 0 24-10.7 24-24s-10.7-24-24-24h-1.8l32.5-84.5c.9-2.3 1.3-4.8 1.3-7.3c0-11.2-9.1-20.2-20.2-20.2H144V64h16c8.8 0 16-7.2 16-16s-7.2-16-16-16H144V16zM48 416L4.8 473.6C1.7 477.8 0 482.8 0 488c0 13.3 10.7 24 24 24H232c13.3 0 24-10.7 24-24c0-5.2-1.7-10.2-4.8-14.4L208 416H48zm288 0l-43.2 57.6c-3.1 4.2-4.8 9.2-4.8 14.4c0 13.3 10.7 24 24 24H488c13.3 0 24-10.7 24-24c0-5.2-1.7-10.2-4.8-14.4L464 416H336zM304 208v51.9c0 7.8 2.8 15.3 8 21.1L339.2 312 337 384H462.5l-3.3-72 28.3-30.8c5.4-5.9 8.5-13.6 8.5-21.7V208c0-8.8-7.2-16-16-16H464c-8.8 0-16 7.2-16 16v16H424V208c0-8.8-7.2-16-16-16H392c-8.8 0-16 7.2-16 16v16H352V208c0-8.8-7.2-16-16-16H320c-8.8 0-16 7.2-16 16zm80 96c0-8.8 7.2-16 16-16s16 7.2 16 16v32H384V304z\"/></svg>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Võ thuật",
                            TieuDeTiengAnh= "Kungfu",
                            MoTa= "Võ thuật là bộ môn đem lại nhiều lợi ích cho các con học sinh. Không chỉ giúp các con tăng cường sức khỏe, dẻo dai hơn và tránh các bệnh vặt, võ thuật còn giúp phát triển khả năng tập trung và sự kiên nhẫn.",
                            Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"40\" viewBox=\"0 0 24 40\" fill=\"none\">\r\n  <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M17.9578 29.0883L21.8526 24.6022C22.2382 24.1523 22.3795 23.3554 22.1353 22.7641L19.6289 17.1727C19.3846 16.6457 18.7933 16.1316 18.202 15.9516L17.1609 15.6431H17.1223L13.6518 14.602L14.0631 13.2137C14.8986 14.2549 16.184 14.9104 17.6108 14.9104H17.6493C18.8704 14.9104 20.0144 14.422 20.8499 13.5608C21.724 12.7253 22.1739 11.5813 22.1739 10.3602C22.1353 7.89227 20.1301 5.87422 17.5851 5.87422C17.1352 5.87422 16.711 5.93843 16.3383 6.05412L17.6237 1.91521C17.7265 1.60672 17.6879 1.25965 17.5593 0.938307C17.3794 0.655522 17.148 0.41127 16.7881 0.347001L15.9269 0.0642536C15.7855 0.025692 15.6827 0 15.5413 0C14.9886 0 14.5002 0.385594 14.3202 0.861187L10.0141 14.6148C10.0141 14.6534 9.9756 14.7177 9.9756 14.7819L5.77236 29.371H1.50487C1.22208 29.4353 0.977904 29.5767 0.746535 29.8209C0.39948 30.1679 0.219482 30.6179 0.219482 31.1449C0.219482 31.7362 0.386627 32.2246 0.746535 32.5716L7.17346 39.1399C7.41769 39.5513 7.76474 39.8341 8.29174 39.937C8.78019 40.0783 9.23006 39.9755 9.64138 39.6927C10.1298 39.4485 10.4383 39.0628 10.5797 38.5101C10.7211 37.9831 10.644 37.5075 10.3741 37.0191L6.72353 33.2658H6.78786H17.2123L13.5618 37.0191C13.3176 37.5075 13.2533 37.996 13.3947 38.5101C13.4975 39.0628 13.8061 39.487 14.256 39.757C14.7444 40.0012 15.2328 40.0655 15.6827 39.9241C16.1712 39.8213 16.5568 39.5385 16.8652 39.1272L23.1508 32.5588C23.575 32.2117 23.7806 31.7619 23.7806 31.2349C23.7806 30.6821 23.6135 30.2322 23.1893 29.8466C22.9451 29.6024 22.7009 29.4353 22.431 29.3582H17.5979C17.7136 29.2939 17.855 29.1911 17.9578 29.0883ZM18.6905 23.8696L16.3639 26.3375L17.8935 20.7075L18.8319 22.9312C18.9605 23.214 18.8576 23.664 18.6905 23.8696Z\" fill=\"#005BAA\"/>\r\n</svg>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Nhảy hiện đại",
                            TieuDeTiengAnh= "Dance",
                            MoTa= "Bộ môn nhảy hiện đại là sân chơi bổ ích cho các học sinh tiểu học tại trường chúng ta. Các em sẽ phát triển sự linh hoạt, tăng cường sức khỏe và sự phối hợp giữa thể chất và tinh thần. Bên cạnh việc rèn luyện kỹ năng nhảy, bộ môn này còn giúp trẻ phát triển sự tự tin, khả năng tập trung và kiên nhẫn. Việc học nhảy hiện đại không chỉ mang lại niềm vui thích, mà còn giúp trẻ rèn luyện sự cởi mở trong giao tiếp và tạo ra một môi trường thú vị để thể hiện bản thân.",
                            Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"50\" viewBox=\"0 0 32 50\" fill=\"none\">\r\n  <path d=\"M31.5974 21.9477C31.5912 22.0345 31.5881 22.1213 31.5825 22.2055C31.5708 22.3766 31.5584 22.547 31.5435 22.7181C31.5404 22.7423 31.5317 22.997 31.5193 22.997C31.4326 23.0118 31.3427 23.0149 31.2559 23.0032C31.2559 23.0063 31.2559 23.0063 31.2528 23.0094C30.4019 23.1203 29.5566 23.2759 28.7596 23.5845C28.7689 23.5727 28.7807 23.5634 28.7924 23.5547C28.4386 23.6508 28.0735 23.7016 27.7079 23.7493L24.9029 24.1361C23.141 24.379 21.5079 25.0322 19.7609 25.3799C18.8436 25.5627 17.9146 25.7152 17.0309 26.0151C16.5723 26.1707 16.126 26.3659 15.6581 26.4886C15.2838 26.5878 14.8642 26.6597 14.63 26.9683C14.537 27.0879 14.4831 27.2379 14.4025 27.3668C14.1658 27.7442 13.6836 28.0021 13.6681 28.4458C13.6532 28.8145 13.3446 29.1318 13.0477 29.3475C12.886 29.4646 12.7001 29.5452 12.5321 29.6562C12.3673 29.7671 12.2117 29.914 12.1516 30.1055C12.0946 30.2945 12.1398 30.4953 12.1454 30.693C12.1541 30.993 12.0704 31.2954 11.9117 31.5532C11.6899 31.9071 11.3335 32.1587 10.9617 32.3502C10.7156 32.476 10.4615 32.5807 10.2273 32.7276C9.99363 32.8776 9.78106 33.0722 9.67261 33.3238C9.96637 33.9801 9.83436 34.7951 9.63047 35.4812C9.56477 35.7117 9.48667 35.9398 9.44763 36.1765C9.38752 36.5843 9.45074 36.9977 9.47739 37.4111C9.50714 37.9087 9.48048 38.4088 9.45321 38.9096C9.41107 38.8768 9.42347 38.8706 9.3993 38.8228C9.43835 39.7097 9.04852 40.5581 8.63515 41.3458C8.22488 42.1341 7.77494 42.9367 7.68507 43.8211C7.65223 44.1266 7.67331 44.4625 7.86481 44.708C7.99991 44.8815 8.21558 44.9986 8.30544 45.2025C8.38043 45.3705 8.35069 45.5713 8.2633 45.733C8.21248 45.8347 8.14059 45.9245 8.0594 46.0057C8.02656 46.0417 7.98751 46.0838 7.94847 46.1135C7.91872 46.1377 7.87348 46.1464 7.84373 46.1737C7.69065 46.3292 7.53509 46.4885 7.42106 46.6738C7.31322 46.8535 7.24443 47.0481 7.19052 47.2489C7.20539 47.9201 7.18742 48.5975 7.1335 49.2687C7.12173 49.4063 7.10934 49.5476 7.04364 49.6703C6.98353 49.7812 6.88807 49.868 6.78272 49.9368C6.69595 49.9969 6.64762 50.0149 6.61787 49.9876C6.58502 49.9665 6.56705 49.9157 6.53978 49.8376C6.51561 49.7719 6.49207 49.7056 6.471 49.6368C6.44993 49.5711 6.43194 49.5017 6.41087 49.4329C6.40467 49.4118 6.39911 49.3908 6.39291 49.3697C6.2702 48.947 6.14996 48.525 6.02725 48.1048C5.83822 47.4516 5.64672 46.7953 5.5897 46.1148C5.53269 45.4374 5.61946 44.7303 5.95536 44.1397C6.10844 43.867 6.21318 43.6091 6.30924 43.3123C6.38732 43.0669 6.43194 42.8121 6.47408 42.5543C6.68356 41.2355 6.77653 39.8993 6.74988 38.5625C6.72881 37.496 6.56085 36.435 6.47408 35.3708C6.46789 35.2928 6.44992 35.1998 6.37493 35.1762C6.33279 35.1614 6.28507 35.1762 6.23983 35.1911C6.1258 35.2302 5.99998 35.2661 5.88594 35.2209C5.73039 35.1576 5.64301 34.9544 5.47568 34.9333C5.37094 34.9184 5.26867 34.9903 5.20298 35.074C5.13729 35.1576 5.09515 35.2599 5.03503 35.3498C4.8584 35.6045 4.5225 35.7303 4.21387 35.6882C3.90523 35.646 3.62944 35.4514 3.45281 35.1967C3.3927 35.113 3.30594 35.0108 3.21298 35.0529C3.18571 35.0647 3.16526 35.092 3.14728 35.1186C3.05122 35.2506 2.9973 35.4186 2.86281 35.5109C2.66821 35.6485 2.39863 35.5586 2.18543 35.4477C2.01438 35.3578 1.83156 35.2587 1.676 35.1453C1.52045 35.0281 1.40332 34.9178 1.21429 34.8453C1.03767 34.7796 0.851735 34.7282 0.695558 34.6203C0.542481 34.5094 0.429074 34.3204 0.470597 34.1382C0.491669 34.0483 0.545586 33.9733 0.593306 33.8952C0.686268 33.7366 0.75506 33.5655 0.794104 33.3889C0.815175 33.2928 0.823855 33.1881 0.766838 33.11C0.719118 33.0468 0.63483 33.0232 0.562939 32.9929C0.48795 32.9631 0.409867 32.9117 0.398092 32.8342C0.391894 32.7834 0.409854 32.7351 0.430925 32.6935C0.502816 32.5349 0.584007 32.3787 0.667673 32.2262C0.964532 31.6747 1.26078 31.1237 1.55764 30.5721C1.79128 30.1408 1.78507 29.6221 1.87246 29.1399C2.12098 27.7827 2.96012 26.602 3.93436 25.6247C3.9703 25.5888 4.00935 25.5497 4.02732 25.502C4.07814 25.3669 3.96722 25.2293 3.86868 25.1215C3.57492 24.7887 3.35305 24.3902 3.23344 23.9619C3.04751 23.3056 2.62794 22.7125 2.45441 22.0531C2.40669 21.8616 2.36454 21.6726 2.3255 21.4804C2.20589 20.8632 2.1216 20.2397 2.13957 19.6138C2.15445 19.0895 2.24432 18.5707 2.42404 18.0762C2.49593 17.8847 2.517 17.7198 2.63661 17.5426C2.79217 17.3089 2.95145 17.0722 3.11011 16.8385C3.14915 16.7784 3.18199 16.6855 3.12188 16.6495C3.08903 16.6284 3.04689 16.6402 3.01094 16.6433C2.84609 16.6675 2.67504 16.5621 2.62112 16.4066C2.55233 16.1996 2.68681 15.9752 2.84856 15.8253C3.01031 15.6753 3.20802 15.5557 3.31895 15.3635C3.41192 15.2049 3.44166 15.001 3.57987 14.8814C3.64866 14.8213 3.73295 14.7884 3.80484 14.7345C3.95792 14.6149 4.03228 14.4048 4.20334 14.3149C4.35641 14.2344 4.55721 14.261 4.6855 14.147C4.82308 14.0243 4.79953 13.8024 4.76359 13.6196C4.70347 13.3109 4.64397 12.9992 4.58385 12.6875C4.39793 11.7318 4.57519 10.6975 4.4878 9.72693C4.44566 9.24725 4.37996 8.76508 4.44565 8.2916C4.49647 7.93772 4.61918 7.59314 4.63158 7.23989C4.66442 6.2328 4.96748 5.25298 5.20422 4.27316C5.24636 4.09343 5.29099 3.9137 5.29718 3.73088C5.30028 3.64411 5.29408 3.55735 5.26434 3.47616C5.19554 3.29953 5.02141 3.18859 4.85965 3.09253C4.51817 2.88864 4.17917 2.67916 3.87983 2.41825C3.80174 2.34946 3.71807 2.23543 3.77818 2.15176C3.81413 2.09784 3.88912 2.08606 3.94923 2.10094C4.01245 2.11581 4.06637 2.15176 4.12277 2.17593C4.19156 2.20878 4.26345 2.22675 4.33844 2.23294C4.36818 2.23604 4.40166 2.23295 4.42211 2.21188C4.43698 2.1939 4.43698 2.16725 4.43698 2.14308C4.43388 2.01728 4.43077 1.88837 4.42768 1.76256C4.42768 1.68137 4.42149 1.59461 4.36448 1.53759C4.29258 1.4688 4.16677 1.47747 4.09798 1.40558C3.96288 1.268 3.78004 1.21099 3.60651 1.1298C3.52284 1.09075 3.43547 1.04923 3.36978 0.982919C3.30408 0.914127 3.26194 0.818067 3.28859 0.728203C3.29169 0.718907 3.29478 0.713324 3.29726 0.707126C3.31213 0.695351 3.33631 0.704026 3.35428 0.713322C3.49187 0.785213 3.64494 0.839137 3.8005 0.866406C3.77633 0.791416 3.75525 0.719521 3.7317 0.644531C3.9325 0.662504 4.12711 0.722621 4.30126 0.82426C4.19652 0.584417 4.09427 0.347678 3.99263 0.107835L4.07939 0.114031C4.02857 0.0898613 4.06761 0.00309874 4.12152 0C4.17854 0 4.22316 0.0446158 4.25911 0.0867586C4.41218 0.266485 4.56774 0.452408 4.64583 0.674278C4.68487 0.788312 4.70285 0.904828 4.73879 1.01886C4.77474 1.1298 4.83486 1.24073 4.9365 1.30642C5.05611 1.38451 5.21539 1.38141 5.3412 1.4502C5.50605 1.54626 5.57484 1.74397 5.64673 1.9206C5.71242 2.08545 5.7936 2.2441 5.88967 2.39718C5.97333 2.53228 6.0663 2.66057 6.12641 2.80745C6.29746 3.25119 6.10843 3.74575 6.15058 4.21862C6.23176 5.14452 6.15057 6.07972 6.1326 7.01182C6.12083 7.56029 6.10844 8.11187 6.04894 8.65973C5.95288 9.54969 5.73102 10.4545 5.92624 11.3296C5.94111 11.4046 5.97395 11.4554 6.00989 11.5217C6.03406 11.3835 6.05762 11.2428 6.08179 11.1053C6.09109 11.0662 6.09667 11.0241 6.12703 10.9943C6.1543 10.967 6.20821 10.9615 6.22867 10.9943C6.19892 10.8443 6.16855 10.6919 6.13881 10.5388C6.13013 10.4911 6.12084 10.4372 6.14501 10.395C6.17786 10.3442 6.24664 10.3318 6.30675 10.3262C6.42946 10.3145 6.55527 10.3021 6.6786 10.2903C6.81619 10.2785 6.96307 10.2636 7.07091 10.1763C7.1366 10.1285 7.18183 10.0591 7.23265 9.99652C7.37024 9.83167 7.55618 9.71454 7.7421 9.6098C8.00859 9.45672 8.31474 9.31604 8.60788 9.39722C8.80868 9.45114 8.94379 9.25035 9.15016 9.2175C9.32679 9.18776 9.50651 9.2268 9.68376 9.26274C10.2025 9.37368 10.7417 9.49639 11.155 9.82919C11.2808 9.93393 11.3949 10.0597 11.4606 10.2097C11.5294 10.3597 11.5418 10.5363 11.4755 10.6863C11.8021 10.8598 11.97 11.2528 11.9427 11.6184C11.9155 11.9872 11.7153 12.3224 11.4544 12.5833C11.3552 12.6825 11.2387 12.7779 11.098 12.7903C10.9573 12.8052 10.8012 12.7067 10.8012 12.5654C10.6933 12.9552 10.5316 13.3295 10.2707 13.6351C10.0128 13.9437 9.65029 14.1742 9.24869 14.2226C9.00017 14.2523 8.74547 14.2133 8.49943 14.2585C8.39469 14.2796 8.28995 14.3186 8.21186 14.3936C7.98689 14.6124 8.01416 15.182 8.2571 15.3766C8.49384 15.5656 8.88366 15.3827 9.12599 15.5656C9.16193 15.5922 9.19478 15.6288 9.23692 15.6406C9.26109 15.6492 9.28774 15.6468 9.31501 15.6523C9.39868 15.6641 9.46189 15.7273 9.53068 15.7781C9.61435 15.8383 9.71351 15.8829 9.79718 15.9461C9.88084 16.0118 9.95583 16.1017 9.96202 16.207C10.0847 16.282 10.1957 16.3898 10.3215 16.4648C10.4175 16.5249 10.5161 16.5844 10.6214 16.6297C10.8972 16.7524 11.2059 16.7852 11.5052 16.7617C11.7122 16.7468 11.9155 16.7078 12.1194 16.6625C12.2842 16.6235 12.4193 16.5454 12.5836 16.4946C12.925 16.3836 13.2969 16.4078 13.6501 16.4469C14.2463 16.5101 14.8401 16.6148 15.4394 16.6836C15.7393 16.7195 16.0417 16.7437 16.3442 16.7524C16.5958 16.7586 16.8865 16.7078 17.1232 16.8032C17.2521 16.854 17.3717 16.929 17.4975 16.986C17.6952 17.0728 17.914 17.1087 18.1266 17.154C18.6509 17.2649 19.1603 17.4508 19.6369 17.6994C19.7627 17.7651 19.8854 17.8369 20.0174 17.8884C20.0806 17.915 20.1612 17.9603 20.1432 18.026C20.1253 18.0948 20.0236 18.0892 19.9542 18.0681C20.1277 18.14 20.2957 18.2268 20.4544 18.329C20.4395 18.3352 20.4271 18.3383 20.4153 18.3439C20.4513 18.3321 20.4934 18.3619 20.499 18.3978C20.5083 18.44 20.4748 18.4846 20.4333 18.4964C20.3942 18.5112 20.3465 18.5026 20.3075 18.4815C20.3347 18.4995 20.2895 18.5323 20.2567 18.5292C19.9183 18.4871 19.6425 18.2323 19.3097 18.1574C19.1417 18.1183 18.9682 18.1276 18.7971 18.1363C18.3925 18.1605 17.9822 18.1815 17.5955 18.298C17.826 18.409 18.0417 18.4988 18.2728 18.6098C18.4916 18.7145 18.7315 18.8372 18.8151 19.0653C18.8542 19.1762 18.8542 19.2989 18.8511 19.4161C18.7941 19.4371 18.716 19.3801 18.6775 19.338C18.6354 19.2958 18.6087 19.2419 18.5635 19.2029C18.4823 19.1341 18.3658 19.1279 18.2611 19.1068C17.9555 19.0436 17.7064 18.8254 17.4758 18.6123C17.2868 18.4387 17.0984 18.2677 16.9094 18.0935C16.8282 18.0216 16.7476 17.9466 16.6485 17.9045C16.5078 17.8506 16.3516 17.8655 16.2047 17.8983C15.8633 17.9795 15.5243 18.1499 15.1766 18.1022C14.8351 18.135 14.4756 18.1921 14.1335 18.228C13.885 18.2522 13.639 18.2788 13.3967 18.3358C13.1959 18.3867 12.9982 18.4555 12.7912 18.4889C12.3716 18.5521 11.9458 18.4468 11.5238 18.4709C11.0416 18.4982 10.5768 18.6928 10.0947 18.6866C9.91493 18.6866 9.729 18.6569 9.55795 18.7139C9.39309 18.7678 9.26419 18.8905 9.14148 19.0108C8.90164 19.2413 8.65622 19.4873 8.55706 19.8046C8.52731 19.8976 8.54528 20.0445 8.64692 20.0445C8.67419 20.0445 8.70084 20.0327 8.72501 20.0203C8.91093 19.9274 9.09686 19.8375 9.27968 19.7445C10.011 19.8226 10.7212 19.7117 11.4525 19.7867C11.6893 19.8108 11.926 19.8555 12.1658 19.8617C12.5315 19.871 12.891 19.7929 13.2535 19.7569C14.0115 19.6788 14.7911 19.7836 15.5038 20.0594C15.6055 20.0984 15.7108 20.1461 15.7703 20.2329C15.8124 20.2961 15.8304 20.368 15.8719 20.4275C16.0368 20.6673 16.4235 20.5384 16.69 20.6549C16.8127 20.7089 16.9088 20.8198 17.0408 20.8526C17.1127 20.8706 17.1877 20.8675 17.2596 20.8855C17.4331 20.9332 17.5353 21.1105 17.5979 21.2778C17.7386 21.6614 17.7597 22.0897 17.6581 22.4857C17.6339 22.5873 17.601 22.6927 17.6339 22.7912C17.7027 22.9771 17.9574 22.9982 18.1551 22.9771C18.416 22.9499 18.6763 22.8904 18.9372 22.8693C19.156 22.8513 19.3146 22.7646 19.5247 22.6896C20.0162 22.5098 20.5436 22.4646 21.0617 22.4231C21.511 22.3902 21.961 22.3599 22.4103 22.3512C23.9175 22.327 25.4731 22.5941 26.971 22.345C27.1148 22.3208 27.2648 22.2223 27.4023 22.1684C27.561 22.1082 27.7258 22.0543 27.8907 22.0215C28.0438 21.9917 28.1962 21.9769 28.3431 21.9378C28.5142 21.8926 28.6728 21.8151 28.8377 21.755C29.4463 21.53 30.1113 21.5331 30.7558 21.587C31.0496 21.6112 31.352 21.6503 31.5949 21.8145C31.5918 21.8176 31.5887 21.8207 31.5887 21.8238C31.6123 21.8579 31.6005 21.9093 31.5974 21.9477Z\" fill=\"#005BAA\"/>\r\n</svg>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Mỹ thuật",
                            TieuDeTiengAnh= "Art",
                            MoTa= "Mĩ thuật là bộ môn truyền cảm hứng vô tận cho học sinh, giúp phát triển óc sáng tạo, khả năng thẩm mỹ, rèn luyện tinh thần kiên nhẫn và sự tỉ mỉ. Bộ môn mĩ thuật còn giúp trẻ phát triển khả năng thể hiện cảm xúc và thấu hiểu sâu hơn về môi trường xung quanh. Đồng thời, việc tham gia vào câu lạc bộ mĩ thuật còn giúp trẻ xây dựng tình bạn và học hỏi kỹ năng giao tiếp thông qua việc chia sẻ ý tưởng và ý kiến với nhau.",
                            Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"40\" height=\"40\" viewBox=\"0 0 40 40\" fill=\"none\">\r\n  <g clip-path=\"url(#clip0_276_2320)\">\r\n    <path d=\"M40 20C40 20.0703 40 20.1406 40 20.2109C39.9688 23.0625 37.375 25 34.5234 25H26.875C24.8047 25 23.125 26.6797 23.125 28.75C23.125 29.0156 23.1562 29.2734 23.2031 29.5234C23.3672 30.3203 23.7109 31.0859 24.0469 31.8594C24.5234 32.9375 24.9922 34.0078 24.9922 35.1406C24.9922 37.625 23.3047 39.8828 20.8203 39.9844C20.5469 39.9922 20.2734 40 19.9922 40C8.95312 40 0 31.0469 0 20C0 8.95312 8.95312 0 20 0C31.0469 0 40 8.95312 40 20ZM10 22.5C10 21.837 9.73661 21.2011 9.26777 20.7322C8.79893 20.2634 8.16304 20 7.5 20C6.83696 20 6.20107 20.2634 5.73223 20.7322C5.26339 21.2011 5 21.837 5 22.5C5 23.163 5.26339 23.7989 5.73223 24.2678C6.20107 24.7366 6.83696 25 7.5 25C8.16304 25 8.79893 24.7366 9.26777 24.2678C9.73661 23.7989 10 23.163 10 22.5ZM10 15C10.663 15 11.2989 14.7366 11.7678 14.2678C12.2366 13.7989 12.5 13.163 12.5 12.5C12.5 11.837 12.2366 11.2011 11.7678 10.7322C11.2989 10.2634 10.663 10 10 10C9.33696 10 8.70107 10.2634 8.23223 10.7322C7.76339 11.2011 7.5 11.837 7.5 12.5C7.5 13.163 7.76339 13.7989 8.23223 14.2678C8.70107 14.7366 9.33696 15 10 15ZM22.5 7.5C22.5 6.83696 22.2366 6.20107 21.7678 5.73223C21.2989 5.26339 20.663 5 20 5C19.337 5 18.7011 5.26339 18.2322 5.73223C17.7634 6.20107 17.5 6.83696 17.5 7.5C17.5 8.16304 17.7634 8.79893 18.2322 9.26777C18.7011 9.73661 19.337 10 20 10C20.663 10 21.2989 9.73661 21.7678 9.26777C22.2366 8.79893 22.5 8.16304 22.5 7.5ZM30 15C30.663 15 31.2989 14.7366 31.7678 14.2678C32.2366 13.7989 32.5 13.163 32.5 12.5C32.5 11.837 32.2366 11.2011 31.7678 10.7322C31.2989 10.2634 30.663 10 30 10C29.337 10 28.7011 10.2634 28.2322 10.7322C27.7634 11.2011 27.5 11.837 27.5 12.5C27.5 13.163 27.7634 13.7989 28.2322 14.2678C28.7011 14.7366 29.337 15 30 15Z\" fill=\"#005BAA\"/>\r\n  </g>\r\n  <defs>\r\n    <clipPath id=\"clip0_276_2320\">\r\n      <rect width=\"40\" height=\"40\" fill=\"white\"/>\r\n    </clipPath>\r\n  </defs>\r\n</svg>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "Robotic",
                            TieuDeTiengAnh= "Robotic",
                            MoTa= "Bộ môn lập trình robot là một hành trình thú vị giúp học sinh tiểu học khám phá thế giới công nghệ. Tham gia câu lạc bộ lập trình robot, các em sẽ phát triển tư duy logic, khả năng giải quyết vấn đề và kỹ năng hợp tác trong nhóm. Qua việc tạo ra và điều khiển robot, trẻ sẽ rèn luyện sự kiên nhẫn, sáng tạo và khả năng tưởng tượng. Đồng thời, bộ môn này còn giúp trẻ xây dựng nền tảng vững chắc cho hiểu biết về khoa học và công nghệ, từ đó kích thúc sự ham muốn tìm hiểu và phát triển trong tương lai.",
                            Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"50\" height=\"50\" viewBox=\"0 0 50 50\" fill=\"none\">\r\n  <path d=\"M25 5C26.3828 5 27.5 6.11719 27.5 7.5V12.5H36.875C39.9844 12.5 42.5 15.0156 42.5 18.125V39.375C42.5 42.4844 39.9844 45 36.875 45H13.125C10.0156 45 7.5 42.4844 7.5 39.375V18.125C7.5 15.0156 10.0156 12.5 13.125 12.5H22.5V7.5C22.5 6.11719 23.6172 5 25 5ZM16.25 35C15.5625 35 15 35.5625 15 36.25C15 36.9375 15.5625 37.5 16.25 37.5H18.75C19.4375 37.5 20 36.9375 20 36.25C20 35.5625 19.4375 35 18.75 35H16.25ZM23.75 35C23.0625 35 22.5 35.5625 22.5 36.25C22.5 36.9375 23.0625 37.5 23.75 37.5H26.25C26.9375 37.5 27.5 36.9375 27.5 36.25C27.5 35.5625 26.9375 35 26.25 35H23.75ZM31.25 35C30.5625 35 30 35.5625 30 36.25C30 36.9375 30.5625 37.5 31.25 37.5H33.75C34.4375 37.5 35 36.9375 35 36.25C35 35.5625 34.4375 35 33.75 35H31.25ZM20.625 25C20.625 24.1712 20.2958 23.3763 19.7097 22.7903C19.1237 22.2042 18.3288 21.875 17.5 21.875C16.6712 21.875 15.8763 22.2042 15.2903 22.7903C14.7042 23.3763 14.375 24.1712 14.375 25C14.375 25.8288 14.7042 26.6237 15.2903 27.2097C15.8763 27.7958 16.6712 28.125 17.5 28.125C18.3288 28.125 19.1237 27.7958 19.7097 27.2097C20.2958 26.6237 20.625 25.8288 20.625 25ZM32.5 28.125C33.3288 28.125 34.1237 27.7958 34.7097 27.2097C35.2958 26.6237 35.625 25.8288 35.625 25C35.625 24.1712 35.2958 23.3763 34.7097 22.7903C34.1237 22.2042 33.3288 21.875 32.5 21.875C31.6712 21.875 30.8763 22.2042 30.2903 22.7903C29.7042 23.3763 29.375 24.1712 29.375 25C29.375 25.8288 29.7042 26.6237 30.2903 27.2097C30.8763 27.7958 31.6712 28.125 32.5 28.125ZM3.75 22.5H5V37.5H3.75C1.67969 37.5 0 35.8203 0 33.75V26.25C0 24.1797 1.67969 22.5 3.75 22.5ZM46.25 22.5C48.3203 22.5 50 24.1797 50 26.25V33.75C50 35.8203 48.3203 37.5 46.25 37.5H45V22.5H46.25Z\" fill=\"#005BAA\"/>\r\n</svg>",
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe= "In 3D",
                            TieuDeTiengAnh= "3D Printing",
                            MoTa= "In 3D là một bộ môn giúp các con phát triển về tư duy sáng tạo, thiết kế và khả năng thẩm mĩ cao. Việc thể hiện ý tưởng trực quan trên máy tính và chạm tay vào quá trình sản xuất sẽ kích thích sự ham muốn khám phá và phát triển của trẻ, từ bây giờ cho đến tương lai.",
                            Icon= "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"icon icon-tabler icon-tabler-brand-codepen\" width=\"64\" height=\"64\" viewBox=\"0 0 24 24\" stroke-width=\"1.5\" stroke=\"#ff2825\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\">\r\n  <path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/>\r\n  <path d=\"M3 15l9 6l9 -6l-9 -6l-9 6\" />\r\n  <path d=\"M3 9l9 6l9 -6l-9 -6l-9 6\" />\r\n  <path d=\"M3 9l0 6\" />\r\n  <path d=\"M21 9l0 6\" />\r\n  <path d=\"M12 3l0 6\" />\r\n  <path d=\"M12 15l0 6\" />\r\n</svg>",
                        }
                    },
                }
            };
        }

        private static ICollection<CaiDatTongThe> SeedCaiDatTrangChu(AppDbContext dbContext)
        {
            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe
                {
                    TrangId = 1,
                    ThuTu = 1,
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TrangChu/069CB778-25BB-4112-A927-F442FFE30E9A.png",
                            Link = "/thong-tin-tuyen-sinh",
                            TieuDe = "Thông tin tuyển sinh 2023",
                            ThuTu = 1
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TrangChu/AA43AEA5-3504-4C89-AF2B-D859BD6B570D.JPG",
                            ThuTu = 2
                        },
                        new CaiDatChiTiet
                        {
                            LinkAnh = "/imgs/TrangChu/4E635465-AC1A-4FF3-A15B-986C2392AD01.jpg",
                            ThuTu = 3
                        },
                    }
                },
                //new CaiDatTongThe
                //{
                //    TrangId = 1,
                //    CaiDatChiTiet = new List<CaiDatChiTiet>
                //    {
                //        new CaiDatChiTiet
                //        {
                //            LinkAnh = "/imgs/TrangChu/6C34EAA8-4D64-4C4D-B636-F35D6D0319D5.jpg",
                //        },
                //    }
                //},
                new CaiDatTongThe
                {
                    TrangId = 1,
                    ThuTu = 2,
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "<p>Trường tiểu học Nguyễn Siêu</p><p><span style=\"font-size:20px;\"><strong>Ngôi trường</strong></span></p><p><span style=\"font-size:20px;\"><strong>hiện đại, vươn tầm quốc tế</strong></span></p>",
                            MoTa = "<p>Trường Tiểu học Nguyễn Siêu là một trường dân lập tọa lạc tại Hà Nội, Việt Nam. Trường được thành lập vào ngày 31/3/1993 theo quyết định số 2860 của UBND Thành phố Hà Nội. Ngôi trường được đặt tên theo danh nhân Việt Nam nổi tiếng Nguyễn Văn Siêu</p>",
                            LinkAnh = "/imgs/TrangChu/0246D6AF-C51A-4578-99DB-9CAC42E0902C.jpg",
                            ThuTu = 1,
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "<p>\"Vì hạnh phúc gia đình - Vì tiến bộ xã hội<br>Thầy mẫu mực- Trò chăm ngoan học giỏi\"</p>",
                            LinkAnh = "/imgs/TrangChu/6DE94FF7-E57D-4F77-9D85-1C70F372DFB1.jpg",
                            ThuTu = 2,
                        },
                    }
                },
                new CaiDatTongThe
                {
                    TrangId = 1,
                    LinkAnh = "/imgs/TrangChu/6DE94FF7-E57D-4F77-9D85-1C70F372DFB1.jpg",
                    ThuTu = 3,
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            TieuDe = "1292",
                            MoTa = "học sinh",
                            ThuTu = 1,
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "10+",
                            MoTa = "năm hoạt động",
                            ThuTu = 2,
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "100%",
                            MoTa = "chương trình cambridge",
                            ThuTu = 3,
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "10+",
                            MoTa = "năm hoạt động",
                            ThuTu = 4,
                        },
                        new CaiDatChiTiet
                        {
                            TieuDe = "10+",
                            MoTa = "năm hoạt động",
                            ThuTu = 5,
                        },
                    }
                },
               
                new CaiDatTongThe
                {
                    TrangId = 1,
                    ThuTu = 5,
                    CaiDatChiTiet = new List<CaiDatChiTiet>
                    {
                        new CaiDatChiTiet
                        {
                            ThuTu = 1,
                            LinkAnh = "/imgs/TrangChu/D14E5A3A-1B5A-4BF7-99DC-4D264104E7A2.png"
                        },
                        new CaiDatChiTiet
                        {
                            ThuTu = 2,
                            LinkAnh = "/imgs/TrangChu/1193C8AB-041E-485A-A4DD-2045DBB249F6.png"
                        },
                        new CaiDatChiTiet
                        {
                            ThuTu = 3,
                            LinkAnh = "/imgs/TrangChu/ABE85469-972C-4C44-A86A-EA54EA4F62BB.png"
                        },
                        new CaiDatChiTiet
                        {
                            ThuTu = 4,
                            LinkAnh = "/imgs/TrangChu/51A5B36F-EB37-4E54-B214-F6B0718E6804.png"
                        },
                    }
                }
            };
        }
        private static ICollection<CaiDatTongThe> SeedAnToanHocDuong(AppDbContext dbContext, IConfiguration config)
        {

            return new List<CaiDatTongThe>
            {
                new CaiDatTongThe {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Chính sách bảo vệ trẻ em",
                    Mota = "Mô Tả",
                },
                new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Quy định xử lý cáo buộc về xâm hại trẻ em",
                    Mota = "Mô Tả",
                   /* CaiDatChiTiet = uploadedImage*/
                },
                 new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Quy định về việc tiếp xúc thân thể với học sinh",
                     Mota = "<Mô Tả"
                   /* CaiDatChiTiet = uploadedImage*/
                },
                  new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Chính sách an toàn trên môi trường mạng",
                     Mota = "Mô Tả"
                   /* CaiDatChiTiet = uploadedImage*/
                },
                  new CaiDatTongThe
                {
                    TrangId = (long)DanhSachTrangTinh.AnToanHocDuong,
                    TieuDe = "Quy định chống bạo lực, bắt nạt",
                     Mota = "Mô Tả"
                   /* CaiDatChiTiet = uploadedImage*/
                }
            };
        }
    }
}

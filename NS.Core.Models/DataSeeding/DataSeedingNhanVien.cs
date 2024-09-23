using Microsoft.Extensions.Configuration;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models;

public partial class DataSeeding
{
    public static void DataSeedingNhanVien(AppDbContext dbContext)
    {
        if (!dbContext.NhanVien.Any(x=>x.LaChuyenVienTuVan==true))
        {
            var phongBanId = dbContext.PhongBan.OrderByDescending(x=>x.Id).Select(x => x.Id).FirstOrDefault();
            dbContext.NhanVien.AddRange(GenerateChuyenVienTuVan(phongBanId));
            dbContext.SaveChanges();
        }
    }

    private static List<NhanVien> GenerateChuyenVienTuVan(long phongBanId)
    {
        return new List<NhanVien>
       {
           new NhanVien()
           {
                PhongBanId=phongBanId,
                HoTen= "NGUYỄN THU HUYỀN",
                ChucVu="Chuyên viên tâm lý - Trưởng bộ phận",
                DanhHieu="TS",
                LinkAnh= "/imgs/HocSinh/TuVanTamLy/nguyen-thu-huyen.png",
                ThongTinLienLac="huyennguyen@nguyesieu.edu" ,
                HocVan="HV Cao học Tâm lý học lâm sàng trẻ em &amp; vị thành niên - Đại học Quốc gia HN" ,
                HienThi=true ,
                LaChuyenVienTuVan= true,
           },
            new NhanVien()
           {
                PhongBanId=phongBanId,
                HoTen= "NGUYỄN THỊ HẰNG",
                ChucVu="Chuyên viên tâm lý cấp Tiểu học",
                DanhHieu="TS",
                LinkAnh= "/imgs/HocSinh/TuVanTamLy/nguyen-thi-hang.png",
                ThongTinLienLac="hangnt@nguyesieu.edu" ,
                HocVan="Cử nhân Tâm lý học trường học - Đại học Sư phạm Hà Nội" ,
                HienThi=true ,
                LaChuyenVienTuVan= true,
           },
             new NhanVien()
           {
                PhongBanId=phongBanId,
                HoTen= "ĐÀO THỊ THU HƯƠNG",
                ChucVu="Chuyên viên tâm lý - Trưởng bộ phận",
                DanhHieu="TS",
                LinkAnh= "/imgs/HocSinh/TuVanTamLy/dao-thi-thu-huong.png",
                ThongTinLienLac="huongdao@nguyesieu.edu" ,
                HocVan="Cử nhân Tâm lý học trường học - Đại học Sư phạm Hà Nội" ,
                HienThi=true ,
                LaChuyenVienTuVan= true,
           }
       };
    }
}
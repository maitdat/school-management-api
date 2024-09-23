using Microsoft.Extensions.Configuration;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models;

public partial class DataSeeding
{

    public static void DataSeedingSuKien(AppDbContext dbContext)
    {
        if (!dbContext.SuKienSapToi.Any())
        {
            dbContext.SuKienSapToi.AddRange(GenerateSukien());
            dbContext.SaveChanges();
        }
    }

    private static List<SuKienSapToi> GenerateSukien()
    {
        return new List<SuKienSapToi>()
        {
            new SuKienSapToi()
            {
                TenSuKien="Minigame “Bùng nổ học tập thời Covid cùng BLACKPINK”",
                TenSuKienTiengAnh=string.Empty,
                DiaDiem="Yên Hòa, Cầu Giấy, Hà Nội",
                ThoiGian= new DateTime(DateTime.Now.Year, 6, 18, 10, 0, 0),
                MoTa=string.Empty,
                MoTaTiengAnh=string.Empty
            },
             new SuKienSapToi()
            {
                TenSuKien="Lễ Khởi động chiến dịch \"Race To Zero\" và Hưởng ứng COP26",
                TenSuKienTiengAnh=string.Empty,
                DiaDiem="Yên Hòa, Cầu Giấy, Hà Nội",
                ThoiGian= new DateTime(DateTime.Now.Year, 6, 8, 10, 0, 0),
                MoTa=string.Empty,
                MoTaTiengAnh=string.Empty
            },


        };

    }
}

    

   
using Microsoft.AspNetCore.Http;
using NS.Core.Models.Entities.LandingPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels.CoSoVatChat
{
    public class CoSoVatChatCMSResponseModel
    {
        public long Id { get; set; }
        public string TenDiaDiem { get; set; }
        public string TenDiaDiemTiengAnh { get; set; }
        public bool HienThi { get; set; }
        public List<ChiTietCoSoVatChatCMSResponseModel> ChiTietCoSoVatChat { get; set; }
    }
    public class ChiTietCoSoVatChatCMSResponseModel
    {
        public long Id { get; set; }
        public long CoSoVatChatId { get; set; }
        public bool HienThi { get; set; }
        public LoaiMedia LoaiMedia { get; set; }
        public string LinkAnh { get; set; }
        public long? FileId { get; set; }
        public IFormFile File { get; set; }
        public int ThuTu { get; set; }
    } 
    public class MediaResponseModel
    {
        public long Id { get; set; }
        public long CoSoVatChatId { get; set; }
        public bool HienThi { get; set; }
        public LoaiMedia LoaiMedia { get; set; }
        public string LinkAnh { get; set; }
        public int ThuTu { get; set; }

        public static MediaResponseModel Mapping(ChiTietCoSoVatChat model)
        {
            return new MediaResponseModel()
            {
                CoSoVatChatId = model.CoSoVatChatId, 
                HienThi = model.HienThi,
                LoaiMedia = model.LoaiMedia,
                LinkAnh = model.LinkAnh,
                Id = model.Id,
                ThuTu = model.ThuTu,
            };
        }
    }

}

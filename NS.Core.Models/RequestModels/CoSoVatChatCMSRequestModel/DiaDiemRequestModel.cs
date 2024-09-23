using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.ResponseModels.FileUpload;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels.CoSoVatChatCMSRequestModel
{
    public class DiaDiemRequestModel
    {
        public long Id { get; set; }
        public string TenDiaDiem { get; set; }
        public string TenDiaDiemTiengAnh { get; set; }
        public bool HienThi { get; set; }
        public List<UpdateMediaRequestModel> ChiTietCoSoVatChat { get; set; }
    }

    public class UpdateMediaRequestModel
    {
        public long Id { get; set; }
        public long CoSoVatChatId { get; set; }
        public bool HienThi { get; set; }
        public LoaiMedia LoaiMedia { get; set; }
        public string LinkAnh { get; set; }
        public long FileId { get; set; }
        public IFormFile? File { get; set; }
        public int ThuTu { get; set; } = 1;

        public  void UpdateImage(ref ChiTietCoSoVatChat model, FileUploadResponseModel fileUpload)
        {
            model.HienThi = HienThi;
            model.LoaiMedia = LoaiMedia;
            model.CoSoVatChatId = CoSoVatChatId;
            model.FileId = fileUpload.Id;
            model.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.CoSoVatChat)}/{fileUpload.FileName}";
            model.ThuTu = ThuTu;
        }

        public  void UpdateVideo(ref ChiTietCoSoVatChat model)
        {
            model.HienThi = HienThi;
            model.LoaiMedia = LoaiMedia;
            model.CoSoVatChatId = CoSoVatChatId;
            model.LinkAnh = LinkAnh;
            model.ThuTu = ThuTu;
        }
    }

    public class CreateMediaRequestModel
    {
        public long? Id { get; set; }
        public long CoSoVatChatId { get; set; }
        public bool HienThi { get; set; }
        public LoaiMedia LoaiMedia { get; set; }
        public string LinkAnh { get; set; }
        public IFormFile? File { get; set; }
        public int ThuTu { get; set; } = 1;

        public static ChiTietCoSoVatChat MappingImage(CreateMediaRequestModel model, FileUploadResponseModel fileUpload)
        {
            return new ChiTietCoSoVatChat()
            {
                HienThi = model.HienThi,
                LoaiMedia = model.LoaiMedia,
                CoSoVatChatId = model.CoSoVatChatId,
                FileId = fileUpload.Id,
                LinkAnh = $"/imgs/{nameof(Enums.FolderChild.CoSoVatChat)}/{fileUpload.FileName}",
                ThuTu = model.ThuTu,
            };
        }

        public static ChiTietCoSoVatChat MappingVideo(CreateMediaRequestModel model)
        {
            return new ChiTietCoSoVatChat()
            {
                CoSoVatChatId = model.CoSoVatChatId,
                HienThi = model.HienThi,
                LoaiMedia = model.LoaiMedia,
                LinkAnh = model.LinkAnh,
                ThuTu = model.ThuTu,
            };
        }
    }

    public class FileUploadRequest
    {
        public IFormFile[] File { get; set; }
    }
}
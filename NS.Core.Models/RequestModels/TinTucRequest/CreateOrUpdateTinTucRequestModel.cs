using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels.FileUpload;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateTinTucRequestModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "ChuyenMucId is required")]
        public long ChuyenMucId { get; set; }

        public DateTime? NgayDang { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "TrangThaiTinTuc is required")]
        public TrangThaiTinTuc TrangThai { get; set; } = TrangThaiTinTuc.ChoPheDuyet;

        [Required(ErrorMessage = "TieuDe is required")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "NoiDungTomTat is required")]
        public string NoiDungTomTat { get; set; }

        [Required(ErrorMessage = "NoiDungChiTiet is required")]
        public string NoiDungChiTiet { get; set; }

        [Required(ErrorMessage = "LoaiBaiViet is required")]
        public LoaiBaiViet LoaiBaiViet { get; set; }
        public IFormFile? File { get; set; }
        public string AnhDaiDien { get; set; }
        public string? TieuDeEnglish { get; set; }
        public string? NoiDungTomTatEnglish { get; set; }
        public string? NoiDungChiTietEnglish { get; set; }
        public bool? LaTinTuc { get; set; }
        public string? TacGia { get; set; }

        public  void Update(ref TinTuc model, FileUploadResponseModel fileUpload)
        {
                model.Id = Id;
                model.ChuyenMucId = ChuyenMucId;
                model.TacGia = TacGia;
                model.TieuDe = TieuDe;
                model.TieuDeEnglish = TieuDeEnglish;
                model.NoiDungTomTat = NoiDungTomTat;
                model.NoiDungTomTatEnglish = NoiDungTomTatEnglish;
                model.NoiDungChiTietEnglish = NoiDungChiTietEnglish;
                model.NoiDungChiTiet = NoiDungChiTiet;
                model.LoaiBaiViet = LoaiBaiViet;
                model.LaTinNoiBat = false;
                model.LaTinTuc = LaTinTuc ?? true;
                model.NgayDang = NgayDang ?? DateTime.Now;
                model.NgayCapNhat = DateTime.Now;
                model.NgayTao = DateTime.Now;
                model.TrangThai = model.Id > 0 ?  TrangThai : TrangThaiTinTuc.ChoPheDuyet;
                model.FileAnhDaiDienId = fileUpload.Id > 0 ? fileUpload.Id : model.FileAnhDaiDienId;
                model.AnhDaiDien = fileUpload.Id > 0
                    ? $"/imgs/{nameof(Enums.FolderChild.TinTuc)}/{fileUpload.FileName}"
                    : model.AnhDaiDien;
        }
    }
}
using Microsoft.AspNetCore.Http;
using NS.Core.Business;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.RequestModels.CMSLandingPage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class CauLacBoRequestModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên câu lạc bộ.")]
        public string TenCauLacBo { get; set; }
        public string TenCauLacBoTiengAnh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số buổi học.")]
        public int SoBuoiHoc { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập học phí.")]
        public int HocPhi { get; set; }
        public string icon { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }
        public List<AnhCauLacBoRequestModel> AnhCauLacBos { get; set; }
    }
    public class AnhCauLacBoRequestModel
    {
        public long Id { get; set; }
        public long CauLacBoId { get; set; }
        public long FileUploadId { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(20 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile File { get; set; } 
        public string LinkAnh { get; set; }
    }
    
}

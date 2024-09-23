using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.ThucDon
{
    public class ThucDonRequestModel
    {
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public string TenTuan { get; set; }
        public string TenTuanTiengAnh { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập trường này")]
        public DateTime TuNgay { get; set; } = DateTime.MinValue;
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public DateTime DenNgay { get; set; } = DateTime.MinValue;
        public IFormFile? LinkAnh { get; set; }
        public string MauThuHai { get; set; }
        public string MauThuBa { get; set; }
        public string MauThuTu { get; set; }
        public string MauThuNam { get; set; }
        public string MauThuSau { get; set; }
        public string MauAnSang { get; set; }
    }
}

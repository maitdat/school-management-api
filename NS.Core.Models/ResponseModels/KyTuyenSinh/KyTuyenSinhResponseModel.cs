using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NS.Core.Models.Entities;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class KyTuyenSinhResponseModel 
    {
        public long Id { get; set; }
        public required string TenKyTuyenSinh { get; set; }
        public required long NamHocId { get; set; } 
        public required string TenNamHoc { get; set; }
        public int ChiTieuTuyenSinh1 { get; set; }
        public int ChiTieuTuyenSinh2 { get; set; }
        public int ChiTieuTuyenSinh3 { get; set; }
        public int ChiTieuTuyenSinh4 { get; set; }
        public int ChiTieuTuyenSinh5 { get; set; }
        public TrangThaiKyTuyenSinh TrangThaiKyTuyenSinh { get; set; }

    }
}

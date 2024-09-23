﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateKyTuyenSinhModel
    { 
        public required string TenKyTuyenSinh { get; set; } // Kỳ tuyển sinh năm học 2021 - 2022
        public long NamHocId { get; set; }
        public int ChiTieuTuyenSinh1 { get; set; }
        public int ChiTieuTuyenSinh2 { get; set; }
        public int ChiTieuTuyenSinh3 { get; set; }
        public int ChiTieuTuyenSinh4 { get; set; }
        public int ChiTieuTuyenSinh5 { get; set; }
        public TrangThaiKyTuyenSinh TrangThaiKyTuyenSinh { get; set; }
    }
}

using System;
﻿using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class TieuChiMonThiResponseModel 
    {
        public long Id {  get; set; }
        public long TieuChiDanhGiaId { get; set; }
        public string TieuChiDanhGia { get; set; }
        public long MonThiTuyenSinhId { get; set; }
        public string MonThiTuyenSinh { get; set; }
        public decimal HeSo { get; set; }
    }
}

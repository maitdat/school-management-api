using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class TieuChiDanhGiaResponseModel
    {
        public long Id { get; set; }
        public required string TenTieuChi { get; set; }
        public string GhiChu { get; set; }
    }
}


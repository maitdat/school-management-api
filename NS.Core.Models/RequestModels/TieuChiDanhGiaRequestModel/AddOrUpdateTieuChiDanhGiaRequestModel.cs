using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class AddOrUpdateTieuChiDanhGiaRequestModel 
    {
        public required string TenTieuChi { get; set; }
        public string GhiChu { get; set; }
    }
}

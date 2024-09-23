using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class TieuChiDanhGia : Commons.BaseEntitySoftDeletable
    {
        public required string TenTieuChi { get; set; }
        public string GhiChu { get; set; }
    }
}

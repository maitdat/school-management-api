using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class AddOrUpdateTieuChiMonThiRequestModel
    {
        public long MonThiTuyenSinhId { get; set; }
        public long TieuChiDanhGiaId { get; set; }
        public decimal HeSo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class LoaiLoiHoSo : Commons.BaseEntity
    {
        public required string TenLoai { get; set; }
        public required string KyHieu { get; set; }
    }
}

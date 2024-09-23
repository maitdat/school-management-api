using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class ThongTinHoiDong : BaseEntitySoftDeletable
    {
        public required string HoTen { get; set; }
        public string ChucDanh { get; set; }

    }
}

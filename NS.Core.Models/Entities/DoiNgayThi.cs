using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class DoiNgayThi : Commons.BaseEntitySoftDeletable
    {
        public long ThoiGianThiId { get; set; }
        public virtual ThoiGianThi ThoiGianThi { get; set; }
        public long HoSoThiId { get; set; }
        public virtual HoSoThi HoSoThi { get; set; }
        // public string LyDo { get; set; }
        // public TrangThaiDoiNgayThi TrangThai { get; set; }

    }
}

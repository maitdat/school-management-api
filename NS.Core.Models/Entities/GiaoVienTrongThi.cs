using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class GiaoVienTrongThi : Commons.BaseEntitySoftDeletable
    {
        public long LopDuThiId { get; set; }
        public virtual LopDuThi LopDuThi { get; set; }
        public  long ThanhVienHoiDongId { get; set; }
        public virtual ThanhVienHoiDong ThanhVienHoiDong { get; set; }
        public bool LaGiaoVienChinh { get; set; }
        public string GhiChu { get; set; }
    }
}

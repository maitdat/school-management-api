using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class YeuCauLienHe : BaseEntitySoftDeletable
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public long BoPhanLienHeId { get; set; }
        public virtual BoPhanLienHe BoPhanLienHe { get; set; }
        public string NoiDungLienHe { get; set; }
        public bool DaPhanHoi { get; set; }
        public DateTime NgayTao { get; set; }
    }
}

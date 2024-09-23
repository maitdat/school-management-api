
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class LienHe : Commons.BaseEntitySoftDeletable
    {
        public long BoPhanLienHeId { get; set; }
        public virtual BoPhanLienHe BoPhanLienHe { get; set; }
        public required string NguoiLienHe { get; set; }
        public required string SoDienThoai { get; set; }
        public required string Email { get; set; }
        public required string TieuDe { get; set; }
        public required string NoiDung { get; set; }
        public TrangThaiLienHe TrangThai { get; set; }
    }
}

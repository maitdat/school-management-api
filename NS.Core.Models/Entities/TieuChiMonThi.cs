using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class TieuChiMonThi : Commons.BaseEntitySoftDeletable
    {
        public long MonThiTuyenSinhId { get; set; }
        public virtual MonThiTuyenSinh MonThiTuyenSinh { get; set; }
        public long TieuChiDanhGiaId { get; set; }
        public virtual TieuChiDanhGia TieuChiDanhGia { get; set; }
        public decimal HeSo { get; set; }
    }
}

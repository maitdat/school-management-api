using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class QuyDoiDiem : Commons.BaseEntitySoftDeletable
    {
        public long MonThiTuyenSinhId { get; set; }
        public virtual MonThiTuyenSinh MonThiTuyenSinh { get; set; }
        public int DiemBatDau { get; set; }
        public int DiemKetThuc { get; set; }
        public string KetQua { get; set; }
    }
}

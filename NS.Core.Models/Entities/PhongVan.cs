using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class PhongVan : Commons.BaseEntitySoftDeletable
    {
        public long UngVienId { get; set; }
        public virtual UngVien UngVien { get; set; }
        public DateTime NgayPhongVan { get; set; }
        public string NoiDungPhongVan { get; set; }
        public KetQuaPhongVan KetQuaPhongVan { get; set; }
    }
}

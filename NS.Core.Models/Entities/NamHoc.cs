using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class NamHoc : Commons.BaseEntitySoftDeletable
    {
        public string TenNamHoc { get; set; } // Năm học 2021 - 2022
        public long TuNam { get; set; } = 0;
        public long DenNam { get; set; } = 0;
        public virtual NamHocPhi NamHocPhi { get; set; }
    }
}

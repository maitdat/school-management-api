using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class CatDatHeThong : BaseEntity
    {
        public CauHinhHeThong CauHinh { get; set; }
        public string CaiDat { get; set; } // JSON String
    }
}

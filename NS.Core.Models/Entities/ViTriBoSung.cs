using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class ViTriBoSung : BaseEntity
    {
        public long HoSoTuyenDungId { get; set; }
        public virtual HoSoTuyenDung HoSoTuyenDung { get; set; }
        public long ViTriTuyenDungId { get; set; }
        public virtual ViTriTuyenDung ViTriTuyenDung { get; set; }
    }
}

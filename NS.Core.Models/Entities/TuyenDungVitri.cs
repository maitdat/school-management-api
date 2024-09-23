using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class TuyenDungViTri : BaseEntity
    {
        public long TinTuyenDungId { get; set; }
        public virtual TinTuyenDung TinTuyenDung { get; set; }
        public long ViTriTuyenDungId { get; set; }
        public virtual ViTriTuyenDung ViTriTuyenDung { get; set; }
    }
}

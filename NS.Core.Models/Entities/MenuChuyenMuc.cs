using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class MenuChuyenMuc : BaseEntity
    {
        public long MenuConfigId { get; set; }
        public virtual MenuConfig MenuConfig { get; set; }
        public long ChuyenMucId { get; set; }
        public virtual ChuyenMuc ChuyenMuc { get; set; }
    }
}

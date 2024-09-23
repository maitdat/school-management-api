using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class Trang : BaseEntitySoftDeletable
    {
        public required string TenTrang { get; set; }
        public virtual ICollection<CaiDatTongThe> CaiDatTongThe { get; set; }
    }
}

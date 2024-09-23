using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class VanDeLienHe : Commons.BaseEntity
    {
        public long VanDeId { get; set; }
        public virtual VanDe VanDe { get; set; }
        public long LienHeId { get; set; }
        public virtual LienHe LienHe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Commons
{
    public class BaseEntitySoftDeletable : BaseEntity
    {
        public bool IsDeleted { get; set; }
    }
}

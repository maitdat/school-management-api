using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class VanDe : Commons.BaseEntitySoftDeletable
    {
        public required string TenVanDe { get; set; }
    }
}

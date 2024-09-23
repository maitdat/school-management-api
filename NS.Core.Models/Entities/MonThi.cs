using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class MonThi : Commons.BaseEntitySoftDeletable
    {
        public required string TenMonThi { get; set; }
        public string MoTa { get; set; }
    }
}

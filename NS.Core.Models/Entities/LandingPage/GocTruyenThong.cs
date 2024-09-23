using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class GocTruyenThong : BaseEntitySoftDeletable
    {
        public int SoTrang { get; set; }
        public string LinkAnh { get; set; }
    }
}

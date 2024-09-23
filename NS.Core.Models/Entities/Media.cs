using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class Media : BaseEntitySoftDeletable
    {
        public required long CoSoVatChatId { get; set; }
        public virtual CoSoVatChat CoSoVatChat { get; set; }
        public required string ContentLink { get; set; }
        public required LoaiMedia ContentType { get; set; }
        public required bool HienThi { get; set; }
    }
}

using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities.LandingPage
{
    public class ThanhTichNoiBat : BaseEntitySoftDeletable
    {
        public string TenHocSinh { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }
        public string LinkAnh { get; set; }
        public long? FileId { get; set; }
        public virtual FileUpload File { get; set; }
    }
}

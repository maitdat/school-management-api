using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class AnhCauLacBo : BaseEntitySoftDeletable
    {
        public long CauLacBoId { get; set; }
        public long FileUploadId { get; set; }
        public string LinkAnh { get; set; }
        public virtual CauLacBo CauLacBo { get; set; }
        public virtual FileUpload FileUpload { get; set; }
    }
}

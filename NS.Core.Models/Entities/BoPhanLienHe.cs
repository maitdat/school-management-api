using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class BoPhanLienHe : Commons.BaseEntitySoftDeletable
    {
        public long? BoPhanChaId { get; set; }
        public virtual BoPhanLienHe BoPhanCha { get; set; }
        public required string TenBoPhan { get; set; }
        public string TenBoPhanEnglish { get; set; }
        public required string Email { get; set; }
    }
}

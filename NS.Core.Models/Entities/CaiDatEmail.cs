using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class CaiDatEmail : Commons.BaseEntitySoftDeletable
    {
        public long? KhoiId { get; set; }
        public virtual Khoi Khoi { get; set; }
        public long? HeDaoTaoId { get; set; }
        public virtual HeDaoTao HeDaoTao { get; set; }
        public EmailCode Code { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string TieuDeEnglish { get; set; }
        public string NoiDungEnglish { get; set; }
    }
}

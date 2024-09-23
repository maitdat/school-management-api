using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class MenuConfig : Commons.BaseEntitySoftDeletable
    {
        public long? ParentId { get; set; }
        public virtual MenuConfig Parent { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public bool IsDefault { get; set; }
        public long? TinTucId { get; set; }
        public virtual TinTuc TinTuc { get; set; }
        public string LinkBanner { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public virtual ICollection<MenuChuyenMuc> MenuChuyenMuc { get; set; }
    }
}

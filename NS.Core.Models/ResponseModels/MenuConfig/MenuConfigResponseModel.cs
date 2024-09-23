using NS.Core.Models.Entities; 
using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class MenuConfigResponseModel
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public virtual List<MenuConfigResponseModel> Children { get; set;}
        public string Name { get; set; }
        public string NameEn { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public long? TinTucId { get; set; }
        public string LinkBanner { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public List<MenuChuyenMucResponseModel> MenuChuyenMuc { get; set; }

    }
}

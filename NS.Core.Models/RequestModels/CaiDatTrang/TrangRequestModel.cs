using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.CaiDatTrang
{
    public class TrangRequestModel
    {
        public required string TenTrang { get; set; }
        public ICollection<CaiDatTongTheRequestModel> CaiDatTongThe{ get; set; }
    }
}

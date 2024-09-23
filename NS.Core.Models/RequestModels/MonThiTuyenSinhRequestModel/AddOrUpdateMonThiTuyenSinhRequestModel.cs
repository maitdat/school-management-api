using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class AddOrUpdateMonThiTuyenSinhRequestModel
    {
        public long KyTuyenSinhId { get; set; }
        public long LopDuThiId { get; set; }
        public long MonThiId { get; set; }
        public long HeDaoTaoId { get; set; }
        
    }
}

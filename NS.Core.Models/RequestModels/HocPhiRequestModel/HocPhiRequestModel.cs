using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.HocPhiRequestModel
{
    public class HocPhiRequestModel
    {      
        public long NamHocPhiId { get; set; }
        public long HeDaoTaoId { get; set; }
        public string Lop { get; set; }
        public int TienHocPhi { get; set; }
    }
}

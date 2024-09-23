using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.HocPhi
{
    public class NamHocPhiReqModel
    {
        public long NamHocId { get; set; }
        public string NoiDung { get; set; }
        public List<ChiTietHocPhiReqModel> ListHocPhi { get; set; }
    }
    public class ChiTietHocPhiReqModel
    {
        public long HeDaoTaoId { get; set; }
        public string Lop { get; set; }
        public int TienHocPhi { get; set; }
    }
}

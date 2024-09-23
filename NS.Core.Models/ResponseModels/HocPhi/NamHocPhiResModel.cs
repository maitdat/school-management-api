using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class NamHocPhiResModel
    {
        public long Id { get; set; }
        public long NamHocId { get; set; }
        public string NoiDung { get; set; }
        public long TuNam { get; set; }
        public long DenNam { get; set; }
        public string TenNamHoc { get; set; }
        public List<ChiTietHocPhiResModel> ListHocPhi { get; set; }
        public string NoiDungTiengAnh { get; set; }
    }

    public class ChiTietHocPhiResModel
    {
        public long Id { get; set; }
        public string HeDaoTao { get; set; }
        public long HeDaoTaoId { get; set; }
        public string Lop { get; set; }
        public int TienHocPhi { get; set; }
    }
}

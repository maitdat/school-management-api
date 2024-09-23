using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
   public class HeDaoTaoResponseModel
    {
        public long Id { get; set; }
        public  string TenHeDaoTao { get; set; }
        public  string TenHeDaoTaoEnglish { get; set; }
        public string MoTa { get; set; }
        public  List<MonThiTuyenSinhResponseModel> MonThiTuyenSinhs { get; set; }

    }
}

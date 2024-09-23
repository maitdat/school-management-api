using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.LopDuThi
{
    public class AddGiaoVienToLopDuThiRequestModel
    {
        public long[] GiaoVienTrongThi { get; set; }
        public long LopDuThiId { get; set; }
    }    

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class MonThiTuyenSinhRequestModel
    {
        public long MonThiTuyenSinhId { get; set; }
        public List<TieuChiMonThiRequestModel> ListTieuChiMonThi { get; set; }
    }
}

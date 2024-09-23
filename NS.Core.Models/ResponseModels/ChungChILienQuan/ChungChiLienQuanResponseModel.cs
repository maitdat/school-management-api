using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class ChungChiLienQuanResponseModel
    {
        public long Id { get; set; }
        public long HoSoTuyenDungId { get; set; }
        public string TenChungChi { get; set; }
        public string FileChungChi { get; set; }
        public string KetQua { get; set; }
    }
}

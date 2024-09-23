using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class KyTuyenSinhRequestModel : BasePaginationRequestModel
    {
        public IEnumerable<long> NamHocIds { get; set; }
        public IEnumerable<TrangThaiKyTuyenSinh> TrangThaiKyTuyenSinhs { get; set; }
    }
}

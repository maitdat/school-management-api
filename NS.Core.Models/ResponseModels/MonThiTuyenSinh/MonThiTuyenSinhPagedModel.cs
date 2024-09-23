using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.MonThiTuyenSinh
{
    public class MonThiTuyenSinhPagedModel : BasePaginationRequestModel
    {
        public long? KyTuyenSinhId { get; set; }
    }
}

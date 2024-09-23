using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.NoiQuyRequest
{
    public class GetPagedNoiQuyRequest:BasePaginationRequestModel
    {
        public long? LoaiNoiQuyId { get; set; }
    }
}

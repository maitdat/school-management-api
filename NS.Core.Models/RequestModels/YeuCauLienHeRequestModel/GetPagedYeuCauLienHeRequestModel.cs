using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class GetPagedYeuCauLienHeRequestModel : BasePaginationRequestModel
    {
        public long? BoPhanLienHeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? DaPhanHoi { get; set; }
    }
}

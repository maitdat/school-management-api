using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class GetPagedBinhLuanRequesModel:BasePaginationRequestModel
    {
        public long? TinTucId { get; set; }
        public DateTime? TuNgay { get; set; } 
        public DateTime? DenNgay { get; set; } 
    }
}

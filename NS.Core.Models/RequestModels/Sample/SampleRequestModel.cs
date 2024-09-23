using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class SampleRequestModel : BasePaginationRequestModel
    {
        public int ItemCount { get; set; } = 15;
        public List<int> Status { get; set; } = new List<int>();
    }
}

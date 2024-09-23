using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.TinTucRequest
{
    public class UpdateTinTucRequestModel : AddTinTucRequestModel
    {
        public long Id { get; set; }
    }
}

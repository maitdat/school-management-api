using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class BoPhanLienHeRequestModel
    {
        public required string TenBoPhan { get; set; }
        public string TenBoPhanEnglish { get; set; }
        public string Email { get; set; }
    }
}

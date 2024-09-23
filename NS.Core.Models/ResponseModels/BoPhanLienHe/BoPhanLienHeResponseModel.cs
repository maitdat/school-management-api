using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels
{
    public class BoPhanLienHeResponseModel
    {
        public long Id { get; set; }
        public string TenBoPhan { get; set; }
        public string TenBoPhanEnglish { get; set; }
        public string Email { get; set; }
    }
}

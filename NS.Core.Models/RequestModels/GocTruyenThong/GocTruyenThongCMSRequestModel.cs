using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.GocTruyenThong
{
    public class GocTruyenThongCMSRequestModel
    {
        [FromForm]
        public int SoTrang { get; set; }
        [FromForm]
        public IFormFile? File { get; set; }
        public string LinkAnh { get; set; }
    }
}

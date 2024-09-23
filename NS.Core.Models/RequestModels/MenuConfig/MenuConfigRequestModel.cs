using Microsoft.AspNetCore.Http;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NS.Core.Models.RequestModels
{
    public class MenuConfigRequestModel
    {
        [FromForm]
        public long? ParentId { get; set; }
        [FromForm]
        public string Name { get; set; }
        [FromForm]
        public string NameEn { get; set; }

        [FromForm]
        public long? TinTucId { get; set; }

        [FromForm]
        public IFormFile? NewBanner { get; set; }

        [FromForm]
        public int Order { get; set; }
    }
}

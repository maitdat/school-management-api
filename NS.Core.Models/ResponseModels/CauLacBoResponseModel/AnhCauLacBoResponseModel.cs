using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class AnhCauLacBoResponseModel
    {
        public long Id { get; set; }
        public long CauLacBoId { get; set; } 
        public long FileUploadId { get; set; }
        public IFormFile File { get; set; }
        public string LinkAnh { get; set; } = string.Empty;
    }
}

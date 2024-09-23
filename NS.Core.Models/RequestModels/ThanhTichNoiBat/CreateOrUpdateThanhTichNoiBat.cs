using Microsoft.AspNetCore.Http;
using NS.Core.Business;
using NS.Core.Models.ResponseModels.ThanhTichNoiBatResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.ThanhTichNoiBat
{
    public class CreateOrUpdateThanhTichNoiBat : GetThanhTichNoiBatResponseModel
    {
        [DataType(DataType.Upload)]
        [MaxFileSize(20 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile File { get; set; }
    }
}

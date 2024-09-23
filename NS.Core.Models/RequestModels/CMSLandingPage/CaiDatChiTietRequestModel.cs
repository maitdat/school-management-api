using Microsoft.AspNetCore.Http;
using NS.Core.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.CMSLandingPage
{
    public class CaiDatChiTietRequestModel
    {
        public long Id { get; set; }
        public long CaiDatTongTheId { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public long FileId { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(20 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile File { get; set; }
        public string LinkAnh { get; set; }

    }
}

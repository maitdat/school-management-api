using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.Video
{
    public class VideoCMSRequestModel
    {
        public required string TieuDe { get; set; }
        public required string Link { get; set; }
        public required DateTime NgayDang { get; set; }
    }
}

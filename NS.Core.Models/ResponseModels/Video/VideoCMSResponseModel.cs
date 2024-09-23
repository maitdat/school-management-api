using NS.Core.Commons;
using NS.Core.Models.ResponseModels.LandingPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels.Video
{
    public class VideoCMSResponseModel : BaseEntitySoftDeletable
    {
        public required string TieuDe { get; set; }
        public required string Link { get; set; }
        public TrangThaiVideo TrangThai { get; set; }
        public required DateTime NgayDang { get; set; }
        public bool HienThi { get; set; }
    }
}

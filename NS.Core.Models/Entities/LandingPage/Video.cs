using NS.Core.Commons;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities.LandingPage
{
    public class Video : BaseEntitySoftDeletable
    {
        public  string TieuDe { get; set; }
        public  string Link { get; set; }
        public  DateTime NgayDang { get; set; }
        public TrangThaiVideo TrangThai { get; set; }
        public bool HienThi { get; set; }
    }
}

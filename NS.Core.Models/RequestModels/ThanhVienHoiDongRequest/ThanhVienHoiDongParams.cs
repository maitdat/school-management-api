using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class ThanhVienHoiDongParams : BasePaginationRequestModel
    {
        public long HoiDongKhaoThiId { get; set; }
        public DateTime DateOpenFrom { get; set; } = DateTime.MinValue;
        public DateTime DateOpenTo { get; set; } = DateTime.MinValue;
        public DateTime DateCloseFrom { get; set; } = DateTime.MinValue;
        public DateTime DateCloseTo { get; set; } = DateTime.MinValue;
        public QuyenKhaoThi? QuyenKhaoThi { get; set; }
        public string SortBy { get; set; } = string.Empty;
        public bool? Status { get; set; }
    }
}

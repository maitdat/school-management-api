namespace NS.Core.Models.ResponseModels
{
    public class HoiDongKhaoThiDropdownModel
    {
        public long Id { get; set; }
        public string TenHoiDong { get; set; }

        public static HoiDongKhaoThiDropdownModel Mapping(NS.Core.Models.Entities.HoiDongKhaoThi model)
        {
            return new HoiDongKhaoThiDropdownModel
            {
                Id = model.Id,
                TenHoiDong = model.TenHoiDong,
            };
        }
    }
}

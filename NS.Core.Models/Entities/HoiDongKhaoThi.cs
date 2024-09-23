namespace NS.Core.Models.Entities
{
    public class HoiDongKhaoThi : Commons.BaseEntitySoftDeletable
    {
        public long KyTuyenSinhId { get; set; }
        public virtual KyTuyenSinh KyTuyenSinh { get; set; }
        public string TenHoiDong { get; set; }
    }
}
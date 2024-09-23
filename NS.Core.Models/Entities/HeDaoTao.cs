namespace NS.Core.Models.Entities
{
    public class HeDaoTao : Commons.BaseEntitySoftDeletable
    {
        public required string TenHeDaoTao { get; set; }
        public required string TenHeDaoTaoEnglish { get; set; }
        public virtual ICollection<MonThiTuyenSinh> MonThiTuyenSinhs { get; set; }
        public string MoTa { get; set; }
    }
}
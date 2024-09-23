using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels.CMSLandingPage
{
    public class CaiDatTongTheResponseModel
    {
        public long Id { get; set; }
        public long TrangId { get; set; }
        public string TieuDe { get; set; } = string.Empty;
        public string TieuDeTiengAnh { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public string MotaTiengAnh { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string LinkAnh { get; set; } = string.Empty;
        public List<CaiDatChitietResponseModel> CaiDatChiTiet { get; set; }

        public static CaiDatTongTheResponseModel Mapping(CaiDatTongThe model)
        {
            return new CaiDatTongTheResponseModel
            {
                Id = model.Id,
                TrangId = model.TrangId,
                Link = model.Link,
                Mota = model.Mota,
                MotaTiengAnh = model.MotaTiengAnh,
                TieuDe = model.TieuDe,
                TieuDeTiengAnh = model.TieuDeTiengAnh,

            };
        }
    }
}

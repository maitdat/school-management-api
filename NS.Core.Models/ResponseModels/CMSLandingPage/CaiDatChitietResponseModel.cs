using Microsoft.AspNetCore.Http;

namespace NS.Core.Models.ResponseModels.CMSLandingPage
{
    public class CaiDatChitietResponseModel
    {
        public long Id { get; set; }
        public long CaiDatTongTheId { get; set; }
        public string TieuDe { get; set; } = string.Empty;
        public string TieuDeTiengAnh { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
        public string MoTaTiengAnh { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public long? FileId { get; set; }
        public IFormFile File { get; set; }
        public string LinkAnh { get; set; } = string.Empty;

    }
}

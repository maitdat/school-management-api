using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.ResponseModels.LandingPage
{
    public class VideoResponseModel : BaseEntity
    {
        public required string TieuDe { get; set; }
        public required string Link { get; set; }
        public static VideoResponseModel Mapping(NS.Core.Models.Entities.LandingPage.Video video)
        {
            return new VideoResponseModel
            {
                Id = video.Id,
                Link = video.Link,
                TieuDe = video.TieuDe
            };
        }
    }
}

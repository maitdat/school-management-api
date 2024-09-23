using NS.Core.Commons;

namespace NS.Core.Models.RequestModels.landingPage
{
    public class VideoRequestModel
    {
        public int PageSize { get; set; } = Constants.DefaultValue.DEFAULT_PAGE_SIZE_VIDEO;
        public int PageNo { get; set; } = Constants.DefaultValue.DEFAULT_PAGE_NO;
    }
}

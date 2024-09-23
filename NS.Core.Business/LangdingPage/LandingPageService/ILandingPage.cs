using NS.Core.Models.ResponseModels.LandingPage;

namespace NS.Core.Business.LandingPageService
{
    public interface ILandingPage
    {
        Task<LandingPageResponseModel> GetDetail(long id);
        Task<ThoiGianBieuPageResponseModel> GetThoiGianBieu();
    }
}

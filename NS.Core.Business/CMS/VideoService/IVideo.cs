using NS.Core.Models.RequestModels.landingPage;
using NS.Core.Models.RequestModels.Video;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LandingPage;
using NS.Core.Models.ResponseModels.Video;

namespace NS.Core.Business.VideoService
{
    public interface IVideo
    {
        Task<BasePaginationResponseModel<VideoResponseModel>> GetAllVideo(VideoRequestModel model);
        Task<BasePaginationResponseModel<VideoCMSResponseModel>> GetAllVideoCMS(GetPageVideoResquestModel input);
        Task CreateVideo(VideoCMSRequestModel input);
        Task UpdateVideo(long idVideo, VideoCMSRequestModel input);
        Task DeleteVideo(long idVideo);
        Task DuyetVideo(long idVideo);
        Task HienThiVideo(long idVideo);
        Task<VideoCMSResponseModel> GetVideoById(long idVideo);
    }
}

using Microsoft.EntityFrameworkCore;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.landingPage;
using NS.Core.Models.RequestModels.Video;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LandingPage;
using NS.Core.Models.ResponseModels.Video;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.Business.VideoService
{
    public class VideoService : IVideo
    {
        private readonly AppDbContext _appDbContext;

        public VideoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateVideo(VideoCMSRequestModel input)
        {
            try
            {
                var newVideo = new Video()
                {
                    TieuDe = input.TieuDe,
                    Link = input.Link,
                    NgayDang = input.NgayDang,
                    TrangThai = Enums.TrangThaiVideo.TuChoi,
                    HienThi = false
                };
                _appDbContext.Video.Add(newVideo);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task UpdateVideo(long idVideo, VideoCMSRequestModel input)
        {
            try
            {
                Video videoUpdate = _appDbContext.Video.GetAvailableById(idVideo);
                videoUpdate.TieuDe = input.TieuDe;
                videoUpdate.Link = input.Link;
                videoUpdate.NgayDang = input.NgayDang;
                _appDbContext.Video.Update(videoUpdate);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND));
            }
        }
        public async Task DeleteVideo(long idVideo)
        {
            _appDbContext.Video.Delete(idVideo);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DuyetVideo(long idVideo)
        {
            Video videoDuyet = _appDbContext.Video.GetAvailableById(idVideo);
            videoDuyet.TrangThai = Enums.TrangThaiVideo.DaDuyet;
            _appDbContext.Video.Update(videoDuyet);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task HienThiVideo(long idVideo)
        {
            Video videoHienThi = _appDbContext.Video.GetAvailableById(idVideo);
            videoHienThi.HienThi = !videoHienThi.HienThi;
            _appDbContext.Video.Update(videoHienThi);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<VideoCMSResponseModel> GetVideoById(long idVideo)
        {
            try
            {
                var result = await _appDbContext.Video.Select(x => new VideoCMSResponseModel
                {
                    Id = x.Id,
                    TieuDe = x.TieuDe,
                    Link = x.Link,
                    TrangThai = x.TrangThai,
                    NgayDang = x.NgayDang,
                    HienThi = x.HienThi,
                    IsDeleted = x.IsDeleted,
                }).Where(x => x.Id == idVideo).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(KyTuyenSinh.Id)));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(KyTuyenSinh.Id)));
            }
        }
        public async Task<BasePaginationResponseModel<VideoResponseModel>> GetAllVideo(VideoRequestModel paramsModel)
        {
            IQueryable<Video> query = _appDbContext.Video.Where(e => !e.IsDeleted && e.TrangThai == Enums.TrangThaiVideo.DaDuyet && e.HienThi == true);

            int totalItems = 0;

            query = query.ApplyPaging(paramsModel.PageNo, paramsModel.PageSize, out totalItems);

            List<VideoResponseModel> videoList = await query.Select(e => VideoResponseModel.Mapping(e)).ToListAsync();

            int totalPages = (int)Math.Ceiling((double)totalItems / paramsModel.PageSize);

            return new BasePaginationResponseModel<VideoResponseModel>(paramsModel.PageNo, paramsModel.PageSize, videoList, totalItems);

        }

        public async Task<BasePaginationResponseModel<VideoCMSResponseModel>> GetAllVideoCMS(GetPageVideoResquestModel input)
        {
            var query = GetAllAvailable();
            query = ApplySearch(query, input);
            query = query.OrderByDescending(e => e.Id);

            int totalItems = 0;

            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<VideoCMSResponseModel> result = query
                    .Select(x => new VideoCMSResponseModel
                    {
                        Id = x.Id,
                        Link = x.Link,
                        TieuDe = x.TieuDe,
                        NgayDang = x.NgayDang,
                        TrangThai = x.TrangThai,
                        HienThi = x.HienThi,
                        IsDeleted = x.IsDeleted
                    })
                    .ToList();
            return new BasePaginationResponseModel<VideoCMSResponseModel>(input.PageNo, input.PageSize, result, totalItems);
        }

        private IQueryable<Video> GetAllAvailable()
        {
            var query = _appDbContext.Video

                .Where(e => !e.IsDeleted);
            return query;
        }
        private IQueryable<Video> ApplySearch(IQueryable<Video> query, GetPageVideoResquestModel input)
        {
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TieuDe.ToLower().Contains(keyword.ToLower()));
            }
            return query;
        }

    }
}

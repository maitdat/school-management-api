using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.TinTucRequest;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.TinTucServices
{
    public interface ITinTucServices
    {
        Task DeleteTinTuc(long id);
        Task<BasePaginationResponseModel<TinTucResponseModel>> GetPagedTinTuc(GetPagedTinTucRequestModel input);
        Task<BasePaginationResponseModel<TinTucResponseModel>> GetPagedTinTruyenThong(GetPagedTinTucRequestModel input);
        Task PheDuyetTinTuc(long id, TrangThaiTinTuc trangThai);
        Task<TinTucResponseModel> GetTinTucById(string id);
        Task ShowHideTinTuc(long id);
        List<TinTucResponseModel> GetAllTinTucNoiBat();
        Task CreateTinTuc(AddTinTucRequestModel data, string url);
        Task UpdateTinTuc(UpdateTinTucRequestModel data, string url);
        Task<BasePaginationResponseModel<TinTucResponseModel>> GetPagedTinTucActive(GetPagedTinTucRequestModel input);
        Task CreateBaiViet(AddTinTucRequestModel data, string url);
        Task UpdateBaiViet(UpdateTinTucRequestModel data, string url);
        Task<BasePaginationResponseModel<TinTucResponseModel>> GetPageBaiViet(GetPagedTinTucRequestModel input);

        Task CreateOrUpdateTinTuc(CreateOrUpdateTinTucRequestModel model);
    }
}
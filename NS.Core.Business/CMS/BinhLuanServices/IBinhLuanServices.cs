using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;
using NS.Core.Models.Entities;

namespace NS.Core.Business.BinhLuanServices
{
    public interface IBinhLuanServices
    {
        Task CreateBinhLuan(CreateOrUpdateBinhLuan data);
        Task UpdateBinhLuan(long id, CreateOrUpdateBinhLuan data);
        Task DeleteBinhLuan(long id);
        Task PheDuyetBinhLuan(long id, TrangThaiBinhLuan trangThai);
        Task<BasePaginationResponseModel<BinhLuanResponseModel>> GetPagedBinhLuan(GetPagedBinhLuanRequesModel input);
        Task<BinhLuanResponseModel> GetBinhLuanById(long id);
        Task ShowHideBinhLuan(long id);
        Task<BasePaginationResponseModel<BinhLuanResponseModel>> GetPagedBinhLuanActive(GetPagedBinhLuanRequesModel input);
    }
}
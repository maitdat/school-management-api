using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.TaiKhoanService
{
    public interface ITaiKhoanService
    {
        Task<TaiKhoanResponseModel> GetDetail(long id);
        Task<BasePaginationResponseModel<TaiKhoanResponseModel>> GetAll(BasePaginationRequestModel userParams);
        Task CreateOrUpdate(CreateOrUpdateTaiKhoanModel user);
        Task Delete(long id);
    }
}

using NS.Core.Models.RequestModels.NoiQuyRequest;
using NS.Core.Models.ResponseModels.NoiQuy;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.NoiQuyService
{
    public interface INoiQuyService
    {
        Task CreateNoiQuy(CreateOrUpdateNoiQuyRequest data);
        Task UpdateNoiQuy(long id, CreateOrUpdateNoiQuyRequest data);
        Task DeleteNoiQuy(long id);
        Task<BasePaginationResponseModel<NoiQuyResponseModel>> GetPageNoiQuy(GetPagedNoiQuyRequest page);
        Task<NoiQuyResponseModel> GetById(long id);
    }
}
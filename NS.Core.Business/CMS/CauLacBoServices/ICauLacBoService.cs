using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.CauLacBoServices;

public interface ICauLacBoService
{
    Task<List<CauLacBoResponseModel>> GetAll();
    Task<CauLacBoResponseModel> GetById(long id);
    Task CreateCauLacBo(CauLacBoRequestModel input);
    Task EditCauLacBo(CauLacBoRequestModel input);
    Task<CauLacBoRequestModel> CreateAnhCauLacBo();
    Task DeleteCauLacBo(long id);
}
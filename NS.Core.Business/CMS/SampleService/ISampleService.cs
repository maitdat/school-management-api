using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.SampleService
{
    public interface ISampleService
    {
        Task<BasePaginationResponseModel<SampleData>> GetAll(SampleRequestModel input);
    }
}
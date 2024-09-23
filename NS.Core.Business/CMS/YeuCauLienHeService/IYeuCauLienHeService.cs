using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.YeuCauLienHeService
{
    public interface IYeuCauLienHeService
    {
        Task<List<YeuCauLienHeResponseModel>> GetAll();
        Task<BasePaginationResponseModel<YeuCauLienHeResponseModel>> GetPagedYeuCauLienHe(GetPagedYeuCauLienHeRequestModel input);
        Task<List<YeuCauLienHeResponseModel>> GetAllAvailable();
        Task<YeuCauLienHeResponseModel> GetById(long id);
        Task Create (YeuCauLienHeRequestModel yeuCauLienHeRequestModel);
        Task ChangeRespondedStatus(long id);
        Task<YeuCauLienHeResponseModel> YeuCauLienHeDetail(long id);
        Task Delete(long id);
    }
}

using NS.Core.Models.RequestModels.SuKienSapToiRequestModel;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.CMS
{
    public interface ISuKienSapToiService
    {
        Task<BasePaginationResponseModel<SukienSapToiResponseModel>> GetPagedSuKíenSapToi(
           GetPagedSuKienSapToiRequestModel input);
        Task CreateSuKien(SuKienSapToiRequestModel input);
        Task UpdateSukien(SuKienSapToiRequestModel input);
        Task DeleteSuKien(long id);
        Task<SukienSapToiResponseModel> GetSukienById(long id);

    }
}

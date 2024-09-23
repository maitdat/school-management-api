using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.MonThiService
{
    public interface IMonThiService
    {
        Task<List<MonThiResponseModel>> GetMonHocAsync();

        Task<MonThiResponseModel> RemoveMonThi(long id);
        Task<BasePaginationResponseModel<MonThiResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel page);

        Task<MonThiResponseModel> UpdateMonThi(MonThiRequestModel monThi, long id);

        Task<MonThiResponseModel> AddNewMonThi(MonThiRequestModel monThi);

        Task<BasePaginationResponseModel<MonThiResponseModel>> GetPageMonThi(GetPageMonThiRequestModel input);
    }
}

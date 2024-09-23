using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.NamHocService
{
    public interface INamHocService
    {
        Task<NamHocResponseModel> GetNamHocById(long id);
        Task<List<NamHocResponseModel>> GetNamHocAsync();
        Task<List<NamHocResponseModel>> GetAvailableNamHoc();
        Task<NamHocResponseModel> AddNewNamHoc(NamHocRequestModel namHoc);
        Task<NamHocResponseModel> UpdateNamHoc(NamHocRequestModel namHoc, long id);
        Task<NamHocResponseModel> DeleteNamHoc(long id);
        Task<BasePaginationResponseModel<NamHocResponseModel>> GetPagedNamHoc(GetPageNamHocResquestModel input);
    }
}

using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.GocTruyenThong;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.GocTruyenThong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.GocTruyenThongService
{
    public interface IGocTruyenThongService
    {
        List<GocTruyenThongResponseModel> GetAllAvailable();
        GocTruyenThongResponseModel GetById(long id);
        Task Create(GocTruyenThongRequestModel model);
        Task Update(long id, GocTruyenThongRequestModel model);
        Task Delete(long id);
        Task CreateCMS(GocTruyenThongCMSRequestModel data);
        Task UpdateCMS(EditGocTruyenThongCMSRequestModel model);
        Task<BasePaginationResponseModel<GocTruyenThongResponseModel>> GetPaged(GetPagedGocTruyenThongReqModel page);
        List<SuKienTruyenThongNoiBatResModel> GetSuKienTruyenThongNoiBat();
    }
}
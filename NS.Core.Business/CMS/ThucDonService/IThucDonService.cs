using NS.Core.Models.RequestModels.ThucDon;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.ThucDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.ThucDonService
{
    public interface IThucDonService
    {
        Task<List<ThucDonResponseModel>> GetAll();
        Task<ThucDonResponseModel> GetById(long id);
        Task<List<ThucDonResponseModel>> GetAllAvailable();
        Task<BasePaginationResponseModel<ThucDonResponseModel>> GetPagedThucDon(GetPagedThucDonRequestModel model);
        Task Create (ThucDonRequestModel model,string url);
        Task UpdateThucDon(long id, ThucDonRequestModel model,string url);
        Task UpdateChiTietThucDon(long id, ChiTietThucDonRequestModel model);
        Task Delete (long id);
        Task<List<ThucDonResponseModel>> GetRelatedThucDon(DateTime startDate);
    }
}

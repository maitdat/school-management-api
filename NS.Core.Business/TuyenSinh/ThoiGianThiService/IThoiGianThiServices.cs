using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.ThoiGianThiService
{
    public interface IThoiGianThiServices
    {
        Task<ThoiGianThiResponseModel> GetThoiGianThiById(long id);
        Task CreateThoiGianThi(CreateThoiGianThiRequestModel input);
        Task UpdateThoiGianThi(long id, UpdateThoiGianThiRequestModel input);
        Task DeleteThoiGianThi (long id);
        Task<BasePaginationResponseModel<ThoiGianThiResponseModel>> GetPagedThoiGianThi(GetPagedThoiGianThiRequestModel input);
        Task<BasePaginationResponseModel<ThoiGianThiResponseModel>> GetPagedThoiGianThiByKyTuyenSinhId(GetPagedThoiGianThiByKyTuyenSinhIdRequestModel input);
    }
}

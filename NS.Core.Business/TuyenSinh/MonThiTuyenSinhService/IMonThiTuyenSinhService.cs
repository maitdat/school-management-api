using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.MonThiTuyenSinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.MonThiTuyenSinhService
{
    public interface IMonThiTuyenSinhService
    {
        Task AddMonThiTuyenSinh(AddOrUpdateMonThiTuyenSinhRequestModel newMonThi);
        Task UpdateMonThiTuyenSinh(long id,AddOrUpdateMonThiTuyenSinhRequestModel updateMonThi);
        Task DeleteMonThiTuyenSinh(long id);
        Task<List<GetTenMonThiTuyenSinhResponseModel>> GetMonThi();
        MonThiTuyenSinhResponseModel GetById(long id);
        Task<BasePaginationResponseModel<MonThiTuyenSinhResponseModel>> GetAvailableAndPaging(MonThiTuyenSinhPagedModel paramsModel);
        Task<List<KyTuyenSinhDropdownModel>> GetKyTuyenSinhAvailableForDropDown();
        Task<List<LopDuThiDropDownModel>> GetLopDuThiAvailableForDropDown();
        Task<List<MonThiDropDownModel>> GetMonThiAvailableForDropDown();
        Task<List<HeDaoTaoDropDownModel>> GetHeDaoTaoAvailableForDropDown();
 
    }
}

using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.KyTuyenSinhService
{
    public interface IKyTuyenSinhService
    {
        Task<KyTuyenSinhResponseModel> GetKyTuyenSinhById(long itemId);
        Task<List<KyTuyenSinhResponseModel>> GetAll();
        Task<BasePaginationResponseModel<KyTuyenSinhResponseModel>> GetPagedKyTuyenSinh(KyTuyenSinhRequestModel input);
        Task CreateKyTuyenSinh(CreateOrUpdateKyTuyenSinhModel data);
        Task UpdateKyTuyenSinh(long id, CreateOrUpdateKyTuyenSinhModel data);
        Task DeleteKyTuyenSinh(long id);
        Task<List<NamHocResponseModel>> GetNamHocForDropdown();
        Task<List<KhoiReponseModel>> GetKhoiForDropdown();
    }
}

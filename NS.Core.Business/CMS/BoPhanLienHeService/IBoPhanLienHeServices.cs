using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.BoPhanLienHeService
{
    public interface IBoPhanLienHeServices
    {
        Task<List<BoPhanLienHeResponseModel>> GetAll();
        Task<List<BoPhanLienHeResponseModel>> GetAllAvailable();
        Task<List<BoPhanLienHeResponseModel>> Search(string keyword);
        Task<BoPhanLienHeResponseModel> GetById(long id);
        Task Create(BoPhanLienHeRequestModel boPhanLienHeRequestModel);
        Task Update(long id, BoPhanLienHeRequestModel boPhanLienHeRequestModel);
        Task Delete(long id);
    }
}

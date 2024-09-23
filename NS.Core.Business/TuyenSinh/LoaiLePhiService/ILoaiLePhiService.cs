using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.LoaiLePhiService
{
    public interface ILoaiLePhiService
    {
        Task<List<LoaiLePhiResponseModel>> GetAllLoaiLePhi();
        Task<LoaiLePhiResponseModel> AddNewLoaiLePhi(LoaiLePhiRequestModel lePhi);
        Task<LoaiLePhiResponseModel> UpdateLoaiLePhi(long id, LoaiLePhiRequestModel lePhi);
        IQueryable<LoaiLePhi> GetLoaiLePhiById(long id);
        void DeleteLoaiLePhi(long id);
        Task<List<LoaiLePhiResponseModel>> GetAvailableLoaiLePhi();
        Task<BasePaginationResponseModel<LoaiLePhiResponseModel>> GetPagedLoaiLePhi(GetPageLoaiLePhiRequestModel input);
    }
}

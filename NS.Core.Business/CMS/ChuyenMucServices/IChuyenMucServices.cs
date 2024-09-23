using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.NhanVien;
using NS.Core.Models.ResponseModels.NhanVien;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.ChuyenMucServices
{
    public interface IChuyenMucServices
    {
        Task<List<ChuyenMucResponeModel>> GetAll();
        Task<ChuyenMucResponeModel> GetById(long id);
       Task<BasePaginationResponseModel<ChuyenMucResponeModel>> GetPagedChuyeMuc(GetPageChuyenMucResponseModel input);
        Task AddNewChuyenMuc(CreateChuyenMucRequestModel newChuyenMuc);
        Task UpdateChuyenMuc(long id, CreateChuyenMucRequestModel updatedChuyenMuc);
        Task DeleteChuyenMuc(long id);       
    }
}

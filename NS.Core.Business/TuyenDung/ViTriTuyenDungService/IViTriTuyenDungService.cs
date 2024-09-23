using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.ViTriTuyenDungService
{
    public interface IViTriTuyenDungService
    {
        Task CreateViTriTuyenDung(ViTriTuyenDungResquestModel input);
        Task EditViTriTuyenDung(long id,ViTriTuyenDungResquestModel input);
        Task DeleteViTriTuyenDung(long id);
        Task<BasePaginationResponseModel<ViTriTuyenDungResponseModel>> GetPagedViTriTuyenDung(GetPagedViTriTuyenDungResquestModel input);
        Task<ViTriTuyenDungResponseModel> GetByIdForDialog(long id);
        Task<List<ViTriTuyenDungResponseModel>> GetAllForDropDown();
    }
}
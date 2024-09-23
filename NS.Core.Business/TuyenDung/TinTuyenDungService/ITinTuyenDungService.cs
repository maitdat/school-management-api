
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.TinTuyenDungService
{
    public interface ITinTuyenDungService
    {

        Task<BasePaginationResponseModel<TinTuyenDungResponseModel>> GetPagedTinTuyenDung(GetPagedTinTuyenDungResquestModel input);
        Task CreateTinTuyenDung(TinTuyenDungResquestModel input);
        Task EditTinTuyenDung(long id, TinTuyenDungResquestModel input);
        Task DeleteTinTuyenDung(long id);
        Task CapNhatTrangThaiTuyenDung(long id, Enums.TrangThaiTinTuyenDung trangThai);
        Task<TinTuyenDungResponseModel> GetByIdForDialog(long id);
    }
}

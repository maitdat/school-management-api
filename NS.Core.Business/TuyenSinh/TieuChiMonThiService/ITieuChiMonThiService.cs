using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.TieuChiMonThiService
{
    public interface ITieuChiMonThiService
    {
        Task AddTieuChiMonThi(AddOrUpdateTieuChiMonThiRequestModel newTieuChi);
        Task UpdateTieuChiMonThi(long id, AddOrUpdateTieuChiMonThiRequestModel updateTieuChi);
        Task DeleteTieuChiMonThi(long id);
        Task<BasePaginationResponseModel<TieuChiMonThiResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel paramsModel);
        IQueryable<TieuChiMonThi> GetAll();
        TieuChiMonThiResponseModel GetById(long id);
        Task<List<MonThiDropDownResponseModel>> GetMonThiTuyenSinhAvailableForDropDown();
        Task<List<TieuChiDanhGiaDropDownModel>> GetTieuChiDanhGiaAvailableForDropDown();
    }
}

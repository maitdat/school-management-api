using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.TieuChiDanhGiaService
{
    public interface ITieuChiDanhGiaService
    {
        Task AddTieuChiDanhGia(AddOrUpdateTieuChiDanhGiaRequestModel newTieuChi);
        Task UpdateTieuChiDanhGia(long id, AddOrUpdateTieuChiDanhGiaRequestModel updateTieuChi);
        Task DeleteTieuChiDanhGia(long id);
        Task<BasePaginationResponseModel<TieuChiDanhGiaResponseModel>> GetAllAndPagingTieuChi(BasePaginationRequestModel page);
        IQueryable<TieuChiDanhGia> GetAll();
        Task<BasePaginationResponseModel<TieuChiDanhGiaResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel paramsModel);
        TieuChiDanhGiaResponseModel GetById(long id);
    }
}

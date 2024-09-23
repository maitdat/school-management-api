using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.QuyDoiDiemService
{
    public interface IQuyDoiDiemService
    {
        Task AddQuyDoiDiem(AddOrUpdateQuyDoiDiemRequestModel newQuyDoiDiem);
        Task UpdateQuyDoiDiem(long id, AddOrUpdateQuyDoiDiemRequestModel updateQuyDoiDiem);
        Task DeleteQuyDoiDiem(long id);
        IQueryable<QuyDoiDiem> GetAll();
        Task<BasePaginationResponseModel<QuyDoiDiemResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel paramsModel);
        QuyDoiDiemResponseModel GetById(long id);
        Task<List<MonThiQuyDoiDiemDropDownModel>> GetMonThiTuyenSinhAvailableForDropDown();
    }
}

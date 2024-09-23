using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.HoSoTuyenDungService
{
    public interface IHoSoTuyenDungService
    {
        IQueryable<HoSoTuyenDung> GetAll();
       Task AddHoSoTuyenDung(HoSoTuyenDungRequestModel hoSoTuyenDung);
        IQueryable<HoSoTuyenDung> GetAllAvailable();
        HoSoTuyenDungResponseModel GetHoSoTuyenDung(long id);
        Task<BasePaginationResponseModel<HoSoTuyenDungResponseModel>> GetListHoSoTuyenDung(BasePaginationRequestModel page);
        Task DeleteHoSoTuyenDung(long id);
        Task UpdateHoSoTuyenDung(long id,HoSoTuyenDungRequestModel hoSoTuyenDungRequestModel);
        Task UpdateStatus(long id, TrangThaiHoSoTuyenDung hoSoTuyenDung);
    }
}
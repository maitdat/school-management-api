using NS.Core.Models.ResponseModels;
using NS.Core.Models.Entities;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;

namespace NS.Core.Business.HoSoTuyenSinhService
{
    public interface IHoSoTuyenSinhService
    {
        Task<BasePaginationResponseModel<HoSoTuyenSinhResponseModel>> GetPagedHoSo(GetPagedHoSoTuyenSinhRequestModel input);
        IQueryable<HoSoTuyenSinhResponseModel> GetAllAvailable();
        Task<HoSoTuyenSinhDetailsResponseModel> GetChiTietHoSoTuyenSinh(long id);
        Task<HoSoThiResponseModel> GetHoSoThiById(long id);
        Task<List<HoSoTuyenSinhResponseModel>> GetHoSoTheoTaiKhoan(long taiKhoanId);
        //Task ExportToXlsx();
        Task UpdateTrangThaiHoSoTS(long id, int index);
        Task UpdateListTrangThaiHoSoTS(List<HoSoTuyenSinhResponseModel> hoSo, int index);
        Task UpdateHoSoTuyenSinh(long id, CreateOrUpdateHoSoRequestModel hoSo);
        Task CreateHoSoTuyenSinh(CreateOrUpdateHoSoRequestModel hoSo);
        Task DeleteListHoSoTuyenSinh(List<HoSoTuyenSinh> id);
        Task<BasePaginationResponseModel<HoSoTrungResponseModel>> GetPagedHoSoTrung(GetPagedHoSoTrungRequestModel input);
        Task GhepHoSo(long id, List<long> input);
        Task DeleteHoSoTuyenSinh(List<long> id);
        Task<BasePaginationResponseModel<DanhSachDuThiResponseModel>> GetDanhSachDuThiAndPaging(GetDanhSachDuThiAndPagingAndFilterRespuestModel paramsModel);
        Task<List<HeDaoTaoDropDownModel>> GetHeDaoTaoAvailableForDropDown();
        Task<List<LopDangKiDropDownResponseModel>> GetLopDangKiAvailableForDropDown();
        Task<List<TrangThaiDuThiDropDownResponseModel>> GetTrangThaiDuThiAvailableForDropDown();
        Task<List<TheDuThiShowResponseModel>> GetTheDuThiAvailableForDropDown();
        Task<List<KyTuyenSinhDropdownModel>> GetKyTuyenSinhAvailableForDropDown();
        Task DeleteListHoSoTuyenSinh(List<long> id);
        Task<BasePaginationResponseModel<HoSoTuyenSinhResponseModel>> GetPagedHoSoTuyenSinhByKyTuyenSinhId(GetPagedHoSoTuyenSinhByKyTuyenSinhIdRequestModel input);
    }
}

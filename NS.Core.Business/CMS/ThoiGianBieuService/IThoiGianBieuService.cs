using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.ThoiGianBieuRequestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LandingPage;


namespace NS.Core.Business.ThoiGianBieuService
{
    public interface IThoiGianBieuService
    {
        Task<LoaiSuKienResponseModel> GetLoaiSuKienById(long id);
        Task<LichSuKienResponseDetail> GetLichSuKienById(long id);
        Task<ThoiGianBieuResponseModel> GetThoiGianBieuById(long id);
        Task DeleteThoiGianBieu(long id);
        Task DeleteLichSuKien(long id);
        Task DeleteLoaiSuKien(long id);
        Task<List<LoaiSuKienResponseModel>> GetAllLoaiSuKien();
        Task<BasePaginationResponseModel<LichSuKienResponseModel>> GetAllLichSuKien(LichSuKienRequestModel page);
        Task<BasePaginationResponseModel<ThoiGianBieuResponseModel>> GetAllThoiGianBieu(ThoiGianBieuRequestModel model);
        Task AddChangeThoiGianBieu(CreateOrUpdateThoiGianBieuRequestModel data);
        Task AddChangeLoaiSuKien(CreateOrUpDateLoaiSuKienRequestModel data);
        Task AddChangeLichSuKien(CreateOrUpdateLichSuKienRequestModel data);
    }
}
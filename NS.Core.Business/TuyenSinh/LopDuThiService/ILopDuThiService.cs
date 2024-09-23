using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.LopDuThi;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LopDuThi;

namespace NS.Core.Business.LopDuThiService
{
    public interface ILopDuThiService
    {
        Task<LopDuThiResponseModel> GetById(long id);
        Task Delete(long id);
        Task<BasePaginationResponseModel<LopDuThiResponseModel>> GetAll(BasePaginationRequestModel page);
        Task AddChange(CreateAndUpdateLopDuThiRequestModel model);
        Task<BasePaginationResponseModel<ThanhVienHoiDongForDropdownResponModel>> GetAllThanhVienHoiDong(GetAllThanhVienHoiDongRequestModel model);
        Task AddGiaoVien(AddGiaoVienToLopDuThiRequestModel model);
        Task DeleteGiaoVien(long id);
    }
}

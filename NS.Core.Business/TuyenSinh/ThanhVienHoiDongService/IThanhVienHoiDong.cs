using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.ThanhVienHoiDongService
{
    public interface IThanhVienHoiDong
    {
        Task<BasePaginationResponseModel<ThanhVienHoiDongResponseModel>> GetAllByHoiDongKhaoThiId(ThanhVienHoiDongParams paramsModel);
        Task<ThanhVienHoiDongResponseModel> GetDetail(long id);
        Task Create(CreateThanhVienHoiDongModel model);
        Task Update(UpdateThanhVienHoiDongModel model);
        Task Delete(long id);
        Task<List<HoiDongKhaoThiDropdownModel>> GetHoiDongKhaoThiDropdown();

    }
}

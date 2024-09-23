using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.HoiDongKhaoThiService
{
    public interface IHoiDongKhaoThiService
    {
        public void CreateHoiDongKhaoThi(CreateOrUpdateHoiDongKhaoThiModel data);
        public void UpdateHoiDongKhaoThi(long id, CreateOrUpdateHoiDongKhaoThiModel data);
        public void DeleteHoiDongKhaoThi(long id);
        public Task<HoiDongKhaoThiResponseModel> GetById(long id);
        public IQueryable<HoiDongKhaoThi> GetAll();
        public Task<BasePaginationResponseModel<HoiDongKhaoThiResponseModel>> GetPaged(BasePaginationRequestModel input);
    }
}
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.PhongBanRequestModel;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business
{
    public interface IPhongBanService
    {
        List<PhongBanResModel> GetAllPhongBan();
        Task<BasePaginationResponseModel<PhongBanResModel>> GetPagePhongBan(BasePaginationRequestModel page);
        void Delete(long id);
        void Update(long id, PhongBanRequestModel model);
        void Create(PhongBanRequestModel model);
        PhongBanResModel GetPhongBanById(long id);
        Task<List<PhongBanResModel>> GetPhongBanByLoaiPhongBan(LoaiPhongBan loaiPhongBan);
        void ChangeShowHidePhongBan(long id);
        Task<List<PhongBanResModel>> GetPhongBanByLoaiPhongBanActive(LoaiPhongBan loaiPhongBan);
    }
}
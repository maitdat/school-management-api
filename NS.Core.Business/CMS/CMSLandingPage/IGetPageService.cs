using NS.Core.Models.RequestModels.CMSLandingPage;
using NS.Core.Models.RequestModels.QuyDinhNhapHocReqestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.CMSLandingPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.CMSLandingPage
{
    public interface IGetPageService
    {
        Task<BasePaginationResponseModel<CaiDatChitietResponseModel>> GetPagedCaiDatChiTiet(long caiDatTongTheId, GetPagedCaiDatChiTietRequestModel input);
        Task<List<CaiDatTongTheResponseModel>> GetCaiDatTongThe(long trangId);
        Task EditCaiDatTongThe(long caiDatTongTheId, CaiDatTongTheRequestModel input);
        Task UpdateCaiDatChiTiet(long caiDatChiTietId, CaiDatChiTietRequestModel input);
        Task DeleteCaiDatChiTiet(long caiDatChiTietId);
        Task CreateCaiDatChiTiet(long caiDatTongTheId, CaiDatChiTietRequestModel input);
        Task<CaiDatChitietResponseModel> GetCaiDatChiTietById(long caiDatChitietId);
        Task<CaiDatTongTheResponseModel> GetCaiDatTongTheById(long id);
        Task CreateCaiDatTongThe(long trangId, CaiDatTongTheRequestModel input);
        Task DeleteCaiDatTongThe(long caiDatTongThe);

        Task UpdateQuyDinhNhapHoc(QuyDinhNhapHocRequestModel model);
    }
}

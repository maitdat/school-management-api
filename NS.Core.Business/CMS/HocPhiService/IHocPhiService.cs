using NS.Core.Models.RequestModels.HocPhi;
using NS.Core.Models.RequestModels.HocPhiRequestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.HocPhiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.HocPhiService
{
    public interface IHocPhiService
    {
        //Task<List<HocPhiResponseModel>> GetAll();
        //Task<HocPhiResponseModel> GetById(long id);
        //Task Create(HocPhiRequestModel model);
        //Task Update(long id, HocPhiRequestModel model);
        //Task Delete(long id);
        NamHocPhiResModel GetByNamHocId(long namHocId);
        void CreateOrUpdateHocPhiByNamHocId(NamHocPhiReqModel input);
        Task DeleteHocPhi(long hocPhiId);
        List<NamHocPhiResModel> GetAllNamHocPhi();
        ChiTietHocPhiResModel GetChiTieHocPhiById(long id);
        Task<List<HeDaoTaoResponseModel>> GetHeDaoTaoForDropDown();
        Task CreateHocPhi( HocPhiRequestModel input);
        Task<List<HocPhiResponseModel>> GetAllHocPhi();
        Task UpdateHocPhi(long id, UpdateHocPhiReqModel data);

    }
}

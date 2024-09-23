using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.ThanhTichNoiBat;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.ThanhTichNoiBatResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.CMS.ThanhTichNoiBatService
{
    public interface IThanhTichNoiBatService
    {
        public Task<BasePaginationResponseModel<GetThanhTichNoiBatResponseModel>> GetPage(BasePaginationRequestModel data);
        public Task Delete(long id);
        public Task Create(CreateOrUpdateThanhTichNoiBat data);
        public Task Update(CreateOrUpdateThanhTichNoiBat data, long id);
        public Task<GetThanhTichNoiBatResponseModel> GetById(long id);
        public Task<List<GetThanhTichNoiBatResponseModel>> GetAll();
    }
}

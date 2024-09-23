using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.HeDaoTaoService
{
    public interface IHeDaoTaoService
    {
        Task<HeDaoTaoResponseModel> GetById(long idItem);
        Task<List<HeDaoTaoResponseModel>> GetAll();
        Task CreateHeDaoTao(CreateOrUpdateHeDaoTaoModel data);
        Task UpdateHdt(long id, CreateOrUpdateHeDaoTaoModel data);
        Task<BasePaginationResponseModel<HeDaoTaoResponseModel>> GetPagedHeDaoTao(HeDaoTaoRequestModel input);
        Task DeleteHdt(long id);
        
    }
}

using NS.Core.Models.ResponseModels.CoSoVatChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.CoSoVatChatService
{
    public interface ICoSoVatChatService
    {
        Task<CoSoVatChatResponseModel> GetById (long id);
        Task<List<CoSoVatChatResponseModel>> GetAll();
        Task<List<CoSoVatChatCMSResponseModel>> GetAllLandingPage();
    }
}

using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.EmailTemplateRequestModel;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.EmailConfigServices
{
    public interface IEmailConfigServices
    {
        IQueryable<CaiDatEmail> GetAllAvailable();
        Task<BasePaginationResponseModel<EmailConfigResponseModel>> GetAllListEmailPage(GetPagedEmailTemplateAndFilter page);
        EmailConfigResponseModel GetById(long id);
        Task AddNewEmailConfig(EmailConfigRequestModel newEmail);
        Task UpdateEmailConfig(long id, EmailConfigRequestModel updateEmail);
        Task DeleteEmail(long id);
        Task<List<EmailConfigResponseModel>> GetAll();
    }
}

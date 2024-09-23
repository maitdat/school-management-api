using NS.Core.Models.Entities;

namespace NS.Core.Business.MailService
{
    public interface IMailService
    {
        Task SendEmailAsync(string mailTo, CaiDatEmail caiDatEmail);
    }
}

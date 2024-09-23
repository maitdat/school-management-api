using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business
{
    public interface IAuthService
    {
        Task<LoginResponseModel> Login(SignInData data);
        Task Register(RegisterData data,string origin);
        Task ChangePassword(ChangePasswordData data);
        Task ForgotPassword(ForgotPasswordModel data, string origin);
        Task VerifyEmail(Guid guid);
    }
}
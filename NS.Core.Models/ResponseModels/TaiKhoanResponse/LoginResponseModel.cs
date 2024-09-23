namespace NS.Core.Models.ResponseModels
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public TaiKhoanResponseModel UserData { get; set; }
    }
}

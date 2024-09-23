namespace NS.Core.Models.RequestModels
{
    public class ChangePasswordData
    {
        public required Guid Key { get; set; }
        public required string MatKhau { get; set; }
    }
}

namespace NS.Core.Models.RequestModels
{
    public class ChamThiRequestModel
    {
        public long HoSoThiId { get; set; }
        public List<MonThiTuyenSinhRequestModel> ListMonThiTuyenSinh { get; set; }
    }
}

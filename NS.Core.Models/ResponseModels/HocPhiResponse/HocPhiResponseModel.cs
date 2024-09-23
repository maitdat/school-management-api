using NS.Core.Commons;
using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels.HocPhiResponse
{
    public class HocPhiResponseModel
    {
        public long Id { get; set; }
        public long NamHocPhiId { get; set; }
        public string TenNamHoc { get; set; }
        public long HeDaoTaoId { get; set; }
        public string MoHinhLop { get; set; }
        public string MoHinhLopTiengAnh { get; set; }
        public string Lop { get; set; }
        public int TienHocPhi { get; set; }
        public static HocPhiResponseModel Mapping(HocPhi model)
        {
            HocPhiResponseModel hocPhiResponseModel = new HocPhiResponseModel()
            {
                Id = model.Id,
                NamHocPhiId = model.NamHocPhiId,
                TenNamHoc = model.NamHocPhi.NamHoc.TenNamHoc,
                HeDaoTaoId = model.HeDaoTaoId,
                Lop = model.Lop,
                TienHocPhi = model.TienHocPhi
            };
            return hocPhiResponseModel;
        }
    }
}

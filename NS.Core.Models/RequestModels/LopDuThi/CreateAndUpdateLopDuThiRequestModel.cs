using NS.Core.Models.Entities;
using NS.Core.Commons;
using Microsoft.IdentityModel.Tokens;

namespace NS.Core.Models.RequestModels
{
    public class CreateAndUpdateLopDuThiRequestModel : BaseEntity
    {
        public long GiaoVienTrongThi { get; set; }
        public long ThoiGianThiId { get; set; }
        public int SoLuong { get; set; }
        public int ConTrong { get; set; }
        public string TenLop { get; set; }
        public Entities.LopDuThi Mapping(Entities.LopDuThi model)
        {
            Id = model.Id;
            model.ConTrong = ConTrong;
            model.ThoiGianThiId = ThoiGianThiId;
            model.SoLuong = SoLuong;
            model.TenLop = TenLop;

            if (model.GiaoVienTrongThi.IsNullOrEmpty())
            {
                model.GiaoVienTrongThi = new List<GiaoVienTrongThi>()
                {
                    new GiaoVienTrongThi
                    {
                        LaGiaoVienChinh = true,
                        ThanhVienHoiDongId = GiaoVienTrongThi
                    }
                };
            }
            else
            {
                model.GiaoVienTrongThi
                .Add(new GiaoVienTrongThi
                {
                    LaGiaoVienChinh = true,
                    ThanhVienHoiDongId = GiaoVienTrongThi
                });
            }

            return model;
        }
    }
    public class GiaoVienTrongThiModel
    {
        public long ThanhVienHoiDongId { get; set; }
        public bool LaGiaoVienChinh { get; set; }
    }

}

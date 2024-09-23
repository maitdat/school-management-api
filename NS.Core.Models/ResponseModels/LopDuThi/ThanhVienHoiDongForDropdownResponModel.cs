using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.LopDuThi
{
    public class ThanhVienHoiDongForDropdownResponModel : BaseEntity
    {
        public string GiaoVienTrongThi { get; set; }
        public bool LaGiaoVienChinh { get; set; }
        public static ThanhVienHoiDongForDropdownResponModel Mapping(ThanhVienHoiDong model)
        {
            return new ThanhVienHoiDongForDropdownResponModel
            {
                Id = model.Id,
                GiaoVienTrongThi = model.TaiKhoan,
                LaGiaoVienChinh = model.GiaoVienTrongThi?.LaGiaoVienChinh ?? false,
            };
        }
    }

}
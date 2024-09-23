using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class HoSoThiResponseModel
    {
        public long HoSoTuyenSinhId { get; set; }
        public long Id { get; set; }
        public long LopDuThiId { get; set; }
        public string SoBaoDanh { get; set; }
        public string HoTen { get; set; }
        public string AnhHoSo { get; set; }

        public TrangThaiDuThi TrangThaiDuThi { get; set; }
        public TrangThaiKetQua TrangThaiKetQua { get; set; }

    }
}

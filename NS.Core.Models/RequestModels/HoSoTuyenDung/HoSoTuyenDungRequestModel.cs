using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class HoSoTuyenDungRequestModel
    {
        public long TaiKhoanId { get; set; }
        public long ViTriTuyenDungId { get; set; }
        public string AnhHoSo { get; set; }
        public string FileCV { get; set; }
        public TrangThaiHoSoTuyenDung TrangThai { get; set; } = Enums.TrangThaiHoSoTuyenDung.DangChoDuyet;
        public List<ChungChiLienQuanRequestModel> ChungChiLienQuan { get; set; }
        public List<ViTriBoSungRequestModel> ViTriBoSung { get; set; }
    }
}

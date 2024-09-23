
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class HoSoTuyenDungResponseModel
    {
        public long Id { get; set; }
        public long TaiKhoanId { get; set; }
        public long ViTriTuyenDungId { get; set; }
        public string ViTriTuyenDung { get; set; }
        public string AnhHoSo { get; set; }
        public string FileCV { get; set; }
        public TrangThaiHoSoTuyenDung TrangThai { get; set; }
        public List<ChungChiLienQuanResponseModel>? ChungChiLienQuan { get; set; }
        public List<ViTriBoSungResponseModel>? ViTriBoSung { get; set; }
    }
}

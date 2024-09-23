using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class KetQuaThiResponseModel
    {
        public long MonThiTuyenSinhId { get; set; }
        public long HoSoThiId { get; set; }
        public long TieuChiDanhGiaId { get; set; }
        public long TieuChiMonThiId { get; set; }   
        public long ThanhVienHoiDongId { get; set; }
        public int Diem { get; set; }
        public string QuyDoi { get; set; }
        public string NhanXet { get; set; }
    }
}

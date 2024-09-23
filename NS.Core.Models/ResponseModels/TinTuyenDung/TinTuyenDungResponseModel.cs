using NS.Core.Models.RequestModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class TinTuyenDungResponseModel
    {
        public long Id { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungTiengAnh { get; set; }
        public TrangThaiTinTuyenDung TrangThai { get; set; }
        public DateTime NgayHetHan { get; set; }
        public List<TuyenDungViTriResponseModel> TuyenDungViTriResponseModels { get; set; }
    }
}

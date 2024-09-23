using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class TinTuyenDungResquestModel
    {
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungTiengAnh { get; set; }
        public DateTime NgayHetHan { get; set; }
        public TrangThaiTinTuyenDung TrangThai { get; set; } = TrangThaiTinTuyenDung.DangChoDuyet;
        public List<long> ViTriTuyenDungIds { get; set; }
    }
}

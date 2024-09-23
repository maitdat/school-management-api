using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.CaiDatTrang
{
    public class CaiDatTongTheRequestModel
    {
        public long Id { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string Mota { get; set; }
        public string MotaTiengAnh { get; set; }
        public string Link { get; set; }
        public ICollection<CaiDatChiTietRequestModel> CaiDatChiTiet{ get; set; }
    }
}

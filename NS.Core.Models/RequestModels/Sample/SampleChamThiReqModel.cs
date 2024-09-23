using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class SampleChamThiReqModel
    {
        public long HoSoThiId { get; set; }
        public List<MonThiTuyenSinhReqModel> ListMonThi { get; set; }
    }

    public class MonThiTuyenSinhReqModel
    {
        public long MonThiTuyenSinhId { get; set; }
        public List<TieuChiMonThiReqModel> TieuChi { get; set; }
    }

    public class TieuChiMonThiReqModel
    {
        public long TieuChiMonThiId { get; set; }
        public int Diem { get; set; }
        public string GhiChu { get; set; }
    }
}

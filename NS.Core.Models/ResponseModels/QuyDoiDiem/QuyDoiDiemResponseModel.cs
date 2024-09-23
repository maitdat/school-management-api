using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class QuyDoiDiemResponseModel : BaseEntity
    {
        public long MonThiTuyenSinhId { get; set; } 
        public string MonThiTuyenSinh { get; set; }
        public int DiemBatDau { get; set; }
        public int DiemKetThuc { get; set; }
        public string KetQua { get; set; }
    }
}

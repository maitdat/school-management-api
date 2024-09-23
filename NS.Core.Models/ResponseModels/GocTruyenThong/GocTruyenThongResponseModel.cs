using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.GocTruyenThong
{
    public class GocTruyenThongResponseModel
    {
        public long Id { get; set; }
        public long SoTrang { get; set; }
        public string LinkAnh { get; set; }
        public bool IsDeleted { get; set; }
    }
}

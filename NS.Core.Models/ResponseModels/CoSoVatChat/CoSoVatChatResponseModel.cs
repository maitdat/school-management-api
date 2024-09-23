using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.CoSoVatChat
{
    public class CoSoVatChatResponseModel
    {
        public long Id { get; set; }
        public required string TenDiaDiem { get; set; }
        public string TenDiaDiemTiengAnh { get; set; }
        public required bool HienThi { get; set; }
    }
}

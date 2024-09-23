using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.NhanVien
{
    public class ChangeHangVaCotNhanVienRequestModel
    {
        public long Id { get; set; }
        public int Hang { get; set; }
        public int Cot { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class TuyenDungViTriResponseModel
    {
        public long Id { get; set; }
        public long TinTuyenDungId { get; set; }
        public long ViTriTuyenDungId { get; set; }
        public string TenViTri { get; set; }
    }
}



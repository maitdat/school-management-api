using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.TaiKhoanResponse
{
    public class RoleTaiKhoan
    {
        public string Email { get; set; }
        public ICollection<Enums.DanhSachPhanQuyen> DanhSachPhanQuyen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class GetPagedTinTuyenDungResquestModel:BasePaginationRequestModel
    {
        public DateTime NgayBatDau { get; set; } = DateTime.MinValue;
        public DateTime NgayKetThuc { get; set; }= DateTime.MinValue;
        public TrangThaiTinTuyenDung? TrangThai { get; set; } 


    }
}

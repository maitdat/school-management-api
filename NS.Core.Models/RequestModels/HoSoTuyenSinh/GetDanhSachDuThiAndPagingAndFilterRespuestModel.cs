using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class GetDanhSachDuThiAndPagingAndFilterRespuestModel : BasePaginationRequestModel
    {
        public string? HeDaoTao { get; set; }
        public string? LopDangKi { get; set; }
        public Enums.TrangThaiDanhSachDuThi TrangThaiDuThi { get; set; }
        public DateTime DateStartFrom { get; set; }
        public DateTime DateEndFrom { get; set; }
    }
}

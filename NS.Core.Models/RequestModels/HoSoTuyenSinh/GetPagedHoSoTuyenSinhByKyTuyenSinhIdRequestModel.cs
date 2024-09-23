using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class GetPagedHoSoTuyenSinhByKyTuyenSinhIdRequestModel : BasePaginationRequestModel
    {
        public required long KyTuyenSinhId { get; set; }
        public IEnumerable<long> HeDaoTaoIds { get; set; }
        public IEnumerable<long> LopDuThiIds { get; set; }
        public IEnumerable<TrangThaiHoSoTuyenSinh> TrangThaiHoSoTuyenSinhs { get; set; }
    } 
}

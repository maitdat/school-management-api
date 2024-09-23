using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class GetAllAndPagingTieuChiRequestModel : BasePaginationRequestModel
    {
        public string TenTieuChi { get; set; }
        public string GhiChu { get; set; }
    }
}

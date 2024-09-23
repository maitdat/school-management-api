using Microsoft.EntityFrameworkCore;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.CaiDatTrang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.CaiDat
{
    public class CaiDatTongTheResponseModel : CaiDatTongTheRequestModel
    {
        public long Id { get; set; }
        public long TrangId { get; set; }
        public virtual IEnumerable<CaiDatChiTietResponseModel> CaiDatChiTiet { get; set; }
       
    }
}

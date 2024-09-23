using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.NoiQuyRequest
{
    public class CreateOrUpdateNoiQuyRequest
    {
        public string TenNoiQuy { get; set; }
        public string NoiDung { get; set; }
        public long LoaiNoiQuyId { get; set; }
        public string TenNoiQuyTiengAnh { get; set; }
        public string NoiDungTiengAnh { get; set; }
    }
}

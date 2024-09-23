using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.NoiQuy
{
    public class NoiQuyResponseModel
    {
        public long Id { get; set; }
        public string LoaiNoiQuy { get; set; }
        public string TenNoiQuy { get; set; }
        public string TenNoiQuyTiengAnh { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungTiengAnh { get; set; }
        public long? LoaiNoiQuyId { get; set; }
    }
}

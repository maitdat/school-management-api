using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class EmailConfigResponseModel
    {
        public long Id { get; set; }
        public EmailCode Code { get; set; }
        public string TenHeDaoTao { get; set; }
        public string TenKhoi { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string TieuDeEnglish { get; set; }
        public string NoiDungEnglish { get; set; }
    }
}

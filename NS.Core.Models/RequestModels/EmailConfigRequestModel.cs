using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class EmailConfigRequestModel
    {
        public EmailCode Code { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string TieuDeEnglish { get; set; }
        public string NoiDungEnglish { get; set; }
    }
}

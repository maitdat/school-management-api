using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels.EmailTemplateRequestModel
{
    public class GetPagedEmailTemplateAndFilter : BasePaginationRequestModel
    {
        public long? HeDaoTaoId { get; set; }
        public long? KhoiId { get; set; }
        public EmailCode? Code { get; set; }
    }
}

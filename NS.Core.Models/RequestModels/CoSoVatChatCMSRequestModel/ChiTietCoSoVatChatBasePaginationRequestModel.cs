using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels.CoSoVatChatCMSRequestModel
{
    public class GetPageChiTietCoSoVatChatRequestModel : BasePaginationRequestModel
    {
        public LoaiMedia? LoaiMedia { get; set; }
    }
}

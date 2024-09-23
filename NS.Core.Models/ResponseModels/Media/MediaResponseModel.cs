using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels.Media
{
    public class MediaResponseModel
    {
        public long Id { get; set; }
        public long CoSoVatChatId { get; set; }
        public string ContentLink { get; set; }
        public LoaiMedia ContentType { get; set; }
        public bool HienThi { get; set; }
    }
}

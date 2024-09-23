using Microsoft.AspNetCore.Http;
using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;


namespace NS.Core.Models.Entities.LandingPage
{
    public class ChiTietCoSoVatChat :BaseEntity
    {
        public long CoSoVatChatId { get; set; }
        public virtual CoSoVatChat CoSoVatChat { get; set; }
        public required bool HienThi { get; set; }
        public required LoaiMedia LoaiMedia { get; set; }
        public string LinkAnh { get; set; }
        public long? FileId { get; set; }
        public virtual FileUpload File { get; set; }
        public int ThuTu { get; set; }
    }
}

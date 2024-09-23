using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateHeDaoTaoModel
    {
        public required string TenHeDaoTao { get; set; }
        public required string TenHeDaoTaoEnglish { get;set; }
        public string MoTa { get; set; }
    }
}

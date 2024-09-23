using NS.Core.Models.Entities;
﻿using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class MonThiTuyenSinhResponseModel : BaseEntity
    {
        public long KyTuyenSinhId { get; set; }
        public  string KyTuyenSinh { get; set; }
        public long LopDuThiId { get; set; }
        public  string LopDuThi { get; set; }
        public long MonThiId { get; set; }
        public  string MonThi { get; set; }
        public long HeDaoTaoId { get; set; }
        public  string HeDaoTao { get; set; }
    }
}

﻿using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class TinTuyenDung : BaseEntitySoftDeletable
    {
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungTiengAnh { get; set; }
        public TrangThaiTinTuyenDung TrangThai { get; set; }
        public DateTime NgayHetHan { get; set; }
        public virtual ICollection<TuyenDungViTri> TuyenDungVitri { get; set; }
    }
}

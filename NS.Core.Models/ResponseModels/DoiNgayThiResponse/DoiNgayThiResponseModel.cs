using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Commons;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class DoiNgayThiResponseModel:BaseEntity
    {
        public string MaSoHoSo { get; set; }
        public string TenHocSinh { get; set; }
        public DateTime NgayGiaoLuuMoi { get; set; }
        public DateTime GioLuuMoi { get; set; }
        public DateTime GioDonMongMuon { get; set; }
        public int  DotThiMongMuon  { get; set; }


        public static DoiNgayThiResponseModel Mapping(DoiNgayThi model)
        {
            return new DoiNgayThiResponseModel
            {
                Id = model.Id,
                GioLuuMoi = model.ThoiGianThi.GioDuThi,
                GioDonMongMuon = model.ThoiGianThi.GioDonCon,
                TenHocSinh = model.HoSoThi.HoSoTuyenSinh.HoTen,
                DotThiMongMuon = model.ThoiGianThi.DotThi,
                MaSoHoSo = model.HoSoThi.HoSoTuyenSinh.MaSoHoSo,
                NgayGiaoLuuMoi = model.ThoiGianThi.NgayThi
            };
        }
    }
}

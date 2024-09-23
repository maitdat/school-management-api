using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.ThucDon
{
    public class ThucDonResponseModel
    {
        public long Id { get; set; }
        public string TenTuan { get; set; }
        public string TenTuanTiengAnh { get; set; }
        public string ThuHai { get; set; }
        public string ThuBa { get; set; }
        public string ThuTu { get; set; }
        public string ThuNam { get; set; }
        public string ThuSau { get; set; }
        public string AnSang { get; set; }
        public string ThuHaiTiengAnh { get; set; }
        public string ThuBaTiengAnh { get; set; }
        public string ThuTuTiengAnh { get; set; }
        public string ThuNamTiengAnh { get; set; }
        public string ThuSauTiengAnh { get; set; }
        public string AnSangTiengAnh { get; set; }
        public string MauThuHai { get; set; }
        public string MauThuBa { get; set; }
        public string MauThuTu { get; set; }
        public string MauThuNam { get; set; }
        public string MauThuSau { get; set; }
        public string MauAnSang { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public DateTime NgayTao { get; set; }
        public string LinkAnh { get; set; }
        public static ThucDonResponseModel Mapping(Entities.ThucDon thucDon)
        {
            return new ThucDonResponseModel
            {
                Id = thucDon.Id,
                TenTuan = thucDon.TenTuan,
                TenTuanTiengAnh = thucDon.TenTuanTiengAnh,
                ThuHai = thucDon.ThuHai,
                ThuBa = thucDon.ThuBa,
                ThuTu = thucDon.ThuTu,
                ThuNam = thucDon.ThuNam,
                ThuSau = thucDon.ThuSau,
                AnSang = thucDon.AnSang,
                ThuHaiTiengAnh = thucDon.ThuTuTiengAnh,
                ThuBaTiengAnh = thucDon.ThuBaTiengAnh,
                ThuTuTiengAnh = thucDon.ThuTuTiengAnh,
                ThuNamTiengAnh = thucDon.ThuNamTiengAnh,
                ThuSauTiengAnh = thucDon.ThuSauTiengAnh,
                AnSangTiengAnh = thucDon.AnSangTiengAnh,
                MauThuHai = thucDon.MauThuHai,
                MauThuBa = thucDon.MauThuBa,
                MauThuTu = thucDon.MauThuTu,
                MauThuNam = thucDon.MauThuNam,
                MauThuSau = thucDon.MauThuSau,
                MauAnSang = thucDon.MauAnSang,
                TuNgay = thucDon.TuNgay,
                DenNgay = thucDon.DenNgay,
                NgayTao = thucDon.NgayTao,
                LinkAnh = thucDon.LinkAnh
            };
        }
    }
}

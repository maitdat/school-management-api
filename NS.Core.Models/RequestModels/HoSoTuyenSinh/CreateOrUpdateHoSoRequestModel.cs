using Microsoft.AspNetCore.Http;
using NS.Core.Business;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateHoSoRequestModel
    {
        public long KyTuyenSinhId { get; set; }
        public long KhoiTuyenSinhId { get; set; }
        public long HeDaoTaoId { get; set; }
        public long TaiKhoanId { get; set; }
        public string MaSoHoSo { get; set; }
        public string HoTen { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MaMoet { get; set; }
        public string NoiSinh { get; set; }
        public string AnhHoSo { get; set; }
        public string AnhGiayKhaiSinh { get; set; }
        public string HoKhauThuongTru { get; set; }
        public string DiaChiHienTai { get; set; }
        public string TruongDangTheoHoc { get; set; }
        public string NguoiKhaiHoSo { get; set; }
        public string AnhChiEm { get; set; }
        public string ChungChiTiengAnh { get; set; }
        public string ThanhTichKhac { get; set; }
        public string HoanCanhDacBiet { get; set; }
        public string DeNghiCuaPhuHuynh { get; set; }
        public KenhGioiThieu KenhGioiThieu { get; set; }
        public bool ThamGiaClub { get; set; }
        public string SucKhoe { get; set; }
        public string CaTinh { get; set; }
        public string NangKhieu { get; set; }
        public string SoThich { get; set; }
        public DateTime NgayGiaoLuu { get; set; }
        public TrangThaiDanhSachDuThi TrangThaiDanhSachDuThi { get; set; }
        public NguoiLienQuanTrongHoSo ThongTinCha { get; set; }
        public NguoiLienQuanTrongHoSo ThongTinMe { get; set; }
        public ThanhTichHocTapTrongHoSo ThanhTichHocTapTrongHoSo { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(20 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile FileAnhHoSo { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(20 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile FileAnhGiayKhaiSinh { get; set; }

        public Entities.HoSoTuyenSinh Mapping()
        {
            return new Entities.HoSoTuyenSinh
            {
                KyTuyenSinhId = KyTuyenSinhId,
                KhoiTuyenSinhId = KhoiTuyenSinhId,
                HeDaoTaoId = HeDaoTaoId,
                TaiKhoanId = TaiKhoanId,
                MaSoHoSo = MaSoHoSo,
                HoTen = HoTen,
                GioiTinh = GioiTinh,
                NgaySinh = NgaySinh,
                MaMoet = MaMoet,
                NoiSinh = NoiSinh,
                HoKhauThuongTru = HoKhauThuongTru,
                DiaChiHienTai = DiaChiHienTai,
                TruongDangTheoHoc = TruongDangTheoHoc,
                NguoiKhaiHoSo = NguoiKhaiHoSo,
                AnhChiEm = AnhChiEm,
                ChungChiTiengAnh = ChungChiTiengAnh,
                ThanhTichKhac = ThanhTichKhac,
                HoanCanhDacBiet = HoanCanhDacBiet,
                DeNghiCuaPhuHuynh = DeNghiCuaPhuHuynh,
                KenhGioiThieu = KenhGioiThieu,
                ThamGiaClub = ThamGiaClub,
                NgayDangKy = DateTime.Now,
                SucKhoe = SucKhoe,
                CaTinh = CaTinh,
                NangKhieu = NangKhieu,
                SoThich = SoThich,
                TrangThai = Enums.TrangThaiHoSoTuyenSinh.DaTiepNhan,
                TrangThaiDuThi = TrangThaiDanhSachDuThi,
                NguoiLienQuan = new List<NguoiLienQuan>()
                {
                    ThongTinCha.MappingThemMoiNguoiLienQuan(),
                    ThongTinMe.MappingThemMoiNguoiLienQuan()
                },
                ThanhTichHocTap = ThanhTichHocTapTrongHoSo.MappingThemMoiThanhTichHocTap(),
            };
        }

        public void Update(ref Entities.HoSoTuyenSinh model)
        {
            model.KyTuyenSinhId = KyTuyenSinhId;
            model.KhoiTuyenSinhId = KhoiTuyenSinhId;
            model.HeDaoTaoId = HeDaoTaoId;
            model.TaiKhoanId = TaiKhoanId;
            model.MaSoHoSo = MaSoHoSo;
            model.HoTen = HoTen;
            model.GioiTinh = GioiTinh;
            model.NgaySinh = NgaySinh;
            model.MaMoet = MaMoet;
            model.NoiSinh = NoiSinh;
            model.AnhHoSo = AnhHoSo;
            model.AnhGiayKhaiSinh = AnhGiayKhaiSinh;
            model.HoKhauThuongTru = HoKhauThuongTru;
            model.DiaChiHienTai = DiaChiHienTai;
            model.TruongDangTheoHoc = TruongDangTheoHoc;
            model.NguoiKhaiHoSo = NguoiKhaiHoSo;
            model.AnhChiEm = AnhChiEm;
            model.ChungChiTiengAnh = ChungChiTiengAnh;
            model.ThanhTichKhac = ThanhTichKhac;
            model.HoanCanhDacBiet = HoanCanhDacBiet;
            model.DeNghiCuaPhuHuynh = DeNghiCuaPhuHuynh;
            model.KenhGioiThieu = KenhGioiThieu;
            model.ThamGiaClub = ThamGiaClub;
            model.SucKhoe = SucKhoe;
            model.NangKhieu = NangKhieu;
            model.CaTinh = CaTinh;
            model.SoThich = SoThich;
            model.TrangThaiDuThi = TrangThaiDanhSachDuThi;
            //model.NguoiLienQuan = NguoiLienQuan;
            //model.ThanhTichHocTap = ThanhTichHocTap;
        }
    }

    public class NguoiLienQuanTrongHoSo
    {
        public LoaiQuanHe LoaiQuanHe { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string CoQuan { get; set; }
        public string NgheNghiep { get; set; }
        public string ChucVu { get; set; }
        public NguoiLienQuan MappingThemMoiNguoiLienQuan()
        {
            return new NguoiLienQuan()
            {
                LoaiQuanHe = LoaiQuanHe,
                HoTen = HoTen,
                SoDienThoai = SoDienThoai,
                Email = Email,
                CoQuan = CoQuan,
                NgheNghiep = NgheNghiep,
                ChucVu = ChucVu,
            };
        }
    }
    public class ThanhTichHocTapTrongHoSo
    {
        public long KhoiHocTapId { get; set; }
        public NangLucPhamChat DatPhamChat { get; set; }
        public NangLucPhamChat DaDatNangLuc { get; set; }
        public NangLucPhamChat DaDatKyNang { get; set; }
        public ThanhTichHocTap MappingThemMoiThanhTichHocTap()
        {
            return new ThanhTichHocTap()
            {
                //KhoiHocTapId = KhoiHocTapId,
                DatPhamChat = DatPhamChat,
                DaDatNangLuc = DaDatNangLuc,
                DaDatKyNang = DaDatKyNang
            };
        }
    }
}

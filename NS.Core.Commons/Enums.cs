using System.ComponentModel;

namespace NS.Core.Commons
{
    public class Enums
    {
        public enum UserType
        {
            External,
            Internal
        }

        public enum TrangThaiTinTuc
        {
            ChoPheDuyet,
            DaPheDuyet,
            DaDang
        }
        public enum TrangThaiVideo
        {
            DaDuyet,
            TuChoi
        }
        public enum KetQuaPhongVan
        {
            Do,
            Truot,
            Cho
        }

        public enum CaThi
        {
            Sang,
            Chieu
        }

        public enum TrangThaiDoiNgayThi
        {
            DangChoDuyet,
            DaDuyet,
            KhongDuyet,
            DaXacNhanThamGia
        }

        public enum TrangThaiDuThi
        {
            DangDoi,
            DaDen,
            KhongDen,
            BoThi,
        }

        public enum TrangThaiKetQua
        {
            DangDoi,
            Do,
            Truot
        }

        public enum QuyenKhaoThi
        {
            GiaoVien,
            ChuTich
        }

        public enum GioiTinh
        {
            Nam,
            Nu
        }

        public enum KenhGioiThieu
        {
            None,
            Internet,
            Website,
            Facebook,
            NguoiQuen
        }

        public enum TrangThaiHoSoTuyenSinh
        {
            ChuaXacNhanDangKy,
            HoSoTrung,
            ChoCMHSSua,
            DaDongPhi,
            DaGuiMailDuTuyen,
            ChoDuyet,
            ChuaDongPhi,
            HoSoKhongHopLe,
            DaTiepNhan,
            CanSuaLoi,
            DaHoanThanh,
            ChoDuyetLai
        }

        public enum TrangThaiDanhSachDuThi
        {
            DaGuiMail,
            ChuaGuiMail
        }

        public enum LoaiQuanHe
        {
            Cha,
            Me,
            NguoiGiamHo
        }

        public enum TrangThaiSuaLoi
        {
            Moi,
            DaCapNhat,
            DaSua
        }

        public enum TrangThaiLienHe
        {
            Moi,
            DaPhanHoi
        }

        public enum TrangThaiTinTuyenDung
        {
            DangChoDuyet,
            DaDuyet,
            TuChoi
        }

        public enum TrangThaiHoSoTuyenDung
        {
            DangChoDuyet,
            DangChoPhongVan,
            Truot
        }

        public enum TrangThaiBinhLuan
        {
            DangChoDuyet,
            DaDuyet
        }

        public enum TrangThaiCaiDat
        {
            QuaHan,
            HienTai,
            Nhap
        }

        public enum DanhSachTrangTinh
        {
            TrangChu = 1,
            ChuongTrinhHoc = 2,
            CoSoVatChat = 3,
            GocTruyenThong = 4,
            TinTucSuKien = 5,
            TongQuan = 6,
            PhuongThucDayHoc = 7,
            ThoiGianBieu_LichNamHoc = 8,
            NoiQuy = 9,
            ThongTinTuyenSinh = 10,
            QuyDinhNhapHoc = 11,
            HocPhi = 12,
            LienHe = 13,
            BanTru = 14,
            TuVanTamLy = 15,
            CoCauToChuc = 16,
            CauLacBo = 17,
            HoiDongTruong = 18,
            BanGiamHieu = 19,
            DoiNguGiaoVien = 20,
            AnToanHocDuong = 21,
        }

        public enum CaHoc
        {
            CaSang,
            CaTrua,
            CaChieu,
        }

        public enum LoaiMedia
        {
            Anh,
            Anh360,
            Video
        }

        public enum FolderChild
        {
            [Description("TrangTinh")] TrangTinh,
            [Description("BaiViet")] BaiViet,
            [Description("TinTuc")] TinTuc,
            [Description("CoSoVatChat")] CoSoVatChat,
            [Description("HoSoThi")] HoSoThi,
            [Description("HoSoTuyenSinh")] HoSoTuyenSinh,
            [Description("TaiKhoan")] TaiKhoan,
            [Description("NhanVien")] NhanVien,
            [Description("CauLacBo")] CauLacBo,
            [Description("ChuongTrinhHoc")] ChuongTrinhHoc,
            [Description("CoCauToChuc")] CoCauToChuc,
            [Description("GocTruyenThong")] GocTruyenThong,
            [Description("ThanhTichNoiBat")] ThanhTichNoiBat,
            [Description("AnhHoSoTuyenSinh")] AnhHoSo,
            [Description("AnhGiayKhaiSinh")] AnhGiayKhaiSinh

        }

        public enum FileType
        {
            Document,
            Pdf,
            Image,
            Video,
        }

        public enum LoaiBaiViet
        {
            None,
            GocTruyenThong,
            Menu,
        }

        public enum LoaiPhongBan
        {
            HoiDongTruong,
            BanGiamHieu,
            PhongBanKhac
        }

        public enum CauHinhHeThong
        {
            Email
        }

        public enum TrangThaiKyTuyenSinh
        {
            Mo,
            TamDung,
            Dong
        }
        public enum LoaiXacThucTaiKhoan
        { 
            DangKy,
            DatLaiMatKhau,
        }
        public enum DanhSachPhanQuyen
        {
            SystemAdmin = 100,
            AdminTinTuc = 301,
            AdminTuyenSinh = 302,
            AdminTaiVu = 303,
            AdminTuyenDung = 304,
            CongTacVienTinTuc = 401,
            BanTuyenSinh = 501,
            BanGiamHieu = 502,
            PhuHuynhHoacUngVien = 601,
        }
        public enum EmailCode
        {
            XacNhanDangKi = 100,
            XacNhanThanhToanPhiDuTuyen = 101,
            HoSoHopLe = 200,
            HoSoHopLeChoChiTieu = 201,
            HoSoLoi = 202,
            Cho = 300,
            Do = 301,
            Truot = 303,
            TuyenThang = 304,
            MoiDuTuyen = 305,
            XacThucTaiKhoan = 400,
            XacThucQuenMatKhau = 401,
        }
        
        public enum NangLucPhamChat
        {
            Tot,
            Dat,
            ChuaDat
        }
    }
}
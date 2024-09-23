using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Constants;

namespace NS.Core.Models.Entities
{
    public class XacThucTaiKhoan
    {
        public Guid Id { get; set; }
        public long TaiKhoanId { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public DateTime NgayYeuCau { get; set; }
        public DateTime NgayHetHan { get; set; }
        public Enums.LoaiXacThucTaiKhoan LoaiXacThucTaiKhoan { get; set; }
        public bool IsDeleted { get; set; }

        public static XacThucTaiKhoan CreateXacThucTaiKhoanDangKy(TaiKhoan taiKhoan)
        {
            return new XacThucTaiKhoan
            {
                TaiKhoan = taiKhoan,
                NgayYeuCau = DateTime.Now,
                NgayHetHan = DateTime.Now.AddDays(EmailConstants.EMAIL_VERIFICATION_EXPIRATION_DAYS),
                LoaiXacThucTaiKhoan = Enums.LoaiXacThucTaiKhoan.DangKy
            };
        }

        public static XacThucTaiKhoan CreateXacThucTaiKhoanQuenMatKhau(TaiKhoan taiKhoan)
        {
            return new XacThucTaiKhoan
            {
                TaiKhoan = taiKhoan,
                NgayYeuCau = DateTime.Now,
                NgayHetHan = DateTime.Now.AddDays(EmailConstants.FORGOT_PASSWORD_EXPIRATION_DATE_NUMBER),
                LoaiXacThucTaiKhoan = Enums.LoaiXacThucTaiKhoan.DatLaiMatKhau
            };
        }
    }
}


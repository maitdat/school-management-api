using Microsoft.AspNetCore.Http;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels.FileUpload;

namespace NS.Core.Models.RequestModels.NhanVien;

public class CreateOrUpdateNhanVienRequestModel : BaseEntity
{
    public long PhongBanId { get; set; }
    public required string HoTen { get; set; }
    public required string ChucVu { get; set; }
    public string LinkAnh { get; set; }
    public long? FileId { get; set; }
    public IFormFile? File { get; set; }
    public string ThongTinLienLac { get; set; }
    public string HocVan { get; set; }
    public string DanhHieu { get; set; }
    public string QuaTrinhLamViec { get; set; }
    public string ChamNgon { get; set; }
    public bool HienThi { get; set; } = true;

    public  void Mapping(ref Entities.NhanVien nhanVien,FileUploadResponseModel file)
    {
            nhanVien.Id = Id;
            nhanVien.PhongBanId = PhongBanId;
            nhanVien.HoTen = HoTen;
            nhanVien.ChucVu = ChucVu;
            nhanVien.ThongTinLienLac = ThongTinLienLac;
            nhanVien.HocVan = HocVan;
            nhanVien.QuaTrinhLamViec = QuaTrinhLamViec;
            nhanVien.ChamNgon = ChamNgon;
            nhanVien.HienThi = HienThi;
            nhanVien.DanhHieu = DanhHieu;
            if (file.Id > 0)
            {
                nhanVien.FileId = file.Id;
                nhanVien.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.CoCauToChuc)}/{file.FileName}";
            }
    }    
   
}
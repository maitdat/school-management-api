using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class CauLacBoResponseModel
    {
        public long Id { get; set; }
        public string TenCauLacBo { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
        public int SoBuoiHoc { get; set; }
        public int HocPhi { get; set; }
        public string icon { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string TenCauLacBoTiengAnh { get; set; } = string.Empty;
        public string MoTaTiengAnh { get; set; } = string.Empty;
        public List<AnhCauLacBoResponseModel> AnhCauLacBos { get; set; }

        public static CauLacBoResponseModel Mapping(CauLacBo model)
        {
            return new CauLacBoResponseModel()
            {
                Id = model.Id,
                HocPhi = model.HocPhi,
                MoTa = model.MoTa,
                icon = model.Icon,
                ThoiGianBatDau = model.ThoiGianBatDau,
                ThoiGianKetThuc = model.ThoiGianKetThuc,
                SoBuoiHoc = model.SoBuoiHoc,
                TenCauLacBo = model.TenCauLacBo,
                MoTaTiengAnh = model.MoTaTiengAnh,
                TenCauLacBoTiengAnh = model.TenCauLacBoTiengAnh,
                AnhCauLacBos = model.AnhCauLacBo.Select(x => new AnhCauLacBoResponseModel
                {
                    Id = x.Id,
                    CauLacBoId = x.CauLacBoId,
                    FileUploadId = x.FileUploadId,
                    LinkAnh = x.LinkAnh,
                }).ToList()
            };
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels
{
    public  class SukienSapToiResponseModel
    {
        public long Id { get; set; }
        public string TenSuKien { get; set; }
        public string TenSuKienTiengAnh { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }
        public DateTime ThoiGian { get; set; }
        public string DiaDiem { get; set; }
        public static SukienSapToiResponseModel Mapping(SuKienSapToi model)
        {
            return new SukienSapToiResponseModel
            {
                Id = model.Id,
                TenSuKien = model.TenSuKien,
                TenSuKienTiengAnh = model.TenSuKienTiengAnh,
                MoTa = model.MoTa,
                MoTaTiengAnh = model.MoTaTiengAnh,
                ThoiGian = model.ThoiGian,
                DiaDiem = model.DiaDiem,
            };


        }
    }

}

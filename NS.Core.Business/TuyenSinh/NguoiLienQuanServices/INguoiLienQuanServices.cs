using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.NguoiLienQuanServices
{
    public interface INguoiLienQuanServices
    {
        IQueryable<NguoiLienQuan> GetAll();
        IQueryable<NguoiLienQuan> GetByHoSoTuyenSinhId(long hoSoTuyenId);    
        IQueryable<NguoiLienQuan> GetById(long id);
        Task AddNewNguoiLienQuan(LoaiQuanHe loaiQuanHe, NguoiLienQuanRequestModel newNguoiLienQuan);
        Task UpdateNguoiLienQuan(long nguoiLienQuanId, LoaiQuanHe loaiQuanHe, NguoiLienQuanRequestModel nguoiLienQuan);
        Task DeleteNguoiLienQuan(long id);
        IQueryable<HoSoTuyenSinh> GetAllHoSoTuyenSinh();
        IQueryable<HoSoTuyenSinh> GetHoSoTuyenSinhById(long id);
       
    }
}

using NS.Core.Models.RequestModels.NhanVien;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.NhanVienService
{
    public interface INhanVienService
    {
        Task<List<NhanVienResponseModel>> GetAll();
        Task<List<NhanVienResponseModel>> GetAllAvailable();
        Task<List<NhanVienResponseModel>> GetAllDisplay();
        Task<BasePaginationResponseModel<NhanVienResponseModel>> GetPagedNhanVien(GetPagedNhanVienRequestModel input);
        Task<NhanVienResponseModel> GetById(long id);
        Task Create(NhanVienRequestModel model);
        Task Update(long id, NhanVienRequestModel model);
        Task Delete(long id);
        Task<List<NhanVienResponseModel>> GetChuyenVienTamLy(bool isDisplay = false);
        Task<List<NhanVienResponseModel>> GetNhanVienByPhongBan(long id);
        Task UpdateLaChuyenVienTamLy(long id);
        Task UpdateNhanVienActive(long id);
        Task<List<NhanVienResponseModel>> GetNhanVienByLoaiPhongBan(LoaiPhongBan loaiPhongBan);
        Task<List<NhanVienResponseModel>> GetNhanVienByLoaiPhongBanActive(LoaiPhongBan loaiPhongBan);
        Task CreateOrUpdate(CreateOrUpdateNhanVienRequestModel model);
        Task UpdateHangVaCot(ChangeHangVaCotNhanVienRequestModel request);
        Task<BasePaginationResponseModel<NhanVienResponseModel>> GetPagedNhanVienActive(GetPagedNhanVienRequestModel input);
    }
}

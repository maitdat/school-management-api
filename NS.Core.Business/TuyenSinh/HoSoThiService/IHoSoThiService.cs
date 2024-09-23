using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.HoSoThiService
{
    public interface IHoSoThiService
    {
        Task<List<HoSoThiResponseModel>> GetHoSoThi(long thanhVienHDId);
        Task<BasePaginationResponseModel<HoSoThiResponseModel>> GetPageHoSoThi(GetPageHoSoThiRequestModel input, long thanhVienHDId);
        Task<IQueryable<MonThiTuyenSinhResponseModel>> GetDiemMonThiTuyenSinh(long hoSoId);


        public Task<bool> UpdateTrangThaiDuThi(long hoSoId,long thanhVienHdId, int input);

    }
}

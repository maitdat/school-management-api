using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.RequestModels;
using NS.Core.Commons;

namespace NS.Core.Business.DoiNgayThiService
{
    public interface IDoiNgayThiService
    {
        Task<BasePaginationResponseModel<DoiNgayThiResponseModel>> GetAll(DoiNgayThiRequestModel model);
        Task<List<HeDaoTaoDropdownResponse>> GetHeDaoTaoDropDown(long kyTuyenSinhId);
        Task<List<LopDangKyDropdownResponse>> GetLopDangKyDropDown(long kyTuyenSinhId);
    }
}

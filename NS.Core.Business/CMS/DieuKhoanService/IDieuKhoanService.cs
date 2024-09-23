using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.DieuKhoanRequestModel;
using NS.Core.Models.ResponseModels.DieuKhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.DieuKhoanService
{
    public interface IDieuKhoanService
    {
        Task<DieuKhoanResponseModel> GetDieuKhoan();
        Task Create(DieuKhoanRequestModel dieuKhoanRequestModel);
        Task Update(DieuKhoanRequestModel dieuKhoanRequestModel);
        //Task Delete(long id);
    }
}

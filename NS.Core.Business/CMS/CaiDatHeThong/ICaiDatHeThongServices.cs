using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.CaiDatHeThongServices
{
    public interface ICaiDatHeThongServices
    {
        Task UpdateCauHinhEmail(CaiDatHeThongModel input);
        List<CaiDatHeThongModel> GetAllCauHinhEmail();
    }
}

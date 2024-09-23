using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business
{
    public interface IThongTinTruongServices
    {
        Task UpdateThongTinTruong(ThongTinTruongReqModel input);
        Task<ThongTinTruongResModel> GetFooter();
    }
}

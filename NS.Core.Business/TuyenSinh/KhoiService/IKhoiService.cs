using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.KhoiService
{
    public interface IKhoiService
    {
        Task<List<KhoiReponseModel>> GetListKhoiTuyenSinh();
    }
}

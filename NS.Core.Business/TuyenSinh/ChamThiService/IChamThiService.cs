using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.ChamThiService
{
    public interface IChamThiService
    {
        Task ChamThi(List<ChamThiRequestModel> input);
    }
}

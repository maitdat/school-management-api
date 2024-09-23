using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.KetQuaThiService
{
    public interface IKetQuaService
    {
        public Task<IQueryable<KetQuaThiResponseModel>> SubmitKetQuaThi(long hoSoThiId);
    }
}

using NS.Core.Business.FileService;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.CaiDatTrang;
using NS.Core.Models.ResponseModels.CaiDat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.CaiDatTrang
{
    public interface ICaiDatTrangService 
    {
        public Task SuaTrang(long id, TrangRequestModel trangDataDto);
        public Task<TrangResponse> GetTrangById(long id);

        public Task ThemCaiDatChiTiet(CreateCaiDatChiTietRequestModel caiDatChiTietDto, long caiDatTongTheId);
        public Task XoaCaiDatChiTiet (long id);
        public Task <CaiDatTongTheResponseModel> GetCaiDatTongTheById(long id);
    }
}

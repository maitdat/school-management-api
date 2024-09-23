using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.LienHeService
{
    public interface ILienHeService
    {
        Task AddLienHe(AddOrUpdateLienHeRequestModel data);
        Task UpdateLienHe(AddOrUpdateLienHeRequestModel update, long id);
        Task DeleteLienHe(long id);
        IQueryable<LienHe> GetById(long id);
        IQueryable<LienHe> GetAll();
        IQueryable<LienHe> GetAllAvailable();
        Task<List<LienHeResponseModel>> GetAllForDropdown();
    }
}

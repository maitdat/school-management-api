using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NS.Core.Business.BoPhanLienHeService
{
    public class BoPhanLienHeServices : IBoPhanLienHeServices
    {
        private readonly AppDbContext _context;
        public BoPhanLienHeServices(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<BoPhanLienHeResponseModel>> GetAll()
        {
            return _context.BoPhanLienHe.Select(boPhanLienHe => new BoPhanLienHeResponseModel
            {
                Id = boPhanLienHe.Id,
                TenBoPhan = boPhanLienHe.TenBoPhan,
                TenBoPhanEnglish = boPhanLienHe.TenBoPhanEnglish,
                Email = boPhanLienHe.Email
            }).ToList();
        }

        public async Task<List<BoPhanLienHeResponseModel>> GetAllAvailable()
        {
            return _context.BoPhanLienHe.Where(x => x.IsDeleted == false)
                .Select(x => new BoPhanLienHeResponseModel
            {
                Id = x.Id,
                TenBoPhan = x.TenBoPhan,
                TenBoPhanEnglish = x.TenBoPhanEnglish,
                Email = x.Email
            }).ToList();
        }

        public async Task<List<BoPhanLienHeResponseModel>> Search(string keyword)
        {
            List<BoPhanLienHeResponseModel> data = await GetAllAvailable();
            keyword = keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.FindAll(record => record.TenBoPhan.ToLower().Contains(keyword)
                    || record.TenBoPhanEnglish.ToLower().Contains(keyword)
                    || record.Email.ToLower().Contains(keyword));
            }
            return data;
        }

        public async Task<BoPhanLienHeResponseModel> GetById(long id)
        {
            BoPhanLienHe boPhanLienHe = _context.BoPhanLienHe.GetById(id);
            BoPhanLienHeResponseModel result = new BoPhanLienHeResponseModel
            {
                Id = boPhanLienHe.Id,
                TenBoPhan = boPhanLienHe.TenBoPhan,
                TenBoPhanEnglish = boPhanLienHe.TenBoPhanEnglish,
                Email = boPhanLienHe.Email
            };
            return result;
        }

        public async Task Create(BoPhanLienHeRequestModel boPhanLienHeRequestModel)
        {
            BoPhanLienHe model = new BoPhanLienHe
            {
                TenBoPhan = boPhanLienHeRequestModel.TenBoPhan,
                TenBoPhanEnglish = boPhanLienHeRequestModel.TenBoPhanEnglish,
                Email = boPhanLienHeRequestModel.Email
            };

            _context.BoPhanLienHe.Add(model);

            await _context.SaveChangesAsync();
        }

        public async Task Update(long id, BoPhanLienHeRequestModel boPhanLienHeRequestModel)
        {
            BoPhanLienHe boPhanLienHe = _context.BoPhanLienHe.GetAvailableById(id);
            boPhanLienHe.TenBoPhan = boPhanLienHeRequestModel.TenBoPhan;
            boPhanLienHe.TenBoPhanEnglish = boPhanLienHeRequestModel.TenBoPhanEnglish;
            boPhanLienHe.Email = boPhanLienHeRequestModel.Email;

            _context.Update(boPhanLienHe);
            
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            _context.BoPhanLienHe.Delete(id);
            await _context.SaveChangesAsync();
        }
    }
}

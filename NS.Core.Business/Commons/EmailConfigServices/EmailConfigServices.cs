using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Commons;
using Microsoft.EntityFrameworkCore;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.RequestModels.ThucDon;
using NS.Core.Models.ResponseModels.ThucDon;
using NS.Core.Models.RequestModels.EmailTemplateRequestModel;

namespace NS.Core.Business.EmailConfigServices
{
    public class EmailConfigServices : IEmailConfigServices
    {
        private readonly AppDbContext _context;

        public EmailConfigServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNewEmailConfig(EmailConfigRequestModel newEmail)
        {
            try
            {
                _context.Add(new CaiDatEmail
                {

                    
                    TieuDe = newEmail.TieuDe,
                    NoiDung = newEmail.NoiDung,
                    TieuDeEnglish = newEmail.TieuDeEnglish,
                    NoiDungEnglish = newEmail.NoiDungEnglish,
                });
               await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(newEmail.TieuDe)));
            }
        }

        public async Task DeleteEmail(long id)
        {
           
            
                _context.CaiDatEmail.Delete(id);
              await  _context.SaveChangesAsync();
           
        }

        public async Task<List<EmailConfigResponseModel>> GetAll()
        {
            var resutl = await GetAllAvailable().Select(x=> new EmailConfigResponseModel
            {
                Id = x.Id,
                TieuDe = x.TieuDe,
                NoiDung = x.NoiDung,
                TieuDeEnglish = x.TieuDeEnglish,
                NoiDungEnglish = x.NoiDungEnglish,
            }).ToListAsync();
            return resutl;
        }

        public IQueryable<CaiDatEmail> GetAllAvailable()
        {
            return _context.CaiDatEmail.AsQueryable();
        }
        public Task<BasePaginationResponseModel<EmailConfigResponseModel>> GetAllListEmailPage(GetPagedEmailTemplateAndFilter page)
        {
            var data = GetAllAvailable();
            data = ApplySearchAndFilter(data, page);
            var res = data.Select(x => new EmailConfigResponseModel{
                Id = x.Id,
                Code = x.Code,
                TenHeDaoTao = x.HeDaoTao.TenHeDaoTao,
                TenKhoi = x.Khoi.TenKhoi,
                TieuDe = x.TieuDe,
                NoiDung = x.NoiDung,
                TieuDeEnglish = x.TieuDeEnglish,
                NoiDungEnglish = x.NoiDungEnglish,
            });
            var pagedData =  res.ApplyPaging(page.PageNo,page.PageSize,out var totalItem ).ToList();
            var result = Task.FromResult(new BasePaginationResponseModel<EmailConfigResponseModel>(page.PageNo, page.PageSize, pagedData, totalItem));
            return result;
        }

        public EmailConfigResponseModel GetById(long id)
        {
            var res = _context.CaiDatEmail.Where(x => x.Id == id).Select(x => new EmailConfigResponseModel
            {
                Id = x.Id,
                Code = x.Code,
                TenHeDaoTao = x.HeDaoTao.TenHeDaoTao,
                TenKhoi = x.Khoi.TenKhoi,
                TieuDe = x.TieuDe,
                NoiDung = x.NoiDung,
                TieuDeEnglish = x.TieuDeEnglish,
                NoiDungEnglish = x.NoiDungEnglish,
            }).FirstOrDefault();
            return res;
        }

        public async Task UpdateEmailConfig(long id, EmailConfigRequestModel updateEmail)
        {
            var emailConfig = _context.CaiDatEmail.GetAvailableById(id);
            emailConfig.Code = updateEmail.Code;
                emailConfig.TieuDe = updateEmail.TieuDe;
                emailConfig.NoiDung = updateEmail.NoiDung;
                emailConfig.TieuDeEnglish = updateEmail.TieuDeEnglish;
                emailConfig.NoiDungEnglish = updateEmail.NoiDungEnglish;
                _context.Update(emailConfig);
              await  _context.SaveChangesAsync();
            
        }
        private IQueryable<CaiDatEmail> ApplySearchAndFilter(IQueryable<CaiDatEmail> query, GetPagedEmailTemplateAndFilter input)
        {
            // apply search
 
            if (input.Code.HasValue)
            {
                query = query.Where(record => record.Code == input.Code);
                   
            }

            //apply filter
            if (input.HeDaoTaoId.HasValue)
            {
                query = query.Where(record => record.HeDaoTaoId == input.HeDaoTaoId);
            }
            if (input.KhoiId.HasValue)
            {
                query = query.Where(record => record.KhoiId == input.KhoiId);
            }
            //if (input.)

            return query;
        }
    }
}


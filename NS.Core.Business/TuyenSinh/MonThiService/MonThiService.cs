using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Constants = NS.Core.Commons.Constants;

namespace NS.Core.Business.MonThiService
{
    public class MonThiService : IMonThiService
    {
        private readonly AppDbContext _dbContext;

        public MonThiService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }



        public async Task<List<MonThiResponseModel>> GetMonHocAsync()
        {
            return await GetAll().Select(x => new MonThiResponseModel
            {
                Id = x.Id,
                TenMonThi = x.TenMonThi,
            }).ToListAsync();

        }

        public Task<BasePaginationResponseModel<MonThiResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel page)
        {
            var data = GetAllAvailablePrivate().Select(y => new MonThiResponseModel
            {
                Id = y.Id,
                TenMonThi = y.TenMonThi,
            });
            var paging = Utilities.ApplyPaging(data, page.PageNo, page.PageSize).ToList();
            var result = Task.FromResult(new BasePaginationResponseModel<MonThiResponseModel>(page.PageNo, page.PageSize, paging, data.Count()));
            return result;
        }


        public async Task<MonThiResponseModel> AddNewMonThi(MonThiRequestModel monThi)
        {

            var monThiToAdd = new MonThi
            {
                Id = monThi.Id,
                TenMonThi = monThi.TenMonThi,
            };
            _dbContext.MonThi.Add(monThiToAdd);
            _dbContext.SaveChanges();

            return MappingPrivate(monThiToAdd);
        }

        public async Task<MonThiResponseModel> UpdateMonThi(MonThiRequestModel monThi, long id)
        {
            MonThi monThiToUpdate = GetById(id);
            if (monThiToUpdate == null)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(MonThi)));
            }
            monThiToUpdate.TenMonThi = monThi.TenMonThi;

            _dbContext.Update(monThiToUpdate);
            _dbContext.SaveChanges();


            return MappingPrivate(monThiToUpdate);
        }

        public async Task<MonThiResponseModel> RemoveMonThi(long id)
        {
            MonThi monThi = GetById(id);
            if (monThi == null) throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(MonThi)));

            monThi.IsDeleted = true;

            _dbContext.Update(monThi);
            _dbContext.SaveChanges();

            return MappingPrivate(monThi);


        }

        public async Task<BasePaginationResponseModel<MonThiResponseModel>> GetPageMonThi(GetPageMonThiRequestModel input)
        {
            try
            {
                var query = GetAllAvailablePrivate();
                ApplySearchAndFilter(ref query, input);

                query = query.OrderByDescending(x => x.TenMonThi);

                var totalItem = 0;

                query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);

                List<MonThiResponseModel> result = FormatData(query);

                return await Task.FromResult(new BasePaginationResponseModel<MonThiResponseModel>(input.PageSize, input.PageNo, result, totalItem));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        #region Private

        private MonThiResponseModel MappingPrivate(MonThi monThi)
        {
            var monThiResponse = new MonThiResponseModel
            {
                Id = monThi.Id,
                TenMonThi = monThi.TenMonThi,
            };
            return monThiResponse;
        }
        private MonThi GetById(long id)
        {
            return _dbContext.MonThi.Find(id);

        }
        private IQueryable<MonThi> GetAll()
        {
            return _dbContext.MonThi.AsQueryable();
        }

        private List<MonThiResponseModel> FormatData(IQueryable<MonThi> query)
        {
            var result = query.Select(x => new MonThiResponseModel
            {
                Id = x.Id,
                TenMonThi = x.TenMonThi,
            }).ToList();
            return result;
        }

        private void ApplySearchAndFilter(ref IQueryable<MonThi> query, GetPageMonThiRequestModel input)
        {
            //Search
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TenMonThi.ToLower().Contains(keyword));
            }
           
        }

        private IQueryable<MonThi> GetAllAvailablePrivate()
        {
            return GetAll().Where(x => !x.IsDeleted);
        }



        #endregion

    }



}

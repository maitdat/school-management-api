using Microsoft.EntityFrameworkCore;
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

namespace NS.Core.Business.NamHocService
{
    public class NamHocService : INamHocService
    {
        private readonly AppDbContext _dbContext;

        public NamHocService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<NamHocResponseModel> GetNamHocById (long id)
        {
            NamHoc namHoc = _dbContext.NamHoc.GetById(id);
            return new NamHocResponseModel
            {
                Id = namHoc.Id,
                TenNamHoc = namHoc.TenNamHoc
            };
        }

        public async Task<List<NamHocResponseModel>> GetNamHocAsync()
        {
            return await GetAll().Select(x => new NamHocResponseModel
            {
                TenNamHoc = x.TenNamHoc,
            }).ToListAsync();
        }

        public async Task<List<NamHocResponseModel>> GetAvailableNamHoc()
        {
            return await GetAll().Where(x => x.IsDeleted == false).Select(y => new NamHocResponseModel
            {
                TenNamHoc = y.TenNamHoc,
            }).ToListAsync();
        }

        public async Task<NamHocResponseModel> AddNewNamHoc(NamHocRequestModel namHoc)
        {
            var namHocToAdd = new NamHoc
            {
                Id = namHoc.Id,
                TenNamHoc = namHoc.TenNamHoc,
            };
            _dbContext.NamHoc.Add(namHocToAdd);
            _dbContext.SaveChanges();

            return MappingPrivate(namHocToAdd);
        }

        public async Task<NamHocResponseModel> UpdateNamHoc(NamHocRequestModel namHoc, long id)
        {
            if (GetById(id) == null) throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(NamHoc)));

            NamHoc namHocToUpdate = _dbContext.NamHoc.Where(x => x.Id == id).FirstOrDefault();
            namHocToUpdate.TenNamHoc = namHoc.TenNamHoc;

            _dbContext.NamHoc.Update(namHocToUpdate);
            _dbContext.SaveChanges();

            return MappingPrivate(namHocToUpdate);
        }

        public async Task<NamHocResponseModel> DeleteNamHoc(long id)
        {
            if (GetById(id) == null) throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(NamHoc)));

            NamHoc namHocToRemove = GetById(id).FirstOrDefault();
            namHocToRemove.IsDeleted = true;

            _dbContext.NamHoc.Update(namHocToRemove);
            _dbContext.SaveChanges();
            return MappingPrivate(namHocToRemove);
        }

        public async Task<BasePaginationResponseModel<NamHocResponseModel>> GetPagedNamHoc(GetPageNamHocResquestModel input)
        {
            try
            {
                var query = GetAvailableNamHocPrivate();
                query = ApplySearch(query, input);
                query = query.OrderByDescending(x => x.TenNamHoc);

                var totalItem = 0;

                query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);


                List<NamHocResponseModel> result = FormatData(query);
                return await Task.FromResult(new BasePaginationResponseModel<NamHocResponseModel>(input.PageSize, input.PageNo, result, totalItem));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        #region Private

        private IQueryable<NamHoc> GetAll()
        {
            return _dbContext.NamHoc.AsQueryable();
        }
        private IQueryable<NamHoc> GetById(long id)
        {
            return GetAll().Where(x => x.Id == id).AsQueryable();
        }

        private IQueryable<NamHoc> GetAvailableNamHocPrivate()
        {
            return GetAll().Where(x => !x.IsDeleted);
        }

        private NamHocResponseModel MappingPrivate(NamHoc namHoc)
        {
            var namHocResponse = new NamHocResponseModel
            {
                TenNamHoc = namHoc.TenNamHoc,
            };
            return namHocResponse;
        }

        private IQueryable<NamHoc> ApplySearch(IQueryable<NamHoc> query, GetPageNamHocResquestModel input)
        {
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TenNamHoc.ToLower().Contains(keyword));
            }
            //Filter
            //if (!string.IsNullOrEmpty(input.TenNamHoc))
            //{
            //    query = query.Where(x => x.TenNamHoc == input.TenNamHoc);
            //}
            return query;
        }
        private List<NamHocResponseModel> FormatData(IQueryable<NamHoc> query)
        {
            return query.Select(x => new NamHocResponseModel
            {
                TenNamHoc = x.TenNamHoc,
            }).ToList();

        }

        #endregion

    }

}



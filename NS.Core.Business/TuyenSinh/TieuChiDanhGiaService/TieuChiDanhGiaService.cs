using Microsoft.EntityFrameworkCore;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.Business.TieuChiDanhGiaService
{
    public class TieuChiDanhGiaService : ITieuChiDanhGiaService
    {
        private readonly AppDbContext _context;
        public TieuChiDanhGiaService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task AddTieuChiDanhGia(AddOrUpdateTieuChiDanhGiaRequestModel newTieuChi)
        {
            try
            {
                _context.TieuChiDanhGia.Add(new TieuChiDanhGia
                {
                    TenTieuChi = newTieuChi.TenTieuChi,
                    GhiChu = newTieuChi.GhiChu
                }) ;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex);
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(newTieuChi.TenTieuChi)));
            }
        }

        public async Task DeleteTieuChiDanhGia(long id)
        {
            try
            {
                if(_context.TieuChiDanhGia.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    var delete = _context.TieuChiDanhGia.FirstOrDefault(x => x.Id == id);
                    delete.IsDeleted = true;
                    _context.SaveChanges();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public IQueryable<TieuChiDanhGia> GetAll()
        {
            return _context.TieuChiDanhGia.AsQueryable();
        }

        public Task <BasePaginationResponseModel<TieuChiDanhGiaResponseModel>> GetAllAndPagingTieuChi(BasePaginationRequestModel page)
        {
            
                var data = GetAll().Select(x => new TieuChiDanhGiaResponseModel
                {
                    Id = x.Id,
                    TenTieuChi = x.TenTieuChi,
                    GhiChu = x.GhiChu
                });
                var paging = Utilities.ApplyPaging(data,page.PageNo,page.PageSize).ToList();
                var result = Task.FromResult( new BasePaginationResponseModel<TieuChiDanhGiaResponseModel>(page.PageNo, page.PageSize, paging, data.Count()));
                return result;
            
        }

        public async Task UpdateTieuChiDanhGia(long id, AddOrUpdateTieuChiDanhGiaRequestModel updateTieuChi)
        {
            try
            {
                if(_context.TieuChiDanhGia.Where(x=>x.Id == id).FirstOrDefault()!= null){
                    var update = _context.TieuChiDanhGia.FirstOrDefault(x => x.Id == id);
                    update.TenTieuChi = updateTieuChi.TenTieuChi;
                    update.GhiChu = updateTieuChi.GhiChu;
                    _context.TieuChiDanhGia.Update(update);
                    await _context.SaveChangesAsync();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public TieuChiDanhGiaResponseModel GetById(long id)
        {
            TieuChiDanhGiaResponseModel? result = _context.TieuChiDanhGia
               .Where(x => x.Id == id)
               .Select(x => new TieuChiDanhGiaResponseModel
               {
                   Id = x.Id,
                   TenTieuChi = x.TenTieuChi,
                   GhiChu = x.GhiChu
               })
               .FirstOrDefault();
            return result;
        }

        //public async Task<BasePaginationResponseModel<TieuChiDanhGiaResponseModel>> GetPagedTieuChi(GetAllAndPagingTieuChiRequestModel input)
        //{
        //    try
        //    {
        //        var query = GetAvailableAndPaging();

        //        query = ApplySearch(query, input);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        await Console.Out.WriteLineAsync(ex.ToString());
        //        throw;
        //    }
        //}
        //private IQueryable<TieuChiDanhGia> ApplySearch(IQueryable<TieuChiDanhGia> query, GetAllAndPagingTieuChiRequestModel input)
        //{
        //    // apply search
        //    var keyword = input.Keyword.ToLower().Trim();
        //    if (!string.IsNullOrEmpty(keyword))
        //    {
        //        query = query.Where(record => record.TenTieuChi.ToLower().Contains(keyword));
        //    }
        //    return query;
        //}
        public Task<BasePaginationResponseModel<TieuChiDanhGiaResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel paramsModel)
        {
            IQueryable<TieuChiDanhGia> query = _context.TieuChiDanhGia
                .Where(x => !x.IsDeleted)
                .AsQueryable();
            ApplySearch(paramsModel, ref query);

            var data = query.Select(e => new TieuChiDanhGiaResponseModel
            {
                 Id = e.Id,
                 TenTieuChi = e.TenTieuChi,
                 GhiChu = e.GhiChu
            });
            var paging = Utilities.ApplyPaging(data, paramsModel.PageNo, paramsModel.PageSize).ToList();
            var result = Task.FromResult(new BasePaginationResponseModel<TieuChiDanhGiaResponseModel>(paramsModel.PageNo, paramsModel.PageSize, paging, data.Count()));
            return result;
        }

        private void ApplySearch (BasePaginationRequestModel paramsModel, ref IQueryable<TieuChiDanhGia> query)
        {
            string keyword = paramsModel.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword)) query = query
                    .Where(x=>x.TenTieuChi.Contains(keyword));
        }
    }
}

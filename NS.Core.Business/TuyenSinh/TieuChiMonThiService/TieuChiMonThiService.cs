using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Commons;
using Microsoft.EntityFrameworkCore;

namespace NS.Core.Business.TieuChiMonThiService
{
    public class TieuChiMonThiService : ITieuChiMonThiService
    {
        private readonly AppDbContext _context;
        public TieuChiMonThiService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddTieuChiMonThi(AddOrUpdateTieuChiMonThiRequestModel newTieuChi)
        {
            try
            {
                _context.TieuChiMonThi.Add(new TieuChiMonThi
                {
                    MonThiTuyenSinhId = newTieuChi.MonThiTuyenSinhId,
                    TieuChiDanhGiaId = newTieuChi.TieuChiDanhGiaId,
                    HeSo = newTieuChi.HeSo
                });
                 _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task DeleteTieuChiMonThi(long id)
        {
            try
            {
                if(_context.TieuChiMonThi.Where(x=>x.Id == id).FirstOrDefault() != null)
                {
                    var delete = _context.TieuChiMonThi.Where(x=>x.Id == id).FirstOrDefault();
                    delete.IsDeleted = true;
                     _context.SaveChanges();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task UpdateTieuChiMonThi(long id, AddOrUpdateTieuChiMonThiRequestModel updateTieuChi)
        {
            try
            {
                var update = _context.TieuChiMonThi.Where(x => x.Id == id).FirstOrDefault();
                if(update  != null)
                {            
                    update.TieuChiDanhGiaId = updateTieuChi.TieuChiDanhGiaId;
                    update.MonThiTuyenSinhId = updateTieuChi.MonThiTuyenSinhId;
                    update.HeSo = updateTieuChi.HeSo;
                    await _context.SaveChangesAsync();
                }

                var update2 = _context.TieuChiMonThi.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public IQueryable<TieuChiMonThi> GetAll()
        {
            return _context.TieuChiMonThi.AsQueryable();
        }

        public TieuChiMonThiResponseModel GetById(long id)
        {
            TieuChiMonThiResponseModel? result = _context.TieuChiMonThi
               .Where(x => x.Id == id)
               .Select(x => new TieuChiMonThiResponseModel
               {
                   Id = x.Id,
                   MonThiTuyenSinhId = x.MonThiTuyenSinhId,
                   MonThiTuyenSinh = x.MonThiTuyenSinh.MonThi.TenMonThi,
                   HeSo = x.HeSo,
                   TieuChiDanhGia = x.TieuChiDanhGia.TenTieuChi,
                   TieuChiDanhGiaId = x.TieuChiDanhGiaId

               })
               .FirstOrDefault();
            return result;
        }

        //public Task<BasePaginationResponseModel<TieuChiMonThiResponseModel>> GetAllAndPagingTieuChi(BasePaginationRequestModel page)
        //{

        //    var data = GetAll().Select(x => new TieuChiMonThiResponseModel
        //    {
        //        Id = x.Id,
        //        MonThiTuyenSinhId = x.MonThiTuyenSinhId,
        //        MonThiTuyenSinh = x.MonThiTuyenSinh.MonThi.TenMonThi,
        //        TieuChiDanhGiaId = x.TieuChiDanhGiaId,
        //        TieuChiDanhGia = x.TieuChiDanhGia.TenTieuChi,
        //        HeSo = x.HeSo
        //    });
        //    var paging = Utilities.ApplyPaging(data, page.PageNo, page.PageSize).ToList();
        //    var result = Task.FromResult(new BasePaginationResponseModel<TieuChiMonThiResponseModel>(page.PageNo, page.PageSize, paging, data.Count()));
        //    return result;
        //}
        public Task<BasePaginationResponseModel<TieuChiMonThiResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel paramsModel)
        {
            IQueryable<TieuChiMonThi> query = _context.TieuChiMonThi
                .Where(x => !x.IsDeleted)
                .AsQueryable();
            ApplySearch(paramsModel, ref query);

            var data = query.Select(e=> new TieuChiMonThiResponseModel {
                Id = e.Id,
                MonThiTuyenSinh = e.MonThiTuyenSinh.MonThi.TenMonThi,
                TieuChiDanhGia = e.TieuChiDanhGia.TenTieuChi,
                HeSo = e.HeSo
            });
            var paging = Utilities.ApplyPaging(data, paramsModel.PageNo, paramsModel.PageSize).ToList();
            var result = Task.FromResult(new BasePaginationResponseModel<TieuChiMonThiResponseModel>(paramsModel.PageNo, paramsModel.PageSize, paging, data.Count()));
            return result;
        }
        public async Task<List<MonThiDropDownResponseModel>> GetMonThiTuyenSinhAvailableForDropDown()
        {
            return await _context.MonThiTuyenSinh.Include(e=>e.MonThi).Where(c => !c.IsDeleted).Select(e => new MonThiDropDownResponseModel
            {
                Id = e.Id,
                MonThiTuyenSinh = e.MonThi.TenMonThi
            }).ToListAsync();
        }
        public async Task<List<TieuChiDanhGiaDropDownModel>> GetTieuChiDanhGiaAvailableForDropDown()
        {
            return await _context.TieuChiDanhGia.Where(c => !c.IsDeleted).Select(e => new TieuChiDanhGiaDropDownModel
            {
                Id = e.Id,
                TieuChiDanhGia = e.TenTieuChi
            }).ToListAsync();
        }
        private void ApplySearch(BasePaginationRequestModel paramsModel, ref IQueryable<TieuChiMonThi> query)
        {
            string keyword = paramsModel.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword)) query = query
                    .Where(x => x.MonThiTuyenSinh.MonThi.TenMonThi.Contains(keyword) || x.TieuChiDanhGia.TenTieuChi.Contains(keyword));

        }
    }
}

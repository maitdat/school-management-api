using Azure;
using Microsoft.EntityFrameworkCore;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.MonThiTuyenSinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.Business.MonThiTuyenSinhService
{
    public class MonThiTuyenSinhService : IMonThiTuyenSinhService
    {
        private readonly AppDbContext _context;
        public MonThiTuyenSinhService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddMonThiTuyenSinh(AddOrUpdateMonThiTuyenSinhRequestModel newMonThi)
        {
            try
            {
                _context.MonThiTuyenSinh.Add(new MonThiTuyenSinh
                {
                    KyTuyenSinhId = newMonThi.KyTuyenSinhId,
                    LopDuThiId = newMonThi.LopDuThiId,
                    MonThiId = newMonThi.MonThiId,
                    HeDaoTaoId = newMonThi.HeDaoTaoId,
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }
        }

        public async Task DeleteMonThiTuyenSinh(long id)
        {
            try
            {
                if (_context.MonThiTuyenSinh.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    var delete = _context.MonThiTuyenSinh.Where(x => x.Id == id).FirstOrDefault();
                    delete.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task UpdateMonThiTuyenSinh(long id, AddOrUpdateMonThiTuyenSinhRequestModel updateMonThi)
        {
            try
            {
                MonThiTuyenSinh? update = _context.MonThiTuyenSinh.Where(x => x.Id == id).FirstOrDefault();

                if (update != null)
                {

                    update.KyTuyenSinhId = updateMonThi.KyTuyenSinhId;
                    update.LopDuThiId = updateMonThi.LopDuThiId;
                    update.HeDaoTaoId = updateMonThi.HeDaoTaoId;
                    update.MonThiId = updateMonThi.MonThiId;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable<MonThiTuyenSinh> GetAll()
        {
            return _context.MonThiTuyenSinh
                .AsQueryable();
        }

        public MonThiTuyenSinhResponseModel GetById(long id)
        {
             MonThiTuyenSinhResponseModel? result = _context.MonThiTuyenSinh
                .Where(x => x.Id == id)
                .Select(x=> new MonThiTuyenSinhResponseModel
                    {
                        Id = x.Id,
                        HeDaoTao = x.HeDaoTao.TenHeDaoTao,
                        HeDaoTaoId = x.HeDaoTaoId,
                        LopDuThi = x.LopDuThi.TenLop,
                        LopDuThiId = x.LopDuThiId,
                        KyTuyenSinh = x.KyTuyenSinh.TenKyTuyenSinh,
                        KyTuyenSinhId = x.KyTuyenSinhId,
                        MonThi = x.MonThi.TenMonThi,
                        MonThiId = x.MonThiId
                    })
                .FirstOrDefault();
            return result;
        }
        public async Task<List<GetTenMonThiTuyenSinhResponseModel>> GetMonThi()
        {
            try
            {
                return await GetAll()
                    .Select(x => new GetTenMonThiTuyenSinhResponseModel
                {
                     Id = x.Id,
                    KyTuyenSinh = x.KyTuyenSinh.TenKyTuyenSinh,
                    LopDuThi = x.LopDuThi.TenLop,
                    MonThi = x.MonThi.TenMonThi,
                    HeDaoTao = x.HeDaoTao.TenHeDaoTao
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }

        }
        public Task<BasePaginationResponseModel<MonThiTuyenSinhResponseModel>> GetAvailableAndPaging(MonThiTuyenSinhPagedModel paramsModel)
        {
            IQueryable<MonThiTuyenSinh> query = _context.MonThiTuyenSinh
               .Where(x => !x.IsDeleted)
               .AsQueryable();
            ApplySearch(paramsModel, ref query);

            var data =  query.Select(e => new MonThiTuyenSinhResponseModel{
             Id = e.Id,
             MonThi=e.MonThi.TenMonThi,
             HeDaoTao= string.Format("{0} / {1}", e.HeDaoTao.TenHeDaoTao, e.HeDaoTao.TenHeDaoTaoEnglish),
             HeDaoTaoId=e.HeDaoTaoId,
             KyTuyenSinh=e.KyTuyenSinh.TenKyTuyenSinh,
             KyTuyenSinhId=e.KyTuyenSinhId,
             MonThiId=e.MonThiId,
             LopDuThi=e.LopDuThi.TenLop,
             LopDuThiId =e.LopDuThiId,
            });
            var paging = Utilities.ApplyPaging(data, paramsModel.PageNo, paramsModel.PageSize).ToList();
            var result = Task.FromResult(new BasePaginationResponseModel<MonThiTuyenSinhResponseModel>(paramsModel.PageNo, paramsModel.PageSize, paging, data.Count()));
            return result;
        }
        public async Task<List<KyTuyenSinhDropdownModel>> GetKyTuyenSinhAvailableForDropDown()
        {
            return await _context.KyTuyenSinh.Where(c => !c.IsDeleted).OrderByDescending(x=>x.TenKyTuyenSinh).Select(e=> new KyTuyenSinhDropdownModel
            {
                Id = e.Id,
                KyTuyenSinh = e.TenKyTuyenSinh,
            }).ToListAsync();
        }
        public async Task<List<LopDuThiDropDownModel>> GetLopDuThiAvailableForDropDown()
        {
            return await _context.LopDuThi.Where(c => !c.IsDeleted).Select(e => new LopDuThiDropDownModel
            {
                Id = e.Id,
                LopDuThi = e.TenLop
            }).ToListAsync();
        }
        public async Task<List<MonThiDropDownModel>> GetMonThiAvailableForDropDown()
        {
            return await _context.MonThi.Where(c => !c.IsDeleted).Select(e => new MonThiDropDownModel
            {
                Id = e.Id,
                MonThi = e.TenMonThi,
            }).ToListAsync();
        }
        public async Task<List<HeDaoTaoDropDownModel>> GetHeDaoTaoAvailableForDropDown()
        {
            return await _context.HeDaoTao.Where(c => !c.IsDeleted).Select(e => new HeDaoTaoDropDownModel
            {
                Id = e.Id,
                HeDaoTao =  string.Format("{0} / {1}", e.TenHeDaoTao, e.TenHeDaoTaoEnglish),
            }).ToListAsync();
        }
        private void ApplySearch(MonThiTuyenSinhPagedModel paramsModel, ref IQueryable<MonThiTuyenSinh> query)
        {
            string keyword = paramsModel.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword)) query = query
                    .Where(x => x.MonThi.TenMonThi.Contains(keyword) || x.LopDuThi.TenLop.Contains(keyword) || x.HeDaoTao.TenHeDaoTao.Contains(keyword));

            if (paramsModel.KyTuyenSinhId.HasValue) query = query.Where(x => x.KyTuyenSinhId == paramsModel.KyTuyenSinhId);
        }
        

    }
}

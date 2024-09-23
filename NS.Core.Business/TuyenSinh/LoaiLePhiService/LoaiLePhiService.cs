using Microsoft.EntityFrameworkCore;
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

namespace NS.Core.Business.LoaiLePhiService
{
    public class LoaiLePhiService : ILoaiLePhiService
    {
        private readonly AppDbContext _dbcontext;
        public LoaiLePhiService(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<LoaiLePhiResponseModel>> GetAllLoaiLePhi()
        {
                return await GetAll().Select(x => new LoaiLePhiResponseModel
                {
                    Id = x.Id,
                    TenLePhi = x.TenLePhi,
                    KyTuyenSinhId = x.KyTuyenSinhId,
                    TenLePhiEnglish = x.TenLePhiEnglish,
                    SoTien = x.SoTien,
                    GhiChu = x.GhiChu
                }).ToListAsync();
        }
        public async Task<List<LoaiLePhiResponseModel>> GetAvailableLoaiLePhi()
        {
            return await GetAll().Where(x => x.IsDeleted == false).Select(x => new LoaiLePhiResponseModel
            {
                Id = x.Id,
                KyTuyenSinhId = x.KyTuyenSinhId,
                TenLePhi = x.TenLePhi,
                TenLePhiEnglish = x.TenLePhiEnglish,
                SoTien = x.SoTien,
                TenKyTuyenSinh = x.KyTuyenSinh.TenKyTuyenSinh,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }
        public async Task<LoaiLePhiResponseModel> AddNewLoaiLePhi(LoaiLePhiRequestModel lePhi)
        {
            var newLoaiLePhi = new LoaiLePhi()
            {
                TenLePhi = lePhi.TenLePhi,
                KyTuyenSinhId = lePhi.KyTuyenSinhId,
                TenLePhiEnglish = lePhi.TenLePhiEnglish,
                SoTien = lePhi.SoTien,
                GhiChu =lePhi.GhiChu
            };
            _dbcontext.LoaiLePhi.AddAsync(newLoaiLePhi);
            _dbcontext.SaveChanges();

            return ViewLoaiLePhi(newLoaiLePhi);
        }
        public async Task<LoaiLePhiResponseModel> UpdateLoaiLePhi(long id, LoaiLePhiRequestModel lePhi)
        {
            LoaiLePhi lePhiUpdate = _dbcontext.LoaiLePhi.GetById(id);
            lePhiUpdate.TenLePhi = lePhi.TenLePhi;
            lePhiUpdate.KyTuyenSinhId = lePhi.KyTuyenSinhId;
            lePhiUpdate.TenLePhiEnglish = lePhi.TenLePhiEnglish;
            lePhiUpdate.SoTien = lePhi.SoTien;
            lePhiUpdate.GhiChu = lePhi.GhiChu;

            _dbcontext.Update(lePhiUpdate);
            _dbcontext.SaveChanges();

            return ViewLoaiLePhi(lePhiUpdate);
        }
        public void DeleteLoaiLePhi(long id)
        {
            _dbcontext.LoaiLePhi.Delete(id);
            _dbcontext.SaveChanges();
        }
        public async Task<BasePaginationResponseModel<LoaiLePhiResponseModel>> GetPagedLoaiLePhi(GetPageLoaiLePhiRequestModel input)
        {
            try
            {
                var query = GetLoaiLePhiAvailablePrivate();
                query = ApplySearch(query, input);
                query = query.OrderByDescending(x => x.TenLePhi);

                var totalItem = 0;

                query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);


                List<LoaiLePhiResponseModel> result = FormatData(query);
                return new BasePaginationResponseModel<LoaiLePhiResponseModel>(input.PageNo, input.PageSize, result, totalItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public IQueryable<LoaiLePhi> GetLoaiLePhiById(long id)
        {
            return GetAll().Where(c => c.Id == id).AsQueryable();
        }
        #region private
        private LoaiLePhiResponseModel ViewLoaiLePhi(LoaiLePhi lePhi)
        {
            var loaiLePhiDTO = new LoaiLePhiResponseModel()
            {
                Id = lePhi.Id,
                TenLePhi = lePhi.TenLePhi,
                TenLePhiEnglish = lePhi.TenLePhiEnglish,
                SoTien = lePhi.SoTien,
                GhiChu = lePhi.GhiChu
            };

            return loaiLePhiDTO;
        }
        private IQueryable<LoaiLePhi> GetAll()
        {
            return _dbcontext.LoaiLePhi.AsQueryable();
        }
        private IQueryable<LoaiLePhi> GetLoaiLePhiAvailablePrivate()
        {
            return GetAll().Where(x => !x.IsDeleted);
        }
        private IQueryable<LoaiLePhi> ApplySearch(IQueryable<LoaiLePhi> query, GetPageLoaiLePhiRequestModel input)
        {
            if (input.Keyword != null)
            {
                var keyword = input.Keyword.ToLower().Trim();
                query = query.Where(x => x.TenLePhi.ToLower().Contains(keyword.ToLower())
                                        ||x.TenLePhiEnglish.ToLower().Contains(keyword.ToLower()));
            }
            return query;
        }
        private List<LoaiLePhiResponseModel> FormatData(IQueryable<LoaiLePhi> query)
        {
            return query.Select(x => new LoaiLePhiResponseModel
            {
                Id = x.Id,
                TenLePhi = x.TenLePhi,
                TenLePhiEnglish= x.TenLePhiEnglish,
                KyTuyenSinhId = x.KyTuyenSinhId,
                TenKyTuyenSinh = x.KyTuyenSinh.TenKyTuyenSinh,
                SoTien = x.SoTien,
                GhiChu = x.GhiChu
            }).ToList();
        }
        #endregion
    }
}

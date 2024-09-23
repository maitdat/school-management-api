using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.PhongBanRequestModel;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business
{
    public class PhongBanService : IPhongBanService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PhongBanService> _logger;

        public PhongBanService(AppDbContext context, ILogger<PhongBanService> logger)
        {
            _context = context;
            _logger = logger;
        }
        //GetAll
        public List<PhongBanResModel> GetAllPhongBan()
        {
            try
            {
                var data = _context.PhongBan
                    .Where(record => !record.IsDeleted)
                    .Select(record => new PhongBanResModel
                    {
                        Id = record.Id,
                        TenPhongBan = record.TenPhongBan,
                        TenPhongBanTiengAnh = record.TenPhongBanTiengAnh,
                        LoaiPhongBan = record.LoaiPhongBan,
                    })
                    .ToList();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
        //Create
        public void Create(PhongBanRequestModel model)
        {
            _context.PhongBan.Add(new PhongBan
            {
                TenPhongBan = model.TenPhongBan,
                TenPhongBanTiengAnh = model.TenPhongBanTiengAnh,
                LoaiPhongBan =LoaiPhongBan.PhongBanKhac,
            });
            _context.SaveChanges();
        }
        //Update
        public void Update(long id, PhongBanRequestModel model)
        {
            try
            {
                var data = _context.PhongBan.GetById(id);
                if (data != null)
                {
                    data.TenPhongBan = model.TenPhongBan;
                    data.TenPhongBanTiengAnh = model.TenPhongBanTiengAnh;
                    data.LoaiPhongBan = model.LoaiPhongBan;
                    _context.PhongBan.Update(data);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
        //Delete
        public void Delete(long id)
        {
            try
            {
                _context.PhongBan.Delete(id);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
        //GetPage
        public Task<BasePaginationResponseModel<PhongBanResModel>> GetPagePhongBan(BasePaginationRequestModel page)
        {
            var data = _context.PhongBan.Where(x=>!x.IsDeleted).Select(x => new PhongBanResModel
            {
                Id = x.Id,
                TenPhongBan = x.TenPhongBan,
                TenPhongBanTiengAnh = x.TenPhongBanTiengAnh,
                LoaiPhongBan = x.LoaiPhongBan
            });
            if (!page.Keyword.IsNullOrEmpty())
            {
                data = data.Where(x => x.TenPhongBan.Contains(page.Keyword));
            }
            var pageing = data.ApplyPaging(page.PageNo, page.PageSize, out var totalItem).ToList();
            return Task.FromResult(new BasePaginationResponseModel<PhongBanResModel>(page.PageNo, page.PageSize, pageing, totalItem));
        }
        //GetById
        public PhongBanResModel GetPhongBanById(long id)
        {
            try
            {
                var data = _context.PhongBan.GetAvailableByIdQueryable(id).Select(x=> new PhongBanResModel
                {
                    Id=x.Id,
                    TenPhongBan = x.TenPhongBan,
                    TenPhongBanTiengAnh = x.TenPhongBanTiengAnh,
                    LoaiPhongBan = x.LoaiPhongBan
                }).FirstOrDefault();
                if (data == null) throw new Exception();
                return data; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
        public async Task<List<PhongBanResModel>> GetPhongBanByLoaiPhongBan(LoaiPhongBan loaiPhongBan) {

            var res = await _context.PhongBan.Where(x=>x.LoaiPhongBan == loaiPhongBan).Select(c=> new PhongBanResModel
            {
                Id = c.Id,
                TenPhongBan = c.TenPhongBan,
                TenPhongBanTiengAnh = c.TenPhongBanTiengAnh,
                LoaiPhongBan = c.LoaiPhongBan,
                isDisplay = c.isDisplay
            }).ToListAsync();
            return res;
        }
        public void ChangeShowHidePhongBan(long id)
        {
            var res = _context.PhongBan.GetAvailableById(id);
            if (res == null) throw new Exception();
            res.isDisplay = !res.isDisplay;
            _context.PhongBan.Update(res);
            _context.SaveChanges();
        }
        public async Task<List<PhongBanResModel>> GetPhongBanByLoaiPhongBanActive(LoaiPhongBan loaiPhongBan)
        {

            var res = await _context.PhongBan.Where(x => x.LoaiPhongBan == loaiPhongBan && x.isDisplay).Select(c => new PhongBanResModel
            {
                Id = c.Id,
                TenPhongBan = c.TenPhongBan,
                TenPhongBanTiengAnh = c.TenPhongBanTiengAnh,
                LoaiPhongBan = c.LoaiPhongBan,
                isDisplay = c.isDisplay
            }).ToListAsync();
            return res;
        }
    }
}

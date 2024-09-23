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
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.BinhLuanServices
{
    public class BinhLuanServices : IBinhLuanServices
    {
        private readonly AppDbContext _context;
        public BinhLuanServices(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateBinhLuan(CreateOrUpdateBinhLuan data)
        {
            try
            {
                var newBinhLuan = new BinhLuan()
                {
                    NoiDung = data.NoiDung,
                    TinTucId = data.TinTucId,
                    TrangThai = data.TrangThai,
                    IsActive = false,
                    TaiKhoanId = data.TaiKhoanId,
                    ThoiGianBinhLuan = DateTime.Now
                };
                _context.BinhLuan.Add(newBinhLuan);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(data.TinTucId)));
            }
        }
        public async Task UpdateBinhLuan(long id, CreateOrUpdateBinhLuan data)
        {
            try
            {
                BinhLuan updateBinhLuan = _context.BinhLuan.GetAvailableById(id);
                updateBinhLuan.TinTucId = data.TinTucId;
                updateBinhLuan.NoiDung = data.NoiDung;
                updateBinhLuan.TrangThai = Enums.TrangThaiBinhLuan.DangChoDuyet;
                updateBinhLuan.ThoiGianBinhLuan = data.ThoiGianBinhLuan;
                updateBinhLuan.TaiKhoanId = data.TaiKhoanId;
                updateBinhLuan.IsActive = data.IsActive;
                _context.BinhLuan.Update(updateBinhLuan);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(data)));
            }
        }
        public async Task DeleteBinhLuan(long id)
        {
            _context.BinhLuan.Delete(id);
            await _context.SaveChangesAsync();
        }
        public async Task PheDuyetBinhLuan(long id, TrangThaiBinhLuan trangThai)
        {
            BinhLuan pheDuyetBinhLuan = _context.BinhLuan.GetAvailableById(id);
            pheDuyetBinhLuan.TrangThai = trangThai;
            _context.BinhLuan.Update(pheDuyetBinhLuan);
            await _context.SaveChangesAsync();
        }
        public IQueryable<BinhLuan> GetAll()
        {
            return _context.BinhLuan.OrderBy(record => record.TinTucId).AsQueryable();
        }
        public async Task<BinhLuanResponseModel> GetBinhLuanById(long id)
        {
            try
            {
                var binhLuan = await _context.BinhLuan.Select(x => new BinhLuanResponseModel
                {
                    Id = x.Id,
                    TinTucId = x.TinTucId,
                    NoiDung = x.NoiDung,
                    TrangThai = x.TrangThai,
                    TieuDe = x.TinTuc.TieuDe,
                    IsDeleted = x.IsDeleted,
                    Avatar = x.TaiKhoan.AnhDaiDien,
                    HoTen = x.TaiKhoan.HoTen,
                    Email = x.TaiKhoan.Email,
                    ThoiGianBinhLuan = x.ThoiGianBinhLuan,
                    IsActive = x.IsActive,

                }).Where(x => x.Id == id).FirstOrDefaultAsync();
                if (binhLuan == null)
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(KyTuyenSinh.Id)));
                }
                return binhLuan;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(KyTuyenSinh.Id)));
            }
        }
        public IQueryable<BinhLuanResponseModel> GetAllAvailable()
        {
            var result = _context.BinhLuan
               .Where(record => !record.IsDeleted)
               .Select(x => new BinhLuanResponseModel
               {
                   Id = x.Id,
                   TinTucId = x.TinTucId,
                   NoiDung = x.NoiDung,
                   TrangThai = x.TrangThai,
                   TieuDe = x.TinTuc.TieuDe,
                   IsDeleted = x.IsDeleted,
                   Avatar = x.TaiKhoan.AnhDaiDien,
                   HoTen = x.TaiKhoan.HoTen,
                   Email = x.TaiKhoan.Email,
                   ThoiGianBinhLuan = x.ThoiGianBinhLuan,
                   IsActive = x.IsActive,
               });
            return result;
        } 
        public async Task<BasePaginationResponseModel<BinhLuanResponseModel>> GetPagedBinhLuan(GetPagedBinhLuanRequesModel input)
        {
            var query = GetAllAvailable();
            query = ApplySearchAndFilter(query, input);
            var totalItems = 0;
                query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<BinhLuanResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<BinhLuanResponseModel>(input.PageNo, input.PageSize, result, totalItems);


        }
        private IQueryable<BinhLuanResponseModel> ApplySearchAndFilter(IQueryable<BinhLuanResponseModel> query, GetPagedBinhLuanRequesModel input)
        {
            // apply search
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(record => record.NoiDung.ToLower().Contains(keyword));
            }

            // apply filter
            if (input.TinTucId.HasValue)
            {
                query = query.Where(record => record.TinTucId == input.TinTucId.Value);
            }
            if (input.TuNgay.HasValue)
            {
                query = query.Where(e => e.ThoiGianBinhLuan >= input.TuNgay);
            }
            
            if (input.TuNgay.HasValue)
            {
                query = query.Where(e => e.ThoiGianBinhLuan <= input.DenNgay);
            }

            return query;
        }
        public async Task ShowHideBinhLuan(long id)
        {
            BinhLuan duyetBinhLuan = _context.BinhLuan.GetById(id);
            duyetBinhLuan.IsActive = !duyetBinhLuan.IsActive;
            _context.BinhLuan.Update(duyetBinhLuan);
            await _context.SaveChangesAsync();
        }

        public async Task<BasePaginationResponseModel<BinhLuanResponseModel>> GetPagedBinhLuanActive(GetPagedBinhLuanRequesModel input)
        {
            var query = GetAllAvailable().Where(x=> x.IsActive == true);
            query = ApplySearchAndFilter(query, input);
            var totalItems = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<BinhLuanResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<BinhLuanResponseModel>(input.PageNo, input.PageSize, result, totalItems);


        }
    }
}

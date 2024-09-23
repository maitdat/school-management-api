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

namespace NS.Core.Business.DoiNgayThiService
{
    public class DoiNgayThiService : IDoiNgayThiService
    {
        private readonly AppDbContext _context;

        public DoiNgayThiService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<HeDaoTaoDropdownResponse>> GetHeDaoTaoDropDown(long kyTuyenSinhId)
        {
            var heDaoTaoDropDownList = await _context.HeDaoTao
                    .Where(e => e.MonThiTuyenSinhs.Any(m => m.KyTuyenSinhId == kyTuyenSinhId))
                    .Select(e => HeDaoTaoDropdownResponse.Mapping(e))
                    .ToListAsync()
                ;
            return heDaoTaoDropDownList;
        }

        public async Task<List<LopDangKyDropdownResponse>> GetLopDangKyDropDown(long kyTuyenSinhId)
        {
            var LopDangKyList = await _context.LopDuThi
                    .Where(e => e.MonThiTuyenSinhs.Any(m => m.KyTuyenSinhId == kyTuyenSinhId))
                    .Select(e => LopDangKyDropdownResponse.Mapping(e))
                    .ToListAsync()
                ;
            return LopDangKyList;
        }

        public async Task<BasePaginationResponseModel<DoiNgayThiResponseModel>> GetAll(DoiNgayThiRequestModel model)
        {
            var query = _context.DoiNgayThi
                .Include(e => e.HoSoThi)
                .ThenInclude(e => e.HoSoTuyenSinh)
                .Include(e => e.ThoiGianThi)
                .AsQueryable();

            ApplySearch(ref query, model);
            ApplyFilter(ref query, model);
            ApplySort(ref query);

            int totalItems = 0;

            query = query.ApplyPaging(model.PageNo, model.PageSize, out totalItems);

            List<DoiNgayThiResponseModel> result = query
                .Select(e => DoiNgayThiResponseModel.Mapping(e))
                .ToList();

            return new BasePaginationResponseModel<DoiNgayThiResponseModel>(
                model.PageNo,
                model.PageSize,
                result,
                totalItems
            );
        }

        private void ApplySearch(ref IQueryable<DoiNgayThi> query, DoiNgayThiRequestModel model)
        {
            string keyword = model.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword))
                query = query
                    .Where(e => e.HoSoThi.HoSoTuyenSinh.HoTen.Contains(keyword));
        }

        private void ApplyFilter(ref IQueryable<DoiNgayThi> query, DoiNgayThiRequestModel model)
        {
            if (model.KyTuyenSinhId > 0)
            {
                query = query.Where(e => e.HoSoThi.HoSoTuyenSinh.KyTuyenSinhId == model.KyTuyenSinhId);
            }

            if (model.HeDaoTaoId > 0)
            {
                query = query.Where(e => e.HoSoThi.HoSoTuyenSinh.HeDaoTaoId == model.HeDaoTaoId);
            }

            if (model.LopDangKyId > 0)
            {
                query = query.Where(e => e.HoSoThi.HoSoTuyenSinh.LopDuThiId == model.LopDangKyId);
            }

            if (model.NgayDangKyBatDau > DateTime.MinValue)
            {
                query = query.Where(e => e.HoSoThi.HoSoTuyenSinh.ThoiGianThi.NgayThi >= model.NgayDangKyBatDau);
            }

            if (model.NgayDangKyKetThuc < DateTime.MaxValue)
            {
                query = query.Where(e => e.HoSoThi.HoSoTuyenSinh.ThoiGianThi.NgayThi <= model.NgayDangKyKetThuc);
            }
        }

        private void ApplySort(ref IQueryable<DoiNgayThi> query)
        {
            query = query.OrderByDescending(e => e.HoSoThi.HoSoTuyenSinh.MaSoHoSo);
        }
    }
}
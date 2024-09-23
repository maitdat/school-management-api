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

namespace NS.Core.Business.ThoiGianThiService
{
    public class ThoiGianThiServices : IThoiGianThiServices
    {
        public readonly AppDbContext _context;
        public ThoiGianThiServices(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<ThoiGianThi> GetAllAvailable()
        {
            return _context.ThoiGianThi.Where(record => !record.IsDeleted);
        }
        public async Task<ThoiGianThiResponseModel> GetThoiGianThiById(long id)
        {
            var thoiGianThi = _context.ThoiGianThi.GetById(id);
            return new ThoiGianThiResponseModel
            {
                Id = thoiGianThi.Id,
                KyTuyenSinhId = thoiGianThi.KyTuyenSinhId,
                CaThi = thoiGianThi.CaThi,
                DotThi = thoiGianThi.DotThi,
                NgayThi = thoiGianThi.NgayThi.ToString("YYYY-MM-DD"),
                GioDuThi = thoiGianThi.GioDuThi.ToString("HH:mm"),
                GioDonCon = thoiGianThi.GioDonCon.ToString("HH:mm"),
                GhiChu = thoiGianThi.GhiChu
            };
        }
        public async Task CreateThoiGianThi(CreateThoiGianThiRequestModel input)
        {
            var thoiGianThi = new ThoiGianThi
            {
                KyTuyenSinhId = input.KyTuyenSinhId,
                CaThi = input.CaThi,
                DotThi = input.DotThi,
                NgayThi = DateTime.Parse(input.NgayThi),
                GioDuThi = DateTime.Parse(input.GioDuThi),
                GioDonCon = DateTime.Parse(input.GioDonCon),
                GhiChu = input.GhiChu,
            };
            _context.ThoiGianThi.Add(thoiGianThi);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateThoiGianThi(long id, UpdateThoiGianThiRequestModel input)
        {
            var thoiGianThi = _context.ThoiGianThi.GetAvailableById(id);
            if (thoiGianThi != null)
            {
                thoiGianThi.CaThi = input.CaThi;
                thoiGianThi.DotThi = input.DotThi;
                thoiGianThi.NgayThi = DateTime.Parse(input.NgayThi);
                thoiGianThi.GioDuThi = DateTime.Parse(input.GioDuThi);
                thoiGianThi.GioDonCon = DateTime.Parse(input.GioDonCon);
                thoiGianThi.GhiChu = input.GhiChu;
                thoiGianThi.KyTuyenSinhId = input.KyTuyenSinhId;
                _context.ThoiGianThi.Update(thoiGianThi);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(input.Id)));
            }
        }
        public Task<BasePaginationResponseModel<ThoiGianThiResponseModel>> GetPagedThoiGianThi(GetPagedThoiGianThiRequestModel input)
        {
            var res = GetAllAvailable().Select(x => new ThoiGianThiResponseModel
            {
                Id = x.Id,
                CaThi = x.CaThi,
                DotThi = x.DotThi,
                GhiChu = x.GhiChu,
                NgayThi = x.NgayThi.ToString("YYYY-MM-DD"),
                GioDuThi = x.GioDuThi.ToString("HH:mm"),
                GioDonCon = x.GioDonCon.ToString("HH:mm"),
                KyTuyenSinhId = x.KyTuyenSinhId,
            });
            if (!input.Keyword.IsNullOrEmpty())
            {
                res = res.Where(x => x.DotThi.ToString().Contains(input.Keyword.ToLower()));
            }
            var paging = res.ApplyPaging(input.PageNo, input.PageSize, out var totalItem).ToList();
            return Task.FromResult(new BasePaginationResponseModel<ThoiGianThiResponseModel>(input.PageNo, input.PageSize, paging, totalItem));
        }
        public Task<BasePaginationResponseModel<ThoiGianThiResponseModel>> GetPagedThoiGianThiByKyTuyenSinhId(GetPagedThoiGianThiByKyTuyenSinhIdRequestModel input)
        {
            var query = _context.ThoiGianThi.Where(x => x.KyTuyenSinhId.Equals(input.KyTuyenSinhId) && !x.IsDeleted)
                                            .Select(x => new ThoiGianThiResponseModel()
                                            {
                                                Id = x.Id,
                                                KyTuyenSinhId = x.KyTuyenSinhId,
                                                CaThi = x.CaThi,
                                                DotThi = x.DotThi,
                                                NgayThi = x.NgayThi.ToString("YYYY-MM-DD"),
                                                GioDuThi = x.GioDuThi.ToString("HH:mm"),
                                                GioDonCon = x.GioDonCon.ToString("HH:mm"),
                                                GhiChu = x.GhiChu,
                                            });
            if (!input.CaThis.IsNullOrEmpty())
            {
                query = query.Where(x => input.CaThis.Contains(x.CaThi));
            }
            var paging = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItem).ToList();
            return Task.FromResult(new BasePaginationResponseModel<ThoiGianThiResponseModel>(input.PageNo, input.PageSize, paging, totalItem));
        }
        public async Task DeleteThoiGianThi(long id)
        {
            _context.ThoiGianThi.Delete(id);
            await _context.SaveChangesAsync();
        }
    }
}

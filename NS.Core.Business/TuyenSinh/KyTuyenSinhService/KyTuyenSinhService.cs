using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.KyTuyenSinhService
{
    public class KyTuyenSinhService : IKyTuyenSinhService
    {
        private readonly AppDbContext _context;
        public KyTuyenSinhService(AppDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task CreateKyTuyenSinh(CreateOrUpdateKyTuyenSinhModel data)
        {
            try
            {
                var result = new KyTuyenSinh()
                {
                    TenKyTuyenSinh = data.TenKyTuyenSinh,
                    NamHocId = data.NamHocId,
                    ChiTieuTuyenSinh1 = data.ChiTieuTuyenSinh1,
                    ChiTieuTuyenSinh2 = data.ChiTieuTuyenSinh2,
                    ChiTieuTuyenSinh3 = data.ChiTieuTuyenSinh3,
                    ChiTieuTuyenSinh4 = data.ChiTieuTuyenSinh4,
                    ChiTieuTuyenSinh5 = data.ChiTieuTuyenSinh5,
                    TrangThaiKyTuyenSinh = Enums.TrangThaiKyTuyenSinh.Mo, 
                };
                _context.Add(result);
                _context.SaveChanges();
            }
            catch 
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(data.TenKyTuyenSinh)));
            }
        }

        public async Task DeleteKyTuyenSinh(long id)
        {
            _context.KyTuyenSinh.Delete(id);
            await _context.SaveChangesAsync();
        }
        public async Task<BasePaginationResponseModel<KyTuyenSinhResponseModel>> GetPagedKyTuyenSinh(KyTuyenSinhRequestModel input)
        {
            var query = GetAllAvailable().Select(x=> new KyTuyenSinhResponseModel
            {
                Id = x.Id,
                TenKyTuyenSinh =x.TenKyTuyenSinh,
                TenNamHoc =x.NamHoc.TenNamHoc,
                NamHocId = x.NamHocId,
                ChiTieuTuyenSinh1=x.ChiTieuTuyenSinh1,
                ChiTieuTuyenSinh2 = x.ChiTieuTuyenSinh2,
                ChiTieuTuyenSinh3 = x.ChiTieuTuyenSinh3,
                ChiTieuTuyenSinh4 = x.ChiTieuTuyenSinh4,
                ChiTieuTuyenSinh5 = x.ChiTieuTuyenSinh5,
                TrangThaiKyTuyenSinh = x.TrangThaiKyTuyenSinh
            });
            if (!input.Keyword.IsNullOrEmpty())
            {
                query = query.Where(c=>c.TenKyTuyenSinh.ToLower().Contains(input.Keyword.ToLower()));
            }
            if (!input.NamHocIds.IsNullOrEmpty() && input.NamHocIds.Any())
            {
                query = query.Where(c => input.NamHocIds.Contains(c.NamHocId));
            }
            if (!input.TrangThaiKyTuyenSinhs.IsNullOrEmpty() && input.TrangThaiKyTuyenSinhs.Any())
            {
                query = query.Where(c => input.TrangThaiKyTuyenSinhs.Contains(c.TrangThaiKyTuyenSinh));
            }
            var paging  = query.ApplyPaging(input.PageNo, input.PageSize).ToList();
            return await Task.FromResult(new BasePaginationResponseModel<KyTuyenSinhResponseModel>(input.PageNo, input.PageSize,paging,query.Count()));
        }
      
        public async Task UpdateKyTuyenSinh(long itemId, CreateOrUpdateKyTuyenSinhModel data)
        {
            try
            {
                var upadateKyTuyenSinh = _context.KyTuyenSinh.GetAvailableById(itemId);
                upadateKyTuyenSinh.TenKyTuyenSinh = data.TenKyTuyenSinh;
                upadateKyTuyenSinh.NamHocId = data.NamHocId;
                upadateKyTuyenSinh.ChiTieuTuyenSinh1 = data.ChiTieuTuyenSinh1;
                upadateKyTuyenSinh.ChiTieuTuyenSinh2 = data.ChiTieuTuyenSinh2;
                upadateKyTuyenSinh.ChiTieuTuyenSinh3 = data.ChiTieuTuyenSinh3;
                upadateKyTuyenSinh.ChiTieuTuyenSinh4 = data.ChiTieuTuyenSinh4;
                upadateKyTuyenSinh.ChiTieuTuyenSinh5 = data.ChiTieuTuyenSinh5;
                upadateKyTuyenSinh.TrangThaiKyTuyenSinh = data.TrangThaiKyTuyenSinh;

                _context.Update(upadateKyTuyenSinh);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(data.TenKyTuyenSinh)));
            }
        }
        public IQueryable<KyTuyenSinh> GetAllAvailable()
        {
            return _context.KyTuyenSinh.Where(c => !c.IsDeleted);
        }

        public async Task<List<KyTuyenSinhResponseModel>> GetAll()
        {
            return _context.KyTuyenSinh.Select(x => new KyTuyenSinhResponseModel
            {
                Id = x.Id,
                TenKyTuyenSinh = x.TenKyTuyenSinh,
                NamHocId = x.NamHocId,
                TenNamHoc = x.NamHoc.TenNamHoc,
                ChiTieuTuyenSinh1 = x.ChiTieuTuyenSinh1,
                ChiTieuTuyenSinh2 = x.ChiTieuTuyenSinh2,
                ChiTieuTuyenSinh3 = x.ChiTieuTuyenSinh3,
                ChiTieuTuyenSinh4 = x.ChiTieuTuyenSinh4,
                ChiTieuTuyenSinh5 = x.ChiTieuTuyenSinh5,
                TrangThaiKyTuyenSinh = x.TrangThaiKyTuyenSinh
            }).ToList();
        }

        public async Task<KyTuyenSinhResponseModel> GetKyTuyenSinhById(long itemId)
        {
            try
            {
                var kyTuyenSinh = await _context.KyTuyenSinh.Select(x => new KyTuyenSinhResponseModel
                {
                    Id = x.Id,
                    TenKyTuyenSinh = x.TenKyTuyenSinh,
                    NamHocId = x.NamHocId,
                    TenNamHoc = x.NamHoc.TenNamHoc,
                    ChiTieuTuyenSinh1 = x.ChiTieuTuyenSinh1,
                    ChiTieuTuyenSinh2 = x.ChiTieuTuyenSinh2,
                    ChiTieuTuyenSinh3 = x.ChiTieuTuyenSinh3,
                    ChiTieuTuyenSinh4 = x.ChiTieuTuyenSinh4,
                    ChiTieuTuyenSinh5 = x.ChiTieuTuyenSinh5,
                    TrangThaiKyTuyenSinh = x.TrangThaiKyTuyenSinh 
                }).Where(x => x.Id == itemId).FirstOrDefaultAsync();
                if (kyTuyenSinh == null)
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(KyTuyenSinh.Id)));
                }
                return kyTuyenSinh;
            }
            catch
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(KyTuyenSinh.Id)));
            }
        }

        public async Task<List<NamHocResponseModel>> GetNamHocForDropdown()
        {
            return _context.NamHoc.Select(c => new NamHocResponseModel
            {
                Id = c.Id,
                TenNamHoc = c.TenNamHoc,
            }).ToList();
        }
        public async Task<List<KhoiReponseModel>> GetKhoiForDropdown()
        {
            return _context.Khoi.Select(c => new KhoiReponseModel
            {
                Id = c.Id,
                TenKhoi = c.TenKhoi,
                TenKhoiTiengAnh = c.TenKhoiEnglish,
            }).ToList();
        }
    }
}

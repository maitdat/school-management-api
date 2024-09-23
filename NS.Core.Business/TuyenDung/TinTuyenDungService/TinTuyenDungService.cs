using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Business.SampleService;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace NS.Core.Business.TinTuyenDungService
{
    public class TinTuyenDungService : ITinTuyenDungService
    {
        private readonly AppDbContext _context;
        public TinTuyenDungService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public IQueryable<TinTuyenDung> GetAllTinTuyenDungAvalable()
        {
            return _context.TinTuyenDung.Where(x => !x.IsDeleted);
        }

        public async Task<BasePaginationResponseModel<TinTuyenDungResponseModel>> GetPagedTinTuyenDung(GetPagedTinTuyenDungResquestModel input)
        {
            try
            {
                var query = GetAllAvalable();
                query = ApplySearchAndFilter(query, input);
                var totalItem = 0;

                query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);

                List<TinTuyenDungResponseModel> result = query.ToList();

                return await Task.FromResult(new BasePaginationResponseModel<TinTuyenDungResponseModel>(input.PageNo, input.PageSize, result, totalItem));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task CapNhatTrangThaiTuyenDung(long id, Enums.TrangThaiTinTuyenDung trangThai)
        {
            var tinTuyenDung = _context.TinTuyenDung.GetById(id);
            tinTuyenDung.TrangThai = trangThai;
            _context.TinTuyenDung.Update(tinTuyenDung);
            await _context.SaveChangesAsync();
        }

        private IQueryable<TinTuyenDungResponseModel> GetAllAvalable()
        {
            var tinTuyenDungResponse = GetAllTinTuyenDungAvalable().Select(input => new TinTuyenDungResponseModel
            {
                Id = input.Id,
                TieuDe = input.TieuDe,
                TieuDeTiengAnh = input.TieuDeTiengAnh,
                NoiDung = input.NoiDung,
                NoiDungTiengAnh = input.NoiDungTiengAnh,
                TrangThai = input.TrangThai,
                NgayHetHan = input.NgayHetHan,
                TuyenDungViTriResponseModels = input.TuyenDungVitri.Select(child => new TuyenDungViTriResponseModel
                {
                    Id = child.Id,
                    TinTuyenDungId = child.TinTuyenDungId,
                    ViTriTuyenDungId = child.ViTriTuyenDungId,
                    TenViTri = child.ViTriTuyenDung.TenViTri

                }).ToList()
            });
            return tinTuyenDungResponse;
        }


        private IQueryable<TinTuyenDungResponseModel> ApplySearchAndFilter(IQueryable<TinTuyenDungResponseModel> query, GetPagedTinTuyenDungResquestModel input)
        {

            if (input.Keyword.IsNullOrEmpty())
            {
                query = query.Where(record => record.TieuDe.Contains(input.Keyword.ToLower())
                || record.TieuDeTiengAnh.Contains(input.Keyword.ToLower())
                || record.NoiDungTiengAnh.Contains(input.Keyword.ToLower())
                || record.NoiDung.Contains(input.Keyword.ToLower())
                );
            }
            if(input.TrangThai.HasValue)
            {
                query = query.Where(record => record.TrangThai==input.TrangThai);
            }
 
            if (input.NgayBatDau != DateTime.MinValue)
            {
                query = query.Where(record => record.NgayHetHan >= input.NgayBatDau);
            }
            if (input.NgayKetThuc != DateTime.MinValue)
            {
                query = query.Where(record => record.NgayHetHan <= input.NgayKetThuc);
            }
            return query;
        }
        private bool TestNgay(DateTime date)
        {
            if (date < DateTime.Now)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.SHOULD_GREATER_TODAY, nameof(date)));

            }
            return true;

        }
        public async Task CreateTinTuyenDung(TinTuyenDungResquestModel input)
        {
            try
            {
                if (TestNgay(input.NgayHetHan))
                {
                    var tinTuyenDung = new TinTuyenDung
                    {
                        TieuDe = input.TieuDe,
                        TieuDeTiengAnh = input.TieuDeTiengAnh,
                        NoiDung = input.NoiDung,
                        NoiDungTiengAnh = input.NoiDungTiengAnh,
                        TrangThai = Enums.TrangThaiTinTuyenDung.DangChoDuyet,
                        NgayHetHan = input.NgayHetHan,
                        TuyenDungVitri = input.ViTriTuyenDungIds.Select(c => new TuyenDungViTri
                        {
                            
                            ViTriTuyenDungId = c,
                        }).ToList()
                    };
                    _context.TinTuyenDung.Add(tinTuyenDung);
                    await _context.SaveChangesAsync();
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task EditTinTuyenDung(long id, TinTuyenDungResquestModel input)
        {
            try
            {
                var tinTuyenDung = _context.TinTuyenDung.GetById(id);
                tinTuyenDung.NoiDung = input.NoiDung;
                tinTuyenDung.NoiDungTiengAnh = input.NoiDungTiengAnh;
                tinTuyenDung.TieuDe = input.TieuDe;
                tinTuyenDung.TieuDeTiengAnh = input.TieuDeTiengAnh;
                tinTuyenDung.TrangThai= input.TrangThai;
                var index = GetAllTuyenDungViTriById(id);
                _context.TuyenDungVitri.RemoveRange(index);
                tinTuyenDung.TuyenDungVitri = input.ViTriTuyenDungIds.Select(c => new TuyenDungViTri
                {   
                    ViTriTuyenDungId = c,
                }).ToList();


                _context.TinTuyenDung.Update(tinTuyenDung);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IQueryable<TuyenDungViTri> GetAllTuyenDungViTriById(long tinTuyenDungId)
        {
            return _context.TuyenDungVitri.Where(x => x.TinTuyenDungId == tinTuyenDungId).AsQueryable();
        }
        public async Task DeleteTinTuyenDung(long id)
        {
            try
            {
                _context.TinTuyenDung.Delete(id);
                var tuyenDungViTri = GetAllTuyenDungViTriById(id);
                _context.TuyenDungVitri.RemoveRange(tuyenDungViTri);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<TinTuyenDungResponseModel> GetByIdForDialog(long id)
        {
            var tinTuyenDungResponse = await _context.TinTuyenDung.Where(x => x.Id == id).Select(input =>
            new TinTuyenDungResponseModel
            {
                Id = input.Id,
                TieuDe = input.TieuDe,
                TieuDeTiengAnh = input.TieuDeTiengAnh,
                NoiDung = input.NoiDung,
                NoiDungTiengAnh = input.NoiDungTiengAnh,
                TrangThai = input.TrangThai,
                NgayHetHan = input.NgayHetHan,
                TuyenDungViTriResponseModels = input.TuyenDungVitri.Select(child => new TuyenDungViTriResponseModel
                {
                    Id = child.Id,
                    TinTuyenDungId = child.TinTuyenDungId,
                    ViTriTuyenDungId = child.ViTriTuyenDungId,
                    TenViTri = child.ViTriTuyenDung.TenViTri

                }).ToList()
            }).FirstOrDefaultAsync();
            return tinTuyenDungResponse;
        }

    }
}

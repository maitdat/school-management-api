using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.NhanVien;
using NS.Core.Models.RequestModels.ThucDon;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.NhanVien;
using NS.Core.Models.ResponseModels.ThucDon;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.ThucDonService
{
    public class ThucDonService : IThucDonService
    {   
        private static DateTime myDate = new DateTime();
        private readonly AppDbContext _context;
        public ThucDonService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<ThucDonResponseModel>> GetAll()
        {
            List<ThucDon> lstThucDon = _context.ThucDon.ToList();
            List<ThucDonResponseModel> lstThucDonResponseModel = CreateThucDonResponseModel(lstThucDon);
            return lstThucDonResponseModel;
        }

        public async Task<ThucDonResponseModel> GetById(long id)
        {
            List<ThucDon> thucDon = new List<ThucDon>
            {
                _context.ThucDon.GetById(id)
            };
            ThucDonResponseModel result = CreateThucDonResponseModel(thucDon).First();
            return result;
        }

        public async Task<List<ThucDonResponseModel>> GetAllAvailable()
        {
            List<ThucDon> lstThucDon = _context.ThucDon.Where(x => !x.IsDeleted).ToList();
            List<ThucDonResponseModel> lstThucDonResponseModel = CreateThucDonResponseModel(lstThucDon);
            return lstThucDonResponseModel;
        }

        private List<ThucDonResponseModel> CreateThucDonResponseModel (List<ThucDon> lstThucDon) 
        {
            List<ThucDonResponseModel> thucDonResponseModels = new List<ThucDonResponseModel>();
            lstThucDon.ForEach(x =>
            {
                thucDonResponseModels.Add(new ThucDonResponseModel
                {
                    Id = x.Id,
                    TenTuan = x.TenTuan,
                    TenTuanTiengAnh = x.TenTuanTiengAnh,
                    ThuHai = x.ThuHai,
                    ThuBa = x.ThuBa,
                    ThuTu = x.ThuTu,
                    ThuNam = x.ThuNam,
                    ThuSau = x.ThuSau,
                    AnSang = x.AnSang,
                    ThuHaiTiengAnh = x.ThuTuTiengAnh,
                    ThuBaTiengAnh = x.ThuBaTiengAnh,
                    ThuTuTiengAnh = x.ThuTuTiengAnh,
                    ThuNamTiengAnh = x.ThuNamTiengAnh,
                    ThuSauTiengAnh = x.ThuSauTiengAnh,
                    AnSangTiengAnh = x.AnSangTiengAnh,
                    MauThuHai = x.MauThuHai,
                    MauThuBa = x.MauThuBa,
                    MauThuTu = x.MauThuTu,
                    MauThuNam = x.MauThuNam,
                    MauThuSau = x.MauThuSau,
                    MauAnSang = x.MauAnSang,
                    TuNgay = x.TuNgay,
                    DenNgay = x.DenNgay,
                    NgayTao = x.NgayTao,
                    LinkAnh = x.LinkAnh
                });
            });
            return thucDonResponseModels;
        }

        public async Task<BasePaginationResponseModel<ThucDonResponseModel>> GetPagedThucDon(GetPagedThucDonRequestModel input)
        {
            var query = _context.ThucDon.Where(x => !x.IsDeleted).Select(x => new ThucDonResponseModel
            {
                Id = x.Id,
                TenTuan = x.TenTuan,
                TenTuanTiengAnh = x.TenTuanTiengAnh,
                ThuHai = x.ThuHai,
                ThuBa = x.ThuBa,
                ThuTu = x.ThuTu,
                ThuNam = x.ThuNam,
                ThuSau = x.ThuSau,
                AnSang = x.AnSang,
                ThuHaiTiengAnh = x.ThuTuTiengAnh,
                ThuBaTiengAnh = x.ThuBaTiengAnh,
                ThuTuTiengAnh = x.ThuTuTiengAnh,
                ThuNamTiengAnh = x.ThuNamTiengAnh,
                ThuSauTiengAnh = x.ThuSauTiengAnh,
                AnSangTiengAnh = x.AnSangTiengAnh,
                MauThuHai = x.MauThuHai,
                MauThuBa = x.MauThuBa,
                MauThuTu = x.MauThuTu,
                MauThuNam = x.MauThuNam,
                MauThuSau = x.MauThuSau,
                MauAnSang = x.MauAnSang,
                TuNgay = x.TuNgay,
                DenNgay = x.DenNgay,
                NgayTao = x.NgayTao,
                LinkAnh = x.LinkAnh
            }).AsQueryable();
            query = ApplySearchAndFilter(query, input);
            var totalItems = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<ThucDonResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<ThucDonResponseModel>(input.PageNo, input.PageSize, result, totalItems);
        }

        private IQueryable<ThucDonResponseModel> ApplySearchAndFilter(IQueryable<ThucDonResponseModel> query, GetPagedThucDonRequestModel input)
        {
            // apply search
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(record =>
                    record.TenTuan.ToLower().Contains(keyword) ||
                    record.TenTuanTiengAnh.ToLower().Contains(keyword));
            }

            //apply filter
            if (input.TuNgay != myDate)
            {
                query = query.Where(record => record.TuNgay >= input.TuNgay);
            }
            if (input.DenNgay != myDate)
            {
                query = query.Where(record => record.DenNgay <= input.DenNgay);
            }
            //if (input.)

            return query;
        }
        public async Task Create(ThucDonRequestModel model, string url)
        {
            ThucDon thucDon = new ThucDon
            {
                TenTuan = model.TenTuan,
                TenTuanTiengAnh = model.TenTuanTiengAnh,
                TuNgay = model.TuNgay,
                DenNgay = model.DenNgay,
                NgayTao = DateTime.Now,
                LinkAnh = url,
                MauThuHai = model.MauThuHai,
                MauThuBa = model.MauThuBa,
                MauThuTu = model.MauThuTu,
                MauThuNam = model.MauThuNam,
                MauThuSau = model.MauThuSau,
                MauAnSang = model.MauAnSang
            };
            _context.ThucDon.Add(thucDon);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateThucDon(long id, ThucDonRequestModel model, string url)
        {
            ThucDon thucDon = _context.ThucDon.GetById(id);
            thucDon.TenTuan = model.TenTuan;
            thucDon.TenTuanTiengAnh = model.TenTuanTiengAnh;
            thucDon.TuNgay = model.TuNgay;
            thucDon.DenNgay = model.DenNgay;
            thucDon.NgayTao = DateTime.Now;
            thucDon.LinkAnh = url == "" ? thucDon.LinkAnh : url;
            _context.ThucDon.Update(thucDon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateChiTietThucDon(long id, ChiTietThucDonRequestModel model)
        {
            ThucDon thucDon = _context.ThucDon.GetById(id);
            thucDon.ThuHai = model.ThuHai;
            thucDon.ThuBa = model.ThuBa;
            thucDon.ThuTu = model.ThuTu;
            thucDon.ThuNam = model.ThuNam;
            thucDon.ThuSau = model.ThuSau;
            thucDon.AnSang = model.AnSang;
            thucDon.ThuHaiTiengAnh = model.ThuHaiTiengAnh;
            thucDon.ThuBaTiengAnh = model.ThuBaTiengAnh;
            thucDon.ThuTuTiengAnh = model.ThuTuTiengAnh;
            thucDon.ThuNamTiengAnh = model.ThuNamTiengAnh;
            thucDon.ThuSauTiengAnh = model.ThuSauTiengAnh;
            thucDon.AnSangTiengAnh = model.AnSangTiengAnh;
            thucDon.MauThuHai = model.MauThuHai;
            thucDon.MauThuBa = model.MauThuBa;
            thucDon.MauThuTu = model.MauThuTu;
            thucDon.MauThuNam = model.MauThuNam;
            thucDon.MauThuSau = model.MauThuSau;
            thucDon.MauAnSang = model.MauAnSang;
            thucDon.NgayTao = DateTime.Now;
            _context.ThucDon.Update(thucDon);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            _context.ThucDon.Delete(id);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ThucDonResponseModel>> GetRelatedThucDon(DateTime startDate)
        {
            List<ThucDon> relatedThucDon = new List<ThucDon>();

            IQueryable<ThucDon> nextThucDon = _context.ThucDon
                       .Where(x => x.IsDeleted == false && x.TuNgay < startDate)
                       .OrderByDescending(x => x.TuNgay);

            IQueryable<ThucDon> prevThucDon = _context.ThucDon
                       .Where(x => x.IsDeleted == false && x.TuNgay > startDate)
                       .OrderBy(x => x.TuNgay);

            if (nextThucDon.IsNullOrEmpty())
            {
                relatedThucDon.AddRange(prevThucDon.Take(2).ToList());
            }
            else if (prevThucDon.IsNullOrEmpty())
            {
                relatedThucDon.AddRange(nextThucDon.Take(2).ToList());
            }
            else
            {
                relatedThucDon.Add(prevThucDon.FirstOrDefault());
                relatedThucDon.Add(nextThucDon.FirstOrDefault());
            }

            var res = await Task.FromResult(relatedThucDon.Select(x => ThucDonResponseModel.Mapping(x)).ToList());
            return res;
        }
    }
}

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
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.HoSoTuyenDungService
{
    public class HoSoTuyenDungService : IHoSoTuyenDungService
    {
        private readonly AppDbContext _context;
        public HoSoTuyenDungService(AppDbContext context)
        {
            _context = context; 
        }
        public IQueryable<HoSoTuyenDung> GetAll()
        {
            return _context.HoSoTuyenDung.AsQueryable();
        }
        public IQueryable<HoSoTuyenDung> GetAllAvailable()
        {
            return GetAll().Where(x=>!x.IsDeleted).AsQueryable();
        }
        public HoSoTuyenDungResponseModel GetHoSoTuyenDung(long id) {
            var hoSo = GetAllAvailable().Where(x => x.Id == id).
            Select(x => new HoSoTuyenDungResponseModel
            {
                Id = x.Id,
                TaiKhoanId = x.TaiKhoanId,
                ViTriTuyenDungId = x.ViTriTuyenDungId,
                ViTriTuyenDung = x.ViTriTuyenDung.TenViTri,
                AnhHoSo = x.AnhHoSo,
                FileCV = x.FileCV,
                TrangThai = x.TrangThai,
                ChungChiLienQuan = x.ChungChiLienQuan.Select(y => new ChungChiLienQuanResponseModel
                {
                    Id = y.Id,
                    HoSoTuyenDungId = y.HoSoTuyenDungId,
                    TenChungChi = y.TenChungChi,
                    FileChungChi = y.FileChungChi,
                    KetQua = y.KetQua,

                }).ToList(),
                ViTriBoSung = x.ViTriBoSung.Select(y => new ViTriBoSungResponseModel
                {
                    Id = y.ViTriTuyenDungId,
                    TenViTri = x.ViTriTuyenDung.TenViTri,
                    TenViTriTiengAnh = x.ViTriTuyenDung.TenViTriTiengAnh
                }).ToList()
            }).FirstOrDefault();
            return hoSo;
        }
        public async Task AddHoSoTuyenDung(HoSoTuyenDungRequestModel hoSoTuyenDung)
        {
            _context.HoSoTuyenDung.Add(new HoSoTuyenDung
            {
                TaiKhoanId = hoSoTuyenDung.TaiKhoanId,
                ViTriTuyenDungId = hoSoTuyenDung.ViTriTuyenDungId,
                AnhHoSo = hoSoTuyenDung.AnhHoSo,
                FileCV = hoSoTuyenDung.FileCV,
                TrangThai = hoSoTuyenDung.TrangThai,
                ViTriBoSung = hoSoTuyenDung.ViTriBoSung.Select(x=> new ViTriBoSung { ViTriTuyenDungId = x.Id,
               
                }).ToList(),
                ChungChiLienQuan = hoSoTuyenDung.ChungChiLienQuan.Select(x => new ChungChiLienQuan
                {
                    TenChungChi = x.TenChungChi,
                    FileChungChi = x.FileChungChi,
                    KetQua = x.KetQua
                }).ToList(),

            });
           await _context.SaveChangesAsync();
        }
        public Task<BasePaginationResponseModel<HoSoTuyenDungResponseModel>> GetListHoSoTuyenDung(BasePaginationRequestModel page)
        {
           
            var data = GetAllAvailable().Select(x => new HoSoTuyenDungResponseModel
            {
                Id = x.Id,
                TaiKhoanId = x.TaiKhoanId,
                ViTriTuyenDungId = x.ViTriTuyenDungId,
                ViTriTuyenDung = x.ViTriTuyenDung.TenViTri,
                AnhHoSo = x.AnhHoSo,
                FileCV = x.FileCV,
                TrangThai = x.TrangThai,
                ChungChiLienQuan = x.ChungChiLienQuan.Select(y => new ChungChiLienQuanResponseModel{ Id = y.Id,HoSoTuyenDungId = y.HoSoTuyenDungId,TenChungChi = y.TenChungChi,FileChungChi = y.FileChungChi,
                    KetQua = y.KetQua,
                }).ToList(),
                ViTriBoSung = x.ViTriBoSung
                .Select(y => new ViTriBoSungResponseModel{
                    Id = y.ViTriTuyenDungId,
                    TenViTri = x.ViTriTuyenDung.TenViTri,
                    TenViTriTiengAnh = x.ViTriTuyenDung.TenViTriTiengAnh
                }).ToList(),
            });;;
            if (!page.Keyword.IsNullOrEmpty())
            {
            data = data.Where(x => x.ViTriTuyenDung.Contains(page.Keyword));
            }
            var pageing = data.ApplyPaging(page.PageNo,page.PageSize,out var totalItem).ToList();
            return Task.FromResult(new BasePaginationResponseModel<HoSoTuyenDungResponseModel>(page.PageNo, page.PageSize, pageing, totalItem));
        }
        public async Task DeleteHoSoTuyenDung(long id)
        {
            _context.HoSoTuyenDung.Delete(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateHoSoTuyenDung(long id,HoSoTuyenDungRequestModel hoSoTuyenDungRequestModel)
        {
            var updateHoso = GetAllAvailable().Where(x=>x.Id == id).FirstOrDefault();
            updateHoso.TaiKhoanId = hoSoTuyenDungRequestModel.TaiKhoanId;
            updateHoso.ViTriTuyenDungId = hoSoTuyenDungRequestModel.ViTriTuyenDungId;
            updateHoso.AnhHoSo = hoSoTuyenDungRequestModel.AnhHoSo;
            updateHoso.FileCV = hoSoTuyenDungRequestModel.FileCV;
            updateHoso.TrangThai = hoSoTuyenDungRequestModel.TrangThai;
            var removeVitri = _context.ViTriBoSung.Where(x => x.HoSoTuyenDungId == id).ToList();
            _context.ViTriBoSung.RemoveRange(removeVitri);
            updateHoso.ViTriBoSung = hoSoTuyenDungRequestModel.ViTriBoSung.Select(x => new ViTriBoSung { ViTriTuyenDungId = x.Id }).ToList();
            var removeChungChi = _context.ChungChiLienQuan.Where(x=>x.HoSoTuyenDungId == id).ToList();
            _context.ChungChiLienQuan.RemoveRange(removeChungChi);
            updateHoso.ChungChiLienQuan = hoSoTuyenDungRequestModel.ChungChiLienQuan.Select(x => new ChungChiLienQuan{TenChungChi = x.TenChungChi,FileChungChi = x.FileChungChi,KetQua = x.KetQua }).ToList();
            _context.HoSoTuyenDung.Update(updateHoso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatus(long id,TrangThaiHoSoTuyenDung hoSoTuyenDung)
        {
           var hoSo = _context.HoSoTuyenDung.GetAvailableById(id);
            hoSo.TrangThai = hoSoTuyenDung;
            _context.HoSoTuyenDung.Update(hoSo);
            await _context.SaveChangesAsync();

        }
    }
}

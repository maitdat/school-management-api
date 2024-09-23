using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.NguoiLienQuanServices
{
    public class NguoiLienQuanServices : INguoiLienQuanServices
    {
        private readonly AppDbContext _context;

        public NguoiLienQuanServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNewNguoiLienQuan(LoaiQuanHe loaiQuanHe, NguoiLienQuanRequestModel newNguoiLienQuan)
        {
            var searchHoSoTuyenSinh = GetHoSoTuyenSinhById(newNguoiLienQuan.HoSoTuyenSinhId).FirstOrDefault();
            if (searchHoSoTuyenSinh != null)
            {
                
                _context.Add(new NguoiLienQuan
                {
                    HoSoTuyenSinhId = newNguoiLienQuan.HoSoTuyenSinhId,
                    HoTen = newNguoiLienQuan.HoTen,
                    SoDienThoai = newNguoiLienQuan.SoDienThoai,
                    SoDienThoaiCoQuan = newNguoiLienQuan.SoDienThoaiCoQuan,
                    ChucVu = newNguoiLienQuan.ChucVu,
                    NgheNghiep = newNguoiLienQuan.NgheNghiep,
                    CoQuan = newNguoiLienQuan.CoQuan,
                    Email = newNguoiLienQuan.Email,
                    LoaiQuanHe = loaiQuanHe
                });
              await  _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(newNguoiLienQuan.HoSoTuyenSinhId)));
            }
        }

        public async Task UpdateNguoiLienQuan(long nguoiLienQuanId,LoaiQuanHe loaiQuanHe, NguoiLienQuanRequestModel nguoiLienQuan)
        {
            var updateNguoiLienQuan = _context.NguoiLienQuan.GetById(nguoiLienQuanId);
            if (updateNguoiLienQuan != null)
            {
                    updateNguoiLienQuan.HoSoTuyenSinhId = nguoiLienQuan.HoSoTuyenSinhId;
                    updateNguoiLienQuan.HoTen = nguoiLienQuan.HoTen;
                    updateNguoiLienQuan.SoDienThoai = nguoiLienQuan.SoDienThoai;
                    updateNguoiLienQuan.SoDienThoaiCoQuan = nguoiLienQuan.SoDienThoaiCoQuan;
                    updateNguoiLienQuan.CoQuan = nguoiLienQuan.CoQuan;
                    updateNguoiLienQuan.ChucVu = nguoiLienQuan.ChucVu;
                    updateNguoiLienQuan.NgheNghiep = nguoiLienQuan.NgheNghiep;
                    updateNguoiLienQuan.Email = nguoiLienQuan.Email;
                    updateNguoiLienQuan.LoaiQuanHe = loaiQuanHe;
                    _context.Update(updateNguoiLienQuan);
                    await _context.SaveChangesAsync();

            }
            else
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(updateNguoiLienQuan.HoTen)));
            }
        }
        public async Task DeleteNguoiLienQuan(long id)
        {
            _context.NguoiLienQuan.Delete(id);
            await _context.SaveChangesAsync();
        }

       

        public IQueryable<NguoiLienQuan> GetAll()
        {
            return _context.NguoiLienQuan.AsQueryable();
        }

        public IQueryable<NguoiLienQuan> GetByHoSoTuyenSinhId(long hoSoTuyenId)
        {
            return _context.NguoiLienQuan.Where(x=>x.HoSoTuyenSinhId == hoSoTuyenId);
        }

        public IQueryable<NguoiLienQuan> GetById(long id)
        {
           return _context.NguoiLienQuan.Where(x=>x.Id == id);
        }

        public IQueryable<HoSoTuyenSinh> GetAllHoSoTuyenSinh()
        {
            return _context.HoSoTuyenSinh.AsQueryable();
        }

        public IQueryable<HoSoTuyenSinh> GetHoSoTuyenSinhById(long id)
        {
            return _context.HoSoTuyenSinh.Where(x=>x.Id ==id);
        }
        
    }
}

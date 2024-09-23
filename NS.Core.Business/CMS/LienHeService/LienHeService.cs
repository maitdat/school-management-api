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

namespace NS.Core.Business.LienHeService
{
    public class LienHeService : ILienHeService
    {
        private readonly AppDbContext _context;
        public LienHeService(AppDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task AddLienHe(AddOrUpdateLienHeRequestModel data)
        {
            try
            {
                _context.LienHe.Add(new LienHe
                {
                    BoPhanLienHeId = data.BoPhanLienHeId,
                    NguoiLienHe = data.NguoiLienHe,
                    SoDienThoai = data.SoDienThoai,
                    Email = data.Email,
                    TieuDe = data.TieuDe,
                    NoiDung = data.NoiDung,
                });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            };

        }

        public async Task UpdateLienHe(AddOrUpdateLienHeRequestModel update, long id)
        {
            try
            {
                if (GetById(id).IsNullOrEmpty()) throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(LienHe)));

                var updateLienHe = _context.LienHe.Find(id);
                updateLienHe.BoPhanLienHeId = update.BoPhanLienHeId;
                updateLienHe.NguoiLienHe = update.NguoiLienHe;
                updateLienHe.TieuDe = update.TieuDe;
                updateLienHe.Email = update.Email;
                updateLienHe.NoiDung = update.NoiDung;
                _context.SaveChanges();

                //if (GetById(id).Any())
                //{
                //    var updateLienHe = _context.LienHe.Find(id);
                //    updateLienHe.BoPhanLienHeId = update.BoPhanLienHeId;
                //    updateLienHe.NguoiLienHe = update.NguoiLienHe;
                //    updateLienHe.TieuDe = update.TieuDe;
                //    updateLienHe.Email = update.Email;
                //    updateLienHe.NoiDung = update.NoiDung;
                //    _context.SaveChanges();
                //}
                //else
                //{
                //    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(LienHe)));
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public async Task DeleteLienHe(long id)
        {
            try
            {
                if (GetById(id).IsNullOrEmpty()) throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(LienHe)));

                var deleteLienHe = _context.LienHe.Find(id);
                deleteLienHe.IsDeleted = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public IQueryable<LienHe> GetById(long id)
        {
            return _context.LienHe.Where(c => c.Id == id);
        }

        public IQueryable<LienHe> GetAll()
        {
            return _context.LienHe.AsQueryable();
        }

        public IQueryable<LienHe> GetAllAvailable()
        {
            return GetAll().Where(c => !c.IsDeleted);
        }
        public async Task<List<LienHeResponseModel>> GetAllForDropdown()
        {
            return await GetAllAvailable().Select(c => new LienHeResponseModel
            {
                Id = c.Id,
                BoPhanLienHeId = c.BoPhanLienHeId,
                SoDienThoai = c.SoDienThoai,
                NoiDung = c.NoiDung,
                TieuDe = c.TieuDe,
                Email = c.Email,
                NguoiLienHe = c.NguoiLienHe
            }).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.Business.ViTriTuyenDungService
{
    public class ViTriTuyenDungService:IViTriTuyenDungService
    {
        private readonly AppDbContext _context;
        public ViTriTuyenDungService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateViTriTuyenDung (ViTriTuyenDungResquestModel input)
        {
            try
            { 
                var viTriTuyenDung= new ViTriTuyenDung()
                {
                TenViTri = input.TenViTri,
                TenViTriTiengAnh = input.TenViTriTiengAnh,

                };
                _context.ViTriTuyenDung.Add(viTriTuyenDung);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task EditViTriTuyenDung(long id,ViTriTuyenDungResquestModel input)
        {
            try
            {
                var index= _context.ViTriTuyenDung.GetById(id);
                index.TenViTri=input.TenViTri;
                index.TenViTriTiengAnh= input.TenViTriTiengAnh;
                _context.ViTriTuyenDung.Update(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteViTriTuyenDung(long id)
        {
            try
            {
                _context.ViTriTuyenDung.Delete(id);
                var hoSoTuyendung = GetAllHoSoTuyenDungAvalableById(id);
                Utilities.DeleteRange(_context.HoSoTuyenDung, hoSoTuyendung);

                var tuyenDungViTri = GetAllTuyenDungViTriById(id);
                _context.TuyenDungVitri.RemoveRange(tuyenDungViTri);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IQueryable<HoSoTuyenDung> GetAllHoSoTuyenDungAvalableById(long id)
        {
            var res = _context.HoSoTuyenDung.Where(x => x.ViTriTuyenDungId == id && !x.IsDeleted).AsQueryable();
            return res;
        }
        public IQueryable<TuyenDungViTri> GetAllTuyenDungViTriById (long id)
        {
            var res = _context.TuyenDungVitri.Where(x => x.ViTriTuyenDungId == id).AsQueryable();

            return res;

        }

        public async Task<BasePaginationResponseModel<ViTriTuyenDungResponseModel>> GetPagedViTriTuyenDung(GetPagedViTriTuyenDungResquestModel input)
        {
            var query = GetAllAvailablePrivate();
            ApplySearchAndFilter(ref query, input);
            var totalItem = 0;

            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);

            List<ViTriTuyenDungResponseModel> result = FormatData(query);

            return await Task.FromResult(new BasePaginationResponseModel<ViTriTuyenDungResponseModel>(input.PageNo, input.PageSize, result, totalItem));
        }
        private IQueryable<ViTriTuyenDung> GetAllAvailablePrivate()
        {
            return _context.ViTriTuyenDung.Where(x => !x.IsDeleted);
        }

        private void ApplySearchAndFilter(ref IQueryable<ViTriTuyenDung> query, GetPagedViTriTuyenDungResquestModel input)
        {
            //Search
            if (!input.Keyword.IsNullOrEmpty())
            {
                query = query.Where(record => record.TenViTri.Contains(input.Keyword.ToLower())
                || record.TenViTriTiengAnh.Contains(input.Keyword.ToLower()));
            }

        }
        private List<ViTriTuyenDungResponseModel> FormatData(IQueryable<ViTriTuyenDung> query)
        {
            var result = query.Select(x => new ViTriTuyenDungResponseModel
            {
                Id = x.Id,
                TenViTri = x.TenViTri,
                TenViTriTiengAnh= x.TenViTriTiengAnh,
               
            }).ToList();
            return result;
        }

        public async Task <ViTriTuyenDungResponseModel> GetByIdForDialog(long id)
        {
            var res=  await _context.ViTriTuyenDung.Where(x=>x.Id==id).Select(input=> new ViTriTuyenDungResponseModel
            {
                Id=input.Id,
                TenViTri=input.TenViTri,
                TenViTriTiengAnh=input.TenViTriTiengAnh,
            }).FirstOrDefaultAsync();
            return  res;
        }
        public async Task<List<ViTriTuyenDungResponseModel>> GetAllForDropDown ()
        {
            var res = await GetAllAvailablePrivate().Select(x => new ViTriTuyenDungResponseModel
            {
                Id = x.Id,
                TenViTri = x.TenViTri,
                TenViTriTiengAnh = x.TenViTriTiengAnh,

            }).ToListAsync();
            return res;
        }

        
    }
}

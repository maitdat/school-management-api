using NS.Core.Models;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.SuKienSapToiRequestModel;
using NS.Core.Commons;
using System.Linq.Expressions;

namespace NS.Core.Business.CMS
{
    public class SuKienSapToiSevice:ISuKienSapToiService
    {
        private readonly AppDbContext _context;

        public SuKienSapToiSevice(AppDbContext dbContext)
        {
           _context= dbContext;
        }

        private IQueryable<SukienSapToiResponseModel> GetAllAvalable()
        {
            var res = _context.SuKienSapToi.Where(x=>!x.IsDeleted).Select(x => SukienSapToiResponseModel.Mapping(x));
            return res;
        }
        public async Task<BasePaginationResponseModel<SukienSapToiResponseModel>> GetPagedSuKíenSapToi(
           GetPagedSuKienSapToiRequestModel input)
        {
            try
            {
                var query = GetAllAvalable();
                var totalItem = 0;
                query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);
                List<SukienSapToiResponseModel> result = query.ToList();
                return new BasePaginationResponseModel<SukienSapToiResponseModel>(input.PageNo, input.PageSize, result, totalItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //crud
        public async Task CreateSuKien(SuKienSapToiRequestModel input)
        {
            try
            {
                var suKienSapToiEntity = MapSukienSapToi(input);
                _context.SuKienSapToi.Add(suKienSapToiEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task UpdateSukien (SuKienSapToiRequestModel input)
        {
            try
            {
                var suKienSapToiEntity = _context.SuKienSapToi.GetById(input.Id);
                suKienSapToiEntity.TenSuKien = input.TenSuKien;
                suKienSapToiEntity.TenSuKienTiengAnh = input.TenSuKienTiengAnh;
                suKienSapToiEntity.MoTa = input.MoTa;
                suKienSapToiEntity.MoTaTiengAnh = input.MoTaTiengAnh;
                suKienSapToiEntity.ThoiGian = input.ThoiGian;
                _context.SuKienSapToi.Update(suKienSapToiEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task DeleteSuKien(long id)
        {
            _context.SuKienSapToi.Delete(id);
            await _context.SaveChangesAsync();
        }
        public async Task<SukienSapToiResponseModel> GetSukienById(long id)
        {
            var suKienSapToiEntity = _context.SuKienSapToi.GetById(id);
            return SukienSapToiResponseModel.Mapping(suKienSapToiEntity);
        }
        private SuKienSapToi MapSukienSapToi(SuKienSapToiRequestModel model)
        {
            return new SuKienSapToi()
            {
                TenSuKien = model.TenSuKien,
                TenSuKienTiengAnh = model.TenSuKienTiengAnh,
                MoTa = model.MoTa,
                MoTaTiengAnh = model.MoTaTiengAnh,
                ThoiGian = model.ThoiGian,
                DiaDiem = model.DiaDiem,
            };
        }
       


    }
}

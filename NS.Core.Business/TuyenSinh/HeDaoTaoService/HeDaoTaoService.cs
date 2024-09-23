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

namespace NS.Core.Business.HeDaoTaoService
{
    public class HeDaoTaoService : IHeDaoTaoService
        
    {
        private readonly AppDbContext _context;

        public HeDaoTaoService(AppDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<HeDaoTaoResponseModel>> GetAll()
        {
            return await _context.HeDaoTao.Select(x => new HeDaoTaoResponseModel
            {
                TenHeDaoTao = x.TenHeDaoTao,
                Id = x.Id,
                TenHeDaoTaoEnglish = x.TenHeDaoTaoEnglish,
                MoTa = x.MoTa,
                MonThiTuyenSinhs = _context.MonThiTuyenSinh.Where(y=>y.HeDaoTaoId==x.Id).Select( y => new MonThiTuyenSinhResponseModel
                {
                    HeDaoTaoId = y.HeDaoTaoId,
                    KyTuyenSinhId = y.KyTuyenSinhId,
                    LopDuThiId = y.LopDuThiId,
                    MonThiId = y.MonThiId,
                    Id = y.Id,
                    HeDaoTao = y.HeDaoTao.TenHeDaoTao,
                    KyTuyenSinh = y.KyTuyenSinh.TenKyTuyenSinh,
                    LopDuThi = y.LopDuThi.TenLop,
                    MonThi= y.MonThi.TenMonThi                   
                }).ToList()
            }).ToListAsync();
        }

        public IQueryable<HeDaoTao> GetAllAvailable()
        {
            return _context.HeDaoTao.Where(c => !c.IsDeleted).AsQueryable();
        }

        public async Task<HeDaoTaoResponseModel> GetById(long itemId)
        {
            try
            {
                var heDaoTao = await _context.HeDaoTao.Select(x => new HeDaoTaoResponseModel
                {
                    Id = x.Id,
                    TenHeDaoTao = x.TenHeDaoTao,
                    TenHeDaoTaoEnglish =x.TenHeDaoTaoEnglish,
                    MoTa = x.MoTa,
                    MonThiTuyenSinhs = _context.MonThiTuyenSinh.Where(y => y.HeDaoTaoId == x.Id).Select(y => new MonThiTuyenSinhResponseModel
                    {
                        HeDaoTaoId = y.HeDaoTaoId,
                        KyTuyenSinhId = y.KyTuyenSinhId,
                        LopDuThiId = y.LopDuThiId,
                        MonThiId = y.MonThiId,
                        Id = y.Id,
                        HeDaoTao = y.HeDaoTao.TenHeDaoTao,
                        KyTuyenSinh = y.KyTuyenSinh.TenKyTuyenSinh,
                        LopDuThi = y.LopDuThi.TenLop,
                        MonThi = y.MonThi.TenMonThi
                    }).ToList()
                }).Where(x => x.Id == itemId ).FirstOrDefaultAsync();
                if (heDaoTao == null)
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(HeDaoTao.Id)));
                }
                return heDaoTao;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(HeDaoTao.Id)));
            }
        }
        public async Task CreateHeDaoTao(CreateOrUpdateHeDaoTaoModel data)
        {
            try
            {   
                    _context.HeDaoTao.Add( new HeDaoTao()
                    {
                        TenHeDaoTao = data.TenHeDaoTao,
                        TenHeDaoTaoEnglish = data.TenHeDaoTaoEnglish,
                        MoTa = data.MoTa
                    });                   
                     await _context.SaveChangesAsync();
           
               
            }catch
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND,nameof(data.TenHeDaoTao)));
            }
        }
        public async Task<BasePaginationResponseModel<HeDaoTaoResponseModel>> GetPagedHeDaoTao(HeDaoTaoRequestModel input)
        {

            var query = GetAllAvailable().Select(x => new HeDaoTaoResponseModel
            {
               TenHeDaoTao = x.TenHeDaoTao,
               TenHeDaoTaoEnglish = x.TenHeDaoTaoEnglish,
               MoTa = x.MoTa,
               Id=x.Id            
            });
            if (!input.Keyword.IsNullOrEmpty())
            {
                query = query.Where(c => c.TenHeDaoTao.ToLower().Contains(input.Keyword.ToLower())
                || c.TenHeDaoTaoEnglish.ToLower().Contains(input.Keyword.ToLower()));
            }
            var paging = query.ApplyPaging(input.PageNo, input.PageSize,out var totalItem).ToList();


            return await Task.FromResult(new BasePaginationResponseModel<HeDaoTaoResponseModel>(input.PageNo, input.PageSize, paging, totalItem));
        }
        public async Task UpdateHdt(long itemId,CreateOrUpdateHeDaoTaoModel data)
        {
            try
            {
                var heDaoTaoUpdate = _context.HeDaoTao.GetById(itemId);
                heDaoTaoUpdate.TenHeDaoTao = data.TenHeDaoTao;
                heDaoTaoUpdate.TenHeDaoTaoEnglish = data.TenHeDaoTaoEnglish;
                heDaoTaoUpdate.MoTa = data.MoTa;
                _context.HeDaoTao.Update(heDaoTaoUpdate);
                await _context.SaveChangesAsync();  
            }
            catch 
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND,nameof(data.TenHeDaoTao)));
            }
        }

        public async  Task DeleteHdt(long id)
        {        
            _context.HeDaoTao.Delete(id);
           await _context.SaveChangesAsync();
        }            

    }
}

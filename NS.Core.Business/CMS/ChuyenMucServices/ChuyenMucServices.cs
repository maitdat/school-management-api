using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Commons;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.NhanVien;

namespace NS.Core.Business.ChuyenMucServices 
{
    public class ChuyenMucServices : IChuyenMucServices
    {
        public readonly AppDbContext _context;

        public ChuyenMucServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNewChuyenMuc(CreateChuyenMucRequestModel newChuyenMuc)
        {
            try
            {
                _context.ChuyenMuc.Add(new ChuyenMuc
                {
                    TenChuyenMuc = newChuyenMuc.TenChuyenMuc,
                    TenChuyenMucEnglish = newChuyenMuc.TenChuyenMucEnglish
                });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteChuyenMuc(long id)
        {
            _context.ChuyenMuc.Delete(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ChuyenMucResponeModel>> GetAll()
        {
            var query =  _context.ChuyenMuc
             .Where(x => !x.IsDeleted)
             .Select(x => new ChuyenMucResponeModel
             {
                 Id = x.Id,
                 TenChuyenMuc = x.TenChuyenMuc,
                 TenChuyenMucEnglish = x.TenChuyenMucEnglish
             }).ToList();
           return query;
        }  
        public async  Task<ChuyenMucResponeModel> GetById(long id)
        {
            ChuyenMuc person = _context.ChuyenMuc.GetById(id);
            return new ChuyenMucResponeModel()
            {
                Id=person.Id,
                TenChuyenMuc = person.TenChuyenMuc,
                TenChuyenMucEnglish = person.TenChuyenMucEnglish

            };
        }

        public  async Task<BasePaginationResponseModel<ChuyenMucResponeModel>> GetPagedChuyeMuc(GetPageChuyenMucResponseModel input)
        {
            var query = _context.ChuyenMuc
               .Where(x => !x.IsDeleted)
               .Select(x => new ChuyenMucResponeModel
               {
                   Id=x.Id,
                   TenChuyenMuc= x.TenChuyenMuc,
                   TenChuyenMucEnglish =x.TenChuyenMucEnglish

               }).AsQueryable();

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var keyword = input.Keyword.ToLower().Trim();
                query = query.Where(record => record.TenChuyenMuc.ToLower().Contains(keyword)
                || record.TenChuyenMucEnglish.ToLower().Contains(keyword));              
            }
            var totalItems = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<ChuyenMucResponeModel> result = query.ToList();
            return  new BasePaginationResponseModel<ChuyenMucResponeModel>(input.PageNo, input.PageSize, result, totalItems);
        }

        public async Task UpdateChuyenMuc(long id, CreateChuyenMucRequestModel updatedChuyenMuc)
        {
           ChuyenMuc chuyenMuc = _context.ChuyenMuc.GetById(id);
            if (chuyenMuc != null)
            {
                chuyenMuc.TenChuyenMuc = updatedChuyenMuc.TenChuyenMuc;
                chuyenMuc.TenChuyenMucEnglish = updatedChuyenMuc.TenChuyenMucEnglish;
                _context.ChuyenMuc.Update(chuyenMuc);
                 await  _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(chuyenMuc.TenChuyenMuc)));
            }
        }
    }
}


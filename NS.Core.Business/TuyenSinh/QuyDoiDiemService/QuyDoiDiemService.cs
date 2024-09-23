using Microsoft.EntityFrameworkCore;
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

namespace NS.Core.Business.QuyDoiDiemService
{
    public class QuyDoiDiemService : IQuyDoiDiemService
    {
        private readonly AppDbContext   _context;
        public QuyDoiDiemService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddQuyDoiDiem(AddOrUpdateQuyDoiDiemRequestModel newQuyDoiDiem)
        {
            try
            {
                _context.QuyDoiDiem.Add(new QuyDoiDiem
                {
                    MonThiTuyenSinhId = newQuyDoiDiem.MonThiTuyenSinhId,
                    DiemBatDau = newQuyDoiDiem.DiemBatDau,
                    DiemKetThuc = newQuyDoiDiem.DiemKetThuc,
                    KetQua = newQuyDoiDiem.KetQua
                }); 
                 _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task DeleteQuyDoiDiem(long id)
        {
            try
            {
                if (_context.QuyDoiDiem.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    var delete = _context.QuyDoiDiem.Where(x => x.Id == id).FirstOrDefault();
                    delete.IsDeleted = true;
                     _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task UpdateQuyDoiDiem(long id ,AddOrUpdateQuyDoiDiemRequestModel updateQuyDoiDiem)
        {
            try
            {
                if (_context.QuyDoiDiem.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    var update = _context.QuyDoiDiem.Where(x => x.Id == id).FirstOrDefault();
                    update.MonThiTuyenSinhId = updateQuyDoiDiem.MonThiTuyenSinhId;
                    update.DiemBatDau = updateQuyDoiDiem.DiemBatDau;
                    update.DiemKetThuc = updateQuyDoiDiem.DiemKetThuc;
                    update.KetQua = updateQuyDoiDiem.KetQua;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public IQueryable<QuyDoiDiem> GetAll()
        {
            return _context.QuyDoiDiem.AsQueryable();
        }

        public QuyDoiDiemResponseModel GetById(long id)
        {
            QuyDoiDiemResponseModel? result = _context.QuyDoiDiem

               .Where(x => x.Id == id)
               .Select(x => new QuyDoiDiemResponseModel
               {
                   Id = x.Id,
                   MonThiTuyenSinhId = x.MonThiTuyenSinhId,
                   MonThiTuyenSinh = x.MonThiTuyenSinh.MonThi.TenMonThi,
                   DiemBatDau = x.DiemBatDau,
                   DiemKetThuc = x.DiemKetThuc,
                   KetQua = x.KetQua
               })
               .FirstOrDefault();
            return result;
        }
        public Task<BasePaginationResponseModel<QuyDoiDiemResponseModel>> GetAvailableAndPaging(BasePaginationRequestModel paramsModel)
        {
            IQueryable<QuyDoiDiem> query = _context.QuyDoiDiem
                .Where(x => !x.IsDeleted)
                .AsQueryable();
            ApplySearch(paramsModel, ref query);
            var data = query.Select(e => new QuyDoiDiemResponseModel
            {
                Id = e.Id,
                DiemBatDau = e.DiemBatDau,
                DiemKetThuc = e.DiemKetThuc,
                MonThiTuyenSinh = e.MonThiTuyenSinh.MonThi.TenMonThi,
                MonThiTuyenSinhId = e.MonThiTuyenSinhId,
                KetQua = e.KetQua
                
            });
            var paging = Utilities.ApplyPaging(data, paramsModel.PageNo, paramsModel.PageSize).ToList();
            var result = Task.FromResult(new BasePaginationResponseModel<QuyDoiDiemResponseModel>(paramsModel.PageNo, paramsModel.PageSize, paging, data.Count()));
            return result;
        }
        public async Task<List<MonThiQuyDoiDiemDropDownModel>> GetMonThiTuyenSinhAvailableForDropDown()
        {
            return await _context.MonThiTuyenSinh.Where(c => !c.IsDeleted).Select(e => new MonThiQuyDoiDiemDropDownModel
            {
                Id = e.Id,
                MonThiTuyenSinh = e.MonThi.TenMonThi
            }).ToListAsync();
        }

        private void ApplySearch(BasePaginationRequestModel paramsModel, ref IQueryable<QuyDoiDiem> query)
        {
            string keyword = paramsModel.Keyword?.Trim();

            if (!string.IsNullOrEmpty(keyword)) query = query
                    .Where(x => x.MonThiTuyenSinh.MonThi.TenMonThi.Contains(keyword));
        }
    }
}

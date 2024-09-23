using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.ChamThiService
{
    public class ChamThiService : IChamThiService
    {
        private readonly AppDbContext _dbContext;
        public ChamThiService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task ChamThi(List<ChamThiRequestModel> input)
        {
            var result = new List<ChiTietChamThi>();
            foreach (var item in input)
            {
                foreach (var chiTiet in item.ListMonThiTuyenSinh)
                {
                    var tieuChi = chiTiet.ListTieuChiMonThi.Select(x => new ChiTietChamThi
                    {
                        HoSoThiId = item.HoSoThiId,
                        MonThiTuyenSinhId = chiTiet.MonThiTuyenSinhId,
                        TieuChiMonThiId = x.TieuChiMonThiId,
                        Diem = x.Diem,
                        GhiChu = x.GhiChu,
                    }).ToList();

                    result.AddRange(tieuChi);
                }
                var chiTietChamThiInput = _dbContext.ChiTietChamThi
                    .Where(x => x.HoSoThiId.Equals(item.HoSoThiId));

                if (chiTietChamThiInput.Any())
                {
                    _dbContext.RemoveRange(chiTietChamThiInput);
                    _dbContext.SaveChanges();
                }
            }
            _dbContext.ChiTietChamThi.AddRange(result);
            _dbContext.SaveChanges();
        }
    }
}

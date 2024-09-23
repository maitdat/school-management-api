using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.KetQuaThiService
{
    public class KetQuaService : IKetQuaService
    {
        private readonly AppDbContext _dbContext;

        public KetQuaService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<KetQuaThiResponseModel>> SubmitKetQuaThi(long hoSoThiId)
        {
            var chiTietChamThi = _dbContext.ChiTietChamThi.Where(x => x.HoSoThiId == hoSoThiId);
            var ketQuaRes = chiTietChamThi
                .Select(selectedChiTiet => new KetQuaThiResponseModel
                {
                    MonThiTuyenSinhId = selectedChiTiet.MonThiTuyenSinhId,
                    HoSoThiId = hoSoThiId,
                    TieuChiDanhGiaId = selectedChiTiet.TieuChiMonThi.TieuChiDanhGiaId,
                    TieuChiMonThiId = selectedChiTiet.TieuChiMonThiId,
                    Diem = selectedChiTiet.Diem
                });

            var ketQuaHienTai = _dbContext.KetQuaThi.Where(x => x.HoSoThiId.Equals(hoSoThiId));
            if (ketQuaHienTai.Any())
            {
                _dbContext.RemoveRange(ketQuaHienTai);
                _dbContext.SaveChanges();
            }
            var ketQuaMoi = MappingKetQua(ketQuaRes);
            _dbContext.AddRange(ketQuaMoi);
            _dbContext.SaveChanges();
            return await Task.FromResult(ketQuaRes);

        }

        private IQueryable<KetQuaThi> MappingKetQua(IQueryable<KetQuaThiResponseModel> input)
        {
            return input.Select(x => new KetQuaThi
            {
                MonThiTuyenSinhId = x.MonThiTuyenSinhId,
                HoSoThiId = x.HoSoThiId,
                TieuChiDanhGiaId = x.TieuChiDanhGiaId,
                ThanhVienHoiDongId = 1,
                Diem = x.Diem,
                QuyDoi = string.Empty,
                NhanXet = string.Empty
            });
        }
    }
}

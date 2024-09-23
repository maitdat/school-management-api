using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.HoSoThiService
{
    public class HoSoThiService : IHoSoThiService
    {
        private readonly AppDbContext _dbContext;
        public HoSoThiService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HoSoThiResponseModel>> GetHoSoThi(long thanhVienHDId)
        {
            var lopDuThi = _dbContext.GiaoVienTrongThi
                .Where(x => x.ThanhVienHoiDongId == thanhVienHDId && x.ThanhVienHoiDong.QuyenKhaoThi == Enums.QuyenKhaoThi.GiaoVien && x.ThanhVienHoiDong.DangKichHoat)
                .Select(y => y.LopDuThiId)
                .FirstOrDefault();

            var dsHoSoThi = _dbContext.HoSoThi
                .Where(x => x.LopDuThiId == lopDuThi)
                .Select(x => new HoSoThiResponseModel
                {
                    Id = x.Id,
                    LopDuThiId = x.LopDuThiId,
                    SoBaoDanh = x.SoBaoDanh,
                    TrangThaiDuThi = x.TrangThaiDuThi,
                    HoTen = x.HoSoTuyenSinh.HoTen,
                    AnhHoSo = x.HoSoTuyenSinh.AnhHoSo,
                })
                .ToList();

            _dbContext.SaveChanges();
            return dsHoSoThi;
        }

        public async Task<BasePaginationResponseModel<HoSoThiResponseModel>> GetPageHoSoThi(GetPageHoSoThiRequestModel input, long thanhVienHDId)
        {
            var query = GetHoSoPrivate(thanhVienHDId);
            ApplySearchAndFilter(ref query, input);
            query = query.OrderBy(x => x.SoBaoDanh);
            var totalItem = 0;

            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);

            List<HoSoThiResponseModel> returnHoSoThi = FormatData(query);
            return await Task.FromResult(new BasePaginationResponseModel<HoSoThiResponseModel>(input.PageNo, input.PageSize, returnHoSoThi, totalItem));
        }

        public async Task<IQueryable<MonThiTuyenSinhResponseModel>> GetDiemMonThiTuyenSinh(long hoSoId)
        {
            var chiTietDiem = _dbContext.ChiTietChamThi.Where(x => x.HoSoThiId.Equals(hoSoId));
            var lopDuThi = _dbContext.HoSoThi.Where(x => x.Id.Equals(hoSoId)).Select(x => x.LopDuThiId).FirstOrDefault();
            //var hoSoThi = _dbContext.MonThiTuyenSinh.Where(x => x.LopDuThiId.Equals(lopDuThi))
            //    .Select(selectedMonThi => new MonThiTuyenSinhResponseModel
            //    {
            //        TenMonThi = selectedMonThi.MonThi.TenMonThi,
            //        TieuChiMonThi = selectedMonThi.TieuChiMonThi
            //                        .Select(selectedTieuChi => new TieuChiMonThiResponseModel
            //                        {
            //                            Id = selectedTieuChi.Id,
            //                            Diem = chiTietDiem
            //                                    .Where(selectedChiTiet => selectedChiTiet.TieuChiMonThiId.Equals(selectedTieuChi.Id))
            //                                    .Select(x => x.Diem).FirstOrDefault(),
            //                            HeSo = selectedTieuChi.HeSo,
            //                            TenTieuChiDanhGia = selectedTieuChi.TieuChiDanhGia.TenTieuChi
            //                        })
            //    });
            //var hoSoThi = new IQueryable<object>();
            //return await Task.FromResult(hoSoThi);
            //=> Todo: confirm với Tùng đoạn code này 
            return null;
        }
        public async Task<bool> UpdateTrangThaiDuThi(long hoSoId,long thanhVienHdId, int input)
        {
            var hoSoDB = _dbContext.HoSoThi.Where(x => x.Id.Equals(hoSoId)).FirstOrDefault();
            if (hoSoDB == null)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(hoSoId)));
            }
            hoSoDB.TrangThaiDuThi = (Enums.TrangThaiDuThi)input;
            if (input == 1)
            {
                var danhSachKetQua = _dbContext.MonThiTuyenSinh
                                            .Where(c => c.LopDuThiId == hoSoDB.LopDuThiId)
                                            .SelectMany(c => c.TieuChiMonThi)
                                            .Select(c => new KetQuaThi
                                            {
                                                HoSoThiId = hoSoId,
                                                ThanhVienHoiDongId = thanhVienHdId,
                                                MonThiTuyenSinhId = c.MonThiTuyenSinhId,
                                                TieuChiDanhGiaId = c.TieuChiDanhGiaId,
                                                QuyDoi = string.Empty,
                                                NhanXet = string.Empty,
                                                Diem = 0
                                            }).ToList();

                var ketQuaHienTai = _dbContext.KetQuaThi.Where(x => x.HoSoThiId.Equals(hoSoId));
                if (ketQuaHienTai.Any())
                    _dbContext.KetQuaThi.RemoveRange(ketQuaHienTai);
                _dbContext.SaveChanges();
                _dbContext.KetQuaThi.AddRange(danhSachKetQua);
                _dbContext.HoSoThi.Update(hoSoDB);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
                return true;
            return false;
        }

        #region Private
        private IQueryable<MonThiTuyenSinhResponseModel> GetMonThiTuyenSinhPrivate(long hoSoId)
        {
            //var result = _dbContext.KetQuaThi
            //    .Where(x => x.HoSoThiId.Equals(hoSoId))
            //    .Select(selectedKetQua => new MonThiTuyenSinhResponseModel
            //    {
            //        TenMonThi = selectedKetQua.MonThiTuyenSinh.MonThi.TenMonThi,
            //        TieuChiMonThi = selectedKetQua.MonThiTuyenSinh.TieuChiMonThi
            //                        .Select(selectedMonThi => new TieuChiMonThiResponseModel
            //                        {
            //                            Diem = 1,
            //                            HeSo = selectedMonThi.HeSo,
            //                            TenTieuChiDanhGia = selectedMonThi.TieuChiDanhGia.TenTieuChi
            //                        }),
            //    });
            //return result;
            //=> Todo: confirm với Tùng đoạn code này 
            return null;
        }
        private IQueryable<HoSoThiResponseModel> GetHoSoPrivate(long thanhVienHDId)
        {
            var lopDuThi = _dbContext.GiaoVienTrongThi
                .Where(x => x.ThanhVienHoiDongId == thanhVienHDId && x.ThanhVienHoiDong.QuyenKhaoThi == Enums.QuyenKhaoThi.GiaoVien && x.ThanhVienHoiDong.DangKichHoat)
                .Select(y => y.LopDuThiId)
                .FirstOrDefault();

            var dsHoSoThi = _dbContext.HoSoThi
                .Where(x => x.LopDuThiId == lopDuThi)
                .Select(x => new HoSoThiResponseModel
                {
                    LopDuThiId = x.LopDuThiId,
                    SoBaoDanh = x.SoBaoDanh,
                    TrangThaiDuThi = Enums.TrangThaiDuThi.DangDoi,
                    HoTen = x.HoSoTuyenSinh.HoTen,
                    AnhHoSo = x.HoSoTuyenSinh.AnhHoSo,
                });

            return dsHoSoThi;
        }
        private IQueryable<HoSoThi> GetAllHoSoThi()
        {
            return _dbContext.HoSoThi.AsQueryable();
        }

        private List<HoSoThiResponseModel> FormatData(IQueryable<HoSoThiResponseModel> query)
        {
            var res = query.Select(x => new HoSoThiResponseModel
            {
                HoTen = x.HoTen,
                AnhHoSo = x.AnhHoSo,
                LopDuThiId = x.LopDuThiId,
                TrangThaiDuThi = x.TrangThaiDuThi,
                SoBaoDanh = x.SoBaoDanh,
            }).ToList();
            return query.ToList();
        }

        private void ApplySearchAndFilter(ref IQueryable<HoSoThiResponseModel> query, GetPageHoSoThiRequestModel input)
        {
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(record => record.SoBaoDanh.ToLower().Contains(keyword));
            }

        }

        #endregion
    }
}

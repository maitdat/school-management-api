
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Business.FileService;
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
using static NS.Core.Commons.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.Business.HoSoTuyenSinhService
{
    public class HoSoTuyenSinhService : IHoSoTuyenSinhService
    {
        private readonly AppDbContext _context;
        private readonly IFile _fileService;
        public HoSoTuyenSinhService(AppDbContext dbContext, IFile fileService)
        {
            _context = dbContext;
            _fileService = fileService;
        }

        public async Task<BasePaginationResponseModel<HoSoTuyenSinhResponseModel>> GetPagedHoSo(GetPagedHoSoTuyenSinhRequestModel input)
        {
            // Init query
            var query = GetAllAvailable();
            query = ApplySearchAndFilter(query, input);
            // apply order
            query = query.OrderByDescending(record => record.NgayDangKy);
            var totalItems = 0;
            // apply paging
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<HoSoTuyenSinhResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<HoSoTuyenSinhResponseModel>(input.PageNo, input.PageSize, result, totalItems);
        }

        private IQueryable<HoSoTuyenSinhResponseModel> ApplySearchAndFilter(IQueryable<HoSoTuyenSinhResponseModel> query, GetPagedHoSoTuyenSinhRequestModel input)
        {
            // apply search
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(record => record.HoTen.ToLower().Contains(keyword));
            }
            // apply filter
            if (input.KyTuyenSinhId.HasValue)
            {
                query = query.Where(record => record.KyTuyenSinhId == input.KyTuyenSinhId);
            }
            if (!string.IsNullOrEmpty(input.NamHoc))
            {
                query = query.Where(record => record.NamHoc == input.NamHoc);
            }
            if (!string.IsNullOrEmpty(input.KhoiTuyenSinh))
            {
                query = query.Where(record => record.TenKhoi == input.KhoiTuyenSinh);
            }
            if (input.KenhGioiThieu.HasValue)
            {
                query = query.Where(record => record.KenhGioiThieu == input.KenhGioiThieu);
            }
            if (!string.IsNullOrEmpty(input.HeDaoTao))
            {
                query = query.Where(record => record.HeDaoTao == input.HeDaoTao);
            }
            if (input.TrangThai.HasValue)
            {
                query = query.Where(record => record.TrangThai == input.TrangThai);
            }

            return query;
        }

        public IQueryable<HoSoTuyenSinhResponseModel> GetAllAvailable()
        {
            var result = _context.HoSoTuyenSinh.Select(x => new HoSoTuyenSinhResponseModel
            {
                Id = x.Id,
                KyTuyenSinhId = x.KyTuyenSinhId,
                KhoiTuyenSinhId = x.KhoiTuyenSinhId,
                HeDaoTaoId = x.HeDaoTaoId,
                TenKhoi = x.KhoiTuyenSinh.TenKhoi,
                HeDaoTao = x.HeDaoTao.TenHeDaoTao,
                TaiKhoanId = x.TaiKhoanId,
                TenTaiKhoan = x.TaiKhoan.HoTen,
                MaSoHoSo = x.MaSoHoSo,
                HoTen = x.HoTen,
                NgayDangKy = x.NgayDangKy,
                NamHoc = x.KyTuyenSinh.TenKyTuyenSinh,
                KenhGioiThieu = x.KenhGioiThieu,
                TrangThai = x.TrangThai,
                IsDeleted = x.IsDeleted,
                NgayGiaoLuu = x.ThoiGianThi.NgayThi,
                GioGiaoLuu = x.ThoiGianThi.GioDuThi,
                GioDon = x.ThoiGianThi.GioDonCon,
                TrangThaiDuThi = x.TrangThaiDuThi,
                SoBaoDanh = _context.HoSoThi.First(y => y.HoSoTuyenSinhId.Equals(x.Id)).SoBaoDanh
            }).Where(x => !x.IsDeleted);
            return result;
        }

        public async Task<List<HoSoTuyenSinhResponseModel>> GetHoSoTheoTaiKhoan(long taiKhoanId)
        {
            var result = _context.HoSoTuyenSinh.Select(x => new HoSoTuyenSinhResponseModel
            {
                Id = x.Id,
                KyTuyenSinhId = x.KyTuyenSinhId,
                KhoiTuyenSinhId = x.KhoiTuyenSinhId,
                HeDaoTaoId = x.HeDaoTaoId,
                TenKhoi = x.KhoiTuyenSinh.TenKhoi,
                HeDaoTao = x.HeDaoTao.TenHeDaoTao,
                TaiKhoanId = x.TaiKhoanId,
                NgayDangKy = x.NgayDangKy,
                TenTaiKhoan = x.TaiKhoan.HoTen,
                MaSoHoSo = x.MaSoHoSo,
                HoTen = x.HoTen,
                NamHoc = x.KyTuyenSinh.TenKyTuyenSinh,
                KenhGioiThieu = x.KenhGioiThieu,
                TrangThai = x.TrangThai,
                IsDeleted = x.IsDeleted,
                NgayGiaoLuu = x.ThoiGianThi.NgayThi,
                GioGiaoLuu = x.ThoiGianThi.GioDuThi,
                GioDon = x.ThoiGianThi.GioDonCon,
                TrangThaiDuThi = x.TrangThaiDuThi,
                NguoiLienQuan = x.NguoiLienQuan
            }).Where(x => !x.IsDeleted).ToList();
            return result;
        }

        public async Task<HoSoTuyenSinhDetailsResponseModel> GetChiTietHoSoTuyenSinh(long id)
        {
            try
            {
                var hoSo = await _context.HoSoTuyenSinh.Select(x => new HoSoTuyenSinhDetailsResponseModel
                {
                    Id = x.Id,
                    KyTuyenSinhId = x.KyTuyenSinhId,
                    HeDaoTaoId = x.HeDaoTaoId,
                    KhoiTuyenSinhId = x.KhoiTuyenSinhId,
                    TenKhoi = x.KhoiTuyenSinh.TenKhoi,
                    HeDaoTao = x.HeDaoTao.TenHeDaoTao,
                    TaiKhoanId = x.TaiKhoanId,
                    NgayDangKy = x.NgayDangKy,
                    NgaySinh = x.NgaySinh,
                    TenTaiKhoan = x.TaiKhoan.HoTen,
                    MaSoHoSo = x.MaSoHoSo,
                    HoTen = x.HoTen,
                    NamHoc = x.KyTuyenSinh.TenKyTuyenSinh,
                    KenhGioiThieu = x.KenhGioiThieu,
                    TrangThai = x.TrangThai,
                    HoKhauThuongTru = x.HoKhauThuongTru,
                    DiaChiHienTai = x.DiaChiHienTai,
                    GioiTinh = x.GioiTinh,
                    NoiSinh = x.NoiSinh,
                    AnhChiEm = x.AnhChiEm,
                    AnhGiayKhaiSinh = x.AnhGiayKhaiSinh,
                    AnhHoSo = x.AnhHoSo,
                    ChungChiTiengAnh = x.ChungChiTiengAnh,
                    DeNghiCuaPhuHuynh = x.DeNghiCuaPhuHuynh,
                    HoanCanhDacBiet = x.HoanCanhDacBiet,
                    MaMoet = x.MaMoet,
                    NguoiKhaiHoSo = x.NguoiKhaiHoSo,
                    ThanhTichKhac = x.ThanhTichKhac,
                    TruongDangTheoHoc = x.TruongDangTheoHoc,
                    SoThich = x.SoThich,
                    CaTinh = x.CaTinh,
                    NangKhieu = x.NangKhieu,
                    SucKhoe = x.SucKhoe,
                    NguoiLienQuan = x.NguoiLienQuan,
                    
                }).Where(x => x.Id == id).FirstOrDefaultAsync();
                if (hoSo == null)
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(HoSoTuyenSinh)));
                }
                return hoSo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<HoSoThiResponseModel> GetHoSoThiById(long id)
        {
            try
            {
                var res = await _context.HoSoThi.Where(x => x.HoSoTuyenSinhId == id).Select(x => new HoSoThiResponseModel
                {
                    HoSoTuyenSinhId = x.HoSoTuyenSinhId,
                    LopDuThiId = x.LopDuThiId,
                    SoBaoDanh = x.SoBaoDanh,
                }).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task CreateHoSoTuyenSinh(CreateOrUpdateHoSoRequestModel hoSo)
        {
            try
            {
                HoSoTuyenSinh obj = hoSo.Mapping();
                if (hoSo.FileAnhGiayKhaiSinh != null)
                {
                    var resImg = await _fileService.UploadFile(hoSo.FileAnhGiayKhaiSinh, Enums.FolderChild.AnhGiayKhaiSinh);
                    obj.FileAnhKhaiSinhId = resImg.Id;
                    obj.AnhGiayKhaiSinh = $"/imgs/{nameof(Enums.FolderChild.AnhGiayKhaiSinh)}/{resImg.FileName}";
                }
                if (hoSo.FileAnhHoSo != null)
                {
                    var resImg = await _fileService.UploadFile(hoSo.FileAnhHoSo, Enums.FolderChild.AnhHoSo);
                    obj.FileAnhHoSoId = resImg.Id;
                    obj.AnhHoSo = $"/imgs/{nameof(Enums.FolderChild.AnhHoSo)}/{resImg.FileName}";
                }
                _context.HoSoTuyenSinh.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task UpdateListTrangThaiHoSoTS(List<HoSoTuyenSinhResponseModel> hoSo, int index)
        {
            try
            {
                List<HoSoTuyenSinh> newHoSo = new List<HoSoTuyenSinh>();
                foreach (var i in hoSo)
                {
                    var b = _context.HoSoTuyenSinh.Where(x => i.Id == x.Id).FirstOrDefault();
                    newHoSo.Add(b);
                }
                foreach (var ho in newHoSo)
                {
                    switch (index)
                    {
                        case 1:
                            ho.TrangThai = Enums.TrangThaiHoSoTuyenSinh.DaGuiMailDuTuyen;
                            _context.HoSoTuyenSinh.Update(ho);
                            break;
                        case 2:
                            ho.TrangThai = Enums.TrangThaiHoSoTuyenSinh.ChoDuyet;
                            _context.HoSoTuyenSinh.Update(ho);
                            break;
                        default:
                            break;
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateTrangThaiHoSoTS(long id, int index)
        {
            try
            {
                var newHoSo = _context.HoSoTuyenSinh.GetById(id);
                switch (index)
                {
                    case 1:
                        newHoSo.TrangThai = TrangThaiHoSoTuyenSinh.ChuaDongPhi;
                        _context.HoSoTuyenSinh.Update(newHoSo);
                        break;
                    case 2:
                        newHoSo.TrangThai = TrangThaiHoSoTuyenSinh.HoSoKhongHopLe;
                        _context.HoSoTuyenSinh.Update(newHoSo);
                        break;
                    case 3:
                        newHoSo.TrangThai = TrangThaiHoSoTuyenSinh.ChoCMHSSua;
                        _context.HoSoTuyenSinh.Update(newHoSo);
                        break;
                    default:
                        break;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateHoSoTuyenSinh(long id, CreateOrUpdateHoSoRequestModel hoSo)
        {
            try
            {
                //var newHoSo = _context.HoSoTuyenSinh.GetById(hoSo.Id);
                IQueryable<HoSoTuyenSinh> hoSoTuyenSinhs = _context.HoSoTuyenSinh.Where(e => e.Id == id);
                if (!hoSoTuyenSinhs.Any()) throw new Exception("newHoSo id nofound");
                var newHoSo = hoSoTuyenSinhs.First();
                hoSo.Update(ref newHoSo);
                _context.HoSoTuyenSinh.Update(newHoSo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteListHoSoTuyenSinh(List<long> id)
        {
            Utilities.DeleteRange(_context.HoSoTuyenSinh, id);
            await _context.SaveChangesAsync();
        }
        public async Task<BasePaginationResponseModel<HoSoTrungResponseModel>> GetPagedHoSoTrung(GetPagedHoSoTrungRequestModel input)
        {

            var hoSoTrung = GetListHoSoTrung(input.KyTuyenSinhId).AsQueryable();
            hoSoTrung = ApplySearchAndFilterForHoSoTrung(hoSoTrung, input);
            var totalItems = 0;
            hoSoTrung = hoSoTrung.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<HoSoTrungResponseModel> result = hoSoTrung.ToList();
            return new BasePaginationResponseModel<HoSoTrungResponseModel>(input.PageNo, input.PageSize, result, totalItems);
        }

        public List<HoSoTrungResponseModel> GetListHoSoTrung(long kyTuyenSinhId)
        {
            var hoSo = _context.HoSoTuyenSinh
                .Where(x => !x.IsDeleted && x.KyTuyenSinhId.Equals(kyTuyenSinhId))
                .GroupBy(x => x.KhoiTuyenSinhId)
                .Select(x => x.Select(d => new HoSoTrungList
                {
                    Id = d.Id,
                    LopDangKyId = d.KhoiTuyenSinhId,
                    KyTuyenSinhId = d.KyTuyenSinhId,
                    HeDaoTaoId = d.HeDaoTaoId,
                    TenHocSinh = d.HoTen,
                    NgaySinh = d.NgaySinh,
                    Email = d.TaiKhoan.Email,
                    NgayDangKy = d.NgayDangKy,
                    HoTenBo = d.NguoiLienQuan.Where(c => c.LoaiQuanHe == LoaiQuanHe.Cha).Select(c => c.HoTen).FirstOrDefault(),
                    HoTenMe = d.NguoiLienQuan.Where(c => c.LoaiQuanHe == LoaiQuanHe.Me).Select(c => c.HoTen).FirstOrDefault(),
                    TrangThai = d.TrangThai
                }).ToList()).ToList();
            var res = new List<HoSoTrungResponseModel>();
            if (hoSo.Count > 1)
            {
                var hoSoTrungMainList = new List<HoSoTrungList>();

                foreach (var item in hoSo)
                {
                    for (var i = 0; i < item.Count(); i++)
                    {
                        hoSoTrungMainList.Add(item[i]);
                        for (var j = i + 1; j < item.Count(); j++)
                        {
                            if (DeepEquals(item[i], item[j]))
                            {
                                hoSoTrungMainList.Add(item[j]);
                                item.RemoveAt(j);
                                j--;
                            }
                        }
                        if (hoSoTrungMainList.Count > 1)
                        {
                            res.Add(GenerateHoSoTrungList(hoSoTrungMainList));
                        }
                        hoSoTrungMainList.Clear();
                    }
                }
                
            }
            return res;

        }


        public static bool DeepEquals(HoSoTrungList obj, HoSoTrungList another)
        {
            //Nếu null hoặc giống nhau, trả true
            if (ReferenceEquals(obj, another)) return true;
            //Nếu 1 trong 2 là null, trả false
            if ((obj == null) || (another == null)) return false;
            return obj.NgaySinh.Equals(another.NgaySinh)
                   && (obj.TenHocSinh).Equals(another.TenHocSinh)
                   && (obj.HoTenBo).Equals(another.HoTenBo)
                   && (obj.HoTenMe).Equals(another.HoTenMe);

        }
        private IQueryable<HoSoTrungResponseModel> ApplySearchAndFilterForHoSoTrung(IQueryable<HoSoTrungResponseModel> query, GetPagedHoSoTrungRequestModel input)
        {
            if (!input.Keyword.ToLower().IsNullOrEmpty())
            {
                query = query.Where(record => record.TenHocSinh.ToLower().Contains(input.Keyword));
            }
            query = query.Where(record => record.KyTuyenSinhId == input.KyTuyenSinhId);
            if (input.HeDaoTaoId.HasValue)
            {
                query = query.Where(record => record.HeDaoTaoId == input.HeDaoTaoId);
            }
            if (input.LopDangKyId.HasValue)
            {
                query = query.Where(record => record.LopDangKyId == input.LopDangKyId);
            }
            if (input.TrangThai.HasValue)
            {
                query = query.Where(record => record.TrangThai == input.TrangThai);
            }
            if (input.NgayDangKiBatDau != DateTime.MinValue)
            {
                query = query.Where(record => record.NgayDangKy >= input.NgayDangKiBatDau);
            }
            if (input.NgayBangKiKetThuc != DateTime.MinValue)
            {
                query = query.Where(record => record.NgayDangKy <= input.NgayBangKiKetThuc);
            }
            return query;
        }


        public async Task GhepHoSo(long id, List<long> input)
        {
            foreach (var item in input)
            {
                var update = _context.HoSoTuyenSinh.Where(x => x.Id == item).First();
                update.IsDeleted = true;
                _context.HoSoTuyenSinh.Update(update);
            }
            var res = await _context.HoSoTuyenSinh.Where(x => x.Id == id).FirstOrDefaultAsync();
            res.IsDeleted = false;
            _context.HoSoTuyenSinh.Update(res);
            await _context.SaveChangesAsync();
        }
        private static HoSoTrungResponseModel GenerateHoSoTrungList(List<HoSoTrungList> input)
        {
            var res = new HoSoTrungResponseModel()
            {
                Id = input.First().Id,
                TenHocSinh = input.First().TenHocSinh,
                KyTuyenSinhId = input.First().KyTuyenSinhId,
                HeDaoTaoId = input.First().HeDaoTaoId,
                LopDangKyId = input.First().LopDangKyId,
                NgaySinh = input.First().NgaySinh,
                TrangThai = input.First().TrangThai,
                NgayDangKy = input.First().NgayDangKy,
                HoSoTrungs = input.ToList(),
            };
            return res;
        }
        public Task<BasePaginationResponseModel<DanhSachDuThiResponseModel>> GetDanhSachDuThiAndPaging(GetDanhSachDuThiAndPagingAndFilterRespuestModel paramsModel)
        {
            IQueryable<HoSoTuyenSinh> query = _context.HoSoTuyenSinh
                    .Where(e => !e.IsDeleted)

                    .AsQueryable();
            var data = GetAllAvailable().Where(record => !record.IsDeleted).Select(e => new DanhSachDuThiResponseModel
            {
                Id = e.Id,
                Nhom = _context.HoSoThi.Include(c => c.LopDuThi).Where(x => x.Id == e.Id).FirstOrDefault().LopDuThi.TenLop,
                SBD = _context.HoSoThi.Where(x => x.Id == e.Id).FirstOrDefault().SoBaoDanh,
                NgayGiaoLuu = e.NgayGiaoLuu,
                GioGiaoLuu = e.GioGiaoLuu,
                GioDon = e.GioDon,
                TrangThaiDuThi = e.TrangThaiDuThi
            });
            ApplyFilter(paramsModel, ref query);

            var paging = Utilities.ApplyPaging(data, paramsModel.PageNo, paramsModel.PageSize).ToList();
            var result = Task.FromResult(new BasePaginationResponseModel<DanhSachDuThiResponseModel>(paramsModel.PageNo, paramsModel.PageSize, paging, data.Count()));
            return result;
        }

        public async Task<List<HeDaoTaoDropDownModel>> GetHeDaoTaoAvailableForDropDown()
        {
            return await _context.HeDaoTao.Where(c => !c.IsDeleted).Select(e => new HeDaoTaoDropDownModel
            {
                Id = e.Id,
                HeDaoTao = e.TenHeDaoTao
            }).ToListAsync();
        }
        public async Task<List<LopDangKiDropDownResponseModel>> GetLopDangKiAvailableForDropDown()
        {
            return await _context.HoSoTuyenSinh.Where(c => !c.IsDeleted).Select(e => new LopDangKiDropDownResponseModel
            {
                Id = e.Id,
                LopDangKi = e.KhoiTuyenSinh.TenKhoi
            }).ToListAsync();
        }
        public async Task<List<TrangThaiDuThiDropDownResponseModel>> GetTrangThaiDuThiAvailableForDropDown()
        {
            return await _context.HoSoTuyenSinh.Where(c => !c.IsDeleted).Select(e => new TrangThaiDuThiDropDownResponseModel
            {
                Id = e.Id,
                TrangThaiDuThi = e.TrangThaiDuThi
            }).ToListAsync();
        }

        private void ApplyFilter(GetDanhSachDuThiAndPagingAndFilterRespuestModel paramsModel, ref IQueryable<HoSoTuyenSinh> query)
        {

            if (paramsModel.HeDaoTao != null)
            {
                query = query.Where(e => e.HeDaoTao.TenHeDaoTao == paramsModel.HeDaoTao);
            }
            if (paramsModel.LopDangKi != null)
            {
                query = query.Where(e => e.KhoiTuyenSinh.TenKhoi == paramsModel.LopDangKi);
            }
            if (paramsModel.TrangThaiDuThi != null)
            {
                query = query.Where(e => e.TrangThaiDuThi == paramsModel.TrangThaiDuThi);
            }
            if (paramsModel.DateStartFrom != DateTime.MinValue)
            {
                query = query.Where(e => paramsModel.DateStartFrom <= e.NgayGiaoLuuStart);
            }
            if (paramsModel.DateEndFrom != DateTime.MinValue)
            {
                query = query.Where(e => paramsModel.DateEndFrom <= e.NgayGiaoLuuEnd);
            }

        }
        
        public async Task<List<TheDuThiShowResponseModel>> GetTheDuThiAvailableForDropDown()
        {
            var resuilt = await _context.HoSoTuyenSinh
                .Where(c => c.TrangThaiDuThi == Enums.TrangThaiDanhSachDuThi.DaGuiMail)
                .Select(e => new TheDuThiShowResponseModel
                {
                    Id = e.Id,
                    SBD = _context.HoSoThi.Where(x => x.HoSoTuyenSinhId == e.Id).FirstOrDefault().SoBaoDanh,
                    AnhDuTuyen = e.AnhHoSo
                }).ToListAsync();
            return resuilt;
        }
        public async Task<List<KyTuyenSinhDropdownModel>> GetKyTuyenSinhAvailableForDropDown()
        {
            return await _context.KyTuyenSinh.Where(c => !c.IsDeleted).Select(e => new KyTuyenSinhDropdownModel
            {
                Id = e.Id,
                KyTuyenSinh = e.TenKyTuyenSinh,
            }).ToListAsync();
        }

        public Task DeleteListHoSoTuyenSinh(List<HoSoTuyenSinh> id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHoSoTuyenSinh(List<long> id)
        {
            throw new NotImplementedException();
        }

        public async Task<BasePaginationResponseModel<HoSoTuyenSinhResponseModel>> GetPagedHoSoTuyenSinhByKyTuyenSinhId(GetPagedHoSoTuyenSinhByKyTuyenSinhIdRequestModel input)
        {
            var query = _context.HoSoTuyenSinh.Where(x => !x.IsDeleted && x.KyTuyenSinhId.Equals(input.KyTuyenSinhId))
                                              .Select(x => new HoSoTuyenSinhResponseModel()
            {
                Id = x.Id,
                KyTuyenSinhId = x.KyTuyenSinhId,
                KhoiTuyenSinhId = x.KhoiTuyenSinhId,
                HeDaoTaoId = x.HeDaoTaoId,
                TenKhoi = x.KhoiTuyenSinh.TenKhoi,
                HeDaoTao = x.HeDaoTao.TenHeDaoTao,
                TaiKhoanId = x.TaiKhoanId,
                TenTaiKhoan = x.TaiKhoan.HoTen,
                MaSoHoSo = x.MaSoHoSo,
                HoTen = x.HoTen,
                NgayDangKy = x.NgayDangKy,
                NamHoc = x.KyTuyenSinh.TenKyTuyenSinh,
                KenhGioiThieu = x.KenhGioiThieu,
                TrangThai = x.TrangThai,
                IsDeleted = x.IsDeleted,
                NgayGiaoLuu = x.ThoiGianThi.NgayThi,
                GioGiaoLuu = x.ThoiGianThi.GioDuThi,
                GioDon = x.ThoiGianThi.GioDonCon,
                TrangThaiDuThi = x.TrangThaiDuThi,
                SoBaoDanh = _context.HoSoThi.First(y => y.HoSoTuyenSinhId.Equals(x.Id)).SoBaoDanh
            });
            if (!input.Keyword.IsNullOrEmpty())
            {
                query = query.Where(x => x.SoBaoDanh.ToLower().Equals(input.Keyword.ToLower()));
            }
            if (!input.HeDaoTaoIds.IsNullOrEmpty() && input.HeDaoTaoIds.Any())
            {
                query = query.Where(x => input.HeDaoTaoIds.Contains(x.HeDaoTaoId));
            }
            if (!input.TrangThaiHoSoTuyenSinhs.IsNullOrEmpty() && input.TrangThaiHoSoTuyenSinhs.Any())
            {
                query = query.Where(x => input.TrangThaiHoSoTuyenSinhs.Contains(x.TrangThai));
            }
            query = query.OrderByDescending(record => record.NgayDangKy);
            var totalItems = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<HoSoTuyenSinhResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<HoSoTuyenSinhResponseModel>(input.PageNo, input.PageSize, result, totalItems);
        }
    }
}

using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.NhanVien;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.NhanVien;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Business.FileService;
using NS.Core.Commons.CustomException;
using NS.Core.Models.ResponseModels.FileUpload;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.NhanVienService
{
    public class NhanVienService : INhanVienService
    {
        private readonly AppDbContext _context;
        private readonly IFile _fileService;

        public NhanVienService(AppDbContext dbContext, IFile fileService)
        {
            _context = dbContext;
            _fileService = fileService;
        }

        public async Task CreateOrUpdate(CreateOrUpdateNhanVienRequestModel model)
        {
            try
            {
                var phongBan = await _context.PhongBan
                    .Where(e => e.Id == model.PhongBanId)
                    .FirstOrDefaultAsync();

                if (phongBan == null) throw new InvalidException(nameof(NhanVien.PhongBanId));
                
                var nhanVien = new NhanVien();
                var file = new FileUploadResponseModel();
                
                if (model.Id > 0)
                {
                    nhanVien = await _context.NhanVien
                        .Where(e=>e.Id == model.Id)
                        .FirstOrDefaultAsync();
                    if(nhanVien == null) throw new NotFoundException(nameof(NhanVien.Id));
                }

                if (model.File?.Length > 0)
                {
                    _fileService.DeleteFile(nhanVien.FileId??0);
                    file = await _fileService.UploadFile( model.File, FolderChild.CoCauToChuc);
                }
                
                model.Mapping(ref nhanVien,file);
                
                _context.NhanVien.Update(nhanVien);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<NhanVienResponseModel>> GetAll()
        {
            return _context.NhanVien
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi
                }).ToList();
        }

        public async Task<List<NhanVienResponseModel>> GetAllAvailable()
        {
            return _context.NhanVien
                .Where(x => !x.IsDeleted)
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi
                }).ToList();
        }

        public async Task<List<NhanVienResponseModel>> GetAllDisplay()
        {
            return _context.NhanVien
                .Where(x => !x.HienThi)
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi
                }).ToList();
        }

        public async Task<NhanVienResponseModel> GetById(long id)
        {
            var queryable = _context.NhanVien
                .Where(e => e.Id == id && !e.IsDeleted)
                .Include(e => e.PhongBan)
                .AsQueryable();

            if (queryable.IsNullOrEmpty()) throw new NotFoundException(nameof(NhanVien.Id));

            var person = await queryable.FirstAsync();

            return new NhanVienResponseModel
            {
                Id = person.Id,
                PhongBanId = person.PhongBanId,
                PhongBan = person.PhongBan.TenPhongBan,
                HoTen = person.HoTen,
                ChucVu = person.ChucVu,
                LinkAnh = person.LinkAnh,
                ThongTinLienLac = person.ThongTinLienLac,
                HocVan = person.HocVan,
                QuaTrinhLamViec = person.QuaTrinhLamViec,
                ChamNgon = person.ChamNgon,
                HienThi = person.HienThi,
                DanhHieu = person.DanhHieu,
                LaChuyenVienTuVan= person.LaChuyenVienTuVan ,
                
            };
        }

        public async Task<BasePaginationResponseModel<NhanVienResponseModel>> GetPagedNhanVien(
            GetPagedNhanVienRequestModel input)
        {
            var query = _context.NhanVien
                .Where(x => !x.IsDeleted)
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi,
                    DanhHieu = x.DanhHieu,
                    LaChuyenVienTuVan = x.LaChuyenVienTuVan
                })
                .AsQueryable();

            query = ApplySearchAndFilter(query, input);
            query = query.OrderByDescending(e => e.Id);
            
            var totalItems = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<NhanVienResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<NhanVienResponseModel>(input.PageNo, input.PageSize, result,
                totalItems);
        }

        private IQueryable<NhanVienResponseModel> ApplySearchAndFilter(IQueryable<NhanVienResponseModel> query,
            GetPagedNhanVienRequestModel input)
        {
            // apply search
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var keyword = input.Keyword.ToLower().Trim();
                query = query
                    .Where(record =>
                        EF.Functions
                            .Collate(record.HoTen, "SQL_Latin1_General_CP1_CI_AI")
                            .Contains(input.Keyword)
                        || EF.Functions
                            .Collate(record.ChucVu, "SQL_Latin1_General_CP1_CI_AI")
                            .Contains(input.Keyword)
                        || EF.Functions
                            .Collate(record.ThongTinLienLac, "SQL_Latin1_General_CP1_CI_AI")
                            .Contains(input.Keyword)
                    );
            }

            //apply filter
            if (input.PhongBanId > 0)
            {
                query = query.Where(record => record.PhongBanId == input.PhongBanId);
            }

            return query;
        }

        public async Task Create(NhanVienRequestModel model)
        {
            NhanVien person = new NhanVien
            {
                PhongBanId = model.PhongBanId,
                HoTen = model.HoTen,
                ChucVu = model.ChucVu,
                LinkAnh = model.LinkAnh,
                ThongTinLienLac = model.ThongTinLienLac,
                HocVan = model.HocVan,
                HienThi = model.HienThi,
                QuaTrinhLamViec = model.QuaTrinhLamViec,
                ChamNgon = model.ChamNgon
            };
            _context.NhanVien.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task Update(long id, NhanVienRequestModel model)
        {
            NhanVien person = _context.NhanVien.GetById(id);
            person.PhongBanId = model.PhongBanId;
            person.HoTen = model.HoTen;
            person.ChucVu = model.ChucVu;
            person.LinkAnh = model.LinkAnh;
            person.ThongTinLienLac = model.ThongTinLienLac;
            person.HocVan = model.HocVan;
            person.HienThi = model.HienThi;
            person.QuaTrinhLamViec = model.QuaTrinhLamViec;
            person.ChamNgon = model.ChamNgon;
            _context.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            _context.NhanVien.Delete(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<NhanVienResponseModel>> GetChuyenVienTamLy(bool isDisplay = false)
        {
            var query = _context.NhanVien.AsQueryable();
            query = query.Where(x => !x.IsDeleted && x.LaChuyenVienTuVan);
            if (isDisplay)
            {
                query = query.Where(x => x.HienThi);
            }
            var res= query.Select(x => new NhanVienResponseModel
            {
                Id = x.Id,
                PhongBanId = x.PhongBanId,
                PhongBan = x.PhongBan.TenPhongBan,
                HoTen = x.HoTen,
                ChucVu = x.ChucVu,
                LinkAnh = x.LinkAnh,
                DanhHieu = x.DanhHieu,
                ThongTinLienLac = x.ThongTinLienLac,
                HocVan = x.HocVan,
                QuaTrinhLamViec = x.QuaTrinhLamViec,
                ChamNgon = x.ChamNgon,
                HienThi = x.HienThi
            }).ToList();
            return res;
        }

        public async Task<List<NhanVienResponseModel>> GetNhanVienByPhongBan(long id)
        {
            var query = _context.NhanVien
                .Where(x => !x.IsDeleted && x.PhongBanId == id && x.LaChuyenVienTuVan == false)
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi,
                    Hang = x.Hang,
                    Cot = x.Cot
                }).AsQueryable();
            var result = query.OrderBy(x => x.Hang).ThenBy(x => x.Cot).ToList();
            return result;
        }

        public async Task<List<NhanVienResponseModel>> GetNhanVienByLoaiPhongBan(LoaiPhongBan loaiPhongBan)
        {
            var query = _context.NhanVien
                .Where(x => !x.IsDeleted && x.PhongBan.LoaiPhongBan == loaiPhongBan && x.LaChuyenVienTuVan == false)
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi,
                    Hang = x.Hang,
                    Cot = x.Cot
                }).AsQueryable();
            var result = query.OrderBy(x => x.Hang).ThenBy(x => x.Cot).ToList();
            return result;
        }
        public async Task<List<NhanVienResponseModel>> GetNhanVienByLoaiPhongBanActive(LoaiPhongBan loaiPhongBan)
        {
            var query = _context.NhanVien
                .Where(x => !x.IsDeleted && x.PhongBan.LoaiPhongBan == loaiPhongBan && x.LaChuyenVienTuVan == false && x.HienThi)
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi,
                    Hang = x.Hang,
                    Cot = x.Cot
                }).AsQueryable();
            var result = query.OrderBy(x => x.Hang).ThenBy(x => x.Cot).ToList();
            return result;
        }

        public async Task UpdateLaChuyenVienTamLy(long id)
        {
            NhanVien person = _context.NhanVien.GetById(id);
            person.LaChuyenVienTuVan = !person.LaChuyenVienTuVan;
            _context.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNhanVienActive(long id)
        {
            NhanVien person = _context.NhanVien.GetById(id);
            person.HienThi = !person.HienThi;
            _context.Update(person);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateHangVaCot(ChangeHangVaCotNhanVienRequestModel request)
        {
            var data = _context.NhanVien.GetByIdQueryable(request.Id).FirstOrDefault();
            if(data != null)
            {
                data.Cot = request.Cot;
                data.Hang = request.Hang;
            }
            _context.NhanVien.Update(data);
            await _context.SaveChangesAsync();
        }
        public async Task<BasePaginationResponseModel<NhanVienResponseModel>> GetPagedNhanVienActive(
          GetPagedNhanVienRequestModel input)
        {
            var query = _context.NhanVien
                .Where(x => !x.IsDeleted && x.HienThi)
                .Select(x => new NhanVienResponseModel
                {
                    Id = x.Id,
                    PhongBanId = x.PhongBanId,
                    PhongBan = x.PhongBan.TenPhongBan,
                    HoTen = x.HoTen,
                    ChucVu = x.ChucVu,
                    LinkAnh = x.LinkAnh,
                    ThongTinLienLac = x.ThongTinLienLac,
                    HocVan = x.HocVan,
                    QuaTrinhLamViec = x.QuaTrinhLamViec,
                    ChamNgon = x.ChamNgon,
                    HienThi = x.HienThi,
                    DanhHieu = x.DanhHieu,
                    LaChuyenVienTuVan = x.LaChuyenVienTuVan
                })
                .AsQueryable();

            query = ApplySearchAndFilter(query, input);
            query = query.OrderByDescending(e => e.Id);

            var totalItems = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<NhanVienResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<NhanVienResponseModel>(input.PageNo, input.PageSize, result,
                totalItems);
        }
    }
}
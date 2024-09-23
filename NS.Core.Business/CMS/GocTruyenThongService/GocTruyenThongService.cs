using Microsoft.EntityFrameworkCore;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.GocTruyenThong;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.GocTruyenThong;
using NS.Core.Business.FileService;
using NS.Core.Commons.CustomException;

namespace NS.Core.Business.GocTruyenThongService
{
    public class GocTruyenThongService : IGocTruyenThongService
    {
        private readonly AppDbContext _context;
        private readonly IFile _fileService;

        public GocTruyenThongService(AppDbContext dbContext, IFile fileService)
        {
            _context = dbContext;
            _fileService = fileService;
        }

        public async Task Create(GocTruyenThongRequestModel model)
        {
            GocTruyenThong gocTruyenThong = new GocTruyenThong
            {
                SoTrang = model.SoTrang,
                LinkAnh = model.LinkAnh
            };
            _context.GocTruyenThong.Add(gocTruyenThong);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            _context.GocTruyenThong.Delete(id);
            await _context.SaveChangesAsync();
        }

        public List<GocTruyenThongResponseModel> GetAllAvailable()
        {
            var result = _context.GocTruyenThong
                .Where(record => !record.IsDeleted)
                .Select(x => new GocTruyenThongResponseModel
                {
                    Id = x.Id,
                    SoTrang = x.SoTrang,
                    LinkAnh = x.LinkAnh
                }).ToList();
            return result;
        }

        public Task<BasePaginationResponseModel<GocTruyenThongResponseModel>> GetPaged(
            GetPagedGocTruyenThongReqModel page)
        {
            var query = _context.GocTruyenThong
                .Where(record => !record.IsDeleted)
                .OrderBy(record => record.SoTrang)
                .AsQueryable();

            var data = query.ApplyPaging(page.PageNo, page.PageSize, out var totalItems);
            var result = data
                .Select(x => new GocTruyenThongResponseModel
                {
                    Id = x.Id,
                    SoTrang = x.SoTrang,
                    LinkAnh = x.LinkAnh
                }).ToList();
            return Task.FromResult(
                new BasePaginationResponseModel<GocTruyenThongResponseModel>(page.PageNo, page.PageSize, result,
                    totalItems));
        }

        public GocTruyenThongResponseModel GetById(long id)
        {
            GocTruyenThong gocTruyenThong = _context.GocTruyenThong.GetById(id);
            return new GocTruyenThongResponseModel
            {
                Id = gocTruyenThong.Id,
                SoTrang = gocTruyenThong.SoTrang,
                LinkAnh = gocTruyenThong.LinkAnh
            };
        }

        public async Task Update(long id, GocTruyenThongRequestModel model)
        {
            var item = _context.GocTruyenThong.GetById(id);
            item.SoTrang = model.SoTrang;
            item.LinkAnh = model.LinkAnh;
            _context.GocTruyenThong.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCMS(GocTruyenThongCMSRequestModel model)
        {
            try
            {
                var query =  _context.GocTruyenThong.Where(x => x.SoTrang == model.SoTrang);
                
                if (query.Any()) throw new ExistException(nameof(GocTruyenThong.SoTrang));

                if (model.File?.Length > 0)
                {
                    var file = await _fileService.UploadFile(model.File, Enums.FolderChild.GocTruyenThong);
                    model.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.GocTruyenThong)}/{file.FileName}";
                }

                GocTruyenThong gocTruyenThong = new GocTruyenThong
                {
                    SoTrang = model.SoTrang,
                    LinkAnh = model.LinkAnh
                };

                _context.GocTruyenThong.Add(gocTruyenThong);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdateCMS(EditGocTruyenThongCMSRequestModel model)
        {
            try
            {
                var gocTruyenThong = _context.GocTruyenThong.GetById(model.Id);

                IEnumerable<GocTruyenThong> query = _context.GocTruyenThong
                    .Where(x => x.SoTrang == model.SoTrang && x.Id != model.Id);

                if (query.Any()) throw new ExistException(nameof(GocTruyenThong.SoTrang));

                if (model.File?.Length > 0)
                {
                    var file = await _fileService.UploadFile(model.File, Enums.FolderChild.GocTruyenThong);
                    model.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.GocTruyenThong)}/{file.FileName}";
                }

                gocTruyenThong.SoTrang = model.SoTrang;
                gocTruyenThong.LinkAnh = model.LinkAnh;

                _context.GocTruyenThong.Update(gocTruyenThong);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<SuKienTruyenThongNoiBatResModel> GetSuKienTruyenThongNoiBat()
        {
            try
            {
                var data = _context.TinTuc.Where(record =>
                        !record.IsDeleted
                        && record.LoaiBaiViet == Enums.LoaiBaiViet.GocTruyenThong
                        && record.LaTinNoiBat
                    )
                    .Select(record => new SuKienTruyenThongNoiBatResModel
                    {
                        Id = record.Id,
                        TieuDe = record.TieuDe,
                        TieuDeTiengAnh = record.TieuDeEnglish,
                        NoiDungTomTat = record.NoiDungTomTat,
                        NoiDungTomTatTiengAnh = record.NoiDungTomTatEnglish,
                        LinkAnh = record.AnhDaiDien,
                    })
                    .ToList();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }

    public class SuKienTruyenThongNoiBatResModel
    {
        public long Id { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string NoiDungTomTat { get; set; }
        public string NoiDungTomTatTiengAnh { get; set; }
        public string LinkAnh { get; set; }
    }
}
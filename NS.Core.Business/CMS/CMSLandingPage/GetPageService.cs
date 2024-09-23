using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NS.Core.Business.FileService;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.CMSLandingPage;
using NS.Core.Models.RequestModels.QuyDinhNhapHocReqestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.CMSLandingPage;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.CMSLandingPage
{
    public class GetPageService : IGetPageService
    {
        private readonly AppDbContext _context;
        private readonly IFile _fileService;
        private readonly ILogger<GetPageService> _logger;

        public GetPageService(AppDbContext dbContext,
                              IFile fileService,
                              ILogger<GetPageService> logger)
        {
            _context = dbContext;
            _fileService = fileService;
            _logger = logger;
        }



        public List<CaiDatChitietResponseModel> GetCaiDatChitiet(long caiDatTongTheId)
        {
            var CaiDatChiTiet = _context.CaiDatChiTiet
                                        .Where(x => x.CaiDatTongTheId.Equals(caiDatTongTheId))
                                        .Select(z => new CaiDatChitietResponseModel
                                        {
                                            Id = z.Id,
                                            CaiDatTongTheId = caiDatTongTheId,
                                            TieuDe = z.TieuDe,
                                            TieuDeTiengAnh = z.TieuDeTiengAnh,
                                            MoTa = z.MoTa ?? string.Empty,
                                            MoTaTiengAnh = z.MoTaTiengAnh ?? string.Empty,
                                            Link = z.Link,
                                            FileId = z.FileId,
                                            Icon = z.Icon,
                                            LinkAnh = z.LinkAnh
                                        }).ToList();
            return CaiDatChiTiet;
        }

        public async Task<BasePaginationResponseModel<CaiDatChitietResponseModel>> GetPagedCaiDatChiTiet(
            long caiDatTongTheId, GetPagedCaiDatChiTietRequestModel input)
        {
            try
            {
                var query = GetCaiDatChitiet(caiDatTongTheId).AsQueryable();
                var totalItem = 0;

                query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);

                List<CaiDatChitietResponseModel> result = query.ToList();

                return await Task.FromResult(
                    new BasePaginationResponseModel<CaiDatChitietResponseModel>(input.PageNo, input.PageSize, result, totalItem));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CaiDatTongTheResponseModel>> GetCaiDatTongThe(long trangId)
        {
            try
            {
                var query = _context.CaiDatTongThe
                                    .Where(x => x.TrangId == trangId).ToList();
                var res = query.OrderBy(c => c.ThuTu).Select(x => new CaiDatTongTheResponseModel
                {
                    Id = x.Id,
                    TrangId = x.TrangId,
                    TieuDe = x.TieuDe ?? string.Empty,
                    Mota = x.Mota ?? string.Empty,
                    MotaTiengAnh = x.MotaTiengAnh ?? string.Empty,
                    TieuDeTiengAnh = x.TieuDeTiengAnh ?? string.Empty,
                    Link = x.Link ?? string.Empty,
                    LinkAnh = x.LinkAnh ?? string.Empty,
                }).ToList();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task EditCaiDatTongThe(long caiDatTongTheId, CaiDatTongTheRequestModel input)
        {
            var query = _context.CaiDatTongThe.GetById(caiDatTongTheId);
            query.TieuDe = input.TieuDe;
            query.Mota = input.Mota;
            query.TieuDeTiengAnh = input.TieuDeTiengAnh;
            query.MotaTiengAnh = input.MotaTiengAnh;
            query.Link = input.Link;
            query.CaiDatChiTiet = new List<CaiDatChiTiet>();
            _context.CaiDatTongThe.Update(query);
            await _context.SaveChangesAsync();
        }


        public async Task CreateCaiDatChiTiet(long caiDatTongTheId, CaiDatChiTietRequestModel input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Kiem tra file va save file
                    if (input.File is { } file)
                    {
                        var res = await _fileService.UploadFile(file, Enums.FolderChild.TrangTinh);
                        input.FileId = res.Id;
                        input.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.TrangTinh)}/{res.FileName}";
                    }

                    var entity = new CaiDatChiTiet()
                    {
                        CaiDatTongTheId = caiDatTongTheId,
                        TieuDe = input.TieuDe,
                        TieuDeTiengAnh = input.TieuDeTiengAnh,
                        MoTa = input.MoTa,
                        MoTaTiengAnh = input.MoTaTiengAnh,
                        Link = input.Link,
                        Icon = input.Icon,
                        LinkAnh = input.LinkAnh,
                        FileId = input.FileId,
                    };
                    _context.CaiDatChiTiet.Add(entity);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, nameof(CreateCaiDatChiTiet));
                    throw;
                }
            }

        }

        public async Task UpdateCaiDatChiTiet(long caiDatChiTietId, CaiDatChiTietRequestModel input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var caiDatChiTietEntity = _context.CaiDatChiTiet.GetById(caiDatChiTietId);

                    // Kiem tra file va save file
                    if (input.File is { } file)
                    {
                        // Neu upload file moi thi phai xoa file cu va save file moi

                        // Xoa file cu
                        if (caiDatChiTietEntity.FileId.HasValue)
                            _fileService.DeleteFile(caiDatChiTietEntity.FileId.Value);

                        // Luu file moi
                        var res = await _fileService.UploadFile(file, Enums.FolderChild.TrangTinh);
                        input.FileId = res.Id;
                        input.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.TrangTinh)}/{res.FileName}";
                    }

                    // Save cai dat chi tiet
                    caiDatChiTietEntity.TieuDe = input.TieuDe;
                    caiDatChiTietEntity.TieuDeTiengAnh = input.TieuDeTiengAnh;
                    caiDatChiTietEntity.MoTa = input.MoTa;
                    caiDatChiTietEntity.MoTaTiengAnh = input.MoTaTiengAnh;
                    caiDatChiTietEntity.Icon = input.Icon;
                    caiDatChiTietEntity.Link = input.Link;
                    caiDatChiTietEntity.LinkAnh = input.LinkAnh;
                    caiDatChiTietEntity.FileId = input.FileId;
                    _context.CaiDatChiTiet.Update(caiDatChiTietEntity);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, nameof(UpdateCaiDatChiTiet));
                    throw;
                }
            }
        }

        public async Task DeleteCaiDatChiTiet(long caiDatChiTietId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var caiDatChiTietEntity = _context.CaiDatChiTiet.FirstOrDefault(x => x.Id == caiDatChiTietId);

                    if (caiDatChiTietEntity is null) return;

                    // Xoa file dinh kem neu co
                    if (caiDatChiTietEntity.FileId.HasValue && caiDatChiTietEntity.FileId.Value > 0)
                    {
                        _fileService.DeleteFile(caiDatChiTietEntity.FileId.Value);
                    }

                    _context.CaiDatChiTiet.Remove(caiDatChiTietEntity);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, nameof(DeleteCaiDatChiTiet));
                    throw;
                }

            }


        }

        public async Task<CaiDatChitietResponseModel> GetCaiDatChiTietById(long caiDatChitietId)
        {
            var query = await _context.CaiDatChiTiet.Where(x => x.Id == caiDatChitietId).Select(y => new CaiDatChitietResponseModel
            {
                Id = y.Id,
                CaiDatTongTheId = y.CaiDatTongTheId,
                Link = y.Link,
                Icon = y.Icon,
                LinkAnh = y.LinkAnh,
                TieuDe = y.TieuDe,
                TieuDeTiengAnh = y.TieuDeTiengAnh,
                MoTa = y.MoTa ?? string.Empty,
                MoTaTiengAnh = y.MoTaTiengAnh ?? string.Empty,
                FileId = y.FileId,
            }).FirstOrDefaultAsync();
            return query;
        }
        public async Task<CaiDatTongTheResponseModel> GetCaiDatTongTheById(long id)
        {
            try
            {
                var query = _context.CaiDatTongThe.Where(e => e.Id == id).AsQueryable();
                if (!query.Any()) throw new NotFoundException(nameof(CaiDatTongThe.Id));
                var result = await query.FirstAsync();
                return CaiDatTongTheResponseModel.Mapping(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public async Task CreateCaiDatTongThe(long trangId, CaiDatTongTheRequestModel input)
        {
            try
            {
                var res = new CaiDatTongThe()
                {
                    TrangId = trangId,
                    TieuDe = input.TieuDe,
                    Mota = input.Mota,
                    MotaTiengAnh = input.MotaTiengAnh,
                    TieuDeTiengAnh = input.TieuDeTiengAnh
                };
                _context.CaiDatTongThe.Add(res);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteCaiDatTongThe(long caiDatTongThe)
        {
            var res = _context.CaiDatTongThe.Where(x => x.Id == caiDatTongThe).FirstOrDefault();
            _context.CaiDatTongThe.Remove(res);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateQuyDinhNhapHoc(QuyDinhNhapHocRequestModel model)
        {
            try
            {
                var res = _context.CaiDatTongThe.Where(x => x.Id == model.Id).FirstOrDefault();
                res.Mota = model.Mota;
                res.MotaTiengAnh = model.MotaTiengAnh;
                res.TieuDe = model.TieuDe;
                res.TieuDeTiengAnh = model.TieuDeTiengAnh;
                if (model == null) throw new Exception();
                if (model.File?.Length > 0)
                {
                    var file = await _fileService.UploadFile(model.File, FolderChild.TrangTinh);
                    res.Link = $"/imgs/{nameof(Enums.FolderChild.TrangTinh)}/{file.FileName}";
                }
                _context.CaiDatTongThe.Update(res);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
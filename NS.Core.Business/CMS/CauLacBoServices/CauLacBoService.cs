using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Business.CMSLandingPage;
using NS.Core.Business.FileService;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System.Net.WebSockets;

namespace NS.Core.Business.CauLacBoServices;

public class CauLacBoService : ICauLacBoService
{
    private readonly AppDbContext _appDbContext;
    private readonly IFile _fileService;
    private readonly ILogger<GetPageService> _logger;

    public CauLacBoService(AppDbContext appDbContext, IFile fileService, ILogger<GetPageService> logger)
    {
        _appDbContext = appDbContext;
        _fileService = fileService;
        _logger = logger;

    }
    public async Task<CauLacBoRequestModel> CreateAnhCauLacBo()
    {
        return new CauLacBoRequestModel()
        {
            AnhCauLacBos = new List<AnhCauLacBoRequestModel>()
            {
                new AnhCauLacBoRequestModel(),
                new AnhCauLacBoRequestModel(),
                new AnhCauLacBoRequestModel(),

            }
         };
    }
    public async Task CreateCauLacBo(CauLacBoRequestModel input)
    {
        using (var transaction = _appDbContext.Database.BeginTransaction())
        {
            try
            {
                var fileId = _appDbContext.FileUpload.Select(x => x.Id).FirstOrDefault();
                if (input.AnhCauLacBos != null)
                {
                    foreach (var item in input.AnhCauLacBos)
                    {
                        if (item.File is { } file)
                        {
                            var res = await _fileService.UploadFile(item.File, Enums.FolderChild.CauLacBo);
                            item.FileUploadId = res.Id;
                            fileId =(int )res.Id;
                            item.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.CauLacBo)}/{res.FileName}";
                        }
                        else
                        {
                            var imageInput = "anhloi";
                            item.FileUploadId = fileId;
                            item.LinkAnh = imageInput;
                        }    
                    }
                    var cauLacBoEntity = Mapping(input);
                    _appDbContext.CauLacBo.Add(cauLacBoEntity);
                }
                else
                {
                    var cauLacBoEntityNoAnh= MappingWithNoAnh(input);
                    _appDbContext.CauLacBo.Add(cauLacBoEntityNoAnh);
                }
                await _appDbContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, nameof(CreateCauLacBo));
                throw;
            }

        }
    }
    public async Task EditCauLacBo(CauLacBoRequestModel input)
    {
        using (var transaction = _appDbContext.Database.BeginTransaction())
        {
            try
            {
                var imageInput = "anhloi";
                List<long> ids = new List<long>();
                if (input.AnhCauLacBos != null)
                {
                    foreach (var item in input.AnhCauLacBos)
                    {
                        if (item.File is { } file)
                        {
                            if(item.LinkAnh!= imageInput)
                            {
                                ids.Add(item.FileUploadId);
                            }    
                            var res = await _fileService.UploadFile(item.File, Enums.FolderChild.CauLacBo);
                            item.FileUploadId = res.Id;
                            item.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.CauLacBo)}/{res.FileName}";
                            
                        }
                    }
                    var entity = _appDbContext.AnhCauLacBo.Where(x => x.CauLacBoId == input.Id);
                    _appDbContext.AnhCauLacBo.RemoveRange(entity);
                    await _appDbContext.SaveChangesAsync();
                }
                var cauLacBoEntity = Mapping(input);
                _appDbContext.CauLacBo.Update(cauLacBoEntity);
                await _appDbContext.SaveChangesAsync();
                if(ids.Count > 0)
                {
                foreach (var item in ids)
                {
                    _fileService.DeleteFile(item);
                }

                }    
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, nameof(EditCauLacBo));
                throw;
            }
        }
    }

    public async Task DeleteCauLacBo(long id)
    {
        using (var transaction = _appDbContext.Database.BeginTransaction())
        {
            try
            {
                var imageInput = "anhloi";
                var cauLacBoEntity = _appDbContext.CauLacBo
                    .Where(x => x.Id == id)
                    .Include(x => x.AnhCauLacBo).FirstOrDefault();
                if (cauLacBoEntity == null) throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(CauLacBo)));
                var listFileUploadId = cauLacBoEntity.AnhCauLacBo.Where(x=>x.LinkAnh!=imageInput).Select(x => x.FileUploadId).ToList();
                if(listFileUploadId.Count > 0)
                {
                foreach (var item in listFileUploadId)
                {
                    _fileService.DeleteFile(item);
                }

                }
                _appDbContext.CauLacBo.Remove(cauLacBoEntity);
                await _appDbContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {

                transaction.Rollback();
                _logger.LogError(ex, nameof(DeleteCauLacBo));
                throw;
            }

        }


    }

    private CauLacBo Mapping(CauLacBoRequestModel input)
    {
        return new CauLacBo
        {
            Id = input.Id,
            TenCauLacBo = input.TenCauLacBo,
            HocPhi = input.HocPhi,
            SoBuoiHoc = input.SoBuoiHoc,
            ThoiGianBatDau = input.ThoiGianBatDau,
            ThoiGianKetThuc = input.ThoiGianKetThuc,
            MoTa = input.MoTa,
            Icon = input.icon,
            MoTaTiengAnh = input.MoTaTiengAnh,
            AnhCauLacBo = input.AnhCauLacBos.Select(x => new AnhCauLacBo
            {
                FileUploadId = x.FileUploadId,
                LinkAnh = x.LinkAnh,
                CauLacBoId = x.CauLacBoId,
            }).ToList()

        };
    }
    private CauLacBo MappingWithNoAnh(CauLacBoRequestModel input)
    {
        return new CauLacBo
        {
            Id = input.Id,
            TenCauLacBo = input.TenCauLacBo,
            HocPhi = input.HocPhi,
            SoBuoiHoc = input.SoBuoiHoc,
            ThoiGianBatDau = input.ThoiGianBatDau,
            ThoiGianKetThuc = input.ThoiGianKetThuc,
            MoTa = input.MoTa,
            Icon = input.icon,
            MoTaTiengAnh = input.MoTaTiengAnh,
        };
     } 
    public async Task<List<CauLacBoResponseModel>> GetAll()
    {
        var cauLacBoDetailList = await _appDbContext.CauLacBo.Include(e => e.AnhCauLacBo)
            .Select(e => CauLacBoResponseModel.Mapping(e))
            .ToListAsync();
        return cauLacBoDetailList;
    }

    public async Task<CauLacBoResponseModel> GetById(long id)
    {
        var cauLacBoResponseModels = await _appDbContext.CauLacBo
            .Where(x => x.Id == id).Include(x => x.AnhCauLacBo)
            .Select(e => CauLacBoResponseModel
            .Mapping(e)).FirstOrDefaultAsync();
        return cauLacBoResponseModels;
    }


}
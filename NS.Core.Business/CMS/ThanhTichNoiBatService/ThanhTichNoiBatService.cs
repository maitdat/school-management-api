using Microsoft.EntityFrameworkCore;
using NS.Core.Business.FileService;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.ThanhTichNoiBat;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.ThanhTichNoiBatResponse;

namespace NS.Core.Business.CMS.ThanhTichNoiBatService
{
    public class ThanhTichNoiBatService : IThanhTichNoiBatService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFile _fileService;
        public ThanhTichNoiBatService(AppDbContext appDbContext, IFile fileService)
        {
            _appDbContext = appDbContext;
            _fileService = fileService;
        }
        public async Task Create(CreateOrUpdateThanhTichNoiBat data)
        {
            ThanhTichNoiBat obj = new ThanhTichNoiBat()
            {
                TenHocSinh = data.TenHocSinh,
                MoTa = data.MoTa,
                MoTaTiengAnh = data.MoTaTiengAnh,
                LinkAnh = data.LinkAnh
            };

            if (data.File != null)
            {
                var resImg = await _fileService.UploadFile(data.File, Enums.FolderChild.ThanhTichNoiBat);
                obj.FileId = resImg.Id;
                obj.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.ThanhTichNoiBat)}/{resImg.FileName}";
            }

            _appDbContext.ThanhTichNoiBat.Add(obj);
            _appDbContext.SaveChanges();
        }

        public async Task Delete(long id)
        {
            ThanhTichNoiBat obj = await _appDbContext.ThanhTichNoiBat.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (obj == null)
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(ThanhTichNoiBat.Id)));
            _appDbContext.ThanhTichNoiBat.Delete(obj);
            _appDbContext.SaveChanges();
        }

        public async Task<GetThanhTichNoiBatResponseModel> GetById(long id)
        {
            ThanhTichNoiBat obj = await _appDbContext.ThanhTichNoiBat.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (obj == null)
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(ThanhTichNoiBat.Id)));
            return MappingResponse(obj);
        }

        public Task<BasePaginationResponseModel<GetThanhTichNoiBatResponseModel>> GetPage(BasePaginationRequestModel data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CreateOrUpdateThanhTichNoiBat data, long id)
        {
            try
            {
                var target = _appDbContext.ThanhTichNoiBat.Where(c => c.Id == id).FirstOrDefault();
                if (target == null)
                {
                    throw new Exception(Constants.ExceptionMessage.ITEM_NOT_FOUND);
                }
                target.TenHocSinh = data.TenHocSinh;
                target.MoTa = data.MoTa;
                target.MoTaTiengAnh = data.MoTaTiengAnh;

                if (data.File != null)
                {
                    var resImg = await _fileService.UploadFile(data.File, Enums.FolderChild.ThanhTichNoiBat);
                    target.FileId = resImg.Id;
                    target.LinkAnh = $"/imgs/{nameof(Enums.FolderChild.ThanhTichNoiBat)}/{resImg.FileName}";
                }

                _appDbContext.ThanhTichNoiBat.Update(target);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static GetThanhTichNoiBatResponseModel MappingResponse(ThanhTichNoiBat obj)
        {
            return new GetThanhTichNoiBatResponseModel()
            {
                Id = obj.Id,
                TenHocSinh = obj.TenHocSinh,
                MoTa = obj.MoTa,
                MoTaTiengAnh = obj.MoTaTiengAnh,
                LinkAnh = obj.LinkAnh,
            };
        }

        public async Task<List<GetThanhTichNoiBatResponseModel>> GetAll()
        {
            List<GetThanhTichNoiBatResponseModel> thanhTichNoiBats = await _appDbContext.ThanhTichNoiBat
            .Where(x => !x.IsDeleted).Select(x => MappingResponse(x)).ToListAsync();
            return thanhTichNoiBats;
        }
    }
}

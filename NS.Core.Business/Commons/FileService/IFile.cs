using NS.Core.Models.ResponseModels.FileUpload;
using Microsoft.AspNetCore.Http;
using NS.Core.Commons;

namespace NS.Core.Business.FileService
{
    public interface IFile
    {
        Task<FileUploadResponseModel> UploadFile(IFormFile formFile,Enums.FolderChild folderChild);
        Task<FileUploadResponseModel> GetById(long id);
        Task<Byte[]> GetFileByteArray(long id);

        void DeleteFile(long id);
    }
}

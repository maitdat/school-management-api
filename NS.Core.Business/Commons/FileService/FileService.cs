using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.FileUpload;
using System.ComponentModel;

namespace NS.Core.Business.FileService
{
    public class FileService : IFile
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<FileService> _logger;

        public FileService(IConfiguration configuration, AppDbContext appDbContext, ILogger<FileService> logger)
        {
            _configuration = configuration;
            _appDbContext = appDbContext;
            _logger = logger;
        }


        public async Task<FileUploadResponseModel> UploadFile(IFormFile formFile, Enums.FolderChild folderChild)
        {
            try
            {
                Guid guildId = Guid.NewGuid();

                if (formFile == null) throw new NotFoundException(nameof(File));
                typeof(Enums.FolderChild).IsDefineEnum(folderChild);

                string pathFolder = GetFullPathFolder(folderChild);
                string fileExt = Path.GetExtension(formFile.FileName);
                string pathFile = Path.Combine(pathFolder, guildId.ToString() + fileExt);

                await WriteFileToDisk(pathFolder, pathFile, formFile);

                //var valueEnum = GetValueFromDescription<Enums.FileType>(fileExt);

                //var enumFileExt = (Enums.FileType)Enum.Parse(typeof(Enums.FileType), valueEnum.ToString());

                FileUpload fileUpload = new FileUpload
                {
                    FileName = guildId,
                    OriginName = formFile.FileName,
                    FileType = Enums.FileType.Image,
                    FilePath = pathFile
                };

                _appDbContext.FileUpload.Add(fileUpload);
                await _appDbContext.SaveChangesAsync();

                var allPaths = fileUpload.FilePath.Split('\\').Reverse().ToList();
                var index = allPaths.IndexOf("imgs");
                var linkAnh = "/" + string.Join('/', allPaths.Take(index + 1).Reverse());

                return new FileUploadResponseModel()
                {
                    Id = fileUpload.Id,
                    FileName = fileUpload.FileName.ToString() + fileExt,
                    FileType = fileUpload.FileType,
                    LinkAnh = linkAnh,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<FileUploadResponseModel> GetById(long id)
        {
            try
            {
                IQueryable<FileUpload> query = _appDbContext.FileUpload.Where(e => e.Id == id);

                if (query.IsNullOrEmpty()) throw new NotFoundException(nameof(FileUpload.Id));

                FileUpload file = await query.FirstAsync();

                if (!File.Exists(file.FilePath)) throw new NotFoundException(nameof(File));

                byte[] fileBytes = await File.ReadAllBytesAsync(file.FilePath);

                return new FileUploadResponseModel()
                {
                    Id = file.Id,
                    FileName = file.FilePath.Split('\\').Last(),
                    FileType = file.FileType,
                    FileData = fileBytes,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<FileInfoResModel> GetByUniqueId(Guid fileId)
        {
            try
            {
                var item = _appDbContext.FileUpload.Where(record => record.FileName == fileId).FirstOrDefault();

                if (item == null || !File.Exists(item.FilePath))
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.FILE_NOT_FOUND, fileId));
                }

                var fileContent = await File.ReadAllBytesAsync(item.FilePath);
                return new FileInfoResModel
                {
                    Id = item.Id,
                    FileData = fileContent,
                    FileType = item.FileType,
                    FileName = item.FilePath.Split('\\').Last(),
                    OriginalFileName = item.OriginName,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<Byte[]> GetFileByteArray(long id)
        {
            try
            {
                var file = await GetById(id);
                return file.FileData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void DeleteFile(long id)
        {
            var fileEntity = _appDbContext.FileUpload.FirstOrDefault(x => x.Id == id);
            if (fileEntity == null) return; // file khong ton tai => khong can xoa

            // Xoa file vat ly
            var file = new FileInfo(fileEntity.FilePath);
            if (file.Exists)
            {
                File.Delete(fileEntity.FilePath);
            }

            // Xoa ban ghi enity
            _appDbContext.FileUpload.Remove(fileEntity);
            _appDbContext.SaveChanges();
        }

        private string GetFullPathFolder(Enums.FolderChild folderChild)
        {
            int year = DateTime.Now.Year;
            string pathFolder = Path.GetFullPath(_configuration[Constants.FileConstans.STORED_FILES_PATH]);

            return Path.Combine(
                pathFolder,
                Enum.GetName(folderChild)
            );
        }

        private async Task WriteFileToDisk(string pathFolder, string pathFile, IFormFile formFile)
        {
            if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);

            using var memoryStream = new MemoryStream();

            await formFile.CopyToAsync(memoryStream);

            var fileData = memoryStream.ToArray();
            await File.WriteAllBytesAsync(pathFile, fileData);
        }

        private T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description) return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description) return (T)field.GetValue(null);
                }
            }

            throw new NotFoundException(nameof(description));
        }
    }
}
using NS.Core.Commons;

namespace NS.Core.Models.ResponseModels.FileUpload
{
    public class FileUploadResponseModel
    {
        public long Id { get; set; }
        public string FileName { get; set; } // Guid + File Ext
        public Enums.FileType FileType { get; set; }
        public Byte[] FileData { get; set; }
        public string LinkAnh { get; set; }

    }
}

using NS.Core.Models.ResponseModels.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class FileInfoResModel : FileUploadResponseModel
    {
        public string OriginalFileName { get; set; }
    }
}

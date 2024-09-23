using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.Entities
{
    public class FileUpload
    {
        public long Id { get; set; }
        public Guid FileName { get; set; }
        public string OriginName { get; set; }
        public Enums.FileType FileType { get; set; }
        public string FilePath { get; set; }
        
        public string LinkFile { get; set; }

    }
}

using NS.Core.Models.ResponseModels.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.MediaService
{
    public interface IMediaService
    {
        Task<MediaResponseModel> GetById(long id);
        Task<List<MediaResponseModel>> GetAll();
    }
}

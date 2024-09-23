using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.MediaService
{
    public class MediaService : IMediaService
    {
        private readonly AppDbContext _context;
        public MediaService (AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<MediaResponseModel>> GetAll()
        {
            List<MediaResponseModel> lstMediaResponseModel = _context.Media
                .Select(x => new MediaResponseModel
                {
                    Id = x.Id,
                    CoSoVatChatId = x.CoSoVatChatId,
                    ContentLink = x.ContentLink,
                    ContentType = x.ContentType,
                    HienThi = x.HienThi
                }).ToList();
            return lstMediaResponseModel;
        }

        public async Task<MediaResponseModel> GetById(long id)
        {
            Media media = _context.Media.GetById(id);
            MediaResponseModel model = new MediaResponseModel
            {
                Id = media.Id,
                CoSoVatChatId = media.CoSoVatChatId,
                ContentLink = media.ContentLink,
                ContentType = media.ContentType,
                HienThi = media.HienThi
            };
            return model;
        }
    }
}

using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels.CoSoVatChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.CoSoVatChatService
{
    public class CoSoVatChatService : ICoSoVatChatService
    {
        private readonly AppDbContext _context;
        public CoSoVatChatService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CoSoVatChatResponseModel>> GetAll()
        {
            List<CoSoVatChatResponseModel> lstCoSoVatChatResponseModel = _context.CoSoVatChat
                .Select(x => new CoSoVatChatResponseModel
                {
                    Id = x.Id,
                    TenDiaDiem = x.TenDiaDiem,
                    TenDiaDiemTiengAnh = x.TenDiaDiemTiengAnh,
                    HienThi = x.HienThi
                }).ToList();
            return lstCoSoVatChatResponseModel;
        }
        public async Task<List<CoSoVatChatCMSResponseModel>> GetAllLandingPage()
        {
            var lstCoSoVatChatResponseModel = _context.CoSoVatChat
                .Where(x => x.HienThi && !x.IsDeleted)
                .Select(x => new CoSoVatChatCMSResponseModel
                {
                    Id = x.Id,
                    TenDiaDiem = x.TenDiaDiem,
                    TenDiaDiemTiengAnh = x.TenDiaDiemTiengAnh,
                    ChiTietCoSoVatChat = x.ChiTietCoSoVatChat.Where(c => c.HienThi).Select(c => new ChiTietCoSoVatChatCMSResponseModel
                    {
                        Id = c.Id,
                        LoaiMedia = c.LoaiMedia,
                        LinkAnh = c.LinkAnh
                    }).ToList()
                }).ToList();
            return lstCoSoVatChatResponseModel;
        }

        public async Task<CoSoVatChatResponseModel> GetById(long id)
        {
            CoSoVatChat coSoVatChat = _context.CoSoVatChat.GetById(id);
            return new CoSoVatChatResponseModel
            {
                Id = coSoVatChat.Id,
                TenDiaDiem = coSoVatChat.TenDiaDiem,
                TenDiaDiemTiengAnh = coSoVatChat.TenDiaDiemTiengAnh,
                HienThi = coSoVatChat.HienThi
            };
        }
    }
}

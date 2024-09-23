using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels.CoSoVatChat;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.RequestModels.CoSoVatChatCMSRequestModel;
using Microsoft.AspNetCore.Http;

namespace NS.Core.Business.CoSoVatChatCMSService
{
    public interface ICoSoVatChatCMSService
    {
        Task<BasePaginationResponseModel<CoSoVatChatCMSResponseModel>> GetPageCoSoVatChat(BasePaginationRequestModel input, Enums.DanhSachTrangTinh trangId);
        Task<BasePaginationResponseModel<ChiTietCoSoVatChatCMSResponseModel>> GetPageChiTietCoSo(GetPageChiTietCoSoVatChatRequestModel input, long coSoVatChatId);
        Task CreateCoSoVatChat(DiaDiemRequestModel input);
        Task CreateMedia(CreateMediaRequestModel input ,IFormFileCollection files);
        Task UpdateCoSoVatChat(DiaDiemRequestModel input, long Id);
        Task UpdateMedia(UpdateMediaRequestModel input ,IFormFileCollection files);
        Task RemoveCoSoVatChat(long Id);
        Task RemoveMedia(long chiTietCoSoVatChatId);
        Task UpdateTrangThaiForOneCoSoVatChat(DiaDiemRequestModel input);
        Task UpdateTrangThaiForOneChiTiet(UpdateMediaRequestModel input);
        Task<CoSoVatChatResponseModel> GetCoSoVatChat(long Id);
        Task<MediaResponseModel> GetMediaById(long id);
    }
}

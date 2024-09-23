using NS.Core.Models;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels.CMSLandingPage;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.ResponseModels.CoSoVatChat;
using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;
using NS.Core.Models.RequestModels.CoSoVatChatCMSRequestModel;
using NS.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static NS.Core.Commons.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using NS.Core.Business.FileService;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons.CustomException;

namespace NS.Core.Business.CoSoVatChatCMSService
{
    public class CoSoVatChatCMSService : ICoSoVatChatCMSService

    {
        private readonly AppDbContext _dbContext;
        private readonly IFile _fileService;
        private readonly IConfiguration _configuration;

        public CoSoVatChatCMSService(AppDbContext dbContext, IFile fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<MediaResponseModel> GetMediaById(long id)
        {
            var query = _dbContext.ChiTietCoSoVatChat
                .Where(e => e.Id == id)
                .Select(e=>MediaResponseModel.Mapping(e))
                ;
            if (query.IsNullOrEmpty()) throw new InvalidException(nameof(ChiTietCoSoVatChat.Id));
            return await query.FirstAsync();
        }

        public async Task<BasePaginationResponseModel<CoSoVatChatCMSResponseModel>> GetPageCoSoVatChat(
            BasePaginationRequestModel input, Enums.DanhSachTrangTinh trangId)
        {
            var query = GetCoSoVatChatPrivate(trangId);

            ApplySearch(ref query, input);

            query = query.OrderByDescending(e => e.Id);

            var totalItem = 0;

            if (input.PageNo.Equals(0)) input.PageNo = 1;

            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);

            List<CoSoVatChatCMSResponseModel> res = query.ToList();

            return await Task.FromResult(
                new BasePaginationResponseModel<CoSoVatChatCMSResponseModel>(input.PageNo, input.PageSize, res,
                    totalItem));
        }

        public async Task CreateCoSoVatChat(DiaDiemRequestModel input)
        {
            try
            {
                var res = new CoSoVatChat
                {
                    TenDiaDiem = input.TenDiaDiem,
                    TenDiaDiemTiengAnh = input.TenDiaDiemTiengAnh,
                    HienThi = input.HienThi,
                };
                _dbContext.CoSoVatChat.Add(res);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task UpdateCoSoVatChat(DiaDiemRequestModel input, long Id)
        {
            try
            {
                var coSoVatChatDb = await _dbContext.CoSoVatChat
                    .Where(x => x.Id.Equals(Id))
                    .FirstOrDefaultAsync();

                if (coSoVatChatDb == null) throw new NotFoundException(nameof(Id));

                MappingCoSoVatChat(input, Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task UpdateTrangThaiForOneCoSoVatChat(DiaDiemRequestModel input)
        {
            try
            {
                var res = await _dbContext.CoSoVatChat
                    .Where(x => x.Id == input.Id)
                    .FirstOrDefaultAsync();

                if (res == null) throw new NotFoundException(input.TenDiaDiem);

                res.HienThi = input.HienThi;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task RemoveCoSoVatChat(long Id)
        {
            try
            {
                var coSoVatChatDb = await _dbContext.CoSoVatChat.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
                var chiTietOfCoSo = await _dbContext.ChiTietCoSoVatChat
                    .Where(x => x.CoSoVatChatId.Equals(Id))
                    .ToListAsync();

                var mediaIdList = chiTietOfCoSo
                    .Select(x => x.FileId)
                    .ToList();

                var mediaOfChiTiet = await _dbContext.FileUpload
                    .Where(x => mediaIdList.Contains(x.Id))
                    .ToListAsync();

                if (coSoVatChatDb == null)
                    throw new NotFoundException(nameof(Id));

                _dbContext.Remove(coSoVatChatDb);
                _dbContext.RemoveRange(chiTietOfCoSo);
                _dbContext.RemoveRange(mediaOfChiTiet);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<CoSoVatChatResponseModel> GetCoSoVatChat(long Id)
        {
            try
            {
                var coSoVatChatDb = await _dbContext.CoSoVatChat
                    .Where(x => x.Id.Equals(Id))
                    .FirstOrDefaultAsync();

                if (coSoVatChatDb == null) throw new NotFoundException(nameof(Id));

                var res = new CoSoVatChatResponseModel
                {
                    TenDiaDiem = coSoVatChatDb.TenDiaDiem,
                    TenDiaDiemTiengAnh = coSoVatChatDb.TenDiaDiemTiengAnh,
                    HienThi = coSoVatChatDb.HienThi
                };
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public async Task<BasePaginationResponseModel<ChiTietCoSoVatChatCMSResponseModel>> GetPageChiTietCoSo(
            GetPageChiTietCoSoVatChatRequestModel input, long coSoVatChatId)
        {
            var query = GetChiTietPrivate(coSoVatChatId);

            ApplyFilter(ref query, input);

            query = query
                .OrderBy(e=>e.ThuTu)
                .ThenByDescending(x => x.Id);

            var totalItem = 0;
            if (input.PageNo.Equals(0)) input.PageNo = 1;

            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);

            List<ChiTietCoSoVatChatCMSResponseModel> returnHoSoThi = query.ToList();

            return await Task.FromResult(
                new BasePaginationResponseModel<ChiTietCoSoVatChatCMSResponseModel>(input.PageNo, input.PageSize,
                    returnHoSoThi, totalItem));
        }

        public async Task CreateMedia(CreateMediaRequestModel input,
            IFormFileCollection files)
        {
            try
            {
                var query = _dbContext.CoSoVatChat.Where(x => x.Id == input.CoSoVatChatId);
                if (query.IsNullOrEmpty()) throw new NotFoundException(nameof(CoSoVatChat.Id));

                if (files?.Count > 0 && (input.LoaiMedia == LoaiMedia.Anh || input.LoaiMedia == LoaiMedia.Anh360))
                {
                    foreach (var file in files)
                    {
                        var fileUpload = await _fileService.UploadFile(file, FolderChild.CoSoVatChat);
                        _dbContext.ChiTietCoSoVatChat
                            .Add(CreateMediaRequestModel.MappingImage(input, fileUpload));
                    }
                }

                else if (input.LinkAnh.Any() && input.LoaiMedia == LoaiMedia.Video)
                    _dbContext.ChiTietCoSoVatChat
                        .Add(CreateMediaRequestModel.MappingVideo(input));

                else throw new InvalidException(nameof(CreateMediaRequestModel.LinkAnh));

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdateMedia(UpdateMediaRequestModel model,IFormFileCollection files)
        {
            try
            {
                var media = await _dbContext.ChiTietCoSoVatChat
                    .Where(e => e.Id == model.Id)
                    .FirstOrDefaultAsync();

                if (media == null) throw new NotFoundException(nameof(CoSoVatChat.Id));

                if (files.Count > 0)
                {
                    var fileUpload = await _fileService.UploadFile(files[0], Enums.FolderChild.CoSoVatChat);
                    _fileService.DeleteFile(media.FileId??0);
                    model.UpdateImage( ref media, fileUpload);
                }
                else if (model.LinkAnh.Any())
                {
                    model.UpdateVideo(ref media);
                }

                _dbContext.ChiTietCoSoVatChat.Update(media);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task UpdateTrangThaiForOneChiTiet(UpdateMediaRequestModel input)
        {
            try
            {
                var res = await _dbContext.ChiTietCoSoVatChat
                    .Where(x => x.Id == input.Id)
                    .FirstOrDefaultAsync();
                
                if (res != null)
                    res.HienThi = input.HienThi;
                
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task RemoveMedia(long chiTietCoSoVatChatId)
        {
            try
            {
                var chiTietCoSo = await _dbContext.ChiTietCoSoVatChat
                    .Where(x => x.Id.Equals(chiTietCoSoVatChatId))
                    .FirstOrDefaultAsync();

                if (chiTietCoSo == null) throw new NotFoundException(nameof(chiTietCoSo));

                if (chiTietCoSo.FileId > 0)
                {
                    var fileId = chiTietCoSo.FileId;

                    var fileOfThisChiTiet =
                        await _dbContext.FileUpload
                            .Where(x => x.Id.Equals(fileId))
                            .FirstOrDefaultAsync();

                    _dbContext.Remove(fileOfThisChiTiet);
                }

                _dbContext.Remove(chiTietCoSo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private Enums.LoaiMedia MediaCheck(long mediaId)
        {
            if (mediaId > 0)
            {
                List<string> ImageExtensions = new List<string>
                    { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG", ".WEBP" };
                var mediaDB = _dbContext.FileUpload
                    .Where(x => x.Id == mediaId).Select(x => x.OriginName)
                    .FirstOrDefault();

                if (ImageExtensions.Contains(Path.GetExtension(mediaDB).ToUpperInvariant()))
                {
                    return LoaiMedia.Anh;
                }
            }

            return LoaiMedia.Video;
        }

        private IQueryable<CoSoVatChatCMSResponseModel> GetCoSoVatChatPrivate(Enums.DanhSachTrangTinh trangId)
        {
            if (trangId != Enums.DanhSachTrangTinh.CoSoVatChat)
            {
                throw new NotFoundException(nameof(trangId));
            }

            var res = _dbContext.CoSoVatChat.Select(x => new CoSoVatChatCMSResponseModel
            {
                Id = x.Id,
                TenDiaDiem = x.TenDiaDiem,
                TenDiaDiemTiengAnh = x.TenDiaDiemTiengAnh,
                HienThi = x.HienThi,
                ChiTietCoSoVatChat = new List<ChiTietCoSoVatChatCMSResponseModel>()
            }).AsQueryable();
            return res;
        }

        private IQueryable<ChiTietCoSoVatChatCMSResponseModel> GetChiTietPrivate(long Id)
        {
            var chiTietDb = _dbContext.ChiTietCoSoVatChat.Where(x => x.CoSoVatChatId.Equals(Id)).ToList();
            if (chiTietDb == null)
                throw new NotFoundException(nameof(Id));
            var res = chiTietDb.Select(x => new ChiTietCoSoVatChatCMSResponseModel
            {
                Id = x.Id,
                CoSoVatChatId = x.CoSoVatChatId,
                HienThi = x.HienThi,
                FileId = x.FileId,
                LinkAnh = x.LinkAnh,
                LoaiMedia = x.LoaiMedia,
                ThuTu = x.ThuTu,
            }).AsQueryable();
            return res;
        }

        private void ApplySearch(ref IQueryable<CoSoVatChatCMSResponseModel> query, BasePaginationRequestModel input)
        {
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query
                        .Where(record =>
                            EF.Functions
                                .Collate(record.TenDiaDiem, "SQL_Latin1_General_CP1_CI_AI")
                                .Contains(input.Keyword)
                            || EF.Functions
                                .Collate(record.TenDiaDiemTiengAnh, "SQL_Latin1_General_CP1_CI_AI")
                                .Contains(input.Keyword))
                    ;
            }
        }

        private void ApplyFilter(ref IQueryable<ChiTietCoSoVatChatCMSResponseModel> query,
            GetPageChiTietCoSoVatChatRequestModel input)
        {
            if (input.LoaiMedia != null)
            {
                query = query.Where(record => record.LoaiMedia == input.LoaiMedia);
            }
        }

        private void MappingCoSoVatChat(DiaDiemRequestModel input, long Id)
        {
            var coSoVatChatDb = _dbContext.CoSoVatChat.Where(x => x.Id.Equals(Id)).FirstOrDefault();
            coSoVatChatDb.TenDiaDiem = input.TenDiaDiem;
            coSoVatChatDb.TenDiaDiemTiengAnh = input.TenDiaDiemTiengAnh;
            coSoVatChatDb.HienThi = input.HienThi;

            _dbContext.CoSoVatChat.Update(coSoVatChatDb);
            _dbContext.SaveChanges();
        }
    }
}
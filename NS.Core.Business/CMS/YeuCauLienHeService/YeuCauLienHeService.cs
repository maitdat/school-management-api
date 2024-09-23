using NS.Core.Business.MailService;
using NS.Core.Models;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static NS.Core.Commons.Constants;

namespace NS.Core.Business.YeuCauLienHeService
{
    public class YeuCauLienHeService : IYeuCauLienHeService
    {
        private readonly AppDbContext _context;
        private readonly IMailService _mailService;
        public YeuCauLienHeService(AppDbContext dbContext, IMailService mailService)
        {
            _context = dbContext;
            _mailService = mailService;
        }
        public async Task<List<YeuCauLienHeResponseModel>> GetAll()
        {
            return _context.YeuCauLienHe
                .Include(boPhanLienHe => boPhanLienHe.BoPhanLienHe)
                .Select(yeuCauLienHe => new YeuCauLienHeResponseModel
            {
                Id = yeuCauLienHe.Id,
                HoTen = yeuCauLienHe.HoTen,
                Email = yeuCauLienHe.Email,
                SoDienThoai = yeuCauLienHe.SoDienThoai,
                BoPhanLienHeId = yeuCauLienHe.BoPhanLienHeId,
                TenBoPhanLienHe = yeuCauLienHe.BoPhanLienHe.TenBoPhan,
                DaPhanHoi = yeuCauLienHe.DaPhanHoi,
                NoiDungLienHe = yeuCauLienHe.NoiDungLienHe,
                NgayTao = yeuCauLienHe.NgayTao
            }).ToList();
        }

        public async Task<BasePaginationResponseModel<YeuCauLienHeResponseModel>> GetPagedYeuCauLienHe(GetPagedYeuCauLienHeRequestModel input)
        {
            var query = GetAllAvailableForPagination();
            query = ApplySearchAndFilter(query, input);
            var totalItems = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItems);
            List<YeuCauLienHeResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<YeuCauLienHeResponseModel>(input.PageNo, input.PageSize, result, totalItems);
        }

        private IQueryable<YeuCauLienHeResponseModel> ApplySearchAndFilter(IQueryable<YeuCauLienHeResponseModel> query, GetPagedYeuCauLienHeRequestModel input)
        {
            // apply search
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(record => record.HoTen.ToLower().Contains(keyword)
                || record.Email.ToLower().Contains(keyword)
                || record.SoDienThoai.ToLower().Contains(keyword));
            }

            //apply filter
            if (input.BoPhanLienHeId.HasValue)
            {
                query = query.Where(record => record.BoPhanLienHeId == input.BoPhanLienHeId);
            }
            if (input.DaPhanHoi != null)
            {
                query = query.Where(record => record.DaPhanHoi == input.DaPhanHoi);
            }
            if (input.StartDate.HasValue)
            {
                query = query.Where(record => record.NgayTao >= input.StartDate.Value);
            }
            if (input.EndDate.HasValue)
            {
                query = query.Where(record => record.NgayTao <= input.EndDate.Value);
            }
            query = query.OrderByDescending(record => record.NgayTao);
            return query;
        }

        private IQueryable<YeuCauLienHeResponseModel> GetAllAvailableForPagination()
        {
            var result = _context.YeuCauLienHe
                .Where(x => !x.IsDeleted)
                .Include(boPhanLienHe => boPhanLienHe.BoPhanLienHe)
                .Select(x => new YeuCauLienHeResponseModel
            {
                Id = x.Id,
                HoTen = x.HoTen,
                Email = x.Email,
                SoDienThoai = x.SoDienThoai,
                BoPhanLienHeId = x.BoPhanLienHeId,
                TenBoPhanLienHe = x.BoPhanLienHe.TenBoPhan,
                NoiDungLienHe = x.NoiDungLienHe,
                DaPhanHoi = x.DaPhanHoi,
                NgayTao = x.NgayTao
                
            });
            return result;
        }

        public async Task<List<YeuCauLienHeResponseModel>> GetAllAvailable()
        {
            return _context.YeuCauLienHe
                .Where(yeuCauLienHe => yeuCauLienHe.IsDeleted == false)
                .Include(boPhanLienHe => boPhanLienHe.BoPhanLienHe)
                .Select(yeuCauLienHe => new YeuCauLienHeResponseModel
            {
                Id = yeuCauLienHe.Id,
                HoTen = yeuCauLienHe.HoTen,
                Email = yeuCauLienHe.Email,
                SoDienThoai = yeuCauLienHe.SoDienThoai,
                BoPhanLienHeId = yeuCauLienHe.BoPhanLienHeId,
                TenBoPhanLienHe = yeuCauLienHe.BoPhanLienHe.TenBoPhan,
                DaPhanHoi = yeuCauLienHe.DaPhanHoi,
                NoiDungLienHe = yeuCauLienHe.NoiDungLienHe,
                NgayTao = yeuCauLienHe.NgayTao
            }).ToList();
        }

        public async Task ChangeRespondedStatus(long id)
        {
            YeuCauLienHe yeuCauLienHe = _context.YeuCauLienHe.GetAvailableById(id);
            yeuCauLienHe.DaPhanHoi = !yeuCauLienHe.DaPhanHoi;
            _context.Update(yeuCauLienHe);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            _context.YeuCauLienHe.Delete(id);
            await _context.SaveChangesAsync();
        }

        public async Task<YeuCauLienHeResponseModel> YeuCauLienHeDetail(long id)
        {
            //YeuCauLienHe yeuCauLienHe = _context.YeuCauLienHe.GetById(id);
            YeuCauLienHe yeuCauLienHe = _context.YeuCauLienHe
                .Include(x => x.BoPhanLienHe)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (yeuCauLienHe == null)
            {
                throw new Exception(ExceptionMessage.ITEM_NOT_FOUND);
            }
            YeuCauLienHeResponseModel yeuCauLienHeResponseModel = new YeuCauLienHeResponseModel
            {
                Id = yeuCauLienHe.Id,
                HoTen = yeuCauLienHe.HoTen,
                Email = yeuCauLienHe.Email,
                SoDienThoai = yeuCauLienHe.SoDienThoai,
                BoPhanLienHeId = yeuCauLienHe.BoPhanLienHeId,
                TenBoPhanLienHe = yeuCauLienHe.BoPhanLienHe.TenBoPhan,
                DaPhanHoi = yeuCauLienHe.DaPhanHoi,
                NoiDungLienHe = yeuCauLienHe.NoiDungLienHe,
                NgayTao = yeuCauLienHe.NgayTao
            };
            return yeuCauLienHeResponseModel;
        }

        public async Task<YeuCauLienHeResponseModel> GetById(long id)
        {
            //YeuCauLienHe yeuCauLienHe = _context.YeuCauLienHe.GetById(id);
            YeuCauLienHe yeuCauLienHe = _context.YeuCauLienHe
                .Include(x => x.BoPhanLienHe)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (yeuCauLienHe == null)
            {
                throw new Exception(ExceptionMessage.ITEM_NOT_FOUND);
            }
            YeuCauLienHeResponseModel result = new YeuCauLienHeResponseModel
            {
                Id = yeuCauLienHe.Id,
                HoTen = yeuCauLienHe.HoTen,
                Email = yeuCauLienHe.Email,
                SoDienThoai = yeuCauLienHe.SoDienThoai,
                BoPhanLienHeId = yeuCauLienHe.BoPhanLienHeId,
                TenBoPhanLienHe = yeuCauLienHe.BoPhanLienHe.TenBoPhan,
                DaPhanHoi = yeuCauLienHe.DaPhanHoi,
                NoiDungLienHe = yeuCauLienHe.NoiDungLienHe,
                NgayTao = yeuCauLienHe.NgayTao
            };
            return result;
        }

        public async Task Create(YeuCauLienHeRequestModel yeuCauLienHeRequestModel)
        {
            YeuCauLienHe yeuCauLienHe = new YeuCauLienHe
            {
                HoTen = yeuCauLienHeRequestModel.HoTen,
                SoDienThoai = yeuCauLienHeRequestModel.SoDienThoai,
                Email = yeuCauLienHeRequestModel.Email,
                BoPhanLienHeId = yeuCauLienHeRequestModel.BoPhanLienHeId,
                NoiDungLienHe = yeuCauLienHeRequestModel.NoiDungLienHe,
                NgayTao = DateTime.Now,
            };
            _context.YeuCauLienHe.Add(yeuCauLienHe);
            await _context.SaveChangesAsync();
            await SendMailToBoPhan(yeuCauLienHe);

        }

        public async Task SendMailToBoPhan(YeuCauLienHe yeuCauLienHe)
        {
            var boPhanLienHe = await _context.BoPhanLienHe
                .Where(e => e.Id == yeuCauLienHe.BoPhanLienHeId)
                .FirstOrDefaultAsync();
            
            var caiDatEmailToSendMail = new CaiDatEmail
            {
                TieuDe = string.Format(MailMessage.TIEU_DE_MAIL_YEU_CAU_LIEN_HE,yeuCauLienHe.Id,yeuCauLienHe.BoPhanLienHe.TenBoPhan),
                NoiDung = String.Format(
                    MailMessage.NOI_DUNG_MAIL_YEU_CAU_LIEN_HE,
                    boPhanLienHe.TenBoPhan,
                    yeuCauLienHe.Id,
                    yeuCauLienHe.HoTen,
                    yeuCauLienHe.SoDienThoai,
                    yeuCauLienHe.Email,
                    yeuCauLienHe.NoiDungLienHe)
            };
            
            await _mailService.SendEmailAsync(boPhanLienHe.Email, caiDatEmailToSendMail);
        }
    }
}

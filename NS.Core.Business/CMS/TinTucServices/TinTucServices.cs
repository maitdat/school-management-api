using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.TinTucRequest;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Business.FileService;
using NS.Core.Commons.CustomException;
using NS.Core.Models.ResponseModels.FileUpload;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.TinTucServices
{
    public class TinTucServices : ITinTucServices
    {
        private readonly AppDbContext _context;
        private readonly IFile _fileService;

        public TinTucServices(AppDbContext dbContext, IFile fileService)
        {
            _context = dbContext;
            _fileService = fileService;
        }

        public async Task<BasePaginationResponseModel<TinTucResponseModel>> GetPagedTinTuc(
            GetPagedTinTucRequestModel input)
        {
            var query = GetAllAvailable().Where(x => x.LaTinTuc == true);
            
            query = ApplySearchAndFilter(query, input);
            query = query.OrderByDescending(e => e.NgayCapNhat); //
            
            var totalItem = 0;
            
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);
            List<TinTucResponseModel> result = query.ToList();
            
            return new BasePaginationResponseModel<TinTucResponseModel>(input.PageNo, input.PageSize, result,
                totalItem);
        }

        public async Task<BasePaginationResponseModel<TinTucResponseModel>> GetPagedTinTruyenThong(
            GetPagedTinTucRequestModel input)
        {
            var query = _context.TinTuc
                .Where(record =>
                    !record.IsDeleted && !record.LaTinTuc && record.LoaiBaiViet == LoaiBaiViet.GocTruyenThong &&
                    !record.LaTinNoiBat)
                .Select(x => new TinTucResponseModel
                {
                    Id = x.Id,
                    TieuDe = x.TieuDe,
                    NoiDungTomTat = x.NoiDungTomTat,
                    AnhDaiDien = x.AnhDaiDien,
                    ChuyenMucId = x.ChuyenMucId,
                    NgayDang = x.NgayDang,
                    NoiDungChiTiet = x.NoiDungChiTiet,
                    NoiDungChiTietEngLish = x.NoiDungChiTietEnglish,
                    TacGia = x.TacGia,
                    TenChuyenMuc = x.ChuyenMuc.TenChuyenMuc,
                    TieuDeEngLish = x.TieuDeEnglish,
                    TrangThai = x.TrangThai,
                    TenChuyenMucEngLish = x.ChuyenMuc.TenChuyenMucEnglish,
                    IsDeleted = x.IsDeleted,
                    LaTinNoiBat = x.LaTinNoiBat,
                    LaTinTuc = x.LaTinTuc,
                    IsActive = x.IsActive,
                });
            var totalItem = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);
            List<TinTucResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<TinTucResponseModel>(input.PageNo, input.PageSize, result,
                totalItem);
        }

        private IQueryable<TinTucResponseModel> ApplySearchAndFilter(IQueryable<TinTucResponseModel> query,
            GetPagedTinTucRequestModel input)
        {
            // apply search
            var keyword = input.Keyword.ToLower().Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(record =>
                    record.TieuDe.ToLower().Contains(keyword)
                    || record.TacGia.ToLower().Contains(keyword)
                    || record.NoiDungTomTat.ToLower().Contains(keyword));
            }

            // apply filter
            if (input.ChuyenMucId.HasValue)
            {
                query = query.Where(record => record.ChuyenMucId == input.ChuyenMucId.Value);
            }

            if (input.LaTinNoiBat != null)
            {
                query = query.Where(record => record.LaTinNoiBat == input.LaTinNoiBat);
            }

            if (input.TrangThai.HasValue)
            {
                query = query.Where(record => record.TrangThai == input.TrangThai.Value);
            }

            if (!string.IsNullOrEmpty(input.TenChuyenMuc))
            {
                query = query.Where(record => record.TenChuyenMuc.ToLower().Contains(input.TenChuyenMuc.ToLower()));
            }

            if (!string.IsNullOrEmpty(input.TacGia))
            {
                query = query.Where(record => record.TacGia.ToLower().Contains(input.TacGia.ToLower()));
            }

            if (input.StartDate.HasValue)
            {
                query = query.Where(record => record.NgayDang >= input.StartDate.Value);
            }

            if (input.EndDate.HasValue)
            {
                query = query.Where(record => record.NgayDang <= input.EndDate.Value);
            }

            return query;
        }

        private bool NameIsValid(string tieuDe)
        {
            return !_context.TinTuc.Where(record => record.TieuDe.ToLower() == tieuDe.ToLower()).Any();
        }

        public async Task<TinTucResponseModel> GetTinTucById(string id)
        {
            try
            {
                long tinTucId = 0;
                if (!long.TryParse(id, out tinTucId))
                {
                    tinTucId = _context.MenuConfig
                        .Where(record => record.TinTucId.HasValue
                                         && !string.IsNullOrEmpty(record.Url)
                                         && record.Url.IndexOf(id) > 1)
                        .Select(record => record.TinTucId.Value)
                        .FirstOrDefault();
                }

                var tinTuc = await _context.TinTuc.Select(x => new TinTucResponseModel
                {
                    Id = x.Id,
                    TieuDe = x.TieuDe,
                    NoiDungTomTat = x.NoiDungTomTat,
                    AnhDaiDien = x.AnhDaiDien,
                    ChuyenMucId = x.ChuyenMucId,
                    NgayDang = x.NgayDang,
                    NoiDungChiTiet = x.NoiDungChiTiet,
                    NoiDungChiTietEngLish = x.NoiDungChiTietEnglish,
                    TacGia = x.TacGia,
                    TenChuyenMuc = x.ChuyenMuc.TenChuyenMuc,
                    TieuDeEngLish = x.TieuDeEnglish,
                    TrangThai = x.TrangThai,
                    TenChuyenMucEngLish = x.ChuyenMuc.TenChuyenMucEnglish,
                    IsDeleted = x.IsDeleted,
                    LaTinNoiBat = x.LaTinNoiBat,
                    LaTinTuc = x.LaTinTuc,
                    IsActive = x.IsActive,
                }).Where(x => x.Id == tinTucId && !x.IsDeleted).FirstOrDefaultAsync();
                if (tinTuc == null)
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(KyTuyenSinh.Id)));
                }

                return tinTuc;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(KyTuyenSinh.Id)));
            }
        }

        public async Task DeleteTinTuc(long id)
        {
            _context.TinTuc.Delete(id);
            await _context.SaveChangesAsync();
        }

        private IQueryable<TinTucResponseModel> GetAllAvailable()
        {
            var result = _context.TinTuc
                .Where(record => !record.IsDeleted)
                .Select(x => new TinTucResponseModel
                {
                    Id = x.Id,
                    TieuDe = x.TieuDe,
                    NoiDungTomTat = x.NoiDungTomTat,
                    AnhDaiDien = x.AnhDaiDien,
                    ChuyenMucId = x.ChuyenMucId,
                    NgayDang = x.NgayDang,
                    NoiDungChiTiet = x.NoiDungChiTiet,
                    NoiDungChiTietEngLish = x.NoiDungChiTietEnglish,
                    TacGia = x.TacGia,
                    TenChuyenMuc = x.ChuyenMuc.TenChuyenMuc,
                    TieuDeEngLish = x.TieuDeEnglish,
                    TrangThai = x.TrangThai,
                    TenChuyenMucEngLish = x.ChuyenMuc.TenChuyenMucEnglish,
                    IsDeleted = x.IsDeleted,
                    LaTinNoiBat = x.LaTinNoiBat,
                    LaTinTuc = x.LaTinTuc,
                    IsActive = x.IsActive,
                    NgayCapNhat = x.NgayCapNhat
                }).Where(x => !x.IsDeleted);
            return result;
        }

        public async Task PheDuyetTinTuc(long id, TrangThaiTinTuc trangThai)
        {
            TinTuc duyetTinTuc = _context.TinTuc.GetAvailableById(id);
            duyetTinTuc.TrangThai = trangThai;
            _context.TinTuc.Update(duyetTinTuc);
            await _context.SaveChangesAsync();
        }

        public async Task ShowHideTinTuc(long id)
        {
            TinTuc duyetTinTuc = _context.TinTuc.GetById(id);
            duyetTinTuc.IsActive = !duyetTinTuc.IsActive;
            _context.TinTuc.Update(duyetTinTuc);
            await _context.SaveChangesAsync();
        }

        public List<TinTucResponseModel> GetAllTinTucNoiBat()
        {
            var result = GetAllAvailable().Where(x => x.LaTinTuc == true && x.LaTinNoiBat == true && x.IsActive == true)
                .ToList();
            return result;
        }

        public async Task CreateTinTuc(AddTinTucRequestModel data, string url)
        {
            try
            {
                if (NameIsValid(data.TieuDe))
                {
                    var newBaiViet = new TinTuc()
                    {
                        AnhDaiDien = url,
                        NgayDang = data.NgayDang,
                        TieuDe = data.TieuDe,
                        NoiDungChiTiet = data.NoiDungChiTiet,
                        NoiDungTomTat = data.NoiDungTomTat,
                        ChuyenMucId = data.ChuyenMucId,
                        NgayCapNhat = DateTime.Today,
                        NgayTao = DateTime.Today,
                        LaTinNoiBat = data.LaTinNoiBat,
                        LoaiBaiViet = LoaiBaiViet.None,
                        LaTinTuc = true,
                        IsActive = true,
                    };
                    _context.TinTuc.Add(newBaiViet);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(data.TieuDe)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateTinTuc(UpdateTinTucRequestModel data, string url)
        {
            try
            {
                TinTuc tinTucToUpdate = _context.TinTuc.GetAvailableById(data.Id);
                tinTucToUpdate.AnhDaiDien = url == "" ? tinTucToUpdate.AnhDaiDien : url;
                tinTucToUpdate.TieuDe = data.TieuDe;
                tinTucToUpdate.NoiDungChiTiet = data.NoiDungChiTiet;
                tinTucToUpdate.NoiDungTomTat = data.NoiDungTomTat;
                tinTucToUpdate.ChuyenMucId = data.ChuyenMucId;
                tinTucToUpdate.NgayCapNhat = DateTime.Today;
                tinTucToUpdate.LaTinNoiBat = data.LaTinNoiBat;
                _context.Update(tinTucToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND));
            }
        }

        public async Task<BasePaginationResponseModel<TinTucResponseModel>> GetPagedTinTucActive(
            GetPagedTinTucRequestModel input)
        {
            var query = GetAllAvailable().Where(x => x.IsActive == true && x.LaTinTuc == true);
            query = ApplySearchAndFilter(query, input);
            var totalItem = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);
            List<TinTucResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<TinTucResponseModel>(input.PageNo, input.PageSize, result,
                totalItem);
        }

        public async Task<BasePaginationResponseModel<TinTucResponseModel>> GetPageBaiViet(
            GetPagedTinTucRequestModel input)
        {
            var query = GetAllAvailable().Where(x => x.LaTinTuc == false);
            query = ApplySearchAndFilter(query, input);
            var totalItem = 0;
            query = query.ApplyPaging(input.PageNo, input.PageSize, out totalItem);
            List<TinTucResponseModel> result = query.ToList();
            return new BasePaginationResponseModel<TinTucResponseModel>(input.PageNo, input.PageSize, result,
                totalItem);
        }

        public async Task CreateOrUpdateTinTuc(CreateOrUpdateTinTucRequestModel model)
        {
            try
            {
                FileUploadResponseModel fileUpload = new FileUploadResponseModel();
                TinTuc tinTuc = new TinTuc();

                var queryable = _context.ChuyenMuc.Where(e => e.Id == model.ChuyenMucId);
                if (queryable.IsNullOrEmpty()) throw new NotFoundException(nameof(model.ChuyenMucId));

                if (!(model.Id > 0 || model.File?.Length > 0)) throw new InvalidException(nameof(model.File));

                if (model.Id > 0)
                {
                    tinTuc = await _context.TinTuc.Where(e => e.Id == model.Id).FirstOrDefaultAsync();
                    if (tinTuc == null) throw new NotFoundException(nameof(TinTuc.Id));
                }

                if (model.File?.Length > 0) fileUpload = await _fileService.UploadFile(model.File, FolderChild.TinTuc);

                model.Update(ref tinTuc, fileUpload);

                _context.TinTuc.Update(tinTuc);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task CreateBaiViet(AddTinTucRequestModel data, string url)
        {
            try
            {
                if (NameIsValid(data.TieuDe))
                {
                    var newBaiViet = new TinTuc()
                    {
                        ChuyenMucId = null,
                        AnhDaiDien = url,
                        NgayDang = data.NgayDang,
                        TieuDe = data.TieuDe,
                        NoiDungChiTiet = data.NoiDungChiTiet,
                        NoiDungTomTat = data.NoiDungTomTat,
                        NgayCapNhat = DateTime.Today,
                        NgayTao = DateTime.Today,
                        LaTinNoiBat = false,
                        LoaiBaiViet = data.LoaiBaiViet,
                        LaTinTuc = false,
                        IsActive = true,
                    };
                    _context.TinTuc.Add(newBaiViet);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(data.TieuDe)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateBaiViet(UpdateTinTucRequestModel data, string url)
        {
            try
            {
                TinTuc tinTucToUpdate = _context.TinTuc.GetAvailableById(data.Id);
                tinTucToUpdate.AnhDaiDien = url == "" ? tinTucToUpdate.AnhDaiDien : url;
                tinTucToUpdate.TieuDe = data.TieuDe;
                tinTucToUpdate.ChuyenMucId = null;
                tinTucToUpdate.NoiDungChiTiet = data.NoiDungChiTiet;
                tinTucToUpdate.NoiDungTomTat = data.NoiDungTomTat;
                tinTucToUpdate.NgayCapNhat = DateTime.Today;
                tinTucToUpdate.LoaiBaiViet = data.LoaiBaiViet;
                _context.Update(tinTucToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND));
            }
        }
    }
}
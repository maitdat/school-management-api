using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.HocPhi;
using NS.Core.Models.RequestModels.HocPhiRequestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.HocPhiResponse;

namespace NS.Core.Business.HocPhiService
{
    public class HocPhiService : IHocPhiService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HocPhiService> _logger;

        public HocPhiService(AppDbContext appDbContext, ILogger<HocPhiService> logger)
        {
            _context = appDbContext;
            _logger = logger;
        }
        public NamHocPhiResModel GetByNamHocId(long namHocId)
        {
            try
            {
                var result = _context.NamHoc.GetAvailableByIdQueryable(namHocId)
                        .Select(record => new NamHocPhiResModel
                        {
                            NamHocId = namHocId,
                            NoiDung = record.NamHocPhi.NoiDung,
                            NoiDungTiengAnh = record.NamHocPhi.NoiDungTiengAnh,
                            TenNamHoc = record.NamHocPhi.NamHoc.TenNamHoc,
                            TuNam = record.TuNam,
                            DenNam = record.DenNam,
                            ListHocPhi = record.NamHocPhi.HocPhi.Where(x => !x.IsDeleted).Select(item => new ChiTietHocPhiResModel
                            {
                                Id = item.Id,
                                HeDaoTao = item.HeDaoTao.TenHeDaoTao,
                                HeDaoTaoId = item.HeDaoTaoId,
                                Lop = item.Lop,
                                TienHocPhi = item.TienHocPhi,
                            })
                            .ToList(),
                        })
                        .FirstOrDefault();
                if (result is null) throw new Exception(Constants.ExceptionMessage.NOT_FOUND);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetByNamHocId));
                throw;
            }
        }
        public void CreateOrUpdateHocPhiByNamHocId(NamHocPhiReqModel input)
        {
            try
            {
                var hocPhi = _context.HocPhi
                    .Where(record => record.NamHocPhi.NamHocId == input.NamHocId)
                    .AsEnumerable();

                if (hocPhi.Count() > 0)
                    _context.HocPhi.DeleteRange(hocPhi, true);

                var namHocPhi = _context.NamHocPhi
                    .Where(record => record.NamHocId == input.NamHocId)
                    .ToList();

                if (namHocPhi.Count > 0)
                    _context.NamHocPhi.DeleteRange(namHocPhi, true);

                var newNamHocPhi = new NamHocPhi
                {
                    NamHocId = input.NamHocId,
                    NoiDung = input.NoiDung,
                    HocPhi = input.ListHocPhi.Select(item => new HocPhi
                    {
                        HeDaoTaoId = item.HeDaoTaoId,
                        Lop = item.Lop,
                        TienHocPhi = item.TienHocPhi,
                    }).ToList()
                };
                _context.NamHocPhi.Add(newNamHocPhi);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(CreateOrUpdateHocPhiByNamHocId));
                throw;
            }
        }
        public async Task DeleteHocPhi(long hocPhiId)
        {
            _context.HocPhi.DeleteAsync(hocPhiId);
            await _context.SaveChangesAsync();
        }
        public List<NamHocPhiResModel> GetAllNamHocPhi()
        {
            try
            {
                var result = _context.NamHoc
                        .Select(record => new NamHocPhiResModel
                        {
                            NamHocId = record.Id,
                            TuNam = record.TuNam,
                            TenNamHoc = record.NamHocPhi.NamHoc.TenNamHoc,
                            DenNam = record.DenNam,
                            NoiDung = record.NamHocPhi.NoiDung,
                            ListHocPhi = record.NamHocPhi.HocPhi.Select(item => new ChiTietHocPhiResModel
                            {
                                Id = item.Id,
                                HeDaoTao = item.HeDaoTao.TenHeDaoTao,
                                HeDaoTaoId = item.HeDaoTaoId,
                                Lop = item.Lop,
                                TienHocPhi = item.TienHocPhi,
                            })
                            .ToList(),
                        })
                        .ToList();
                if (result is null) throw new Exception(Constants.ExceptionMessage.NOT_FOUND);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetByNamHocId));
                throw;
            }
        }
        public ChiTietHocPhiResModel GetChiTieHocPhiById(long id)
        {
            HocPhi hocPhi = _context.HocPhi.GetById(id)
;
            ChiTietHocPhiResModel model = new ChiTietHocPhiResModel
            {
                Id = hocPhi.Id,
                HeDaoTaoId = hocPhi.HeDaoTaoId,
                Lop = hocPhi.Lop,
                TienHocPhi = hocPhi.TienHocPhi
            };
            return model;
        }
        public async Task<List<HeDaoTaoResponseModel>> GetHeDaoTaoForDropDown()
        {
            return _context.HeDaoTao.Select(c => new HeDaoTaoResponseModel
            {
                Id = c.Id,
                TenHeDaoTao = c.TenHeDaoTao,
                TenHeDaoTaoEnglish = c.TenHeDaoTaoEnglish
            }).ToList();
        }
        public async Task CreateHocPhi(HocPhiRequestModel input)
        {
            var res = _context.NamHocPhi.GetById(input.NamHocPhiId);
            if (res != null)
            {
                try
                {
                    _context.HocPhi.Add(new HocPhi()
                    {
                        NamHocPhiId = input.NamHocPhiId,
                        HeDaoTaoId = input.HeDaoTaoId,
                        Lop = input.Lop,
                        TienHocPhi = input.TienHocPhi
                    });
                    await _context.SaveChangesAsync();

                }
                catch
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND));
                }
            }

        }
        public async Task<List<HocPhiResponseModel>> GetAllHocPhi()
        {
            var res = await _context.HocPhi.Select(x => new HocPhiResponseModel()
            {
                Id = x.Id,
                TenNamHoc = x.NamHocPhi.NamHoc.TenNamHoc,
                HeDaoTaoId = x.HeDaoTaoId,
                MoHinhLop = x.HeDaoTao.TenHeDaoTao,
                MoHinhLopTiengAnh = x.HeDaoTao.TenHeDaoTaoEnglish,
                Lop = x.Lop,
                TienHocPhi = x.TienHocPhi,
                NamHocPhiId = x.NamHocPhiId,
            }).ToListAsync();
            return res;
        }
        public async Task UpdateHocPhi(long id, UpdateHocPhiReqModel data)
        {
            try
            {
                var updateHocPhi = _context.HocPhi.GetAvailableById(id);
                updateHocPhi.HeDaoTaoId = data.HeDaoTaoId;
                updateHocPhi.Lop = data.Lop;
                updateHocPhi.TienHocPhi = data.TienHocPhi;
                _context.HocPhi.Update(updateHocPhi);

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND));
            }

        }
    }
}

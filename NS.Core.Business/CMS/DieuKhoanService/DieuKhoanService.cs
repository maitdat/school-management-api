using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels.DieuKhoanRequestModel;
using NS.Core.Models.ResponseModels.DieuKhoan;
using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static NS.Core.Commons.Constants;

namespace NS.Core.Business.DieuKhoanService
{
    public class DieuKhoanService : IDieuKhoanService
    {
        private readonly AppDbContext _context;
        public DieuKhoanService (AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<DieuKhoanResponseModel> GetDieuKhoan()
        {
            //try
            //{
            //    var res = _context.CaiDatTongThe
            //        .Where(x => x.TrangId == 13)
            //        .FirstOrDefault();
            //    DieuKhoanResponseModel model = new DieuKhoanResponseModel
            //    {
            //        TieuDe = res.TieuDe,
            //        MoTa = res.Mota,
            //        TieuDeTiengAnh = res.TieuDeTiengAnh,
            //        MoTaTiengAnh = res.MotaTiengAnh
            //    };
            //    return model;
            //} catch
            //{
            //    await Console.Out.WriteLineAsync(ExceptionMessage.ITEM_NOT_FOUND);
            //    return new DieuKhoanResponseModel();
            //}

            var res = _context.CaiDatTongThe
                    .Where(x => x.TrangId == 13)
                    .FirstOrDefault();
            if (res == null)
            {
                throw new Exception(ExceptionMessage.ITEM_NOT_FOUND);
            } else
            {
                DieuKhoanResponseModel model = new DieuKhoanResponseModel
                {
                    TieuDe = res.TieuDe,
                    MoTa = res.Mota,
                    TieuDeTiengAnh = res.TieuDeTiengAnh,
                    MoTaTiengAnh = res.MotaTiengAnh
                };
                return model;   
            }
        }

        public async Task Create(DieuKhoanRequestModel dieuKhoanRequestModel)
        {
            CaiDatTongThe dieuKhoan = new CaiDatTongThe
            {
               TrangId = 13,
               TieuDe = dieuKhoanRequestModel.TieuDe,
               Mota = dieuKhoanRequestModel.MoTa,
               TieuDeTiengAnh = dieuKhoanRequestModel.TieuDeTiengAnh,
               MotaTiengAnh = dieuKhoanRequestModel.MoTaTiengAnh
            };
            _context.CaiDatTongThe.Add(dieuKhoan);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DieuKhoanRequestModel dieuKhoanRequestModel)
        {
            var res = _context.CaiDatTongThe
                .Where(x => x.TrangId == 13)
                .FirstOrDefault();
            if (res == null)
            {
                throw new Exception(ExceptionMessage.ITEM_NOT_FOUND);
            } else
            {
                res.TieuDe = dieuKhoanRequestModel.TieuDe;
                res.Mota = dieuKhoanRequestModel.MoTa;
                res.TieuDeTiengAnh = dieuKhoanRequestModel.TieuDeTiengAnh;
                res.MotaTiengAnh = dieuKhoanRequestModel.MoTaTiengAnh;

                _context.CaiDatTongThe.Update(res);
                await _context.SaveChangesAsync();
            }
        }
    }
}

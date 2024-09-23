using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.HoiDongKhaoThiService
{
    public class HoiDongKhaoThiService : IHoiDongKhaoThiService
    {
        private readonly AppDbContext _context;
        public HoiDongKhaoThiService(AppDbContext appcontext)
        {
            _context = appcontext;
        }
        public void CreateHoiDongKhaoThi(CreateOrUpdateHoiDongKhaoThiModel data)
        {
            var newHDKT = new HoiDongKhaoThi()
            {
                KyTuyenSinhId = data.KyTuyenSinhId,
                TenHoiDong = data.TenHoiDong,
                KyTuyenSinh = _context.KyTuyenSinh.Where(x => x.Id == data.KyTuyenSinhId).FirstOrDefault()
            };
            _context.Add(newHDKT);
            _context.SaveChanges();
        }

        public void UpdateHoiDongKhaoThi(long id, CreateOrUpdateHoiDongKhaoThiModel data)
        {
            var hoiDongKhaoThiUpdated = _context.HoiDongKhaoThi.Where(x => x.Id == id).FirstOrDefault();
            if (hoiDongKhaoThiUpdated == null)
                throw new(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(HoiDongKhaoThi.Id)));
            {
                hoiDongKhaoThiUpdated.KyTuyenSinhId = data.KyTuyenSinhId;
                hoiDongKhaoThiUpdated.TenHoiDong = data.TenHoiDong;
                hoiDongKhaoThiUpdated.KyTuyenSinh = _context.KyTuyenSinh.Where(x => x.Id == data.KyTuyenSinhId).FirstOrDefault();
            };
            _context.Update(hoiDongKhaoThiUpdated);
            _context.SaveChanges();
        }
        public void DeleteHoiDongKhaoThi(long id)
        {
            _context.HoiDongKhaoThi.Delete(id);
            _context.SaveChanges();
        }

        public IQueryable<HoiDongKhaoThi> GetAll()
        {
            return _context.HoiDongKhaoThi.AsQueryable();
        }

        public async Task<HoiDongKhaoThiResponseModel> GetById(long id)
        {
            var hoiDongKhaoThi = GetAll().Select(x => new HoiDongKhaoThiResponseModel()
            {
                Id = x.Id,
                KyTuyenSinhId = x.KyTuyenSinhId,
                TenKyTuyenSinh = x.KyTuyenSinh.TenKyTuyenSinh,
                TenHoiDong = x.TenHoiDong,
            }).Where(x => x.Id == id).FirstOrDefault();

            if (hoiDongKhaoThi == null)
                throw new(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(HoiDongKhaoThi.Id)));
            return hoiDongKhaoThi;
        }

        public async Task<BasePaginationResponseModel<HoiDongKhaoThiResponseModel>> GetPaged(BasePaginationRequestModel input)
        {
            var query = _context.HoiDongKhaoThi
            .Where(x => x.IsDeleted == false);

            if (!input.Keyword.IsNullOrEmpty()) 
                query = query.Where(e => EF.Functions
                                        .Collate(e.TenHoiDong, "SQL_Latin1_General_CP1_CI_AI")
                                        .Contains(input.Keyword));

            query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);
            var data = await query.Select(x => new HoiDongKhaoThiResponseModel()
            {
                Id = x.Id,
                KyTuyenSinhId = x.KyTuyenSinhId,
                TenKyTuyenSinh = x.KyTuyenSinh.TenKyTuyenSinh,
                TenHoiDong = x.TenHoiDong
            })
                .ToListAsync();
            return new BasePaginationResponseModel<HoiDongKhaoThiResponseModel>(input.PageNo, input.PageSize, data, totalItems);
        }
    }
}

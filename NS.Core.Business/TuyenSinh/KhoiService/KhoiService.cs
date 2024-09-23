using NS.Core.Models;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Business.KhoiService
{
    public class KhoiService:IKhoiService
    {
        private readonly AppDbContext _context;
        public KhoiService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<KhoiReponseModel>> GetListKhoiTuyenSinh()
        {
            var khoiTuyenSinhRes = _context.Khoi.Select(k => new KhoiReponseModel
            {
                Id = k.Id,
                TenKhoi = k.TenKhoi,
                TenKhoiTiengAnh = k.TenKhoiEnglish,
            }).ToList();
            return khoiTuyenSinhRes;
        }
            
          
    }
}

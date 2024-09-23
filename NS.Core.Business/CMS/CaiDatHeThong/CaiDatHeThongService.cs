using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace NS.Core.Business.CaiDatHeThongServices
{
    public class CaiDatHeThongService : ICaiDatHeThongServices
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CaiDatHeThongService> _logger;
        private readonly IConfiguration _config;

        public CaiDatHeThongService(AppDbContext context, ILogger<CaiDatHeThongService> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }


        public async Task UpdateCauHinhEmail(CaiDatHeThongModel input)
        {
            var config = await _context.CatDatHeThong.Where(x => x.CauHinh == CauHinhHeThong.Email).FirstOrDefaultAsync();
            if (config is null)
                throw new Exception(Constants.ExceptionMessage.ITEM_NOT_FOUND);
            config.CauHinh = input.CauHinh;
            config.CaiDat = input.CaiDat;
            _context.CatDatHeThong.Update(config);
            await _context.SaveChangesAsync();
        }
        public List<CaiDatHeThongModel> GetAllCauHinhEmail()
        {
            try
            {
                var data = _context.CatDatHeThong.Select(x => new CaiDatHeThongModel
                    {
                        CaiDat = x.CaiDat,
                        CauHinh = x.CauHinh
                    })
                    .ToList();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

    }
}

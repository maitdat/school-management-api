using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using System.Text.Json;

namespace NS.Core.Business.MailService
{
    public class MailService : IMailService
    {
        public readonly AppDbContext _context;
        public MailService(AppDbContext context)
        {
            _context = context;
        }
        public async Task SendEmailAsync(string mailTo, CaiDatEmail caiDatEmail)
        {
            if (caiDatEmail == null) throw new NotFoundException(nameof(caiDatEmail));

            var catDatHeThong = await _context.CatDatHeThong
                .Where(e => e.CauHinh == Enums.CauHinhHeThong.Email)
                .FirstOrDefaultAsync();

            if (catDatHeThong == null) throw new NotFoundException(nameof(CatDatHeThong));

            var mailSettings = JsonSerializer.Deserialize<MailSettings>(catDatHeThong.CaiDat);

            SmtpClient client = new SmtpClient();
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.From));
            message.To.Add(MailboxAddress.Parse(mailTo));
            message.Subject = caiDatEmail.TieuDe;
            message.Body = new TextPart("html") { Text = caiDatEmail.NoiDung };

            try
            {
                client.Connect(mailSettings.Host, mailSettings.Port, mailSettings.UseSSL);
                client.Authenticate(mailSettings.From, mailSettings.Password);

                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

    }
}
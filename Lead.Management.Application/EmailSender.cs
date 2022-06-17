using Lead.Management.Application.Interfaces;
using Lead.Management.Application.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Lead.Management.Application
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task<string> SendEmailAsync(string recipientEmail, float discountedValue)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "How to send email in .Net Core";
            message.Body = new TextPart("plain")
            {
                Text = @$"Você esta recebendo 10% de desconto, valor total é R$: { discountedValue }"
            };

            var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}

using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSchedulerHangfire.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync()
        {
            var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("rishabhb1213@gmail.com"));
            email.From.Add(new MailboxAddress("MyDailyLove", "rishabhb1213@gmail.com"));
            email.To.Add(MailboxAddress.Parse("zjooie@gmail.com"));
            email.Cc.Add(MailboxAddress.Parse("bajirao508@gmail.com"));
            email.Subject = "Scheduled Email";

            email.Body = new TextPart("plain")
            {
                Text = "Hello! Email sent using Hangfire."
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, false);
            await smtp.AuthenticateAsync("rishabhb1213@gmail.com", "glhwopvmauharbzu");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}

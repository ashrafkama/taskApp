using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Task_Application.Helper
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        public EmailSender(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }

        public void SendEmail(string toEmail, string subject)
        {
            using (SmtpClient SmtpServer = new SmtpClient(_mailSettings.Server, _mailSettings.Port))
            {
                var mail = new MailMessage();
                if(_mailSettings.SenderEmail != null)
                     mail.From = new MailAddress(_mailSettings.SenderEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                StringBuilder mailBody = new StringBuilder();
                mailBody.AppendFormat("<h1>There are new tasks assigned to you </h1>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>greeting for you </p>");
                mail.Body = mailBody.ToString();
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_mailSettings.UserName, _mailSettings.Password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
          

        }
    }
}

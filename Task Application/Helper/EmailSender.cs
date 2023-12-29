using System.Net;
using System.Net.Mail;
using System.Text;

namespace Task_Application.Helper
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string toEmail, string subject)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("taskapplication84@gmail.com", "taskApp@001");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("taskapplication84@gmail.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>There are new tasks assigned to you </h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>greeting for you </p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}

using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

namespace tcc_chat.Services {
    public class EmailService
    {
        public void SendEmail(List<string> toList, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("jexum.senai@gmail.com", "kfwu rrgn bnew sapj"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("jexum.senai@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            foreach (var to in toList)
            {
                mailMessage.To.Add(to);
            }

            smtpClient.Send(mailMessage);
        }
    }
}

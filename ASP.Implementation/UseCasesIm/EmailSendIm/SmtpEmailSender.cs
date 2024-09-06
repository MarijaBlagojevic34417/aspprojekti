using ASP.Aplication.UseCases.Commands.EmailSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.EmailSendIm
{
    public class SmtpEmailSender : IEmailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("projekat53@gmail.com", "ProjekatASP")
            };
            var message = new MailMessage("projekat53@gmail.com", toEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}

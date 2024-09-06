using ASP.Aplication.DTO;
using ASP.Aplication.UseCases.Commands.EmailSend;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ASP.Implementation.UseCasesIm.EmailSendIm
{
    public class OAuthEmailSender: IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public OAuthEmailSender(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            UserCredential credential;
            var currentDirectory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDirectory, "Core", "client_secret.json");
            
            // Combine it with the relative path to the file
            //var filePath = Path.Combine(assemblyDirectory, "client_secret.json");
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { GmailService.Scope.GmailSend },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true));
                }
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Gmail API .NET Quickstart",
                });
                var email = CreateEmail(to, from, subject, body);
                await SendMessageAsync(service, "me", email);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            

           
        }

        private static MimeMessage CreateEmail(string to, string from, string subject, string body)
        {
            var email = new MimeMessage();
           
            
            email.From.Add(new MailboxAddress("Sender name",from));
            email.To.Add(new MailboxAddress("Receiver name",to));
            email.Subject = subject;
            email.Body = new TextPart("plain") { Text = body };
            return email;
        }

        private static async Task SendMessageAsync(GmailService service, string userId, MimeMessage email)
        {
            var message = new Message();
            using (var ms = new MemoryStream())
            {
                email.WriteTo(ms);
                message.Raw = Convert.ToBase64String(ms.ToArray())
                    .Replace('+', '-')
                    .Replace('/', '_')
                    .Replace("=", "");
            }

            await service.Users.Messages.Send(message, userId).ExecuteAsync();
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            SendEmailAsync(toEmail, "projekat53@gmail.com", subject, body);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using HashtagWebApp.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;

namespace HashtagWebApp.Services
{
    public class EmailSender : IEmailSender
    {
        public static Mail Email;
        public EmailSender(IOptions<Mail> email)
        {
            Email = email.Value;
        }
       
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(subject, htmlMessage, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            //var client = new SendGridClient(apiKey);
            //var msg = new SendGridMessage()
            //{
            //    From = new EmailAddress("webmaster@tamjomi.com", Options.SendGridUser),
            //    Subject = subject,
            //    PlainTextContent = message,
            //    HtmlContent = message
            //};
            //msg.AddTo(new EmailAddress(email));

            //msg.SetClickTracking(false, false);

            //return client.SendEmailAsync(msg);
            var client = new SmtpClient(Email.Client);

            var credentials = new NetworkCredential(Email.NetworkCredentials.Username, Email.NetworkCredentials.Password);
            client.Credentials = credentials;

            var mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("webmaster@tamjomi.com");
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = message;
            return client.SendMailAsync(mail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Service
{
    public class EmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";

        //public EmailService(Ioptions<SMTPConfigModel> _smtpConfig)
        //{

        //}
        private async Task SendEmail(UserEmailoptions userEmailoptions)
        {
            MailMessage mail = new MailMessage
            {
                //Subject=userEmailoptions.Subject,
                //Body=userEmailoptions.Body,
                //From= new MailAddress("no-reply@bookstoreapp.com", "Book store team")
                //IsBodyHtml = 
            };
        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
    }
}

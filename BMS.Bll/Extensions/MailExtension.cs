using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace BMS.Bll.Extensions
{
    public static class MailExtension
    {
        public static void SendMail(string Title,string MailBody,string Receiver)
        {
            string from = "ahmet.karabudakk@yandex.com";
            string pass = "Patika.Ahmet";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(Receiver));
            email.Subject = Title;
            email.Body = new TextPart(TextFormat.Html) { Text = MailBody };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.yandex.com", 465, SecureSocketOptions.Auto);
            smtp.Authenticate(from, pass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

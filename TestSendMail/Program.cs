using System;
using System.Net.Mime;

namespace TestSendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            string SMTPUser = "ivanov.ava2000@yandex.ru";
            string SMTPPassword = "FUCK";
            int SmtpPort = 587;
            string SmtpServer = "smtp.yandex.com";

            System.Net.Mail.MailAddress sender = new System.Net.Mail.MailAddress("ivanov.ava2000@yandex.ru", "", System.Text.Encoding.UTF8);

            System.Net.Mail.MailAddress recipient = new System.Net.Mail.MailAddress("mitran@mail.ru", "", System.Text.Encoding.UTF8);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage(sender, recipient);

            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace("My plan body", @"<(.|\n)*?>", string.Empty), null, MediaTypeNames.Text.Plain);

            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString("My HTML body", null, MediaTypeNames.Text.Html);

            email.AlternateViews.Clear();
            email.AlternateViews.Add(plainView);
            email.AlternateViews.Add(htmlView);
            email.Subject = $"Azure {DateTime.Now}";

            System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient();
            SMTP.UseDefaultCredentials = false;

            SMTP.Host = SmtpServer;
            SMTP.Port = SmtpPort;

            SMTP.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);
            SMTP.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            SMTP.EnableSsl = true;

            SMTP.Send(email);
        }
    }
}



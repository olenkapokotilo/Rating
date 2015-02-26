using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Rating.Services
{
    public static class UserEmailService
    {
        public static void SendForgottenPassword(string email, string password)
        {
            SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);
            smtpClient.UseDefaultCredentials = true;

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("noreply@rating.com", "Rating");
            mail.To.Add(new MailAddress(email));

            smtpClient.Send(mail);
        }
    }
}
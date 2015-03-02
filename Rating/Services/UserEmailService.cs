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

            //MailMessage mail = new MailMessage();
            //mail.To.Add(email);
            //mail.From = new MailAddress(email);
            //mail.Subject = "Hello world";
            //mail.Body = "Hello world Body";
            //mail.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 465;//I have also tried the 587 option here
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = new System.Net.NetworkCredential(email, password);
            //smtp.EnableSsl = true;
            //smtp.Timeout = 3000000;
            //smtp.ServicePoint.MaxIdleTime = System.Threading.Timeout.Infinite;//1;
            //smtp.EnableSsl = true;
            //smtp.Send(mail);
        }
    }
}
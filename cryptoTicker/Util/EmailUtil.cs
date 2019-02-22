using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace cryptoTicker.Util
{
    public static class EmailUtil
    {
        public static string FromMail { get; set; }
        public static string FromMailPassword { get; set; }
        public static List<string> ToMails { get; set; }
        public static string SendEmail(string title, string message)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(FromMail);
            
            if(ToMails!= null) ToMails.ForEach(x=> msg.To.Add(x));

            msg.Subject = "Crypto Ticker Notifier - " + title;
            msg.Body = message;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(FromMail, FromMailPassword);

            try
            {
                client.Send(msg);
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}

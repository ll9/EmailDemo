using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailDemo
{
    class Program
    {
        private const string _sourceEmail = "<_sourceEmail@web.de>";
        private const string _destinationEmail = "<_destinationEmail@web.de>";
        private const string _emailPassword = "<_emailPassword>";

        static void Main(string[] args)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(_sourceEmail);
            message.To.Add(new MailAddress(_destinationEmail));
            message.Subject = "Test";

            //message.IsBodyHtml = true; //to make message body as html  
            //message.Body = "<h1>Nachricht</h1>";
            message.Body = $@"
Sehr geehrter Nutzer,

danke, dass Sie sich für unseren Newsletter angemeldet haben.

Mit freundlichen Grüßen
";

            smtp.Port = 587;
            smtp.Host = "smtp.web.de"; //for web.de host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_destinationEmail, _emailPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(message);
        }
    }
}

﻿using BlogEngine.Common.Constants;
using System.Net.Mail;
using System.Text;

namespace BlogEngine.Common.Helpers
{
    public class MailHelper
    {
        public static bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                var host = ConfigHelper.GetByKey(Config.SMTPHost);
                var port = int.Parse(ConfigHelper.GetByKey(Config.SMTPPort));
                var fromEmail = ConfigHelper.GetByKey(Config.FromEmailAddress);
                var password = ConfigHelper.GetByKey(Config.FromEmailPassword);
                var fromName = ConfigHelper.GetByKey(Config.FromName);

                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 100000
                };

                var mail = new MailMessage
                {
                    Body = content,
                    Subject = subject,
                    From = new MailAddress(fromEmail, fromName)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                smtpClient.Send(mail);

                return true;
            }
            catch (SmtpException smex)
            {

                return false;
            }
        }
    }
}

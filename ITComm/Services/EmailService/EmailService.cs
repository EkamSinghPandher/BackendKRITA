using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ITComm.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public string sendOtpEmail(string otp, string email, IConfiguration config)
        {
            try
            {
                var smtpClient = new SmtpClient(config.GetSection("Mail")["server"])
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("TODO: SMTP SERVER USERNAME HERE", config.GetSection("Mail")["emailPass"]),
                    EnableSsl = true,
                    Timeout = 20000
                };

                string message = "Your One Time Password is: " + otp;
                smtpClient.Send(config.GetSection("Mail")["emailId"], email, "One Time Password", message);
                return "Email Sent";
            }
            catch(Exception e)
            {
                return "Something went wrong: " + e.Message;
            }
        }
    }
}

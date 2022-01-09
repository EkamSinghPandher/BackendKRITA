using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Services.EmailService
{
    public interface IEmailService
    {
        string sendOtpEmail(string otp, string nusNetId, IConfiguration config);
    }
}

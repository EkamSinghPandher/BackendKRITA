using ITComm.Dtos.Account;
using ITComm.Services.EmailService;
using Microsoft.Extensions.Configuration;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Services.AccountService
{
    public interface IAccountService
    {
        public Task<ServiceResponse<StudentLoginSuccessDto>> LoginStudentOtp(StudentLoginOtpRequestDto loginDto);
        public Task<ServiceResponse<string>> LoginStudent(string nusNetId, IEmailService emailService, IConfiguration config);
        public Task<ServiceResponse<StudentLoginSuccessDto>> RegisterStudent(StudentRegisterDto registerDto);
    }
}

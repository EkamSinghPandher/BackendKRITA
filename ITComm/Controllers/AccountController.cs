using ITComm.Dtos.Account;
using ITComm.Services.AccountService;
using ITComm.Services.EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SOC_IR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private IConfiguration _config;
        private readonly IEmailService _emailService;
        public AccountController(IAccountService accountService, IConfiguration config, IEmailService emailService)
        {
            this._emailService = emailService;
            this._config = config;
            this._accountService = accountService;
        }

        [HttpPost("login")]
        async public Task<IActionResult> loginStudent(string id)
        {
            ServiceResponse<string> response = await _accountService.LoginStudent(id);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }
            else
            {
                return Ok("Success, otp has been sent");
            }
        }

        [HttpPost("login/otp")]
        async public Task<IActionResult> loginStudentOtp(StudentLoginOtpRequestDto loginDto)
        {
            ServiceResponse<StudentLoginSuccessDto> response = await _accountService.LoginStudentOtp(loginDto, _emailService, _config);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            else
            {
                return Ok(response.Data);
            }
        }

        [HttpPost("register")]
        async public Task<IActionResult> registerStudentOtp(StudentRegisterDto registerDto)
        {
            ServiceResponse<StudentLoginSuccessDto> response = await _accountService.RegisterStudent(registerDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            else
            {
                return Ok(response.Data);
            }
        }
    }
}

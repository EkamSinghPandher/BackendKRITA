using ITComm.Dtos.Account;
using ITComm.Models;
using ITComm.Services.EmailService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SOC_IR.Data;
using SOC_IR.Model;
using SOC_IR.Services.IdGenerator;
using System;
using System.Threading.Tasks;

namespace ITComm.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<string>> LoginStudent(string nusNetId, IEmailService emailService, IConfiguration config)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            Student student = await _context.Students.FirstOrDefaultAsync(student => student.nusNetId == nusNetId);
            
            if(student == null)
            {
                response.Success = false;
                response.Message = "Incorrect NUSNET ID";
                return response;
            }
            
            string otpCode = new OtpGenerator().generate();
            OTPToken token = new OTPToken(otpCode, nusNetId);

            await _context.OTPTokens.AddAsync(token);
            await _context.SaveChangesAsync();
            string studentEmail = nusNetId + "@u.nus.edu";
            string emailResponse = emailService.sendOtpEmail(otpCode, studentEmail, config);

            if(emailResponse == "Email Sent")
            {
                response.Data = "Successful Login, please check email OTP";
                return response;
            }
            else
            {
                response.Message = emailResponse;
                response.Success = false;
                return response;
            }        
        }

        public async  Task<ServiceResponse<StudentLoginSuccessDto>> LoginStudentOtp(StudentLoginOtpRequestDto loginDto)
        {
            ServiceResponse<StudentLoginSuccessDto> response = new ServiceResponse<StudentLoginSuccessDto>();
            OTPToken token = await _context.OTPTokens.FirstOrDefaultAsync(otp => otp.isValidToken(loginDto.code, loginDto.nusNetId));
            if(token == null)
            {
                response.Success = false;
                response.Message = "The OTP entered was incorrect or expired";
                return response;
            }
            else
            {
                Student student = await _context.Students.FirstOrDefaultAsync(student => student.nusNetId == token.nusNetId);
                response.Data = new StudentLoginSuccessDto(student.firstName, student.lastName);
                _context.OTPTokens.Remove(token);
                await _context.SaveChangesAsync();
                return response;
            }
        }

        public async Task<ServiceResponse<StudentLoginSuccessDto>> RegisterStudent(StudentRegisterDto registerDto)
        {
            ServiceResponse<StudentLoginSuccessDto> response = new ServiceResponse<StudentLoginSuccessDto>();
            Student studentToAdd = new Student(registerDto.nusNetId, registerDto.firstName, registerDto.lastName);
            Student existingStudent = await _context.Students.FirstOrDefaultAsync(student => student.nusNetId == studentToAdd.nusNetId);
            if(existingStudent != null)
            {
                response.Success = false;
                response.Message = "There is already an exisiting student with that NUSNET ID";
                return response;
            }
            else
            {
                await _context.Students.AddAsync(studentToAdd);
                await _context.SaveChangesAsync();
                response.Data = new StudentLoginSuccessDto(studentToAdd.firstName, studentToAdd.lastName);
                return response;
            }
        }
    }
}

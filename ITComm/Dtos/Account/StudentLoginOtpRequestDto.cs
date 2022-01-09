using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Dtos.Account
{
    public class StudentLoginOtpRequestDto
    {
        public string nusNetId { get; set; }
        public string code { get; set; }

        public StudentLoginOtpRequestDto(string nusNetId, string code)
        {
            this.nusNetId = nusNetId;
            this.code = code;
        }
    }
}

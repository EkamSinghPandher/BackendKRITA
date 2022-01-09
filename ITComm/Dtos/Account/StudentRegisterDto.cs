using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Dtos.Account
{
    public class StudentRegisterDto
    {
        public string nusNetId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public StudentRegisterDto(string nusNetId, string firstName, string lastName)
        {
            this.nusNetId = nusNetId;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

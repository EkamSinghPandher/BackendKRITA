using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Dtos.Account
{
    public class StudentLoginSuccessDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public StudentLoginSuccessDto(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

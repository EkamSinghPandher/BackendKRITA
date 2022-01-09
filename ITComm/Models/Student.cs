using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Models
{
    [Table("STUDENTS")]
    public class Student
    {
        [Key]
        [Column("NUSNET_ID")]
        public string nusNetId { get; set; }
        [Column("FIRSTNAME")]
        public string firstName { get; set; }
        [Column("LASTNAME")]
        public string lastName { get; set; }

        public Student(string id, string firstName, string lastName)
        {
            this.nusNetId = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

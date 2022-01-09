using SOC_IR.Model;
using SOC_IR.Services.IDGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITComm.Models
{
    [Table("OTP_TOKENS")]
    public class OTPToken
    {
        [Key]
        [Column("UID")]
        public string UID { get; set; }
        [Column("OTP")]
        public string otpCode { get; set; }
        [Column("NUSNET_ID")]
        public string nusNetId { get; set; }
        [Column("DATE_ISSUED")]
        public string dateTimeIssued { get; set; }

        public OTPToken(string otpCode, string nusNetId)
        {
            UID = new IDGenerator().generate();
            this.otpCode = otpCode;
            this.nusNetId = nusNetId;
            this.dateTimeIssued = DateTime.Now.ToString();
        }

        public bool isValidToken(string otp, string nusNetId)
        {
            if(this.nusNetId != nusNetId)
            {
                return false;
            }
            if(otp != otpCode)
            {
                return false;
            }

            bool isExpired = DateTime.Now.Subtract(DateTime.ParseExact(dateTimeIssued, "MM/dd/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture)).TotalMinutes > 10;

            if (isExpired)
            {
                return false;
            }

            return true;
        }
    }
}

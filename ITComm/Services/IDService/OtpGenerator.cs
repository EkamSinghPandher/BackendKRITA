using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.IdGenerator
{
    public class OtpGenerator
    {
        private string _chars;

        public OtpGenerator()
        {
            this._chars = "0123456789";
        }

        public string generate()
        {
            char[] stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = _chars[random.Next(_chars.Length)];
            }
            return new String(stringChars);
        }
    }
}

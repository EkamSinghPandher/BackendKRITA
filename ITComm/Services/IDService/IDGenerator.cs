using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC_IR.Services.IDGenerator
{
    public class IDGenerator
    {
        private string _chars;

        public IDGenerator()
        {
            this._chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        }

        public string generate()
        {
            char[] stringChars = new char[16];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = _chars[random.Next(_chars.Length)];
            }
            return new String(stringChars);
        }
       
}
}

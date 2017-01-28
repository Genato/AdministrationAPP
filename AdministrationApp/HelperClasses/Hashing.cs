using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdministrationApp.HelperClasses
{
    /// <summary>
    /// Class for hashing + salting
    /// </summary>
    internal class Hashing
    {
        /// <summary>
        /// hashing + salting
        /// </summary>
        /// <param name="unHashedString"></param>
        /// <returns></returns>
        public string Hash(string unHashedString)
        {
            int i = 0;
            StringBuilder tmpHashStr = new StringBuilder();
            SHA512Cng crypto = new SHA512Cng();
            byte[] bytePass = Encoding.UTF32.GetBytes(unHashedString);
            byte[] byteHashPass = crypto.ComputeHash(bytePass);

            foreach (var item in byteHashPass)
            {
                tmpHashStr.Append((item.ToString() + i.ToString()));
                ++i;
            }

            return tmpHashStr.ToString();
        }
    }
}

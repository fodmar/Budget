using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Utils.Extensions
{
    public static class StringExtensions
    {
        public static byte[] ToMD5(this string value)
        {
            using (MD5 algorithm = MD5.Create())
            {
                return algorithm.ComputeHash(Encoding.ASCII.GetBytes(value));
            }
        }

        public static string ToMD5String(this string value)
        {
            StringBuilder stringBuiler = new StringBuilder();
            foreach (byte item in value.ToMD5())
            {
                stringBuiler.Append(item.ToString("x2"));
            }

            return stringBuiler.ToString();
        }
    }
}

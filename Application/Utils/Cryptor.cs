using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class Cryptor
    {
        public static string MD5Encrypt(string password)
        {
            password = password.Trim();
            ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] data = encoding.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            password = encoding.GetString(result);
            return password;
        }
    }
}

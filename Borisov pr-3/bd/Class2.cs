using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Borisov_pr_3.bd
{
    class Hasha
    {
        public static string Hash(string password)
        {
            var sha256 = new SHA256CryptoServiceProvider();
            var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}

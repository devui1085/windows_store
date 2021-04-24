using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaasteelAppEncryptor
{
    public static class SecurityHelper
    {
        public static byte[] ComputeSha256Hash(string data)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);
            var hasher = new SHA256Managed();
            return hasher.ComputeHash(bytes);
        }

        public static byte[] ComputeSha256Hash(Guid data)
        {
            var hasher = new SHA256Managed();
            return hasher.ComputeHash(data.ToByteArray());
        }
    }
}

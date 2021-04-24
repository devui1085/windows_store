using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace WindowsStore.Client.User.Common.Security
{
    public static class HashHelper
    {
        public static byte[] ComputeHash(byte[] data, string hashAlgorithmName)
        {
            //String algorithmName = HashAlgorithmNames.Sha256;
            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(hashAlgorithmName);
            CryptographicHash hasher = objAlgProv.CreateHash();

            // Hash data
            hasher.Append(data.AsBuffer());
            IBuffer hashBuffer = hasher.GetValueAndReset();
            return hashBuffer.ToArray();
        }
    }
}

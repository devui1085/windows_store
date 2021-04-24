using System;
using System.IO;
using System.Linq;
using Store.Common.Security;

namespace Store.StoreService.AppCode.Security
{
    public static class FileEncryptor
    {

        /// <summary>
        /// Create new key from user provided key
        /// </summary>
        /// <param name="key">base key</param>
        /// <returns></returns>
        public static byte[] GenerateEncryptionKey(string key)
        {
            // add peper to key
            var newKey = SecurityHelper.ComputeSha256Hash(Guid.Parse(key));

            // add salt to key 
            Array.Reverse(newKey);
            return newKey.Select(baseKey => (byte)~baseKey).ToArray();
        }



    }
}
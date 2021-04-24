using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaasteelAppEncryptor
{
    public static class FileEncryptor
    {
        /// <summary>
        ///  Encrypt a file with user provided key
        /// </summary>
        /// <param name="fileFullName">File fullName</param>
        /// <param name="encryptionKey">user provided key</param>
        public static void EncryptFile(string fileFullName, byte[] encryptionKey)
        {
            var saveLocation = fileFullName.Replace((new FileInfo(fileFullName)).Extension, ".pstl");
            var buffer = new byte[encryptionKey.Length];

            using (var inputStream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read)) {
                using (var outputStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write)) {
                    var contentLength = inputStream.Length;
                    var transferLength = contentLength;

                    var byteNo = 0L;
                    while (transferLength > 0) {
                        //Thread.Sleep(50); // For Debug
                        inputStream.Read(buffer, 0, buffer.Length);

                        var sendLength = (int)Math.Min(transferLength, buffer.Length);

                        for (var i = 0; i < sendLength; i++) {
                            buffer[i] = (byte)(buffer[i] ^ encryptionKey[byteNo % encryptionKey.Length]);
                            byteNo++;
                        }

                        outputStream.Write(buffer, 0, sendLength);
                        transferLength -= sendLength;
                    }
                }
            }
        }

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

        ///// <summary>
        ///// Xor two byte array
        ///// </summary>
        ///// <param name="buffer1"></param>
        ///// <param name="buffer2"></param>
        ///// <returns></returns>
        //private static byte[] Xor(byte[] buffer1, byte[] buffer2)
        //{
        //    for (int i = 0; i < buffer1.Length; i++)
        //        buffer1[i] ^= buffer2[i];
        //    return buffer1;
        //}

    }
}
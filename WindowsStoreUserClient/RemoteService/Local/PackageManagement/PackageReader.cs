using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Security;
using Windows.Storage;

namespace WindowsStore.Client.User.Service.Local.PackageManagement
{
    public class PackageReader : IInputStream
    {
        private IInputStream _inputStream;
        private byte[] _key;
        private long _position;

        public PackageReader(IInputStream inputStream, Guid rawKey)
        {
            _inputStream = inputStream;
            _key = GenerateKey(rawKey);
        }

        private byte[] GenerateKey(Guid rawKey)
        {
            var hash = HashHelper.ComputeHash(rawKey.ToByteArray(), HashAlgorithmNames.Sha256);
            Array.Reverse(hash);
            return hash.Select(b => (byte)~b).ToArray();
        }

        IAsyncOperationWithProgress<IBuffer, uint> IInputStream.ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
        {
            return AsyncInfo.Run<IBuffer, uint>(async (token, progress) =>
            {
                await _inputStream.ReadAsync(buffer, count, options);
                progress.Report(50);

                // Decrypt
                var bufferBytes = buffer.ToArray();
                for (int i = 0; i < bufferBytes.Length; i++) {
                    bufferBytes[i] ^= _key[_position % _key.Length]; 
                    _position++;
                }

                //
                progress.Report(100);
                return bufferBytes.AsBuffer();
            });
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects).
                    _inputStream.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PackageReader() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

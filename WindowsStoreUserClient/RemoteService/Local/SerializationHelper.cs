using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace WindowsStore.Client.User.Service.Local
{
    /// <summary>
    /// Serializes and deserializes objects into and from XML documents.
    /// </summary>
    internal static class SerializationHelper<T>
    {
        public async static void SerializeToFileAsync(T objectToSerialize, IStorageFile file)
        {
            using (var stream = (await file.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0).AsStreamForWrite()) {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, objectToSerialize);
            }
        }

        public async static Task<T> DeserializeFromFileAsync(IStorageFile file)
        {
            using (var stream = (await file.OpenAsync(FileAccessMode.Read)).GetInputStreamAt(0).AsStreamForRead()) {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(stream);
            }
        }

    }
}

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cmd.Logging.Tools
{
    public static class StreamConverter
    {
        private readonly static BinaryFormatter BinaryFormatter = new BinaryFormatter();

        public static Stream Serialize<T>(T objToSerialize)
        {
            Stream serializationStream = new MemoryStream();
            try
            {
                BinaryFormatter.Serialize(serializationStream, objToSerialize);
            }
            catch (Exception)
            {
                serializationStream = null;
            }
            return serializationStream;
        }

        public static T Deserialize<T>(Stream streamToDeserialize) where T : class
        {
            try
            {
                var objectToReturn = BinaryFormatter.Deserialize(streamToDeserialize);

                return objectToReturn as T;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

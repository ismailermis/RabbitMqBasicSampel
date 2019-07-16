using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace RabbitMQSample
{
    public class ConvertTool
    {
        private byte[] SerialiseIntoXml(Person customer)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xmlSerialiser = new XmlSerializer(customer.GetType());
            xmlSerialiser.Serialize(memoryStream, customer);
            memoryStream.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream.GetBuffer();
        }
        private byte[] SerialiseIntoBinary(Person customer)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, customer);
            memoryStream.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream.GetBuffer();
        }
        private Person DeserialiseFromXml(byte[] messageBody)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(messageBody, 0, messageBody.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            XmlSerializer xmlSerialiser = new XmlSerializer(typeof(Person));
            return xmlSerialiser.Deserialize(memoryStream) as Person;
        }
        private Person DeserialiseFromBinary(byte[] messageBody)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(messageBody, 0, messageBody.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(memoryStream) as Person;
        }
    }
}
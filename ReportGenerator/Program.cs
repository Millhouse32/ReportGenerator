using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace ReportGenerator
{
    class Program 
    { 
        public static void Main(string[] args)
        {
            string data = @"[ {""name"": ""Nick Miller"", ""age"": ""21""},
            {""name"": ""john dow"", ""age"" : ""25""} ]";



            XmlDocument doc = new XmlDocument();

            var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(Encoding.ASCII.GetBytes(data), new XmlDictionaryReaderQuotas()));

            Console.WriteLine(xml);
        }
    }
}
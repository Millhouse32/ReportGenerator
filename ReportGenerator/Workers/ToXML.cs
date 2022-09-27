using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ReportGenerator.Workers
{
    /// <summary>
    /// Worker class responsible for converting JSON data to XML and outputing XML to console and file
    /// </summary>
    public static class ToXML
    {
        /// <summary>
        /// Converts Json string to XML and outputs it to file and console window
        /// </summary>
        /// <param name="json">json string</param>
        /// <param name="filename">name of file</param>
        public static void ConvertToXML(string json, string filename)
        {
            /// adding .xml to end of filename
            filename += ".xml";

            /// creating xml document
            XmlDocument doc = new XmlDocument();

            /// converting JSON to xml
            var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(Encoding.ASCII.GetBytes(json), new XmlDictionaryReaderQuotas()));

            /// displaying xml to console window
            Console.WriteLine(xml);

            /// writing xml to file
            xml.Save(filename);
        }
    }
}
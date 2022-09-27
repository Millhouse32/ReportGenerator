using System;
using System.Data;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Aspose.Cells;
using Aspose.Cells.Utility;
using Newtonsoft.Json;
using ReportGenerator.Workers;

namespace ReportGenerator
{
    class Program 
    { 
        public static void Main(string[] args)
        {
            string data = "{\n    \"email\":[\n        {\n            \"type\":\"home\",\n            \"name\":\"john.doe@gmail.com\"\n        },\n        {\n            \"type\":\"work\",\n            \"name\":\"jdoe@gmail.com\"\n        }\n    ]\n}";


            ToXML.ConvertToXML(data, "email");

            //ToEXCEL(data);
            
        }

        //public static void ToXML(string json)
        //{
        //    XmlDocument doc = new XmlDocument();

        //    var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(Encoding.ASCII.GetBytes(json), new XmlDictionaryReaderQuotas()));

        //    Console.WriteLine(xml);
        //}

        public static void ToEXCEL(string json)
        {
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

            StringBuilder fileContent = new StringBuilder();

            foreach (var col in dt.Columns)
            {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow row in dt.Rows)
            {
                foreach (var col in row.ItemArray)
                {
                    fileContent.Append("\"" + col.ToString() + "\",");

                }
                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
                System.IO.File.WriteAllText("people.csv", fileContent.ToString());
            }
        }

    }
}
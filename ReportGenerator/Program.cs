using ReportGenerator.Workers;

namespace ReportGenerator
{
    class Program 
    { 
        public static void Main(string[] args)
        {
            string data = "{\n\"email\":[\n{\n\"type\":\"home\",\n\"name\":\"john.doe@gmail.com\"\n},\n{\n\"type\":\"work\",\n\"name\":\"jdoe@gmail.com\"\n}\n]\n}";

            string filepath = "../../../../Reports/";

            ToXML.ConvertToXML(data, "email", filepath);

            ToCSV.ConvertToCSV(data, "email", filepath);

            ToXLSX.ConvertToXLSX(data, "email", filepath);

            ToXLSM.ConvertToXLSM(data, "email", filepath);

            ToJSON.ConvertToJSON(data, "email", filepath);
        }
    }
}
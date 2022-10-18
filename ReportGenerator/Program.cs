using ReportGenerator.Workers;
using ReportGenerator.ServerNamespace;

namespace ReportGenerator
{
    class Program 
    { 
        public static void Main(string[] args)
        {
            string data = "{\n\"email\":[\n{\n\"type\":\"home\",\n\"name\":\"john.doe@gmail.com\"\n},\n{\n\"type\":\"work\",\n\"name\":\"jdoe@gmail.com\"\n}\n]\n}";

            string filepath = "../../../../Reports/";

            Server server = new Server();

            Server.MessageReceived += new EventHandler<string>(HandleMessageReceived);

            //ToXML.ConvertToXML(data, "email", filepath);

            //ToCSV.ConvertToCSV(data, "email", filepath);

            //ToXLSX.ConvertToXLSX(data, "email", filepath);

            //ToXLSM.ConvertToXLSM(data, "email", filepath);

            //ToJSON.ConvertToJSON(data, "email", filepath);

            //ToXLT.ConvertToXLT(data, "email", filepath);

            Console.ReadLine();
        }

        private static void HandleMessageReceived(object sender, string args)
        {
            Console.WriteLine($"Event invoked with Message({args})");
        }
    }
}
using ReportGenerator.Workers;
using ReportGenerator.ServerNamespace;
using System.Threading;

namespace ReportGenerator
{
    class Program 
    { 
        public string data = "{\n\"email\":[\n{\n\"type\":\"home\",\n\"name\":\"john.doe@gmail.com\"\n},\n{\n\"type\":\"work\",\n\"name\":\"jdoe@gmail.com\"\n}\n]\n}";

        public static string filepath = "../../../../Reports/";
        public static void Main(string[] args)
        {

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

            //Thread xmlThread = new Thread(new ThreadStart(ToXML.ConvertToXML(args, "email", "../../../../Reports/"));

            Thread xmlThread = new Thread(() => ToXML.ConvertToXML(args, "email", filepath));
            xmlThread.Start();

            Thread csvThread = new Thread(() => ToCSV.ConvertToCSV(args, "email", filepath));
            csvThread.Start();

            //Thread ToXLSX = new Thread(() => ToXLSX.)
            
        }
    }
}
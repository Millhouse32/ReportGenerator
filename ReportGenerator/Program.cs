using ReportGenerator.Workers;
using ReportGenerator.ServerNamespace;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace ReportGenerator
{
    class Program 
    { 
        public static string data = "{\n\"email\":[\n{\n\"type\":\"home\",\n\"name\":\"john.doe@gmail.com\"\n},\n{\n\"type\":\"work\",\n\"name\":\"jdoe@gmail.com\"\n}\n]\n}";

        public static string message = "[{\"PLU\":1,\"Item\":\"Brisket (Trimmed)\",\"Price\":\"8.95\",\"CutType\":\"Briskets\",\"PoundsSold\":135},{\"PLU\":10,\"Item\":\"English Roast (Boneless)\",\"Price\":\"6.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":55.7},{\"PLU\":11,\"Item\":\"Chuck Blade Roasts\",\"Price\":\"6.65\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":285.5},{\"PLU\":12,\"Item\":\"English Roast (Bone-In)\",\"Price\":\"5.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":542.8},{\"PLU\":14,\"Item\":\"Top Round (18-22#)\",\"Price\":\"5.95\",\"CutType\":\"Whole Beef Primals\",\"PoundsSold\":42.1},{\"PLU\":33,\"Item\":\"Corned Beef Brisket\",\"Price\":\"8.95\",\"CutType\":\"Briskets\",\"PoundsSold\":62.8},{\"PLU\":48,\"Item\":\"Strip Steak\",\"Price\":\"13.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":340.7},{\"PLU\":49,\"Item\":\"T-Bone Steak\",\"Price\":\"10.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":340.3},{\"PLU\":65,\"Item\":\"London Broil\",\"Price\":\"7.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":300.4},{\"PLU\":66,\"Item\":\"Tenderloin (Whole 6-7#)\",\"Price\":\"15.95\",\"CutType\":\"Whole Beef Primals\",\"PoundsSold\":162.2},{\"PLU\":67,\"Item\":\"Porterhouse Stek\",\"Price\":\"11.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":323},{\"PLU\":68,\"Item\":\"Sirloin Steak \",\"Price\":\"9.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":317.4},{\"PLU\":69,\"Item\":\"Top Sirloins (Whole 5-6#)\",\"Price\":\"8.95\",\"CutType\":\"Whole Beef Primals\",\"PoundsSold\":565.9},{\"PLU\":70,\"Item\":\"Short Loin (P-House/T-Bones) (18-22#)\",\"Price\":\"8.95\",\"CutType\":\"Whole Beef Primals\",\"PoundsSold\":85.5},{\"PLU\":81,\"Item\":\"Chipped Steaks\",\"Price\":\"9.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":376.5},{\"PLU\":82,\"Item\":\"Prime Rib Roast Rib Eye (Bone In) (16-18#)\",\"Price\":\"10.95\",\"CutType\":\"Whole Beef Primals\",\"PoundsSold\":173.5},{\"PLU\":94,\"Item\":\"Tomahawk Steak\",\"Price\":\"12.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":122.9},{\"PLU\":95,\"Item\":\"Ribeye Steak\",\"Price\":\"11.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":432.5},{\"PLU\":96,\"Item\":\"Delmonico Steak\",\"Price\":\"13.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":57.2},{\"PLU\":106,\"Item\":\"Eye of Round\",\"Price\":\"6.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":149.4},{\"PLU\":107,\"Item\":\"Rump Roast\",\"Price\":\"6.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":154.2},{\"PLU\":108,\"Item\":\"Round Steak\",\"Price\":\"7.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":254.6},{\"PLU\":109,\"Item\":\"Sirloin Tip Roast\",\"Price\":\"6.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":321.8},{\"PLU\":111,\"Item\":\"Brisket (Untrimmed)\",\"Price\":\"6.49\",\"CutType\":\"Briskets\",\"PoundsSold\":352.3},{\"PLU\":123,\"Item\":\"Chuck Roast (Boneless)\",\"Price\":\"5.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":549.6},{\"PLU\":124,\"Item\":\"Beef Tenderloin (Filets)\",\"Price\":\"22.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":479.5},{\"PLU\":141,\"Item\":\"Ground Chuck\",\"Price\":\"4.95\",\"CutType\":\"Ground Chuck\",\"PoundsSold\":475.8},{\"PLU\":142,\"Item\":\"Ground Round\",\"Price\":\"5.95\",\"CutType\":\"Ground Round\",\"PoundsSold\":180.9},{\"PLU\":143,\"Item\":\"Chuck Patties (Frozen)\",\"Price\":\"24.75\",\"CutType\":\"Beef Patties\",\"PoundsSold\":479},{\"PLU\":144,\"Item\":\"Ground Sirloin\",\"Price\":\"7.25\",\"CutType\":\"Ground Round\",\"PoundsSold\":242},{\"PLU\":147,\"Item\":\"Sirloin Patties\",\"Price\":\"5.95\",\"CutType\":\"Beef Patties\",\"PoundsSold\":145.9},{\"PLU\":154,\"Item\":\"Burgundy Marinated Steaks\",\"Price\":\"9.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":208.6},{\"PLU\":169,\"Item\":\"Brisket Burgers\",\"Price\":\"6.95\",\"CutType\":\"Beef Patties\",\"PoundsSold\":192.3},{\"PLU\":362,\"Item\":\"Stew Meat\",\"Price\":\"9.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":444},{\"PLU\":370,\"Item\":\"Liver\",\"Price\":\"4.99\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":125.3},{\"PLU\":488,\"Item\":\"Strip Loin (Whole 11-13#)\",\"Price\":\"9.95\",\"CutType\":\"Whole Beef Primals\",\"PoundsSold\":116.9},{\"PLU\":491,\"Item\":\"T-Bone\",\"Price\":\"14.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":100.8},{\"PLU\":494,\"Item\":\"Boneless English Roast\",\"Price\":\"9.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":398.5},{\"PLU\":650,\"Item\":\"Short Ribs\",\"Price\":\"9.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":338.9},{\"PLU\":651,\"Item\":\"Flank Steak\",\"Price\":\"11.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":390.1},{\"PLU\":652,\"Item\":\"Soup Bones\",\"Price\":\"3.99\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":454.2},{\"PLU\":653,\"Item\":\"Shank (Bone-In)\",\"Price\":\"6.49\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":420.3},{\"PLU\":654,\"Item\":\"Back Ribs\",\"Price\":\"8.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":300.5},{\"PLU\":661,\"Item\":\"Tenderloin (Individual)\",\"Price\":\"23.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":419.9},{\"PLU\":671,\"Item\":\"Porterhouse\",\"Price\":\"15.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":113.6},{\"PLU\":673,\"Item\":\"Blade Roast\",\"Price\":\"7.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":427.1},{\"PLU\":674,\"Item\":\"Ribeye\",\"Price\":\"15.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":213.2},{\"PLU\":676,\"Item\":\"Rump Roast\",\"Price\":\"9.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":446.9},{\"PLU\":682,\"Item\":\"Sirloin Steak\",\"Price\":\"11.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":330},{\"PLU\":961,\"Item\":\"Delmonico Whole (14-16#)\",\"Price\":\"12.95\",\"CutType\":\"Whole Beef Primals\",\"PoundsSold\":413.8},{\"PLU\":1082,\"Item\":\"Round Steak\",\"Price\":\"8.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":386.6},{\"PLU\":1091,\"Item\":\"Tri Tip\",\"Price\":\"8.95\",\"CutType\":\"Beef Roasts\",\"PoundsSold\":405.7},{\"PLU\":1143,\"Item\":\"Chuck Patties (Fresh)\",\"Price\":\"5.49\",\"CutType\":\"Beef Patties\",\"PoundsSold\":255.9},{\"PLU\":1411,\"Item\":\"Ground Chuck -5# or More\",\"Price\":\"4.85\",\"CutType\":\"Ground Chuck\",\"PoundsSold\":635.2},{\"PLU\":1412,\"Item\":\"Ground Chuck -10# or More\",\"Price\":\"4.75\",\"CutType\":\"Ground Chuck\",\"PoundsSold\":475.8},{\"PLU\":1413,\"Item\":\"Ground Chuck - 20# or More\",\"Price\":\"4.65\",\"CutType\":\"Ground Chuck\",\"PoundsSold\":350.5},{\"PLU\":1414,\"Item\":\"Ground Chuck - 50# or More\",\"Price\":\"4.65\",\"CutType\":\"Ground Chuck\",\"PoundsSold\":358.7},{\"PLU\":1422,\"Item\":\"Ground Round - 5# or more\",\"Price\":\"5.85\",\"CutType\":\"Ground Round\",\"PoundsSold\":172.3},{\"PLU\":1423,\"Item\":\"Ground Round - 10# or more\",\"Price\":\"5.75\",\"CutType\":\"Ground Round\",\"PoundsSold\":394},{\"PLU\":1431,\"Item\":\"Ground Chuck -2# Frozen Pack\",\"Price\":\"7.95\",\"CutType\":\"Ground Chuck\",\"PoundsSold\":211.6},{\"PLU\":1432,\"Item\":\"Bulk (Ground Beef)\",\"Price\":\"7.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":1348.4},{\"PLU\":1434,\"Item\":\"Seasoned Patties\",\"Price\":\"24.75\",\"CutType\":\"Beef Patties\",\"PoundsSold\":176.1},{\"PLU\":1439,\"Item\":\"Patties\",\"Price\":\"8.95\",\"CutType\":\"Grass Fed Beef\",\"PoundsSold\":326.3},{\"PLU\":1552,\"Item\":\"Burgundy Marinated Filets\",\"Price\":\"11.95\",\"CutType\":\"Beef Steaks\",\"PoundsSold\":180.8},{\"PLU\":2434,\"Item\":\"6 oz. Seasoned Patties\",\"Price\":\"5.49\",\"CutType\":\"Beef Patties\",\"PoundsSold\":298},{\"PLU\":4446,\"Item\":\"Hind Quarter Grass Fed\",\"Price\":\"4.69\",\"CutType\":\"Sides and Hindquarters\",\"PoundsSold\":2295.5},{\"PLU\":4545,\"Item\":\"Half Grass Fed\",\"Price\":\"3.99\",\"CutType\":\"Sides and Hindquarters\",\"PoundsSold\":2011.4},{\"PLU\":8566,\"Item\":\"Half Beef (300-400lb.)\",\"Price\":\"3.69\",\"CutType\":\"Sides and Hindquarters\",\"PoundsSold\":1541.1},{\"PLU\":8567,\"Item\":\"Hind Quarter (200-200lb.)\",\"Price\":\"4.39\",\"CutType\":\"Sides and Hindquarters\",\"PoundsSold\":1841.1},{\"PLU\":123456,\"Item\":\"test\",\"Price\":\"5.55\",\"CutType\":\"testtype\",\"PoundsSold\":0}]";
        public static string filepath = "C:\\Users\\ac39437\\ReportGenerator\\ReportGenerator\\Reports\\";
        public static string filename = "Generated-Report-";
        public static void Main(string[] args)
        {

            Server server = new Server();

            Server.MessageReceived += new EventHandler<string>(HandleMessageReceived);

            //ToXML.ConvertToXML(Program.data, "email", filepath);

            //ToCSV.ConvertToCSV(data, "email", filepath);

            //ToXLSX.ConvertToXLSX(data, "email", filepath);

            //ToXLSM.ConvertToXLSM(data, "email", filepath);

            //ToJSON.ConvertToJSON(data, "email", filepath);

            //ToXLT.ConvertToXLT(data, "email", filepath);

            Console.ReadLine();
        }

        private static void HandleMessageReceived(object sender, string args)
        {

            if (args.IndexOf("filename") != -1)
            {
                int length = (args.Length - 3) - args.IndexOf(":") + 1;
                filename += args.Substring(args.IndexOf(":") + 1, length);
            }

            else
            {
                Thread xmlThread = new Thread(() => ToXML.ConvertToXML(args, filename, filepath));
                xmlThread.Start();

                Thread csvThread = new Thread(() => ToCSV.ConvertToCSV(args, filename, filepath));
                csvThread.Start();

                Thread xlsxThread = new Thread(() => ToXLSX.ConvertToXLSX(args, filename, filepath));
                xlsxThread.Start();

                Thread jsonThread = new Thread(() => ToJSON.ConvertToJSON(args, filename, filepath));
                jsonThread.Start();

                Thread xltTread = new Thread(() => ToXLT.ConvertToXLT(args, filename, filepath));
                xltTread.Start();

                Thread xlsmThread = new Thread(() => ToXLSM.ConvertToXLSM(args, filename, filepath));
                xlsmThread.Start();
            }
        }
    }
}
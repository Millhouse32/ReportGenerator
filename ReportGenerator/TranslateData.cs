using System;
using System.Threading;
using ReportGenerator.Workers;

namespace ReportGenerator
{
    /// <summary>
    /// This class is responsible translating the data in a parallel fashion
    /// </summary>
    public class TranslateData
    {
        public TranslateData(string json, string filename, string filepath)
        {
            //Thread CSVThread = new ThreadStart(ToCSV.ConvertToCSV(json, filename, filepath));
        }
    }
}
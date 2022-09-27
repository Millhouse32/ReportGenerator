using Aspose.Cells;
using Aspose.Cells.Utility;

namespace ReportGenerator.Workers
{
    /// <summary>
    /// Worker class to support csv translation
    /// </summary>
    public static class ToCSV
    {
        /// <summary>
        /// Method that converts json string, converts it to csv and outputs it to file
        /// </summary>
        /// <param name="json">json string</param>
        /// <param name="filename">output file</param>
        public static void ConvertToCSV(string json, string filename, string filepath)
        {
            // appending correct .csv extension to filename
            string csv = ".csv";

            // create csv work book
            var workbook = new Workbook();

            /// create sheet inside workbook
            var worksheet = workbook.Worksheets[0];

            /// sets worksheet name to filename without extension
            worksheet.Name = filename;

            /// defines layout options
            var layoutOptions = new JsonLayoutOptions();

            layoutOptions.ArrayAsTable = true;

            /// save object
            XlsSaveOptions saveOptions = new XlsSaveOptions(SaveFormat.Csv);

            /// allows the cretion of new directory if does not exist
            saveOptions.CreateDirectory = true;

            /// imports json to workbook
            JsonUtility.ImportData(json, worksheet.Cells, 0, 0, layoutOptions);

            //. outputs workbook to file
            workbook.Save(filepath+filename+csv, saveOptions);  
        }
    }
}
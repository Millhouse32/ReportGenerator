using Aspose.Cells;
using Aspose.Cells.Utility;

namespace ReportGenerator.Workers
{
    /// <summary>
    /// Worker class to support xlt translation
    /// </summary>
    public static class ToXLT
    {
        /// <summary>
        /// Method that converts json string, converts it to xlt and outputs it to file
        /// </summary>
        /// <param name="json">json string</param>
        /// <param name="filename">output file</param>
        public static void ConvertToXLT(string json, string filename, string filepath)
        {
            // appending correct .xlt extension to filename
            string xlt = ".xlt";

            // create xlt work book
            var workbook = new Workbook();

            /// create sheet inside workbook
            var worksheet = workbook.Worksheets[0];

            /// sets worksheet name to filename without extension
            worksheet.Name = filename;

            /// defines layout options
            var layoutOptions = new JsonLayoutOptions();

            layoutOptions.ArrayAsTable = true;

            /// save object
            XlsSaveOptions saveOptions = new XlsSaveOptions(SaveFormat.Xlt);

            /// allows the creation of a directory if does not exist
            saveOptions.CreateDirectory = true;

            /// imports json to workbook
            JsonUtility.ImportData(json, worksheet.Cells, 0, 0, layoutOptions);

            /// outputs workbook to file
            workbook.Save(filepath + filename + xlt, saveOptions);

            /// tells user file has been created
            Console.WriteLine(filename + xlt + " created!");
        }
    }
}
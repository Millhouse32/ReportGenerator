using Aspose.Cells;
using Aspose.Cells.Utility;

namespace ReportGenerator.Workers
{
    /// <summary>
    /// Worker class to support xlsx translation
    /// </summary>
    public static class ToXLSX
    {
        /// <summary>
        /// Method that converts json string, converts it to xlsx and outputs it to file
        /// </summary>
        /// <param name="json">json string</param>
        /// <param name="filename">output file</param>
        public static void ConvertToXLSX(string json, string filename, string filepath)
        {
            // appending correct .xlsx extension to filename
            string xlsx = ".xlsx";

            // create xlsx work book
            var workbook = new Workbook();

            /// create sheet inside workbook
            var worksheet = workbook.Worksheets[0];

            /// sets worksheet name to filename without extension
            worksheet.Name = filename;

            /// defines layout options
            var layoutOptions = new JsonLayoutOptions();

            layoutOptions.ArrayAsTable = true;

            /// save object
            XlsSaveOptions saveOptions = new XlsSaveOptions(SaveFormat.Xlsx);

            /// allows the creation of a directory if does not exist
            saveOptions.CreateDirectory = true;

            /// imports json to workbook
            JsonUtility.ImportData(json, worksheet.Cells, 0, 0, layoutOptions);

            /// outputs workbook to file
            workbook.Save(filepath + filename + xlsx, saveOptions);

            /// tells user file has been created
            Console.WriteLine(filename + xlsx + " created!");
        }
    }
}
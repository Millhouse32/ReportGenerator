using Aspose.Cells;
using Aspose.Cells.Utility;

namespace ReportGenerator.Workers
{
    public static class ToXLSX
    {
        public static void ConvertToXLSX(string json, string filename)
        {
            filename += ".Xlsx";

            var workbook = new Workbook();

            var worksheet = workbook.Worksheets[0];

            var layoutOptions = new JsonLayoutOptions();

            layoutOptions.ArrayAsTable = true;

            JsonUtility.ImportData(json, worksheet.Cells, 0, 0, layoutOptions);

            workbook.Save(filename, SaveFormat.Xlsx);  
        }
    }
}
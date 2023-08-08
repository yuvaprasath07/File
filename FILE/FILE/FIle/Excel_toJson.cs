using Aardvark.Base;
using iTextSharp.text;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FILE.FIle
{
    public class Excel_toJson
    {


        public void ExcelConvertJson()
        {
            string excelFilePath = @"\\192.168.0.5\vaf\task\EXCEL\task.xlsx";

            string outputJsonPath = @"\\192.168.0.5\vaf\task\JSON\out.json";

            List<Dictionary<string, object>> jsonData = new List<Dictionary<string, object>>();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++) // Assuming header is in the first row
                {
                    var rowData = new Dictionary<string, object>();

                    for (int col = 1; col <= colCount; col++)
                    {
                        string header = worksheet.Cells[1, col].Value.ToString();
                        object value = worksheet.Cells[row, col].Value;
                        rowData[header] = value;
                    }

                    jsonData.Add(rowData);
                }
            }

            string jsonOutput = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            File.WriteAllText(outputJsonPath, jsonOutput);

            Console.WriteLine("Excel data converted to JSON.");
        }
    }
}

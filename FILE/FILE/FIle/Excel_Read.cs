using FILE.PepoleModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FILE.FIle
{
    public class Excel_Read
    {
        public void excelRead()
        {
            string virtualPath = @"\\192.168.0.115\vaf\New folder\sam.json";
            string jsonread = File.ReadAllText(virtualPath);
            List<sample> json = JsonConvert.DeserializeObject<List<sample>>(jsonread);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells.LoadFromCollection(json, true);

                FileInfo excelFile = new FileInfo("D:\\Csharpwork\\CSharpTask\\OutPut.xlsx");
                package.SaveAs(excelFile);
            }

            Console.WriteLine("Excel file created successfully.");
        }
    }
}



//using (var package = new ExcelPackage())
//     {
//         ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("SampleData");

//         worksheet.Cells[1, 1].Value = "AgencyId";
//         worksheet.Cells[1, 2].Value = "AgencyName";
//         worksheet.Cells[1, 3].Value = "AgencyCode";
//         worksheet.Cells[1, 4].Value = "RegistrationKey";
//         worksheet.Cells[1, 5].Value = "IsExternalAgency";
//         worksheet.Cells[1, 6].Value = "IsActive";
//         worksheet.Cells[1, 7].Value = "SalesForceID";
//         worksheet.Cells[1, 8].Value = "CreatedBy";
//         worksheet.Cells[1, 9].Value = "CreateDate";
//         worksheet.Cells[1, 10].Value = "LastModifiedBy";
//         worksheet.Cells[1, 11].Value = "LastModifyDate";

//         int rowIndex = 2;
//         foreach (var item in json)
//         {
//             worksheet.Cells[rowIndex, 1].Value = item.AgencyId;
//             worksheet.Cells[rowIndex, 2].Value = item.AgencyName;
//             worksheet.Cells[rowIndex, 3].Value = item.AgencyCode;
//             worksheet.Cells[rowIndex, 4].Value = item.RegistrationKey;
//             worksheet.Cells[rowIndex, 5].Value = item.IsExternalAgency;
//             worksheet.Cells[rowIndex, 6].Value = item.IsActive;
//             worksheet.Cells[rowIndex, 7].Value = item.SalesForceID?.ToString();
//             worksheet.Cells[rowIndex, 8].Value = item.CreatedBy;
//             worksheet.Cells[rowIndex, 9].Value = item.CreateDate;
//             worksheet.Cells[rowIndex, 10].Value = item.LastModifiedBy?.ToString();
//             worksheet.Cells[rowIndex, 11].Value = item.LastModifyDate?.ToString();

//             rowIndex++;
//         }
//         FileInfo file = new FileInfo("D:\\Csharpwork\\CSharpTask\\SampleData.xlsx");
//         package.SaveAs(file);
//     }
//     Console.WriteLine("Excel file created successfully.");*/
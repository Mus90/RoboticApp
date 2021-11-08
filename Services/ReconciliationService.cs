
using OfficeOpenXml;
using OfficeOpenXml.Table;
using RoboticApp.Models;
using RoboticApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RoboticApp.Services
{
    public class ReconciliationService
    {
        
        public List<FileModelView> ReadFile(string path, IFileStructure headers)
        {
            var fi = new FileInfo(path);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(fi))
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.First();
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;
                List<FileModelView> data = new List<FileModelView>();
                

                for (int row = 2; row <= rowCount; row++)
                {
                    FileModelView line = new FileModelView();
                    for (int col = 1; col <= colCount; col++)
                    {
                        if (col == headers.Amount)
                        {
                            line.Amount = worksheet.Cells[row, col].Value?.ToString().Trim();
                        }
                        if (col == headers.ClientName)
                        {
                            line.ClientName = worksheet.Cells[row, col].Value?.ToString().Trim();
                        }
                        if (col == headers.TransactionDate)
                        {
                            line.TransactionDate = worksheet.Cells[row, col].Value?.ToString().Trim();
                        }
                        if (col == headers.TransactionTime)
                        {
                            line.TransactionTime = worksheet.Cells[row, col].Value?.ToString().Trim();
                        }
                    }

                    data.Add(line);
                }
                return data;
            }
        }

        public void WriteFile(string path,List<OutputFileModelView> outputList)
        {
            using (ExcelPackage pck = new ExcelPackage(path))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                ws.Cells["A1"].LoadFromCollection<OutputFileModelView>(outputList.ToList(), true);
                pck.Save();
            }
        }
    }
        // Do reconciliation
        // write excel file 
    
}

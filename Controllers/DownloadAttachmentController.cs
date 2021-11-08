using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RoboticApp.Models;
using RoboticApp.Models.Enum;
using RoboticApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RoboticApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadAttachmentController : ControllerBase
    {
        [HttpGet("ReadExcelFile")]
        public void ReadExcelFile()
        {
            var outputlist = new List<OutputFileModelView>(); 
            var fileA = new ReconciliationService().ReadFile(@"/Users/mustafa/Downloads/FileA.xlsx", new FileAStructure());
            var fileB = new ReconciliationService().ReadFile(@"/Users/mustafa/Downloads/FileB.xlsx", new FileBStructure());
            
            foreach (var lineInFileB in fileB.Select(x => new { x.Amount, x.ClientName, x.TransactionTime }))
            {
                string status = "Fail";
                foreach (var lineInFileA in fileA.Select(x => new { x.Amount, x.ClientName, x.TransactionTime }))
                {
                    status = "Fail";
                    if (lineInFileB.Amount == lineInFileA.Amount &&
                        lineInFileB.ClientName == lineInFileA.ClientName &&
                        lineInFileB.TransactionTime == lineInFileA.TransactionTime)
                    {
                        status = "Success";
                        break;
                    }
                    
                }

                var data = fileB.FirstOrDefault(u => u.Amount == lineInFileB.Amount &&
                            u.ClientName == lineInFileB.ClientName &&
                            u.TransactionTime == lineInFileB.TransactionTime);
                var outputItem = new OutputFileModelView
                {
                    Amount = data.Amount,
                    ClientName = data.ClientName,
                    TransactionDate = data.TransactionDate,
                    TransactionTime = data.TransactionTime,
                    Status = status
                };

                outputlist.Add(outputItem);

                
            }
            new ReconciliationService().WriteFile(@"/Users/mustafa/Downloads/MYOUTPUT.xlsx", outputlist);
        }
    }
}

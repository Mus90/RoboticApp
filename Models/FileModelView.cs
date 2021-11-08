using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoboticApp.Models
{
    public class FileModelView
    {
        [Description("Amount")]
        public string Amount { get; set; }
        [Description("Client Name")]
        public string ClientName{ get; set; }
        [Description("Transaction Date")]
        public string TransactionDate{ get; set; }
        [Description("Transaction Time")]
        public string TransactionTime{ get; set; }
    }
}

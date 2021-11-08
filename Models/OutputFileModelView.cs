using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RoboticApp.Models
{
    public class OutputFileModelView
    {
        [Description("Amount")]
        public string Amount { get; set; }
        [Description("Client Name")]
        public string ClientName { get; set; }
        [Description("Transaction Date")]
        public string TransactionDate { get; set; }
        [Description("Transaction Time")]
        public string TransactionTime { get; set; }
        public string Status { get; set; }
    }
}

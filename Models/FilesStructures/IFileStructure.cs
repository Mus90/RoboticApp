namespace RoboticApp.Models.Enum
{
    public interface IFileStructure
    {
        public int Amount { get; }
        public int ClientName { get; }
        public int TransactionDate {get; }
        public int TransactionTime {get; }
        public int Status {get; }
    }
}

using System;

namespace RoboticApp.Models.Enum
{
    public class FileBStructure : IFileStructure
    {
        int IFileStructure.Amount => 3;

        int IFileStructure.ClientName => 2;

        int IFileStructure.TransactionDate => 1;

        int IFileStructure.TransactionTime => 4;

        int IFileStructure.Status => throw new NotImplementedException();
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboticApp.Models.Enum
{
    public class FileAStructure : IFileStructure
    {
        int IFileStructure.Amount => 1;

        int IFileStructure.ClientName => 2;

        int IFileStructure.TransactionDate => 3;

        int IFileStructure.TransactionTime => 4;

        int IFileStructure.Status => throw new NotImplementedException();
    }
}

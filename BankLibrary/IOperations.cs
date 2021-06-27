using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    interface IOperations
    {
        void Put(decimal sum);
        void Withdraw(decimal sum);
        void OpenAccount();
        void CloseAccount();
        void TransferMoneyToAnotherAccount();
    }
}

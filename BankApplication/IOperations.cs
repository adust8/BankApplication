using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Windows.Страницы_MainMenu.Способы_платежа;
using BankApplication.Windows.Страницы_MainMenu.Способы_перевода;
using BankApplication.Windows;

namespace BankApplication
{
    interface IOperations
    {
        
        void CreateAccount(OpenAccount window);
        void DeleteAccount(DeleteAccountWindow window);

        void PutMoneyWithAccountNumber(FromAccount window);
        void PutMoneyWithPhoneNumber(WithPhoneNumber window);

        void TransferMoneyWithAccountNumber(Account window);
        void TransferMoneyWithPhoneNumber(Phone window);
        bool FieldsChecker(string a, string b);
    }
}

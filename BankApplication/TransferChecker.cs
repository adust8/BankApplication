using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Tables;
using Microsoft.EntityFrameworkCore;
using BankApplication.Windows.Страницы_MainMenu.Способы_платежа;
using BankApplication.Windows.Страницы_MainMenu.Способы_перевода;
using System.Windows;
using BankApplication.Windows;
namespace BankApplication
{
    public static class TransferChecker
    {
        public static bool PhoneOtherSymbolsChecker(string from,string to)
        {
            char[] array1 = from.ToCharArray();
            char[] array2 = to.ToCharArray();
            for (int i = 1; i < from.Length; i++)
            {
                if (!char.IsDigit(array1[i]) || !char.IsDigit(array2[i]))

                    return false;
            }
            return true;
        }
        #region Проверки по номеру телефона
        public static bool FromPhoneTransferCheck(string from,string to,string sum)
        {
            char[] array1 = from.ToCharArray();
            char[] array2 = to.ToCharArray();
            char[] array3 = sum.ToCharArray();

            if ((array1.Length == 12 && array1[0] == '+' && array1[1] == '7') && (array2.Length == 12 && array2[0] == '+' && array2[1] == '7'))
            {
                if (PhoneOtherSymbolsChecker(from, to))
                {
                    if (sum.All(char.IsDigit)) return true;
                    else return false;
                }
                else return false;
                
            }
                
            else
            {
                MessageBox.Show("Заполните \"Номер телефона\" в правильном формате (+7) или проверьте правильность заполнения данного поля.");
                return false;
            }                      
        }
        #endregion
    }
}

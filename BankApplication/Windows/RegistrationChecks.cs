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

namespace BankApplication.Windows
{
    public static  class RegistrationChecks
    {
        static public bool NullOrWhiteSpaceChecker(SignUp signUpWindow)
        {
            if (string.IsNullOrWhiteSpace(signUpWindow.surnameTextBox.Text) || string.IsNullOrWhiteSpace(signUpWindow.nameTextBox.Text) || string.IsNullOrWhiteSpace(signUpWindow.patronymicTextBox.Text) || string.IsNullOrWhiteSpace(signUpWindow.birthDateTextBox.Text) || string.IsNullOrWhiteSpace(signUpWindow.loginTextBox.Text)  || string.IsNullOrWhiteSpace(signUpWindow.passwordTextBox.Password) || string.IsNullOrWhiteSpace(signUpWindow.repeatPasswordTextBox.Password) || string.IsNullOrWhiteSpace(signUpWindow.phoneNumberTextBox.Text) || string.IsNullOrWhiteSpace(signUpWindow.emailTextBox.Text))
            {
                return true;
            }
            else return false;
        }

        static public bool PhoneLengthAndFormatChecker(SignUp window,string a)
        {
            char[] array = a.ToCharArray();
            if (array[0] == '+' && array[1] == '7' && array.Length == 12) return true;
            else return false;
        }

        static public bool PhoneLengthAndFormatChecker(string a)
        {
            char[] array = a.ToCharArray();
            if (array[0] == '+' && array[1] == '7' && array.Length == 12) return true;
            else return false;
        }

        static public bool PhoneNumberExistingChecker(SignUp window)
        {
            using (BankAppContext db = new())
            {
                var account = db.Users.Where(c => c.PhoneNumber == window.phoneNumberTextBox.Text).ToList();
                if (account.Any())
                    return false;
                else return true;
            }
        }

        static public bool BirthDateChecker(SignUp window,string a)
        {
            var today = DateTime.Today;
            var birthDate = Convert.ToDateTime(a);
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            if (age >= 18) return true;
            else return false;

        }

        static public bool PhoneOtherSymbolsChecker(SignUp window,string a)
        {
            char[] array = a.ToCharArray();
            for (int i = 1; i < a.Length; i++)
            {
                if (!char.IsDigit(array[i]))

                    return false;
            }
            return true;
        }

        static public bool PhoneOtherSymbolChecker(string a)
        {
            char[] array = a.ToCharArray();
            for (int i = 1; i < a.Length; i++)
            {
                if (!char.IsDigit(array[i]))

                    return false;
            }
            return true;
        }

        static public bool OtherSymbolsChecker(SignUp window)
        {
            if (window.nameTextBox.Text.All(char.IsLetter) && window.surnameTextBox.Text.All(char.IsLetter) && window.patronymicTextBox.Text.All(char.IsLetter) && window.surnameTextBox.Text.All(char.IsLetter))   return true;
            else return false;
        }       

        static public bool LoginChecker(SignUp window)
        {
            using (BankAppContext db = new())
            {
                var list = db.LoginsAndPasswords.Where(c => c.Login == window.loginTextBox.Text);
                if (list.Any()) return false;
                else return true;
                    
                    
            }
            
        }

        static public bool PasswordChecker(SignUp signUpWindow)
        {
            if(signUpWindow.passwordTextBox.Password == signUpWindow.repeatPasswordTextBox.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary;
using DatabaseLibrary.Tables;
using Microsoft.EntityFrameworkCore;
using BankApplication.Windows.Страницы_MainMenu.Способы_платежа;
using BankApplication.Windows.Страницы_MainMenu.Способы_перевода;
using System.Windows;
using BankApplication.Windows;




namespace BankApplication
{
    public class Operations:IOperations
    {

         
        public bool FieldsChecker(string a,string b)
        {
            if (Int32.TryParse(a, out int num) && Int32.TryParse(b, out int sum))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Некорректно заполнены поля.");
                return false;
            }
        }

        public bool FieldsChecker(string a)
        {
            if (Int32.TryParse(a, out int num))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Некорректно заполнены поля.");
                return false;
            }
        }

        public bool FieldsChecker(string a, string b,string c)
        {
            if (Int32.TryParse(a, out int toAccount) && Int32.TryParse(b, out int fromAccount) && Int32.TryParse(c, out int sum))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Некорректно заполнены поля.");
                return false;
            }
        }

        public void CreateAccount(OpenAccount window)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(window.accountTypeComboBox.SelectedItem)))
            {
                MessageBox.Show("Выберите тип счёта");
            }
            else
            {                
                ulong accountNumber = 0;
                if (window.accountTypeComboBox.SelectedIndex == 0)
                {
                    using (BankAppContext db = new())
                    {
                        var number = db.AccountNumbers.FromSqlRaw("SELECT * FROM AccountNumbers WHERE account_id = 1").ToList();
                        foreach (var item in number)
                        {
                            accountNumber = item.AccountNumber;
                        }

                        var accounts = db.Accounts.Where(c => c.AccountPhoneNumber == window.phoneNumberTextBox.Text).ToList();

                        if (accounts.Any())
                        {
                            MessageBox.Show("Такой телефонный номер уже привязан к счёту");
                        }
                        else
                        {
                            if (RegistrationChecks.PhoneOtherSymbolChecker(window.phoneNumberTextBox.Text) && RegistrationChecks.PhoneLengthAndFormatChecker(window.phoneNumberTextBox.Text))
                            {
                                DateTime now = DateTime.Now;
                                accountNumber++;
                                db.Accounts.Add(new AccountDB() { Balance = 0, UserId = UserInfo.UserId, AccountTypeId = 1, AccountIdentificationNumber = accountNumber, AccountPhoneNumber = window.phoneNumberTextBox.Text,CreatingAccountDate = DateTime.Now,NextReplenishment = now.AddYears(1)});
                                db.SaveChanges();
                                MessageBox.Show($"Успех! Вы открыли счёт \"{window.accountTypeComboBox.SelectedItem}\", номер Вашего счёта: {accountNumber}, номер телефона: {window.phoneNumberTextBox.Text}");

                                int command = db.Database.ExecuteSqlRaw($"UPDATE AccountNumbers SET account_number={accountNumber}");
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Заполните корректно поля.");
                            
                        }


                    }
                }
                else
                {
                    using (BankAppContext db = new())
                    {
                        var number = db.AccountNumbers.FromSqlRaw("SELECT * FROM AccountNumbers").ToList();
                        foreach (var item in number)
                        {
                            accountNumber = item.AccountNumber;
                        }

                        var accounts = db.Accounts.Where(c => c.AccountPhoneNumber == window.phoneNumberTextBox.Text).ToList();

                        if (accounts.Any())
                        {
                            MessageBox.Show("Такой телефонный номер уже привязан к счёту");
                        }

                        else
                        {
                            if (RegistrationChecks.PhoneOtherSymbolChecker(window.phoneNumberTextBox.Text) && RegistrationChecks.PhoneLengthAndFormatChecker(window.phoneNumberTextBox.Text))
                            {
                                DateTime date = DateTime.Now;
                                accountNumber++;
                                db.Accounts.Add(new AccountDB() { Balance = 0, UserId = UserInfo.UserId, AccountTypeId = 2, AccountIdentificationNumber = accountNumber, AccountPhoneNumber = window.phoneNumberTextBox.Text, CreatingAccountDate = DateTime.Now,NextReplenishment = date.AddYears(1) });
                                db.SaveChanges();
                                MessageBox.Show($"Успех! Вы открыли счёт \"{window.accountTypeComboBox.SelectedItem}\", номер Вашего счёта: {accountNumber}, номер телефона: {window.phoneNumberTextBox.Text}");

                                int command = db.Database.ExecuteSqlRaw($"UPDATE AccountNumbers SET account_number={accountNumber}");
                                db.SaveChanges();
                            }
                                else MessageBox.Show("Заполните корректно поля.");
                        }


                    }


                }
            }
        }

        public void DeleteAccount(DeleteAccountWindow window)
        {
            if (string.IsNullOrWhiteSpace(window.accountNumber.Text))
            {
                MessageBox.Show("Заполните все поля.");
            }
            else
            {
                if (window.accountNumber.Text.All(char.IsDigit))
                {
                    using (BankAppContext db = new())
                    {
                        var accounts = db.Accounts.Where(c => c.UserId == UserInfo.UserId && c.AccountIdentificationNumber == Convert.ToUInt64(window.accountNumber.Text)).ToList();
                        if (accounts.Any())
                        {
                            var command = db.Database.ExecuteSqlRaw($"DELETE FROM Accounts WHERE account_id_number={window.accountNumber.Text}");
                            db.SaveChanges();
                            MessageBox.Show($"Счёт \"{window.accountNumber.Text}\" закрыт.");

                        }
                        else MessageBox.Show("Ошибка, проверьте введённые данные и попробуйте снова.");
                    }
                }
                else MessageBox.Show("Корретно заполните поля.");
                

            }
        }

        public void PutMoneyWithAccountNumber(FromAccount window)
        {
            decimal currentBalance = 0;
            decimal newBalance;
            

            if (string.IsNullOrWhiteSpace(window.accountNumberTextBox.Text) || string.IsNullOrWhiteSpace(window.sumTextBox.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                using (BankAppContext db = new())
                {
                    if (FieldsChecker(window.accountNumberTextBox.Text,window.sumTextBox.Text))
                    {
                        var accounts = db.Accounts.Where(c => c.AccountIdentificationNumber == Convert.ToUInt64(window.accountNumberTextBox.Text) && c.UserId == UserInfo.UserId).ToList();

                        //db.Accounts.FromSqlRaw($"SELECT * FROM Accounts WHERE account_id_number = {Convert.ToInt32(accountNumberTextBox.Text)} AND account_user_id={UserInfo.UserId}").ToList();

                        //проверку если сумма больше баланса
                        if (accounts.Any())
                        {
                            foreach (var item in accounts)
                            {
                                currentBalance = Convert.ToDecimal(item.Balance);
                            }

                            newBalance = currentBalance + Convert.ToDecimal(window.sumTextBox.Text);

                            IEnumerable<AccountDB> account = db.Accounts.Where(c => c.AccountIdentificationNumber == Convert.ToUInt64(window.accountNumberTextBox.Text)).AsEnumerable().Select(c => { c.Balance = newBalance; return c; });

                            foreach (var item in account)
                            {
                                db.Entry(item).State = EntityState.Modified;
                            }
                            db.SaveChanges();

                            MessageBox.Show($"Счёт \"{window.accountNumberTextBox.Text}\" пополнен на {window.sumTextBox.Text} рублей.");
                        }

                        else MessageBox.Show("Такого счёта не существует.");

                    }
                }
            }
        }

        public void PutMoneyWithPhoneNumber(WithPhoneNumber window)
        {
            decimal currentBalance = 0;
            decimal newBalance;
            decimal currentAccountNumber=0;

            if (string.IsNullOrWhiteSpace(window.accountNumberTextBox.Text) || (string.IsNullOrWhiteSpace(window.sumTextBox.Text)))
            {
                MessageBox.Show("Заполните все поля.");
            }
            else
            {
                if(FieldsChecker(window.sumTextBox.Text))
                {
                    using (BankAppContext db = new())
                    {
                        var accounts = db.Accounts.Where(c => c.AccountPhoneNumber == window.accountNumberTextBox.Text && c.UserId == UserInfo.UserId).ToList();
                        if (accounts.Any())
                        {
                            foreach (var item in accounts)
                            {
                                currentBalance = item.Balance;
                                currentAccountNumber = item.AccountIdentificationNumber;
                            }
                            newBalance = currentBalance + Convert.ToDecimal(window.sumTextBox.Text);
                            IEnumerable<AccountDB> account = db.Accounts.Where(c => c.AccountPhoneNumber == window.accountNumberTextBox.Text && c.UserId == UserInfo.UserId).AsEnumerable().Select(c => { c.Balance = newBalance; return c; });

                            foreach (var item in account)
                            {
                                db.Entry(item).State = EntityState.Modified;
                            }
                            db.SaveChanges();
                            MessageBox.Show($"Счёт \"{currentAccountNumber}\" пополнен на {window.sumTextBox.Text} рублей.");

                        }
                        else MessageBox.Show("Ошибка пополнения, проверьте введённые данные и повторите ещё раз");


                    }
                }
                
                
            }
            
        }

        public void TransferMoneyWithAccountNumber(Account window)
        {
            decimal fromAccountCurrentBalance = 0, fromAccountNewBalance;
            decimal toAccountCurrentBalance = 0, toAccountNewBalance;
            

            if (string.IsNullOrWhiteSpace(window.fromAccountTextBox.Text) || string.IsNullOrWhiteSpace(window.toAccountTextBox.Text) || string.IsNullOrWhiteSpace(window.sumTextBox.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                if(FieldsChecker(window.fromAccountTextBox.Text,window.toAccountTextBox.Text,window.sumTextBox.Text))
                {
                    using (BankAppContext db = new())
                    {
                        #region Баланс счёта списания
                        var fromAccounts = db.Accounts.Where(c => c.UserId == UserInfo.UserId && c.AccountIdentificationNumber == Convert.ToUInt64(window.fromAccountTextBox.Text)).ToList();
                        foreach (var item in fromAccounts)
                        {
                            fromAccountCurrentBalance = item.Balance;
                        }
                        #endregion

                        #region Баланс счёта пополнения
                        var toAccounts = db.Accounts.Where(c => c.AccountIdentificationNumber == Convert.ToUInt64(window.toAccountTextBox.Text)).ToList();
                        foreach (var item in toAccounts)
                        {
                            toAccountCurrentBalance = item.Balance;
                        }
                        #endregion



                        if (fromAccounts.Any() && toAccounts.Any() && window.toAccountTextBox.Text != window.fromAccountTextBox.Text)
                        {
                            if (Convert.ToInt64(window.sumTextBox.Text) > fromAccountCurrentBalance)
                                MessageBox.Show("Недостаточно стредств для осуществления перевода.");
                            else
                            {
                                #region Снятие средств
                                fromAccountNewBalance = fromAccountCurrentBalance - Convert.ToInt64(window.sumTextBox.Text);
                                IEnumerable<AccountDB> fromAccount = db.Accounts.Where(c => c.AccountIdentificationNumber == Convert.ToUInt64(window.fromAccountTextBox.Text)).AsEnumerable().Select(c => { c.Balance = fromAccountNewBalance; return c; });
                                foreach (var item in fromAccount)
                                {
                                    db.Entry(item).State = EntityState.Modified;
                                }
                                db.SaveChanges();
                                #endregion

                                #region Начисление средств
                                toAccountNewBalance = toAccountCurrentBalance + Convert.ToInt64(window.sumTextBox.Text);
                                IEnumerable<AccountDB> toAccount = db.Accounts.Where(c => c.AccountIdentificationNumber == Convert.ToUInt64(window.toAccountTextBox.Text)).AsEnumerable().Select(c => { c.Balance = toAccountNewBalance; return c; });
                                foreach (var item in toAccount)
                                {
                                    db.Entry(item).State = EntityState.Modified;
                                }
                                db.SaveChanges();
                                #endregion

                                MessageBox.Show($"Выполнен перевод со счёта \"{window.fromAccountTextBox.Text}\" на счёт \"{window.toAccountTextBox.Text}\" в количестве {window.sumTextBox.Text} рублей.");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка перевода, проверьте введённые данные и попробуйте снова.");
                        }




                    }
                }
            }
        }

        public void TransferMoneyWithPhoneNumber(Phone window)
        {
            decimal fromAccountCurrentBalance = 0, fromAccountNewBalance;
            ulong fromAccountNumber = 0;
            ulong toAccountNumber = 0;
            decimal toAccountCurrentBalance = 0, toAccountNewBalance;

            if (string.IsNullOrWhiteSpace(window.fromAccountPhoneNumberTextBox.Text) || string.IsNullOrWhiteSpace(window.toAccountPhoneNumberTextBox.Text) || string.IsNullOrWhiteSpace(window.sumTextBox.Text))
            {
                MessageBox.Show("Заполните все поля.");
            }
            else
            {
                if (FieldsChecker(window.sumTextBox.Text))
                {
                    using (BankAppContext db = new())
                    {
                        var fromAccounts = db.Accounts.Where(c => c.UserId == UserInfo.UserId && c.AccountPhoneNumber == window.fromAccountPhoneNumberTextBox.Text).ToList();
                        var toAccounts = db.Accounts.Where(c=>c.AccountPhoneNumber == window.toAccountPhoneNumberTextBox.Text).ToList();
                        if (fromAccounts.Any() && toAccounts.Any())
                        {
                            if(window.fromAccountPhoneNumberTextBox.Text == window.toAccountPhoneNumberTextBox.Text)
                            {
                                MessageBox.Show("Вы пытаетесь совершить перевод с одного и того же счёта, в таком случае воспользуйтесь операцией \"Пополнение\".");
                            }
                            else
                            {
                                foreach (var item in fromAccounts)
                                {
                                    fromAccountNumber = item.AccountIdentificationNumber;
                                    fromAccountCurrentBalance = item.Balance;
                                }

                                foreach (var item in toAccounts)
                                {
                                    toAccountNumber = item.AccountIdentificationNumber;
                                    toAccountCurrentBalance = item.Balance;
                                }

                                if (fromAccountCurrentBalance >= Convert.ToDecimal(window.sumTextBox.Text))
                                {
                                    fromAccountNewBalance = fromAccountCurrentBalance - Convert.ToDecimal(window.sumTextBox.Text);
                                    toAccountNewBalance = toAccountCurrentBalance + Convert.ToDecimal(window.sumTextBox.Text);

                                    IEnumerable<AccountDB> fromAccount = db.Accounts.Where(c => c.UserId == UserInfo.UserId && c.AccountPhoneNumber == window.fromAccountPhoneNumberTextBox.Text).AsEnumerable().Select(c=> { c.Balance = fromAccountNewBalance;return c; });
                                    foreach (var item in fromAccount)
                                    {
                                        db.Entry(item).State = EntityState.Modified;
                                    }
                                    db.SaveChanges();

                                    IEnumerable<AccountDB> toAccount = db.Accounts.Where(c => c.AccountPhoneNumber == window.toAccountPhoneNumberTextBox.Text).AsEnumerable().Select(c => { c.Balance = toAccountNewBalance; return c; });
                                    foreach (var item in toAccount)
                                    {
                                        db.Entry(item).State = EntityState.Modified;
                                    }
                                    db.SaveChanges();
                                    MessageBox.Show($"Выполнен перевод со счёта \"{fromAccountNumber}\" на счёт \"{toAccountNumber}\" в количестве {window.sumTextBox.Text} рублей.");
                                }
                                else
                                    MessageBox.Show("Недостаточно средств для осуществления перевода.");
                                
                            }
                        }
                        else MessageBox.Show("Такого счёта не существует");
                    }
                }
            }
                 



        }

    }
}

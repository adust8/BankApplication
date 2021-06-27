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
using System.Windows.Controls;

namespace BankApplication.Windows.Страницы_MainMenu
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public void DepositAccountCounter()
        {
            DateTime now = DateTime.Now;
            using (BankAppContext db = new())
            {

                foreach (var item in db.Accounts.Where(c => c.NextReplenishment <= now &&  c.AccountTypeId == 2))
                {
                    item.Balance = item.Balance + (item.Balance * Convert.ToDecimal(0.07));
                    item.NextReplenishment.AddYears(1);
                    //nextReplenishment = item.NextReplenishment.AddYears(1);
                    //IEnumerable<AccountDB> account = db.Accounts.Where(c => c.NextReplenishment <= now).AsEnumerable().Select(c => { c.Balance = balance; c.NextReplenishment = nextReplenishment; return c; });
                }
                db.SaveChanges();
            }
        }
        public Account()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var open = new OpenAccount();
            open.Show();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var window = new DeleteAccountWindow();
            window.Show();
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            using (BankAppContext db = new BankAppContext())
            {
                var getInfo = db.Users.FromSqlRaw($"SELECT * FROM Users WHERE id=(SELECT user_id FROM LoginsAndPasswords WHERE user_login='{UserInfo.Login}' AND user_password='{UserInfo.Password}')").ToList();

                foreach (var item in getInfo)
                {
                    this.nameTextBlock.Text = item.Name;
                    this.surnameTextBlock.Text = item.Surname;
                    this.patronymicTextBlock.Text = item.Patronymic;
                    this.phoneNumberTextBlock.Text = item.PhoneNumber;
                    UserInfo.UserId = item.Id;
                    
                }
            }
            LoadDataGrid();

            DepositAccountCounter();


            

            
        }

        private void LoadDataGrid()
        {
            using (BankAppContext db = new())
            {
   
                var list1 = (from c in db.Accounts.Include(c => c.AccountType)
                             where c.UserId == UserInfo.UserId
                             select c);
                privateOfficeDataGrid.ItemsSource = list1.ToList();
            }
        }

        private void privateOfficeDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            e.Cancel = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (BankAppContext db = new())
            {

                var list1 = (from c in db.Accounts.Include(c => c.AccountType)
                             where c.UserId == UserInfo.UserId
                             select c);
                privateOfficeDataGrid.ItemsSource = list1.ToList();
            }
        }
    }
}
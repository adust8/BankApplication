using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseLibrary;
using DatabaseLibrary.Tables;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для openAccount.xaml
    /// </summary>
    public partial class OpenAccount : Window
    {
        public OpenAccount()
        {
            InitializeComponent();
        }


        private void BtnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            var openAccount = new Operations();
            openAccount.CreateAccount(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (BankAppContext db = new BankAppContext())
            {
                List<AccountType> data = db.AccountTypes.ToList();
                accountTypeComboBox.ItemsSource = data;
                accountTypeComboBox.DisplayMemberPath = "Name";
                accountTypeComboBox.SelectedValuePath = "Id";

            }
        }

        private void deleteAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

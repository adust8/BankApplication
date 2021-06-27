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
using DatabaseLibrary.Tables;
using DatabaseLibrary;
using Microsoft.EntityFrameworkCore;


namespace BankApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeleteAccountWindow.xaml
    /// </summary>
    public partial class DeleteAccountWindow : Window
    {
        public DeleteAccountWindow()
        {
            InitializeComponent();
        }


        private void deleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var delete = new Operations();
            delete.DeleteAccount(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (BankAppContext db = new BankAppContext())
            {
                var getInfo = db.Users.FromSqlRaw($"SELECT * FROM Users WHERE id=(SELECT user_id FROM LoginsAndPasswords WHERE user_login='{UserInfo.Login}' AND user_password='{UserInfo.Password}')").ToList();

                foreach (var item in getInfo)
                {
                    UserInfo.UserId = item.Id;
                }
            }
        }
    }
}

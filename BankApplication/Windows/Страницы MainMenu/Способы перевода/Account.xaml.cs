using DatabaseLibrary.Tables;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BankApplication.Windows.Страницы_MainMenu.Способы_перевода
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
        }

        private void transferButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var operation = new Operations();
            operation.TransferMoneyWithAccountNumber(this);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
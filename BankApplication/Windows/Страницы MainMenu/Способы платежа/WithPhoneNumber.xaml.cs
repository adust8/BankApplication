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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseLibrary.Tables;
using DatabaseLibrary;
using Microsoft.EntityFrameworkCore;


namespace BankApplication.Windows.Страницы_MainMenu.Способы_платежа
{
    /// <summary>
    /// Логика взаимодействия для WithPhoneNumbere.xaml
    /// </summary>
    public partial class WithPhoneNumber : Page
    {
        public WithPhoneNumber()
        {
            InitializeComponent();
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

        private void putMoneyWithPhoneNumberButton_Click(object sender, RoutedEventArgs e)
        {
            var operation = new Operations();

            operation.PutMoneyWithPhoneNumber(this);
        }
    }
}

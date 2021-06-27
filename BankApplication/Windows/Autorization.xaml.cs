using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using DatabaseLibrary.Tables;
using System.Linq;
using System.Collections.Generic;

using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System;

namespace BankApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public class UserInfo
    {
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static int UserId { get; set; }
    }


    public partial class Autorization : Window
    {

        private void SendEmail()
        {
            MailAddress from = new("audubonsunshin@gmail.com", "Andrew");
            MailAddress to = new("maskepptt232@mail.ru", "SomeOne");

            using (MailMessage message = new(from, to))
            using (SmtpClient smtp = new("smtp.gmail.com", 587))
            {
                message.Subject = "Восстановление пароля.";
                message.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
                message.IsBodyHtml = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("audubonsunshin@gmail.com", "12344321oKS228336655");
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
            Console.WriteLine("Письмо отправлено.");
        }
        public bool SignInChecker(Autorization signInWindow)
        {         
            using (BankAppContext db = new())
            {
                var users = db.LoginsAndPasswords.Where(c => c.Login == this.loginTextBox.Text && c.Password == this.passwordTextBox.Password)
                    .AsNoTracking()
                    .ToList();
                //var users = db.Users.FromSqlRaw($"SELECT * FROM Users WHERE id=(SELECT user_id FROM LoginsAndPasswords WHERE user_login='{signInWindow.loginTextBox.Text}' AND user_password='{signInWindow.passwordTextBox.Password}')").ToList();
                if (users.Any())
                    return true;

                else return false;
            }
        }


        public Autorization()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var menu = new MainMenu();

            if (SignInChecker(this))
            {
                UserInfo.Login = this.loginTextBox.Text;
                UserInfo.Password = this.passwordTextBox.Password;
                menu.Show();
                Close();
            }
            else MessageBox.Show("Вы ввели неправильный логин или пароль");

        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            var signUpWindow = new SignUp();
            signUpWindow.Show();
            Close();
        }

        private void forgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
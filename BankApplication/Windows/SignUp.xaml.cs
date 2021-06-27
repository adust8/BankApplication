using System.Windows;
using Microsoft.EntityFrameworkCore;
using DatabaseLibrary.Tables;
using DatabaseLibrary;
using System;
using System.Linq;

namespace BankApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void  Registration()
        {
            using (BankAppContext db = new())
            {

                var newUser = new User() { RegistrationDate = DateTime.Now, Patronymic = this.patronymicTextBox.Text, Surname = this.surnameTextBox.Text, Name = this.nameTextBox.Text, BirthDate = Convert.ToDateTime(this.birthDateTextBox.Text), PhoneNumber = this.phoneNumberTextBox.Text };
                db.Add(newUser);
                db.SaveChanges();
                db.Add(new LoginAndPassword() { Login = this.loginTextBox.Text, Password = this.passwordTextBox.Password, UserId = newUser.Id, Email = this.emailTextBox.Text });
                db.SaveChanges();
            }
        }

        


        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            char[] charArray;
            var autorizationWindow = new Autorization();
            

            charArray = phoneNumberTextBox.Text.ToCharArray();


            if (RegistrationChecks.NullOrWhiteSpaceChecker(this))
                MessageBox.Show("Заполните все поля регистрации.");
            else
            {
                if (RegistrationChecks.PhoneNumberExistingChecker(this))
                {
                    if (RegistrationChecks.OtherSymbolsChecker(this))
                    {
                        if (RegistrationChecks.BirthDateChecker(this, birthDateTextBox.Text))
                        {
                            if (RegistrationChecks.PhoneLengthAndFormatChecker(this, phoneNumberTextBox.Text) && RegistrationChecks.PhoneOtherSymbolsChecker(this, phoneNumberTextBox.Text))
                            {
                                if (RegistrationChecks.PasswordChecker(this))
                                {
                                    if(RegistrationChecks.LoginChecker(this))
                                    {
                                        Registration();
                                        MessageBox.Show("Регистрация прошла успешно.");
                                        this.Close();
                                        autorizationWindow.Show();
                                    }
                                    else MessageBox.Show("Такой логин уже существует.");

                                }
                                else MessageBox.Show("Пароли не совпадают.");
                            }
                            else MessageBox.Show("Заполните \"Номер телефона\" в правильном формате (+7) или проверьте правильность заполнения данного поля.");
                        }
                        else MessageBox.Show("Чтобы пользоваться услугами нашего банка вам должно быть 18 или более лет.");

                    }
                    else MessageBox.Show("Заполните поля в корректном формате.");
                }
                else MessageBox.Show("Такой номер телефона уже привязан к какой-то учётной записи.");
                
                
                
                
            }

            
        }
    }
}
using BankApplication.Windows.Страницы_MainMenu.Способы_перевода;
using System.Windows;
using System.Windows.Controls;

namespace BankApplication.Windows.Страницы_MainMenu
{
    /// <summary>
    /// Логика взаимодействия для Transfer.xaml
    /// </summary>
    public partial class Transfer : Page
    {
        public Transfer()
        {
            InitializeComponent();
        }

        private void ItemPhone_Selected(object sender, RoutedEventArgs e)
        {
            frameTransfer.Navigate(new Phone());
        }

        private void ItemAccount_Selected(object sender, RoutedEventArgs e)
        {
            frameTransfer.Navigate(new Способы_перевода.Account());
        }
    }
}
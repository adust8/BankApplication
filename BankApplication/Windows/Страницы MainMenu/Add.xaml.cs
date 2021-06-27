using BankApplication.Windows.Страницы_MainMenu.Способы_платежа;
using System.Windows;
using System.Windows.Controls;

namespace BankApplication.Windows.Страницы_MainMenu
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
        }

        private void ItemAccount_Selected(object sender, RoutedEventArgs e)
        {
            frameAdd.Navigate(new FromAccount());
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            frameAdd.Navigate(new WithPhoneNumber());
        }
    }
}
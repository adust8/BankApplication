using BankApplication.Windows.Страницы_MainMenu;
using System.Windows;

namespace BankApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для mainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Transfer());
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Account());

            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Add());
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
        }
    }
}
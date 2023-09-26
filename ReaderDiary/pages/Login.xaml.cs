using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ReaderDiary.pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoToRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Registration.xaml", UriKind.Relative));
        }
    }
}

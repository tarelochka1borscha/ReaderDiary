using ReaderDiary.classes;
using System;
using System.Linq;
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
            Account user = Base.RDBase.Account.FirstOrDefault(x => x.login.ToString() == login.Text && x.password.ToString() == password.Text);
            if (user != null)
            {
                switch (user.id_role)
                {
                    case 1:
                        NavigationService.Navigate(new Uri("pages/AdminMenu.xaml", UriKind.Relative));
                        break;
                        case 2:
                        MessageBox.Show("Юзер");
                        break;
                    default:
                        MessageBox.Show("Не найден");
                        break;
                }
            }
        }

        private void GoToRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Registration.xaml", UriKind.Relative));
        }
    }
}

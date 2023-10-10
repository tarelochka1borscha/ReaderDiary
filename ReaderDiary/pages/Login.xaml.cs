using ReaderDiary.classes;
using System;
using System.Collections.Generic;
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
            Base.RDBase = new EntitiesRDiary();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            int pass = password.Text.GetHashCode();
            Account user = Base.RDBase.Account.FirstOrDefault(x => x.login == login.Text);
            if (user != null)
            {
                if (user.password == pass)
                {
                    switch (user.id_role)
                    {
                        case 1:
                            NavigationService.Navigate(new Uri("pages/AdminMenu.xaml", UriKind.Relative));
                            break;
                        case 2:
                            NavigationService.Navigate(new UserMainPage(user));
                            break;
                        default:
                            Message.Text = "Пользователь не найден.\nПроверьте вводимый логин.";
                            break;
                    }
                }
                else
                {
                    Message.Text = "Неверный пароль.";
                }
            }
            else
            {
                Message.Text = "Пользователь не найден.\nПроверьте вводимый логин.";
            }
        }

        private void GoToRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Registration.xaml", UriKind.Relative));
        }
    }
}

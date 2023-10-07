using ReaderDiary.classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ReaderDiary.pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            int id_gender = 3;
            if (B1.IsChecked==true) id_gender = 1;
            else if (B2.IsChecked==true) id_gender = 2;

            Account account = new Account()
            {
                login = Login.Text,
                password = Password.Text.GetHashCode(),
                id_gender = id_gender,
                birthday = Convert.ToDateTime(DateBirth.SelectedDate),
                id_role = 2
            };
            Base.RDBase.Account.Add(account);
            Base.RDBase.SaveChanges();

            UserData data = new UserData()
            {
                id_user = Base.RDBase.Account.Max(x => x.id_user),
                name = Name.Text,
                surname = Surname.Text,
                patronymic = Patronymic.Text
            };
            Base.RDBase.UserData.Add(data);
            Base.RDBase.SaveChanges();
        }

        private void ToEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Login.xaml", UriKind.Relative));
        }
    }
}

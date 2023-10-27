using ReaderDiary.classes;
using ReaderDiary.windows;
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

namespace ReaderDiary.pages
{
    /// <summary>
    /// Логика взаимодействия для UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Page
    {
        Account current_user;
        public UserProfile(Account user)
        {
            InitializeComponent();
            current_user = user;
            UserData current_user_data = Base.RDBase.UserData.Where(x => x.id_user == current_user.id_user).FirstOrDefault();
            TBWelcome.Text = current_user_data.surname + " " + current_user_data.name + " " + current_user_data.surname + TBWelcome.Text;
            Surname.Text = current_user_data.surname;
            Name.Text = current_user_data.name;
            Patronimyc.Text = current_user_data.patronymic;
            Birthday.Text = current_user.birthday.ToString().Substring(0, current_user.birthday.ToString().Length - 8);
            Gender.Text = current_user.Gender.title;
            Login.Text = current_user.login;
        }

        private void ChangeProfile_Click(object sender, RoutedEventArgs e)
        {
            ChangePersonalData cpd = new ChangePersonalData(current_user);
            cpd.ShowDialog();
            NavigationService.Navigate(new UserProfile(current_user));
        }
    }
}

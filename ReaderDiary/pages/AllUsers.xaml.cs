using ReaderDiary.classes;
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
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        List<UserData> data = Base.RDBase.UserData.ToList();
        bool up = false;
        bool down = false;
        bool man = false;
        bool woman = false;
        public AllUsers()
        {
            InitializeComponent();

            Users.ItemsSource = data;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text != string.Empty)
            {
                data = data.Where(x=> x.surname.ToLower().Contains(Search.Text.ToLower()) || x.Account.login.ToLower().Contains(Search.Text.ToLower())).ToList();
            }
            else
            {
                if (up)
                {
                    data = Base.RDBase.UserData.OrderBy(x => x.surname).ToList();
                }
                if (down)
                {
                    data = Base.RDBase.UserData.OrderByDescending(x => x.surname).ToList();
                }
                if (man)
                {
                    data = Base.RDBase.UserData.Where(x => x.Account.id_gender == 1).ToList();
                }
                if (woman)
                {
                    data = Base.RDBase.UserData.Where(x => x.Account.id_gender == 2).ToList();
                }
            }

            Users.ItemsSource = data;
        }

        private void Upp_Click(object sender, RoutedEventArgs e)
        {
            data = data.OrderBy(x => x.surname).ToList();
            Users.ItemsSource = data;
            up = true;
            down = false;
        }

        private void Low_Click(object sender, RoutedEventArgs e)
        {
            data = data.OrderByDescending(x => x.surname).ToList();
            Users.ItemsSource = data;
            up = false;
            down = true;
        }

        private void Man_Click(object sender, RoutedEventArgs e)
        {
            data = data.Where(x => x.Account.id_gender == 1).ToList();
            Users.ItemsSource = data;
            man = true;
            woman = false;
        }

        private void Woman_Click(object sender, RoutedEventArgs e)
        {
            data = data.Where(x => x.Account.id_gender == 2).ToList();
            Users.ItemsSource = data;
            man = false;
            woman = true;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Search.Clear();
            data = Base.RDBase.UserData.ToList();
            bool up = false;
            bool down = false;
            bool man = false;
            bool woman = false;
            Users.ItemsSource = data;
        }
    }
}

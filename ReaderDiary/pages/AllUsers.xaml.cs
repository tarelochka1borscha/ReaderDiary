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
        public AllUsers()
        {
            InitializeComponent();

            Users.ItemsSource = Base.RDBase.UserData.ToList();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text != string.Empty)
            {
                Users.ItemsSource = Base.RDBase.UserData.Where(x=> x.surname.ToLower().Contains(Search.Text.ToLower()) || x.Account.login.ToLower().Contains(Search.Text.ToLower())).ToList();
            }
            else
            {
                Users.ItemsSource = Base.RDBase.UserData.ToList();
            }
        }
    }
}

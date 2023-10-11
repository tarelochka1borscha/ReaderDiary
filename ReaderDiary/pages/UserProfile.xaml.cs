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
        }
    }
}

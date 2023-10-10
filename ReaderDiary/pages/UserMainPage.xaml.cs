using ReaderDiary.classes;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UserMainPage.xaml
    /// </summary>
    public partial class UserMainPage : Page
    {
        public UserMainPage(Account current_user)
        {
            InitializeComponent();
            UserData current_user_data = Base.RDBase.UserData.Where(x=>x.id_user==current_user.id_user).FirstOrDefault();
            UserName.Text = current_user_data.name;
            if (current_user_data.photo != null)
            {
                MemoryStream byteStream = new MemoryStream(current_user_data.photo);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                ImageUser.Source = image;
            }
        }
    }
}

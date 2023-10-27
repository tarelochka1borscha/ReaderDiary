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
        Account current_user;
        public UserMainPage(Account user)
        {
            InitializeComponent();
            current_user = user;
            UserData current_user_data = Base.RDBase.UserData.Where(x => x.id_user == current_user.id_user).FirstOrDefault();
            UserName.Text = current_user_data.name;
            Photos last_photo = null;
            try
            {
                last_photo = Base.RDBase.Photos.Where(x => x.id_userdata == current_user_data.id_userdata).ToList().Last();
            }
            catch
            {

            }
            if (last_photo != null)
            {
                MemoryStream byteStream = new MemoryStream(last_photo.data);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                ImageUser.Source = image;
            }
        }

        private void ToMyProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProfile(current_user));
        }
    }
}

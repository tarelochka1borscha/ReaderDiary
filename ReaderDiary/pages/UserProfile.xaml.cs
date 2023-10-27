using Microsoft.Win32;
using ReaderDiary.classes;
using ReaderDiary.windows;
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
            UserName.Text = current_user_data.name;
            TBWelcome.Text = current_user_data.surname + " " + current_user_data.name + " " + current_user_data.patronymic + TBWelcome.Text;
            Surname.Text = current_user_data.surname;
            Name.Text = current_user_data.name;
            Patronimyc.Text = current_user_data.patronymic;
            Birthday.Text = current_user.birthday.ToString().Substring(0, current_user.birthday.ToString().Length - 8);
            Gender.Text = current_user.Gender.title;
            Login.Text = current_user.login;

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

        private void ChangeProfile_Click(object sender, RoutedEventArgs e)
        {
            ChangePersonalData cpd = new ChangePersonalData(current_user);
            cpd.ShowDialog();
            NavigationService.Navigate(new UserProfile(current_user));
        }

        private void ChangeAccount_Click(object sender, RoutedEventArgs e)
        {
            ChangeAccountData cad = new ChangeAccountData(current_user);
            cad.ShowDialog();
            NavigationService.Navigate(new UserProfile(current_user));
        }

        private void NewAvatar_Click(object sender, RoutedEventArgs e)
        {
            byte[] image_bytes;
            try
            {
                UserData current_user_data = Base.RDBase.UserData.Where(x => x.id_user == current_user.id_user).FirstOrDefault();

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                image_bytes = File.ReadAllBytes(openFileDialog.FileName);

                Photos photos = new Photos();
                photos.id_userdata = current_user_data.id_userdata;
                photos.data = image_bytes;

                Base.RDBase.Photos.Add(photos);
                Base.RDBase.SaveChanges();
                SomeMessage someMessage = new SomeMessage();
                someMessage.ShowDialog();

                NavigationService.Navigate(new UserProfile(current_user));
            }
            catch
            {
                SomeMessage someMessage = new SomeMessage("Фото не добавлено", "Досадно");
                someMessage.ShowDialog();
            }
        }

        private void GoToGalery(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Galery(current_user));
        }
    }
}

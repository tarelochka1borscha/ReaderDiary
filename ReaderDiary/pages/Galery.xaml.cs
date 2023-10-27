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
    /// Логика взаимодействия для Galery.xaml
    /// </summary>
    public partial class Galery : Page
    {
        Account current_user;
        List<Photos> photos = new List<Photos>();
        int n = 0;
        public Galery(Account user)
        {
            InitializeComponent();
            Back.IsEnabled = false;
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

            try
            {
                photos = Base.RDBase.Photos.Where(x=>x.id_userdata==current_user_data.id_userdata).ToList();
            }
            catch {}
            if (photos.Count >0)
            {
                showPhoto();
            }
            else
            {
                SomeMessage someMessage = new SomeMessage("Похоже, у вас нет фото :с", "Досадно");
                someMessage.ShowDialog();
                GaleryPanel.Visibility = Visibility.Hidden; 
                Back.Visibility = Visibility.Hidden;
                ToAvatar.Visibility = Visibility.Hidden;
                Delete.Visibility = Visibility.Hidden;
            }
            if(photos.Count == 1)
            {
                Forth.IsEnabled = false;
            }
        }

        

        private void showPhoto()
        {
            MemoryStream byteStream = new MemoryStream(photos[n].data);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            Photo.Source = image;
            Photo.Stretch = Stretch.Uniform;
        }

        

        private void Forth_Click(object sender, RoutedEventArgs e)
        {
            if (photos.Count == n + 1)
            {
                n = -1;
            }
            Back.IsEnabled = true;
            n++;
            showPhoto();
            NavigationService.Refresh();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (0 == n)
            {
                n = photos.Count();
            }
            Forth.IsEnabled = true;
            n--;
            showPhoto();
            
            NavigationService.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            delete.ShowDialog();
            if (delete.YesOrNo())
            {
                Base.RDBase.Photos.Remove(photos[n]);
                Base.RDBase.SaveChanges();
                SomeMessage someMessage = new SomeMessage();
                someMessage.ShowDialog();
                NavigationService.Navigate(new Galery(current_user));
            }
        }

        private void ToAvatar_Click(object sender, RoutedEventArgs e)
        {
            Base.RDBase.Photos.Remove(photos[n]);
            Base.RDBase.SaveChanges();
            Base.RDBase.Photos.Add(photos[n]);
            Base.RDBase.SaveChanges();
            SomeMessage someMessage = new SomeMessage();
            someMessage.ShowDialog();
            NavigationService.Navigate(new Galery(current_user));
        }

        private void AddPhotos_Click(object sender, RoutedEventArgs e)
        {
            UserData current_user_data = Base.RDBase.UserData.Where(x => x.id_user == current_user.id_user).FirstOrDefault();
            OpenFileDialog image = new OpenFileDialog();
            image.Multiselect = true;
            if (image.ShowDialog() == true)
            {
                foreach (string file in image.FileNames)
                {
                    Photos photo = new Photos();
                    photo.id_userdata = current_user_data.id_userdata;
                    photo.data = File.ReadAllBytes(file);
                    Base.RDBase.Photos.Add(photo);

                }
                Base.RDBase.SaveChanges();
                NavigationService.Navigate(new Galery(current_user));
            }
        }
    }
}

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
    /// Логика взаимодействия для BookData.xaml
    /// </summary>
    public partial class BookData : Page
    {
        public BookData()
        {
            InitializeComponent();
            Books.ItemsSource = Base.RDBase.Passport.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_Loaded_Genre(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            List<BookGenre> genres = Base.RDBase.BookGenre.Where(x=> x.id_passport == id).ToList();
            string book_genres = "Жанры: ";
            foreach(BookGenre genre in genres)
            {
                book_genres += genre.Genre.title + ", ";
            }
            tb.Text = book_genres.Substring(0, book_genres.Length-2);
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text != string.Empty)
            {
                Books.ItemsSource = Base.RDBase.Passport.Where(x => x.title.ToLower().Contains(Search.Text.ToLower()) || x.Author.surname.ToLower().Contains(Search.Text.ToLower())).ToList();
            }
            else
            {
                Books.ItemsSource = Base.RDBase.Passport.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBook(1));
        }
    }
}

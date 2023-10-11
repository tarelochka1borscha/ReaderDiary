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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        Passport new_book = new Passport();
        public AddBook(int role)
        {
            InitializeComponent();
            addGenres();
            
        }

        private void addGenres()
        {
            Genres.ItemsSource = Base.RDBase.Genre.ToList();
            Genres.DisplayMemberPath = "title";
            Genres.SelectedValuePath = "id_genre";
        }

        private void Add_Book_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_Author_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_Photo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

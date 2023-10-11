using ReaderDiary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
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
        string path;
        Passport new_book = new Passport();
        BookGenre book_genre = new BookGenre();
        public AddBook(int role)
        {
            InitializeComponent();
            addLists();
            
        }

        private void addLists()
        {
            Genres.ItemsSource = Base.RDBase.Genre.ToList();
            Genres.DisplayMemberPath = "title";
            Genres.SelectedValuePath = "id_genre";

            Author.ItemsSource = Base.RDBase.Author.ToList();
            Author.DisplayMemberPath = "surname";
            Author.SelectedValuePath = "id_author";
        }

        private void Add_Book_Click(object sender, RoutedEventArgs e)
        {
            new_book.title = Name.Text;
            new_book.id_author = ((Author)Author.SelectedItem).id_author;
            new_book.description = Description.Text;
            new_book.pages = Convert.ToInt32(Pages.Text);
            
            //new_book.photo = s; надо сделать байты

        }

        private void Add_Author_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_Photo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();  // создаем объект диалогового окна
                OFD.ShowDialog(); // открываем диалоговое окно
                path = OFD.FileName; // извлекаем полный путь к картинке
                int n = path.IndexOf("images");
                path = "\\" + path.Substring(n); // записываем в бд путь, начиная с имени папки
            }
            catch
            {
                MessageBox.Show("Фото не добавлено");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

using Microsoft.Win32;
using ReaderDiary.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ReaderDiary.pages
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        int role, id_book;
        byte[] image_bytes;
        Passport new_book = new Passport();

        public AddBook(int user) //добавление
        {
            InitializeComponent();
            addLists();
            role = user;
            id_book = 0;
        }
        public AddBook(int user, int index) //изменение
        {
            InitializeComponent();
            addLists();
            role = user;
            id_book = index;
            new_book = Base.RDBase.Passport.FirstOrDefault(x => x.id_passport == id_book);
            Name.Text = new_book.title;
            Author author = Base.RDBase.Author.Where(x => x.id_author == new_book.id_author).FirstOrDefault();
            Author.SelectedItem = author;
            Description.Text = new_book.description;
            Pages.Text = new_book.pages.ToString();

            List<BookGenre> genres = Base.RDBase.BookGenre.Where(x => x.id_passport == new_book.id_passport).ToList();
            foreach (Genre genre in Genres.Items)
            {
                if (genres.FirstOrDefault(x => x.id_genre == genre.id_genre) != null)
                {
                    Genres.SelectedItems.Add(genre);
                }
            }
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
            if (id_book == 0)
            {
                new_book.title = Name.Text;
                new_book.id_author = ((Author)Author.SelectedItem).id_author; //как присвоить null???
                new_book.description = Description.Text;
                new_book.pages = Convert.ToInt32(Pages.Text);
                new_book.photo = image_bytes;

                Base.RDBase.Passport.Add(new_book);


                foreach (Genre book in Genres.SelectedItems)
                {
                    BookGenre bookGenre = new BookGenre()
                    {
                        id_genre = book.id_genre,
                        id_passport = new_book.id_passport,
                    };
                    Base.RDBase.BookGenre.Add(bookGenre);
                }

                Base.RDBase.SaveChanges();
            }
            else
            {
                Passport checking = Base.RDBase.Passport.FirstOrDefault(x => x.id_passport == new_book.id_passport);
                if (checking != null)
                {
                    List<BookGenre> checking_genre = Base.RDBase.BookGenre.Where(x => x.id_passport == checking.id_passport).ToList();
                    foreach (BookGenre bookGenre in checking_genre)
                    {
                        Base.RDBase.BookGenre.Remove(bookGenre);
                    }
                    Base.RDBase.Passport.Remove(checking);
                    Base.RDBase.SaveChanges();
                }
                new_book.title = Name.Text;
                new_book.id_author = ((Author)Author.SelectedItem).id_author;
                new_book.description = Description.Text;
                new_book.pages = Convert.ToInt32(Pages.Text);
                new_book.photo = image_bytes;

                Base.RDBase.Passport.Add(new_book);

                foreach (Genre book in Genres.SelectedItems)
                {
                    BookGenre bookGenre = new BookGenre()
                    {
                        id_genre = book.id_genre,
                        id_passport = new_book.id_passport,
                    };
                    Base.RDBase.BookGenre.Add(bookGenre);
                }

                Base.RDBase.SaveChanges();
            }
            if (role == 1)
            {
                NavigationService.Navigate(new Uri("pages/BookData.xaml", UriKind.Relative));
            }
            else
            {
                //NavigationService.Navigate(new Uri("pages/AllUsers.xaml", UriKind.Relative));
            }
        }

        private void Add_Author_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Photo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                image_bytes = File.ReadAllBytes(openFileDialog.FileName);
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

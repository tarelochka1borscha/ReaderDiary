using ReaderDiary.classes;
using ReaderDiary.windows;
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
    /// Логика взаимодействия для AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : Page
    {
        Author author = new Author();
        public AddAuthor()
        {
            InitializeComponent();
            addList();
        }

        private void addList()
        {
            Countries.ItemsSource = Base.RDBase.Country.ToList();
            Countries.DisplayMemberPath = "title";
            Countries.SelectedValuePath = "id_country";
        }
        private void addAuthor()
        {
            author.name = Name.Text;
            author.surname = Surname.Text;
            author.id_country = ((Country)Countries.SelectedItem).id_country;
            Base.RDBase.Author.Add(author);
            Base.RDBase.SaveChanges();
            NavigationService.GoBack();
        }
        private bool Checking()
        {
            bool checking = true;
            if (Name.Text.Length == 0)
            {
                checking = false;
                NameMessage.Text = "Поле не должно быть пустым!";
            }
            if (Surname.Text.Length == 0)
            {
                checking = false;
                SurnameMessage.Text = "Поле не должно быть пустым!";
            }
            return checking;
        }
        private void Add_Book_Click(object sender, RoutedEventArgs e)
        {
            if (Checking())
            {
                Author checking = Base.RDBase.Author.FirstOrDefault(x => x.name == Name.Text && x.surname == Surname.Text);
                if (checking != null)
                {
                    Delete win = new Delete("Похоже, автор существует.\nТочно хотите добавить?");
                    win.ShowDialog();
                    if (win.YesOrNo())
                    {
                        addAuthor();
                    }
                    NavigationService.GoBack();
                }
                else
                {
                    addAuthor();
                    NavigationService.GoBack();
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

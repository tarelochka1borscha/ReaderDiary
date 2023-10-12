using ReaderDiary.classes;
using ReaderDiary.windows;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ReaderDiary.pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            int id_gender = 3;
            if (B1.IsChecked == true) id_gender = 1;
            else if (B2.IsChecked == true) id_gender = 2;
            if (CheckingData())
            {
                Account account = new Account()
                {
                    login = Login.Text,
                    password = Password.Text.GetHashCode(),
                    id_gender = id_gender,
                    birthday = Convert.ToDateTime(DateBirth.SelectedDate),
                    id_role = 2
                };
                Base.RDBase.Account.Add(account);
                Base.RDBase.SaveChanges();

                UserData data = new UserData()
                {
                    id_user = Base.RDBase.Account.Max(x => x.id_user),
                    name = Name.Text,
                    surname = Surname.Text,
                    patronymic = Patronymic.Text
                };
                Base.RDBase.UserData.Add(data);
                Base.RDBase.SaveChanges();
                SomeMessage someMessage = new SomeMessage();
                someMessage.ShowDialog();
                NavigationService.Navigate(new Uri("pages/Login.xaml", UriKind.Relative));
            }
        }

        private void ToEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/Login.xaml", UriKind.Relative));
        }

        private bool CheckingData()
        {
            bool allDataIsCorrect = true;

            Regex passNum = new Regex("(?=.*[0-9]{2,})");
            Regex passSimbols = new Regex("(?=.*[!@#$%^&*])");
            Regex passUncial = new Regex("(?=.*[A-Z])");
            Regex passUpper = new Regex("(?=.*[a-z]{3,})");

            Account user = Base.RDBase.Account.FirstOrDefault(x => x.login == Login.Text);

            if (Name.Text.Length == 0)
            {
                NameMessage.Text = "Поле обязательно для ввода.";
                allDataIsCorrect = false;
            }
            else
            {
                NameMessage.Text = "";
            }
            if (Login.Text.Length == 0)
            {
                LoginMessage.Text = "Поле обязательно для ввода.";
                allDataIsCorrect = false;
            }
            else if ((Login.Text.Length < 6) || (Login.Text.Length > 25))
            {
                LoginMessage.Text = "Логин должен иметь длину\nот 6 до 25 символов.";
                allDataIsCorrect = false;
            }
            else if (user != null){
                LoginMessage.Text = "Аккаунт существует.\nПридумайте другой логин.";
                allDataIsCorrect = false;
            }
            else
            {
                LoginMessage.Text = "";
            }
            if (Password.Text.Length == 0)
            {
                PasswordMessage.Text = "Поле обязательно для ввода.";
                allDataIsCorrect = false;
            }
            else if (!passNum.IsMatch(Password.Text))
            {
                PasswordMessage.Text = "Пароль должен содержать\n2 цифры.";
                allDataIsCorrect = false;
            }
            else if(!passSimbols.IsMatch(Password.Text))
            {
                PasswordMessage.Text = "Пароль должен содержать\n1 спец. символ.\n!@#$%^&*";
                allDataIsCorrect = false;
            }
            else if(!passUncial.IsMatch(Password.Text))
            {
                PasswordMessage.Text = "Пароль должен содержать\n1 заглавную латинскую букву.";
                allDataIsCorrect = false;
            }
            else if(!passUpper.IsMatch(Password.Text))
            {
                PasswordMessage.Text = "Пароль должен содержать\n3 прописных латинских буквы";
                allDataIsCorrect = false;
            }
            else if(Password.Text.Length<8)
            {
                PasswordMessage.Text = "Пароль должен быть\nне менее 8 символов.";
                allDataIsCorrect = false;
            }
            else
            {
                PasswordMessage.Text = "";
            }

            

            return allDataIsCorrect;
        }
    }
}

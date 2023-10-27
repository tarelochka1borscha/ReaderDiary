using ReaderDiary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReaderDiary.windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeAccountData.xaml
    /// </summary>
    public partial class ChangeAccountData : Window
    {
        Account current_user;
        public ChangeAccountData(Account user)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            current_user = user;
            Login.Text = user.login;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (Checking())
            {
                try
                {
                    current_user.login = Login.Text;
                    if (NewPassword.Text.Length > 0)
                    {
                        current_user.password = NewPassword.Text.GetHashCode();
                    }
                    Delete del = new Delete("Сохранить изменения?");
                    del.ShowDialog();
                    if (del.YesOrNo())
                    {
                        Base.RDBase.SaveChanges();
                        SomeMessage someMessage = new SomeMessage();
                        someMessage.ShowDialog();
                    }
                    this.Close();
                }
                catch
                {
                    SomeMessage someMessage = new SomeMessage("Ой! Что-то пошло не так :с", "Досадно");
                    someMessage.ShowDialog();
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Checking()
        {
            bool allDataIsCorrect = true;
            Regex passNum = new Regex("(?=.*[0-9]{2,})");
            Regex passSimbols = new Regex("(?=.*[!@#$%^&*])");
            Regex passUncial = new Regex("(?=.*[A-Z])");
            Regex passUpper = new Regex("(?=.*[a-z]{3,})");
            Account data = Base.RDBase.Account.Where(x => x.id_user == current_user.id_user).FirstOrDefault();
            Account user = Base.RDBase.Account.FirstOrDefault(x => x.login == Login.Text);

            if (Login.Text.Length == 0)
            {
                SomeMessage someMessage = new SomeMessage("Логин не должен быть пустым!", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            else if ((Login.Text.Length < 6) || (Login.Text.Length > 25))
            {
                SomeMessage someMessage = new SomeMessage("Логин должен иметь длину от 6 до 25 символов.", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            else if ((user != null)&&(user.id_user != current_user.id_user))
            {
                SomeMessage someMessage = new SomeMessage("Аккаунт существует. Введите другой логин", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            

            if ((!passNum.IsMatch(NewPassword.Text))&&(NewPassword.Text.Length > 0))
            {
                SomeMessage someMessage = new SomeMessage("Пароль должен содержать 2 цифры", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            else if ((!passSimbols.IsMatch(NewPassword.Text))&& (NewPassword.Text.Length > 0))
            {
                SomeMessage someMessage = new SomeMessage("Пароль должен содержать 1 спец. символ (!@#$%^&*)", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            else if ((!passUncial.IsMatch(NewPassword.Text))&& (NewPassword.Text.Length > 0))
            {
                SomeMessage someMessage = new SomeMessage("Пароль должен содержать 1 заглавную латинскую букву", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            else if ((!passUpper.IsMatch(NewPassword.Text)) && (NewPassword.Text.Length > 0))
            {
                SomeMessage someMessage = new SomeMessage("Пароль должен содержать 3 прописных латинских буквы", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            else if ((NewPassword.Text.Length < 8) && (NewPassword.Text.Length > 0))
            {
                SomeMessage someMessage = new SomeMessage("Пароль должен быть не менее 8 символов", "Исправлюсь");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            
            if (OldPassword.Text.Length == 0)
            {
                SomeMessage someMessage = new SomeMessage("Старый пароль обязателен для ввода!", "Досадно");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            else if ((data.password!=OldPassword.Text.GetHashCode()))
            {
                SomeMessage someMessage = new SomeMessage("Неверный старый пароль!", "Досадно");
                someMessage.ShowDialog();
                allDataIsCorrect = false;
            }
            
            return allDataIsCorrect;
        }
    }
}

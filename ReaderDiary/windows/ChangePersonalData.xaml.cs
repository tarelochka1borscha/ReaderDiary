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
using System.Windows.Shapes;

namespace ReaderDiary.windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePersonalData.xaml
    /// </summary>
    public partial class ChangePersonalData : Window
    {
        Account current_user;
        public ChangePersonalData(Account user)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            current_user = user;
            UserData current_user_data = Base.RDBase.UserData.Where(x => x.id_user == current_user.id_user).FirstOrDefault();
            Name.Text = current_user_data.name;
            Surname.Text = current_user_data.surname;
            Patronymic.Text = current_user_data.patronymic;
            DateBirth.Text = current_user.birthday.ToString();
            switch (current_user.id_gender)
            {
                case 1:
                    { B1.IsChecked = true; break; }
                case 2:
                    { B2.IsChecked = true; break; }
                case 3:
                    { B3.IsChecked = true; break; }
                default: break;
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (CheckingData())
            {
                try
                {
                    if (B1.IsChecked == true) current_user.id_gender = 1;
                    else if (B2.IsChecked == true) current_user.id_gender = 2;
                    else current_user.id_gender = 3;
                    current_user.birthday = Convert.ToDateTime(DateBirth.SelectedDate);
                    UserData current_user_data = Base.RDBase.UserData.Where(x => x.id_user == current_user.id_user).FirstOrDefault();
                    current_user_data.name = Name.Text;
                    current_user_data.surname = Surname.Text;
                    current_user_data.patronymic = Patronymic.Text;

                    Delete del = new Delete("Сохранить изменения?");
                    del.ShowDialog();
                    if (del.YesOrNo())
                    {
                        Base.RDBase.SaveChanges();
                        SomeMessage someMessage = new SomeMessage();
                        someMessage.ShowDialog();
                    }


                }
                catch
                {
                    SomeMessage someMessage = new SomeMessage("Ой! Что-то пошло не так :с", "Досадно");
                    someMessage.ShowDialog();
                }
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private bool CheckingData()
        {
            bool allDataIsCorrect = true;

            if (Name.Text.Length == 0)
            {
                NameMessage.Text = "Поле обязательно для ввода.";
                allDataIsCorrect = false;
            }
            else
            {
                NameMessage.Text = "";
            }
            return allDataIsCorrect;
        }
    }
}

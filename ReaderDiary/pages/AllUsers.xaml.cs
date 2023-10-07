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
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        public AllUsers()
        {
            InitializeComponent();

            List<Account> accounts = Base.RDBase.Account.ToList();
            List<Gender> genders = Base.RDBase.Gender.ToList();
            List<UserData> userDatas = Base.RDBase.UserData.ToList();
            List<UserRole> userRoles = Base.RDBase.UserRole.ToList();

            var users = from gender in genders
                        join account in accounts on gender.id_gender equals account.id_gender
                        join datas in userDatas on account.id_user equals datas.id_user
                        join roles in userRoles on account.id_role equals roles.id_role
                        select new
                        {
                            login = account.login,
                            name = datas.name,
                            surname = datas.surname,
                            patronymic = datas.patronymic,
                            birthday = account.birthday,
                            gender = gender.title,
                            roles = roles.title,
                        };

            ListUsers.ItemsSource = users;
        }
    }
}

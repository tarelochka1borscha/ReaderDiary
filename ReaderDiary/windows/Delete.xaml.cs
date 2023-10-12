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
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        bool action;
        public Delete()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        public Delete(string other_action)
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            TextWindow.Text = other_action;
        }

        public bool YesOrNo()
        {
            return action;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            action = true;
            this.Hide();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            action=false;
            this.Hide();
        }
    }
}

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
    /// Логика взаимодействия для SomeMessage.xaml
    /// </summary>
    public partial class SomeMessage : Window
    {
        public SomeMessage()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        public SomeMessage(string text, string button)
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            TextWindow.Text = text;
            TextButton.Content = button;
        }

        private void Good_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

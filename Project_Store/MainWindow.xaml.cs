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
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Shapes;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow(string login = "")
        {
            InitializeComponent();
            if (login == "") { }
            else { log.Content = login; }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Entrance mform = new Entrance();
            mform.Show();
            Close();
        }
        private void MainTovar_Click(object sender, RoutedEventArgs e)
        {
            MainTovar mform = new MainTovar();
            mform.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Entrance mform = new Entrance();
            mform.Show();
            Close();
        }

        private void Товари_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Вихід_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

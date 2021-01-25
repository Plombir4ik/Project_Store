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
        public MainWindow(string login)
        {
            InitializeComponent();
            log.Text = login;
        }

        private void BtnUnlogin(object sender, RoutedEventArgs e)
        {
            Entrance form = new Entrance();
            form.Show();
            Close();
        }

        private void BtnMainTovar(object sender, RoutedEventArgs e)
        {
            MainTovar form = new MainTovar(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainOrder(object sender, RoutedEventArgs e)
        {
            MainOrder form = new MainOrder(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainClient(object sender, RoutedEventArgs e)
        {
            MainClient form = new MainClient(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainJournal(object sender, RoutedEventArgs e)
        {
            //MainJournal form = new MainJournal(log.Text);
            //form.Show();
            //Close();
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

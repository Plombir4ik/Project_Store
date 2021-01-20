using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
//using Microsoft.Office.Interop.Word;
//using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainTovar : Window
    {
        MySqlDataAdapter sda, sda1;
        MySqlCommandBuilder scb, scb1;
        System.Data.DataTable dt, dt1;

        private void MainTovar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void toMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mform = new MainWindow();
            mform.Show();
            Close();
        }

        private void AddTovar(object sender, RoutedEventArgs e)
        {
            AddTovar mform = new AddTovar();
            mform.Show();
        }

        public MainTovar()
        {
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Left = 0;
            this.Top = 0;
            this.WindowState = WindowState.Normal;
                Info();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Info()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlConnection con = new MySqlConnection("server=localhost;port=3306;username=root;database=compstore");
            sda = new MySqlDataAdapter("select * from tovar", con);
            dt = new System.Data.DataTable();
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}

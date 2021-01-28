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
using System.Windows.Media.Animation;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Zvits : Window
    {
        string login = "";
        public Zvits(string login = "")
        {
            InitializeComponent();
            log.Text = login;
            this.login = login;
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Left = 0;
            this.Top = 0;
            this.WindowState = WindowState.Maximized;
            Info();
            Info2();
            Info3();
            Info4();
            Info5();
            StoreFill();
        }
        private void ToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mform = new MainWindow(log.Text);
            mform.Show();
            Close();
        }
       
        private void DataGridTovar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridTovar_Copy.SelectedItem != null && DataGridTovar_Copy.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                Info();
            }
        }
        public void Info()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(Number) as 'StoreNumber', sum(PurchasePrice) as 'StorePrice' from tovar", DB.GetConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridStore.ItemsSource = dt.DefaultView;
        }
        public void Info2()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(Number) as 'OborotNumber', sum(Pay) as 'OborotValue' from orders", DB.GetConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridTovar_Copy1.ItemsSource = dt.DefaultView;
        }
        public void Info3()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(Number) as 'RevenueNumber', sum(Pay) as 'RevenueValue' from orders", DB.GetConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridTovar_Copy3.ItemsSource = dt.DefaultView;
        }
        public void Info4()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter sda = new MySqlDataAdapter("select tovar.ID, tovar.Name, sum(orders.Number) as 'SellNumber' from tovar, orders where tovar.ID = orders.ID_T order by orders.Number desc limit 1", DB.GetConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridTovar_Copy.ItemsSource = dt.DefaultView;
        }
        public void Info5()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(Number) as 'RevenueNumber', sum(Pay) as 'RevenueValue' from orders", DB.GetConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridTovar_Copy2.ItemsSource = dt.DefaultView;
        }
        public void StoreFill()
        {
            //StoreDatabase DB = new StoreDatabase();
            //MySqlDataAdapter sda = new MySqlDataAdapter("")
        }
    }
}

using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Project_Store
{
    public partial class Zvits : Window
    {
        public Zvits(string login = "")
        {
            InitializeComponent();
            log.Text = login;
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Left = 0;
            this.Top = 0;
            this.WindowState = WindowState.Maximized;
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
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(orders.Number) as 'RevenueNumber', sum(orders.Pay - tovar.PurchasePrice) as 'RevenueValue' from orders, tovar", DB.GetConnection());
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
        public void StoreFill()
        {
            Info();
            Info2();
            Info3();
            Info4();
        }

        private void ToUpdate(object sender, RoutedEventArgs e)
        {
            StoreFill();
        }
    }
}

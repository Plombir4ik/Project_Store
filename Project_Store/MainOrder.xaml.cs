using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using System.Windows.Media.Animation;

namespace Project_Store
{
    public partial class MainOrder : Window
    {
        bool a = false;
        public MainOrder(string login)
        {
            InitializeComponent();
            log.Text = login;
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Left = 0;
            this.Top = 0;
            this.WindowState = WindowState.Maximized;
            Info();
        }
        private void ToSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnSearchTovar(this, null);
        }
        private void ToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mform = new MainWindow(log.Text);
            mform.Show();
            Close();
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            AddOrder mform = new AddOrder(log.Text, this);
            mform.Show();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Info();
        }

        private void BtnSearchTovar(object sender, RoutedEventArgs e)
        {
            StoreDatabase DB = new StoreDatabase();
            string searching;
            if (ButtonSearchID.IsChecked == true)
            {
                searching = "select * from orders where orders.ID = '" + SearchBox.Text + "' ";
            }
            else if (ButtonSearchManufacturer.IsChecked == true)
            {
                searching = "select * from orders where orders.Number like '%"+SearchBox.Text+"%'";
            }
            else if (ButtonSearchName.IsChecked == true)
            {
                searching = "select * from orders where orders.Discount like '%" + SearchBox.Text + "%'";
            }
            else
            {
                searching = "select * from orders where orders.Pay = '" + SearchBox.Text + "' ";
            }
            MySqlCommand thesearch = new MySqlCommand(searching, DB.GetConnection());
            DB.OpenConnection();
            if (Convert.ToInt32(thesearch.ExecuteScalar()) <= 0)
            {
                MessageBox.Show("Нима");
                Info();
                SearchBox.Text = "";
            }
            else
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(searching, DB.GetConnection());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataGridOrder.ItemsSource = dt.DefaultView;
            }
            DB.CloseConnection();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (a == false)
            {
                DoubleAnimation anim = new DoubleAnimation();
                DoubleAnimation anim2 = new DoubleAnimation();
                DoubleAnimation anim3 = new DoubleAnimation();
                DoubleAnimation anim4 = new DoubleAnimation();
                anim.From = 33;
                anim.To = 600;
                anim2.From = 0;
                anim2.To = 1;
                anim3.From = 0;
                anim3.To = 1;
                anim4.From = 0;
                anim4.To = 1;
                anim.Duration = TimeSpan.FromSeconds(0.5);
                anim2.Duration = TimeSpan.FromSeconds(0.25);
                anim3.Duration = TimeSpan.FromSeconds(0.5);
                anim4.Duration = TimeSpan.FromSeconds(0.75);
                ramka.BeginAnimation(WidthProperty, anim);
                ButtonSearchID.BeginAnimation(OpacityProperty, anim2);
                ButtonSearchManufacturer.BeginAnimation(OpacityProperty, anim3);
                ButtonSearchName.BeginAnimation(OpacityProperty, anim4);
                a = true;
            }
            else
            {
                DoubleAnimation anim = new DoubleAnimation();
                DoubleAnimation anim2 = new DoubleAnimation();
                DoubleAnimation anim3 = new DoubleAnimation();
                DoubleAnimation anim4 = new DoubleAnimation();
                anim.From = 600;
                anim.To = 33;
                anim2.From = 1;
                anim2.To = 0;
                anim3.From = 1;
                anim3.To = 0;
                anim4.From = 1;
                anim4.To = 0;
                anim.Duration = TimeSpan.FromSeconds(0.5);
                anim2.Duration = TimeSpan.FromSeconds(0.5);
                anim3.Duration = TimeSpan.FromSeconds(0.5);
                anim4.Duration = TimeSpan.FromSeconds(0.25);
                ramka.BeginAnimation(WidthProperty, anim);
                ButtonSearchID.BeginAnimation(OpacityProperty, anim2);
                ButtonSearchManufacturer.BeginAnimation(OpacityProperty, anim3);
                ButtonSearchName.BeginAnimation(OpacityProperty, anim4);
                a = false;
            }
        }

        public void Info()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from orders", DB.GetConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridOrder.ItemsSource = dt.DefaultView;
        }
        private void SearchBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SearchBox.Text = "";
            SearchBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                Info();
            }
        }
    }
}

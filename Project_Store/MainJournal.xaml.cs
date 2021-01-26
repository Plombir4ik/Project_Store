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
    public partial class MainJournal : Window
    {
        long id = 0;
        bool a = false;
        public MainJournal(string login)
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
        private void toMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mform = new MainWindow(log.Text);
            mform.Show();
            Close();
        }

        private void AddTovar(object sender, RoutedEventArgs e)
        {
            //AddTovar mform = new AddTovar(this);
            //mform.Show();
        }

        private void BtnEditTovar(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null && dataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                //AddTovar a = new AddTovar(this, id);
                //a.Show();
            }
            else
            {
                MessageBox.Show("Виберіть потрібний товар!");
            }
        }

        private void BtnDeleteTovar(object sender, RoutedEventArgs e)
        {
            
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Info();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSearchTovar(object sender, RoutedEventArgs e)
        {
            StoreDatabase DB = new StoreDatabase();
            string searching;
            if (ButtonSearchID.IsChecked == true)
            {
                searching = "select * from tovar where tovar.id = '" + SearchBox.Text + "' ";
            }
            else if (ButtonSearchManufacturer.IsChecked == true)
            {
                searching = "select * from tovar where tovar.Manufacturer like '%"+SearchBox.Text+"%'";
            }
            else if (ButtonSearchName.IsChecked == true)
            {
                searching = "select * from tovar where tovar.Name like '%" + SearchBox.Text + "%'";
            }
            else
            {
                searching = "select * from tovar where tovar.id = '" + SearchBox.Text + "' ";
            }
            MySqlCommand thesearch = new MySqlCommand(searching, DB.getConnection());
            DB.openConnection();
            if (Convert.ToInt32(thesearch.ExecuteScalar()) <= 0)
            {
                MessageBox.Show("Нима");
                Info();
                SearchBox.Text = "";
            }
            else
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(searching, DB.getConnection());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }
            DB.closeConnection();
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
                //id_ellipse.BeginAnimation(OpacityProperty, anim2);
                ButtonSearchID.BeginAnimation(OpacityProperty, anim2);
                ButtonSearchManufacturer.BeginAnimation(OpacityProperty, anim3);
                //Manufacturer_ellipse.BeginAnimation(OpacityProperty, anim3);
                ButtonSearchName.BeginAnimation(OpacityProperty, anim4);
                //Name_ellipse.BeginAnimation(OpacityProperty, anim4);
                a = false;
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null && dataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                foreach (DataRowView row in dataGrid.SelectedItems)
                {
                    if (row.Row.ItemArray[0] != DBNull.Value)
                    {
                        id = Convert.ToInt32(row.Row.ItemArray[0]);
                    }
                }
            }
        }
        public void Info()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tovar", DB.getConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
        private void SearchBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SearchBox.Text = "";
            SearchBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}

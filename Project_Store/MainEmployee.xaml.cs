﻿using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using System.Windows.Media.Animation;

namespace Project_Store
{
    public partial class MainEmployee : Window
    {
        long id = 0;
        bool a = false;
        public MainEmployee(string login)
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
        private void ToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mform = new MainWindow(log.Text);
            mform.Show();
            Close();
        }

        private void AddTovar(object sender, RoutedEventArgs e)
        {
            AddEmployee mform = new AddEmployee(log.Text, this);
            mform.Show();
        }

        private void BtnEditTovar(object sender, RoutedEventArgs e)
        {
            if (DataGridTovar.SelectedItem != null && DataGridTovar.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                AddEmployee a = new AddEmployee(log.Text, this, id);
                a.Show();
            }
            else
            {
                MessageBox.Show("Виберіть потрібного працівника!");
            }
        }

        private void BtnDeleteTovar(object sender, RoutedEventArgs e)
        {
            if (DataGridTovar.SelectedItem != null && DataGridTovar.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                var result = MessageBox.Show("Ви точно хочете звільнити даного працівника?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    StoreDatabase DB = new StoreDatabase();
                    DB.OpenConnection();
                    MySqlCommand dismissal = new MySqlCommand("UPDATE prazivnuku SET Status = 0 WHERE ID = '" + id + "';", DB.GetConnection());
                    dismissal.ExecuteNonQuery();
                    DB.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Виберіть працівника!");
            }
            Info();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Info();
        }
        private void ToSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnSearchTovar(this, null);
        }
        private void BtnSearchTovar(object sender, RoutedEventArgs e)
        {
            string searching;
            if (ButtonSearchID.IsChecked == true)
            {
                searching = "select * from prazivnuku where id = '" + SearchBox.Text + "' ";
            }
            else if (ButtonSearchManufacturer.IsChecked == true)
            {
                searching = "select * from prazivnuku where login like '%" + SearchBox.Text + "%'";
            }
            else if (ButtonSearchName.IsChecked == true)
            {
                searching = "select * from prazivnuku where concat(P, ' ', I, ' ', B) like '%" + SearchBox.Text + "%'";
            }
            else
            {
                searching = "select * from prazivnuku where id = '" + SearchBox.Text + "' ";
            }
            StoreDatabase DB = new StoreDatabase();
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
                DataGridTovar.ItemsSource = dt.DefaultView;
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
                //id_ellipse.BeginAnimation(OpacityProperty, anim2);
                ButtonSearchID.BeginAnimation(OpacityProperty, anim2);
                ButtonSearchManufacturer.BeginAnimation(OpacityProperty, anim3);
                //Manufacturer_ellipse.BeginAnimation(OpacityProperty, anim3);
                ButtonSearchName.BeginAnimation(OpacityProperty, anim4);
                //Name_ellipse.BeginAnimation(OpacityProperty, anim4);
                a = false;
            }
        }

        private void DataGridTovar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridTovar.SelectedItem != null && DataGridTovar.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                foreach (DataRowView row in DataGridTovar.SelectedItems)
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
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from prazivnuku", DB.GetConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridTovar.ItemsSource = dt.DefaultView;
        }
        private void SearchBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SearchBox.Text = "";
            SearchBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchBox.Text == "")
            {
                Info();
            }
        }

        private void ToZvits(object sender, RoutedEventArgs e)
        {
            Zvits form = new Zvits(log.Text);
            form.Show();
            Close();
        }
    }
}

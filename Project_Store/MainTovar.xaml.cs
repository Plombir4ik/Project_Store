﻿using System;
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
        long id = 0;

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

        private void BtnEditTovar(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null && dataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                AddTovar a = new AddTovar(id);
                a.Show();
            }
            else
            {
                MessageBox.Show("Виберіть потрібний товар!");
            }
        }

        private void BtnDeleteTovar(object sender, RoutedEventArgs e)
        {
            StoreDatabase DB = new StoreDatabase();
            if (dataGrid.SelectedItem != null && dataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                DB.openConnection();
                MySqlCommand deleting = new MySqlCommand("DELETE FROM tovar WHERE ID = '" + id + "';", DB.getConnection());
                deleting.ExecuteNonQuery();
                DB.closeConnection();
            }
            else
            {
                MessageBox.Show("Виберіть товар!");
            }
            Info();
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
            MySqlConnection con = new MySqlConnection("server=localhost; port=3306;username=root;database=compstore");
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
            else if (LubchekPodymau.IsChecked == true)
            {
                MessageBox.Show("Подумай.");
                searching = "select * from tovar where tovar.id = '" + SearchBox.Text + "' ";
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
                sda = new MySqlDataAdapter(searching, con);
                dt = new System.Data.DataTable();
                sda.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }
            DB.closeConnection();
        }

        public MainTovar()
        {
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Left = 0;
            this.Top = 0;
            this.WindowState = WindowState.Maximized;
            Info();
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
            MySqlConnection con = new MySqlConnection("server=localhost;port=3306;username=root;database=compstore");
            sda = new MySqlDataAdapter("select * from tovar", con);
            dt = new System.Data.DataTable();
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}

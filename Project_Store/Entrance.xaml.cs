﻿using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Data;


namespace Project_Store
{
    public partial class Entrance : Window
    {
        public Entrance()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void ToPassword(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                PasswordTextBox.Focus();
        }
        private void AcceptLogin(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ButtonEntrance(this, null);
        }
        private void ButtonEntrance(object sender, RoutedEventArgs e)
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select login from prazivnuku where login = '"+LoginTextBox.Text+"' and password = '"+PasswordTextBox.Password+"';", DB.GetConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);    
            if (table.Rows.Count > 0)       
            {
                MainWindow mform = new MainWindow(LoginTextBox.Text);
                    mform.Show();
                FillJournal jr = new FillJournal();
                jr.FillProcess(LoginTextBox.Text, "Login");
                Close();
            }
            else { Error.Visibility = Visibility.Visible; }
        }
    }
}

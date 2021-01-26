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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для AddTovar.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        readonly long id = 0;
        private readonly MainEmployee mform;
        public AddEmployee(MainEmployee form, long id = -1)
        {
            InitializeComponent();
            mform = form;
            this.id = id;
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                Label.Content = "Змінити вибраний товар";
                StoreDatabase DB = new StoreDatabase();
                MySqlCommand command = new MySqlCommand("select * from prazivnuku where id = '" + id + "';", DB.GetConnection());
                DB.OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BoxPIB.Text = (string)reader.GetValue(1);
                        BoxLogin.Text = (string)reader.GetValue(2);
                        BoxPassword.Text = (string)reader.GetValue(3);
                    }
                }
                DB.CloseConnection();
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            if (BoxPIB.Text == "" || BoxLogin.Text == "" || BoxPassword.Text == "")
            {
                MessageBox.Show("Щось тут не так");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                if (id == -1)
                {
                    MySqlCommand adding = new MySqlCommand("INSERT INTO prazivnuku (PIB, login, password) VALUES ('" + BoxPIB.Text + "', '" + BoxLogin.Text + "', '" + BoxPassword.Text + "');", DB.GetConnection());
                    DB.OpenConnection();
                    if (adding.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Працівника успішно додано! ВІТАЄМО!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Хм, товар не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.CloseConnection();
                }
                else
                {
                    MySqlCommand editing = new MySqlCommand("UPDATE prazivnuku SET `PIB` = '"+BoxPIB.Text+"', `login` = '"+BoxLogin.Text+"', `password` = '"+BoxPassword.Text+"' where ID = '"+id+"';", DB.GetConnection());
                    DB.OpenConnection();
                    if (editing.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Інформація про товар \nбула успішно змінена!", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Інформація про товар \nне була успішно змінена.", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.CloseConnection();
                }
                mform.Info();
                this.Close();
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}

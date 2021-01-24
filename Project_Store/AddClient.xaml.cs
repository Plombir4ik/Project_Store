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
    public partial class AddClient : Window
    {
        long id = 0;
        public AddClient(long id = -1)
        {
            InitializeComponent();
            this.id = id;
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                Label.Content = "Змінити інформацію про клієнта";
                StoreDatabase DB = new StoreDatabase();
                MySqlCommand command = new MySqlCommand("select * from client where id = '" + id + "';", DB.getConnection());
                DB.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BoxPIB.Text = (string)reader.GetValue(1);
                        BoxPhone.Text = (string)reader.GetValue(2);
                        BoxEmail.Text = (string)reader.GetValue(3);
                    }
                    reader.Close();
                    DB.closeConnection();
                }
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            StoreDatabase DB = new StoreDatabase();
            if (BoxPIB.Text == "" || BoxPhone.Text == "" || BoxEmail.Text == "")
            {
                MessageBox.Show("Ви забули ввести якусь інформацію!");
            }
            else
            {
                if (id == -1)
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand adding = new MySqlCommand("INSERT INTO client (PIB, Phone, Email) VALUES ('" + BoxPIB.Text + "', '" + BoxPhone.Text + "', '" + BoxEmail.Text + "');", DB.getConnection());
                    DB.openConnection();
                    if (adding.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Клієнта успішно додано!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Хм, клієнта не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.closeConnection();
                }
                else
                {
                    MySqlCommand editing = new MySqlCommand("UPDATE client SET `PIB` = '" + BoxPIB.Text + "', `Phone` = '" + BoxPhone.Text + "', `Email` = '" + BoxEmail.Text + "' where ID = '" + id + "';", DB.getConnection());
                    DB.openConnection();
                    if (editing.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Інформація про клієнта \nбула успішно змінена!", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Інформація про клієнта \nне була успішно змінена.", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.closeConnection();
                }
                this.Close();
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
using Xceed.Wpf.Toolkit;
using System.Text.RegularExpressions;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для AddTovar.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        readonly long id = 0;
        private readonly MainClient mform;
        string login = "";
        public AddClient(string login, MainClient form, long id = -1)
        {
            InitializeComponent();
            this.id = id;
            this.login = login;
            mform = form;
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                Label.Content = "Змінити інформацію про клієнта";
                StoreDatabase DB = new StoreDatabase();
                MySqlCommand command = new MySqlCommand("select * from client where id = '" + id + "';", DB.GetConnection());
                DB.OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BoxPIB.Text = (string)reader.GetValue(1);
                        BoxPhoneMask.Text = (string)reader.GetValue(2);
                        BoxEmail.Text = (string)reader.GetValue(3);
                    }
                    reader.Close();
                }
                DB.CloseConnection();
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            if (!BoxPhoneMask.IsMaskFull || BoxPIB.Text == "" || BoxEmail.Text == "")
            {
                System.Windows.MessageBox.Show("Ви забули ввести якусь інформацію!");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                if (id == -1)
                {
                    MySqlCommand adding = new MySqlCommand("INSERT INTO client (PIB, Phone, Email) VALUES ('"+BoxPIB.Text+"', '" + BoxPhoneMask.Text + "', '" + BoxEmail.Text + "');", DB.GetConnection());
                    DB.OpenConnection();
                    if (adding.ExecuteNonQuery() > 0)
                    {
                        System.Windows.MessageBox.Show("Клієнта успішно додано!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        FillJournal jr = new FillJournal();
                        jr.FillProcess(login, "AddClient");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Хм, клієнта не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.CloseConnection();
                }
                else
                {
                    MySqlCommand editing = new MySqlCommand("UPDATE client SET `PIB` = '"+BoxPIB.Text+"', `Phone` = '"+BoxPhoneMask.Text+"', `Email` = '"+BoxEmail.Text+"' where ID = '"+id+"';", DB.GetConnection());
                    DB.OpenConnection();
                    if (editing.ExecuteNonQuery() > 0)
                    {
                        System.Windows.MessageBox.Show("Інформація про клієнта \nбула успішно змінена!", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        FillJournal jr = new FillJournal();
                        jr.FillProcess(login, "EditClient");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Інформація про клієнта \nне була успішно змінена.", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.CloseConnection();
                }
                mform.Info();
                this.Close();
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

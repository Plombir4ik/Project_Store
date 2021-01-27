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
                        BoxP.Text = (string)reader.GetValue(1);
                        BoxI.Text = (string)reader.GetValue(2);
                        BoxB.Text = (string)reader.GetValue(3);
                        BoxPhoneMask.Text = (string)reader.GetValue(4);
                        BoxEmail.Text = (string)reader.GetValue(5);
                    }
                    reader.Close();
                }
                DB.CloseConnection();
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            if (!BoxPhoneMask.IsMaskFull || BoxP.Text == "" || BoxI.Text == "" || BoxB.Text == "" || BoxEmail.Text == "")
            {
                System.Windows.MessageBox.Show("Ви забули ввести якусь інформацію!");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                if (id == -1)
                {
                    MySqlCommand adding = new MySqlCommand("INSERT INTO client (P, I, B, Phone, Email) VALUES (@P, @I, @B, '" + BoxPhoneMask.Text + "', '" + BoxEmail.Text + "');", DB.GetConnection());
                    adding.Parameters.AddWithValue("@P", BoxP.Text);
                    adding.Parameters.AddWithValue("@I", BoxI.Text);
                    adding.Parameters.AddWithValue("@B", BoxB.Text);
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
                    MySqlCommand editing = new MySqlCommand("UPDATE client SET `P` = @P, `I` = @I, `B` = @B, `Phone` = '" + BoxPhoneMask.Text+"', `Email` = '"+BoxEmail.Text+"' where ID = '"+id+"';", DB.GetConnection());
                    editing.Parameters.AddWithValue("@P", BoxP.Text);
                    editing.Parameters.AddWithValue("@I", BoxI.Text);
                    editing.Parameters.AddWithValue("@B", BoxB.Text);
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

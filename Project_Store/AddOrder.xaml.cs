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
    public partial class AddOrder : Window
    {
        long id = 0;
        private readonly MainTovar mform;
        public AddOrder(MainOrder mform, long id = -1)
        {
            InitializeComponent();
            this.id = id;
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                Label.Content = "Змінити інформацію про замовлення";
                StoreDatabase DB = new StoreDatabase();
                MySqlCommand command = new MySqlCommand("select * from orders where id = '" + id + "';", DB.getConnection());
                DB.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //ID_TBox.Text = Convert.ToString(reader.GetValue(1));
                        //ID_CBox.Text = Convert.ToString(reader.GetValue(2));
                        //ID_PBox.Text = Convert.ToString(reader.GetValue(3));
                        //NumberBox.Text = Convert.ToString(reader.GetValue(4));
                    }
                    reader.Close();
                    DB.closeConnection();
                }
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            StoreDatabase DB = new StoreDatabase();
            if (PayBox.Text == "" || ID_CBox.Text == "" || ID_TBox.Text == "")
            {
                MessageBox.Show("Ви забули ввести якусь інформацію!");
            }
            else
            {
                if (id == -1)
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand adding = new MySqlCommand("INSERT INTO orders (ID_C, ID_T, ID_P, Number, Pay, Discount, Date) VALUES ('" + ID_CBox.Text + "', '" + ID_TBox.Text + "', '" + ID_PBox.Text + "', '" + NumberBox.Text + "', '" + PayBox.Text + "', '" + DiscountBox.Text + "', '" + DateBox.Text + "');", DB.getConnection());
                    DB.openConnection();
                    if (adding.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Замовлення успішно додано!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Хм, замовлення не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.closeConnection();
                }
                else
                {
                    MySqlCommand editing = new MySqlCommand(); //("UPDATE orders SET `PIB` = '" + BoxPIB.Text + "', `Phone` = '" + BoxPhone.Text + "', `Email` = '" + BoxEmail.Text + "' where ID = '" + id + "';", DB.getConnection());
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
                mform.Info();
                this.Close();
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnComboboxTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ID_CBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ID_TBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BoxEmail_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

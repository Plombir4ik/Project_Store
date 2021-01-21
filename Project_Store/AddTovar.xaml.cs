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
    public partial class AddTovar : Window
    {
        long id = 0;
        public AddTovar(long id = -1)
        {
            InitializeComponent();
            this.id = id;
            InitializeComponent();
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                StoreDatabase DB = new StoreDatabase();
                MySqlCommand command = new MySqlCommand("select * from tovar where id = '" + id + "';", DB.getConnection());
                DB.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BoxTypeOF.Text = (string)reader.GetValue(1);
                        BoxManufacturer.Text = (string)reader.GetValue(2);
                        BoxName.Text = (string)reader.GetValue(3);
                        BoxSpecifications.Text = (string)reader.GetValue(4);
                        BoxDescription.Text = (string)reader.GetValue(5);
                        //BoxNumber.Text = (string)reader.GetValue(6);
                        //BoxPurchasePrice.Text = (string)reader.GetValue(7);
                        //BoxSellingPrice.Text = (string)reader.GetValue(8);
                    }
                    reader.Close();
                    DB.closeConnection();
                }
                Label.Content = "Змінити вибраного працівника";
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            StoreDatabase DB = new StoreDatabase();
            if (BoxTypeOF.Text == "")
            {
                MessageBox.Show("Щось тут не так");
            }
            else
            {
                if (id == -1)
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand adding = new MySqlCommand("INSERT INTO tovar (ID, Type, Manufacturer, Name, Specifications, Description, Number, PurchasePrice, SellingPrice) VALUES " +
                        "('" + BoxTypeOF.Text + "', '" + BoxManufacturer.Text + "', '" + BoxName.Text + "', '" + BoxSpecifications.Text + "', '" + BoxDescription.Text + "', '" + BoxNumber.Text + "', '" + BoxPurchasePrice.Text + "', '" + BoxSellingPrice.Text + "');", DB.getConnection());
                    DB.openConnection();
                    if (adding.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Товар успішно додано!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Хм, товар не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.closeConnection();
                }
                else
                {
                    MySqlCommand editing = new MySqlCommand("UPDATE tovar SET `Type` = '" + BoxTypeOF.Text + "', `Manufacturer` = '" + BoxManufacturer.Text + "', `Name` = '" + BoxName.Text + "', `Specifications` = '" + BoxSpecifications.Text + "', `Description` = '" + BoxDescription.Text + "', `Number` = '" + BoxNumber.Text + "', `PurchasePrice` = '" + BoxPurchasePrice.Text + "', `SellingPrice` = '"+BoxSellingPrice.Text+"' where ID = '" + id + "';", DB.getConnection());
                    DB.openConnection();
                    if (editing.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Інформація про товар \nбула успішно змінена!", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Інформація про товар \nне була успішно змінена.", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.closeConnection();
                }
                this.Hide();
            }
        }
        void OnComboboxTextChanged(object sender, RoutedEventArgs e)
        {
            BoxTypeOF.Items.Clear();
        }
        void OnComboboxTextChanged2(object sender, RoutedEventArgs e)
        {
            BoxManufacturer.Items.Clear();
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BoxManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

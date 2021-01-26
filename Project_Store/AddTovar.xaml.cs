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
        private readonly MainTovar mform;
        public AddTovar(MainTovar form, long id = -1)
        {
            InitializeComponent();
            fillComboBoxTypeOf();
            fillComboBoxManufacturer();
            mform = form;
            this.id = id;
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                Label.Content = "Змінити вибраний товар";
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
                        BoxNumber.Text = Convert.ToString(reader.GetValue(6));
                        BoxPurchasePrice.Text = Convert.ToString(reader.GetValue(7));
                        BoxSellingPrice.Text = Convert.ToString(reader.GetValue(8));
                    }
                }
                DB.closeConnection();
                BoxTypeOF.IsDropDownOpen = false;
                BoxManufacturer.IsDropDownOpen = false;
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            if (BoxTypeOF.Text == "")
            {
                MessageBox.Show("Щось тут не так");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                if (id == -1)
                {
                    MySqlCommand adding = new MySqlCommand("INSERT INTO tovar (Type, Manufacturer, Name, Specifications, Description, Number, PurchasePrice, SellingPrice) VALUES " +
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
                    MySqlCommand editing = new MySqlCommand("UPDATE tovar SET `Type` = '" + BoxTypeOF.Text + "', `Manufacturer` = '" + BoxManufacturer.Text + "', `Name` = '" + BoxName.Text + "', `Specifications` = '" + BoxSpecifications.Text + "', `Description` = '" + BoxDescription.Text + "', `Number` = '" + BoxNumber.Text + "', `PurchasePrice` = '" + BoxPurchasePrice.Text + "', `SellingPrice` = '" + BoxSellingPrice.Text + "' where ID = '" + id + "';", DB.getConnection());
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
                mform.Info();
                this.Close();
            }
        }

        private void fillComboBoxTypeOf()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataReader myReader;
            if (BoxTypeOF.Text == "")
            {
                MySqlCommand comm = new MySqlCommand("select Type as 'Type' from tovar group by Type", DB.getConnection());
                DB.openConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxTypeOF.Items.Add(myReader.GetString("Type"));
                }
                DB.closeConnection();
            }
            else
            {
                MySqlCommand comm = new MySqlCommand("select Type from tovar where Type like '%" + BoxTypeOF.Text + "%' group by Type", DB.getConnection());
                DB.openConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxTypeOF.Items.Add(myReader.GetString("Type"));
                }
                DB.closeConnection();
            }
        }
        private void fillComboBoxManufacturer()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataReader myReader;
            if (BoxManufacturer.Text == "")
            {
                DB.openConnection();
                MySqlCommand comm = new MySqlCommand("select Manufacturer from tovar group by Manufacturer", DB.getConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxManufacturer.Items.Add(myReader.GetString("Manufacturer"));
                }
                DB.closeConnection();
            }
            else
            {
                MySqlCommand comm = new MySqlCommand("select Manufacturer from tovar where Manufacturer like '%" + BoxManufacturer.Text + "%' group by Manufacturer", DB.getConnection());
                DB.openConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxManufacturer.Items.Add(myReader.GetString("Manufacturer"));
                }
                DB.closeConnection();
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BoxTypeOFTextChanged(object sender, RoutedEventArgs e)
        {
            BoxTypeOF.Items.Clear();
            fillComboBoxTypeOf();
            BoxTypeOF.IsDropDownOpen = true;
        }

        private void BoxManufacturerTextChanged(object sender, RoutedEventArgs e)
        {
            BoxManufacturer.Items.Clear();
            fillComboBoxManufacturer();
            BoxManufacturer.IsDropDownOpen = true;
        }

    }
}

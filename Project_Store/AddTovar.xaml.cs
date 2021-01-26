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
        readonly long id = 0;
        private readonly MainTovar mform;
        string login = "";
        public AddTovar(string login, MainTovar form, long id = -1)
        {
            InitializeComponent();
            FillComboBoxTypeOf();
            FillComboBoxManufacturer();
            mform = form;
            this.login = login;
            this.id = id;
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                Label.Content = "Змінити вибраний товар";
                StoreDatabase DB = new StoreDatabase();
                MySqlCommand command = new MySqlCommand("select * from tovar where id = '" + id + "';", DB.GetConnection());
                DB.OpenConnection();
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
                DB.CloseConnection();
                BoxTypeOF.IsDropDownOpen = false;
                BoxManufacturer.IsDropDownOpen = false;
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            if (BoxTypeOF.Text == "" || BoxManufacturer.Text == "" || BoxNumber.Text == ""|| BoxSpecifications.Text == "" || BoxDescription.Text == "" || BoxPurchasePrice.Text == "" || BoxName.Text == "" || BoxSellingPrice.Text == "")
            {
                MessageBox.Show("Щось тут не так");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                if (id == -1)
                {
                    MySqlCommand adding = new MySqlCommand("INSERT INTO tovar (Type, Manufacturer, Name, Specifications, Description, Number, PurchasePrice, SellingPrice) VALUES " +
                        "('" + BoxTypeOF.Text + "', '" + BoxManufacturer.Text + "', '" + BoxName.Text + "', '" + BoxSpecifications.Text + "', '" + BoxDescription.Text + "', '" + BoxNumber.Text + "', '" + BoxPurchasePrice.Text + "', '" + BoxSellingPrice.Text + "');", DB.GetConnection());
                    DB.OpenConnection();
                    if (adding.ExecuteNonQuery() > 0)
                    {
                        FillJournal jr = new FillJournal();
                        jr.FillProcess(login, "AddTovar");
                        MessageBox.Show("Товар успішно додано!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);                       
                    }
                    else
                    {
                        MessageBox.Show("Хм, товар не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.CloseConnection();
                }
                else
                {
                    MySqlCommand editing = new MySqlCommand("UPDATE tovar SET `Type` = '" + BoxTypeOF.Text + "', `Manufacturer` = '" + BoxManufacturer.Text + "', `Name` = '" + BoxName.Text + "', `Specifications` = '" + BoxSpecifications.Text + "', `Description` = '" + BoxDescription.Text + "', `Number` = '" + BoxNumber.Text + "', `PurchasePrice` = '" + BoxPurchasePrice.Text + "', `SellingPrice` = '" + BoxSellingPrice.Text + "' where ID = '" + id + "';", DB.GetConnection());
                    DB.OpenConnection();
                    if (editing.ExecuteNonQuery() > 0)
                    {
                        FillJournal jr = new FillJournal();
                        jr.FillProcess(login, "EditTovar");
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

        private void FillComboBoxTypeOf()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataReader myReader;
            if (BoxTypeOF.Text == "")
            {
                MySqlCommand comm = new MySqlCommand("select Type as 'Type' from tovar group by Type", DB.GetConnection());
                DB.OpenConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxTypeOF.Items.Add(myReader.GetString("Type"));
                }
                DB.CloseConnection();
            }
            else
            {
                MySqlCommand comm = new MySqlCommand("select Type from tovar where Type like '%" + BoxTypeOF.Text + "%' group by Type", DB.GetConnection());
                DB.OpenConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxTypeOF.Items.Add(myReader.GetString("Type"));
                }
                DB.CloseConnection();
            }
        }
        private void FillComboBoxManufacturer()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataReader myReader;
            if (BoxManufacturer.Text == "")
            {
                DB.OpenConnection();
                MySqlCommand comm = new MySqlCommand("select Manufacturer from tovar group by Manufacturer", DB.GetConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxManufacturer.Items.Add(myReader.GetString("Manufacturer"));
                }
                DB.CloseConnection();
            }
            else
            {
                MySqlCommand comm = new MySqlCommand("select Manufacturer from tovar where Manufacturer like '%" + BoxManufacturer.Text + "%' group by Manufacturer", DB.GetConnection());
                DB.OpenConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxManufacturer.Items.Add(myReader.GetString("Manufacturer"));
                }
                DB.CloseConnection();
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BoxTypeOFTextChanged(object sender, RoutedEventArgs e)
        {
            BoxTypeOF.Items.Clear();
            FillComboBoxTypeOf();
            BoxTypeOF.IsDropDownOpen = true;
        }

        private void BoxManufacturerTextChanged(object sender, RoutedEventArgs e)
        {
            BoxManufacturer.Items.Clear();
            FillComboBoxManufacturer();
            BoxManufacturer.IsDropDownOpen = true;
        }

    }
}

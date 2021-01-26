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
        private readonly MainOrder mform;
        public AddOrder(MainOrder form, long id = -1)
        {
            InitializeComponent();
            fillComboBoxID_C();
            fillComboBoxID_T();
            dP.SelectedDate = DateTime.Now;
            mform = form;
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
            if (PayBox.Text == "" || BoxID_C.Text == "" || BoxID_T.Text == "")
            {
                MessageBox.Show("Ви забули ввести якусь інформацію!");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                if (id == -1)
                {
                    MySqlCommand adding = new MySqlCommand("INSERT INTO orders (ID_C, ID_T, ID_P, Number, Pay, Discount, Date) VALUES ('" + BoxID_C.Text + "', '" + BoxID_T.Text + "', '" + ID_PBox.Text + "', '" + NumberBox.Text + "', '" + PayBox.Text + "', '" + DiscountBox.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');", DB.getConnection());
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
        void fillComboBoxID_C()
        {
            StoreDatabase DB = new StoreDatabase();
            if (BoxID_C.Text == "")
            {
                MySqlDataReader myReader;
                DB.openConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID,') ', PIB) as 'ID_C' from client group by ID", DB.getConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_C.Items.Add(myReader.GetString("ID_C"));
                }
                DB.closeConnection();
            }
            else
            {
                MySqlDataReader myReader;
                DB.openConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID,') ', PIB) as 'ID_C' from client where concat(ID, ') ', PIB) like '%" + BoxID_C.Text + "%' group by ID_C", DB.getConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_C.Items.Add(myReader.GetString("ID_C"));
                }
                DB.closeConnection();
            }
        }
        void fillComboBoxID_T()
        {
            StoreDatabase DB = new StoreDatabase();
            if (BoxID_T.Text == "")
            {
                MySqlDataReader myReader;
                DB.openConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID, ') ', Name) as 'ID_T' from tovar group by ID", DB.getConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_T.Items.Add(myReader.GetString("ID_T"));
                }
                DB.closeConnection();
            }
            else
            {
                MySqlDataReader myReader;
                DB.openConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID, ') ', Name) as 'ID_T' from tovar where like '%" + BoxID_T.Text + "%' group by ID_T" , DB.getConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_T.Items.Add(myReader.GetString("ID_T"));
                }
                DB.closeConnection();
            }
        }

        private void BoxID_CTextChanged(object sender, RoutedEventArgs e)
        {
            BoxID_C.Items.Clear();
            fillComboBoxID_T();
            BoxID_C.IsDropDownOpen = true;
        }
        private void BoxID_TTextChanged(object sender, RoutedEventArgs e)
        {
            BoxID_T.Items.Clear();
            fillComboBoxID_C();
            BoxID_T.IsDropDownOpen = true;
        }

        private void BoxEmail_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

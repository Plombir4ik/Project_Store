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
        public AddTovar()
        {
            InitializeComponent();
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
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                //MySqlCommand adding = new MySqlCommand("INSERT INTO tovar (ID, Type, Manufacturer, Name, Specifications, Description, Number, PurchasePrice, SellingPrice) VALUES " +
                //    "('" + BoxTypeOF.Text + "', '" + BoxManufacturer.Text + "', '" + BoxName.Text + "', '" + BoxSpecifications.Text + "', '" + BoxDescription.Text + "', '" + BoxNumber.Text + "', '" + BoxPurchasePrice.Text + "', '" + BoxSellingPrice.Text + "');", DB.getConnection());
                MySqlCommand adding = new MySqlCommand("INSERT INTO `tovar` (`ID`, `Type`, `Manufacturer`, `Name`, `Specifications`, `Description`, `Number`, `PurchasePrice`, `SellingPrice`) VALUES (@ID, @Type, @Manufacturer, @Name, @Specifications, @Description, @Number, @PurchasePrice, @SellingPrice);", DB.getConnection());
                adding.Parameters.AddWithValue("@ID", "");
                adding.Parameters.AddWithValue("@Type", BoxTypeOF.Text);
                adding.Parameters.AddWithValue("@Manufacturer", BoxManufacturer.Text);
                adding.Parameters.AddWithValue("@Name", BoxName.Text);
                adding.Parameters.AddWithValue("@Specifications", BoxSpecifications.Text);
                adding.Parameters.AddWithValue("@Description", BoxSpecifications.Text);
                adding.Parameters.AddWithValue("@Number", BoxNumber.Text);
                adding.Parameters.AddWithValue("@PurchasePrice", BoxPurchasePrice.Text);
                adding.Parameters.AddWithValue("@SellingPrice", BoxSellingPrice.Text);
                DB.openConnection();
                if (adding.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Товар успішно додано!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    MessageBox.Show("Хм, товар не було додано...", "Створення договору", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
                DB.closeConnection();
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

﻿using System.Windows;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string login)
        {
            InitializeComponent();
            log.Text = login;
        }

        private void BtnUnlogin(object sender, RoutedEventArgs e)
        {
            Entrance form = new Entrance();
            form.Show();
            Close();
        }

        private void BtnMainTovar(object sender, RoutedEventArgs e)
        {
            MainTovar form = new MainTovar(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainOrder(object sender, RoutedEventArgs e)
        {
            MainOrder form = new MainOrder(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainClient(object sender, RoutedEventArgs e)
        {
            MainClient form = new MainClient(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainJournal(object sender, RoutedEventArgs e)
        {
            MainJournal form = new MainJournal(log.Text);
            form.Show();
            Close();
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        void ExitProgram(object sender, ExitEventArgs e)
        {
            MessageBox.Show("Ти дебіл");
        }
    }
}
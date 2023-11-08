using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _1._11._2023
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow view = new MainWindow();
            MainViewModel viewModel = new MainViewModel();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}

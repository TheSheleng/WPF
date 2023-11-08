using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using _08._11._2023.ViewModels;
using _08._11._2023.Views;


namespace _08._11._2023
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow View = new MainWindow();
            MainViewModel ViewModel = new MainViewModel();
            View.DataContext = ViewModel;

            View.Show();
        }
    }
}

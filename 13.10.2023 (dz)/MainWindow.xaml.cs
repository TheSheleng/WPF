using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _13._10._2023__dz_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private bool RuLangFlag = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RuLangFlag = !RuLangFlag;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(RuLangFlag ? "ru" : "en");
            name.Content = lang.Name;
            surname.Content = lang.Surname;
            phone.Content = lang.Phone;
            ok.Content = lang.OK;
            cancel.Content = lang.Cancel;
            change_language.Content = lang.ChangeLanguage;
        }
    }
}

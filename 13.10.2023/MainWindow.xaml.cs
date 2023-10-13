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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _13._10._2023
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
            ResourceDictionary newDictionary = new ResourceDictionary();

            if (RuLangFlag) newDictionary.Source = new Uri("ru_ru.xaml", UriKind.Relative);
            else newDictionary.Source = new Uri("en_en.xaml", UriKind.Relative);

            Application.Current.Resources.MergedDictionaries[0] = newDictionary;
        }
    }
}

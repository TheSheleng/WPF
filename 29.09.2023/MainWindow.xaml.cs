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

namespace _29._09._2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LanguagesModel langM;
        KeyValuePair<string, List<string>> CurrentLang;
        public MainWindow()
        {
            langM = new LanguagesModel();

            langM.AddLanguage("usa.jpg", new List<string> {
                "test button 1",
                "test button 2",
                "test button 3",
            });

            langM.AddLanguage("ger.png", new List<string> {
                "Testtaste 1",
                "Testtaste 2",
                "Testtaste 3",
            });

            langM.AddLanguage("ital.jpg", new List<string> {
                "pulsante di prova 1",
                "pulsante di prova 2",
                "pulsante di prova 3",
            });

            CurrentLang = langM.GetCurrent();

            InitializeComponent();
            TranslateMenu();
        }

        void TranslateMenu()
        { 
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(CurrentLang.Key, UriKind.RelativeOrAbsolute));
            image.Width = 70;
            image.Height = 40;
            LangButt.Content = image;

            Butt1.Content = CurrentLang.Value[0];
            Butt2.Content = CurrentLang.Value[1];
            Butt3.Content = CurrentLang.Value[2];
        }

        private void ButtonLang_Click(object sender, RoutedEventArgs e)
        {
            CurrentLang = langM.GetNext();
            TranslateMenu();
        }
    }
}

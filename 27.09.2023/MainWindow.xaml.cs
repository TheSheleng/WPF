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

namespace _27._09._2023
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

        private void WrapPanel_Loaded(object sender, RoutedEventArgs e)
        {
            canva.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void GetColor(object sender, RoutedEventArgs e)
        {
            canva.EditingMode = InkCanvasEditingMode.Ink;
            canva.DefaultDrawingAttributes.Color = ((sender as Button).Background as SolidColorBrush).Color;
        }

        private void GetErase(object sender, RoutedEventArgs e)
        {
            canva.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }
    }
}

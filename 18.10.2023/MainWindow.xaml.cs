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

namespace _18._10._2023
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

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumbr_1.Text == "0") TextNumbr_1.Text = "";
            TextNumbr_1.Text += (sender as Button).Content.ToString();
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumbr_1.Text.Contains(',')) return;
            TextNumbr_1.Text += ',';
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            TextNumbr_1.Text = TextNumbr_1.Text.Remove(TextNumbr_1.Text.Length - 1);
            if (TextNumbr_1.Text == "") TextNumbr_1.Text = "0";
        }

        private void CEButton_Click(object sender, RoutedEventArgs e)
        {
            TextNumbr_1.Text = "0";
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            TextNumbr_1.Text = "0";
            TextNumbr_2.Text = "0";
        }

        private void ActButton_Click(object sender, RoutedEventArgs e)
        {
            TextNumbr_2.Text = TextNumbr_1.Text + (sender as Button).Content.ToString();
            TextNumbr_1.Text = "0";
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double Number_1 = double.Parse(TextNumbr_1.Text);
            double Number_2 = double.Parse(TextNumbr_2.Text.Remove(TextNumbr_2.Text.Length - 1));

            double Ansv = 0;
            switch (TextNumbr_2.Text.Last())
            {
                case '+': Ansv = Number_2 + Number_1; break;
                case '-': Ansv = Number_2 - Number_1; break;
                case '*': Ansv = Number_2 * Number_1; break;
                case '/': Ansv = Number_2 / Number_1; break;
            }

            TextNumbr_2.Text = Ansv.ToString();
            TextNumbr_1.Text = "0";
        }

        private void OneDevButton_Click(object sender, RoutedEventArgs e)
        {
            TextNumbr_2.Text = (1 / double.Parse(TextNumbr_1.Text)).ToString();
            TextNumbr_1.Text = "0";
        }

        private void ProcButton_Click(object sender, RoutedEventArgs e)
        {
            TextNumbr_2.Text = (float.Parse(TextNumbr_1.Text) / 100).ToString();
            TextNumbr_1.Text = "0";
        }

        private string Memory = "0";

        private void MSButton_Click(object sender, RoutedEventArgs e)
        {
            Memory = TextNumbr_1.Text;
        }

        private void MRButton_Click(object sender, RoutedEventArgs e)
        {
            TextNumbr_1.Text = Memory;
        }
    }
}

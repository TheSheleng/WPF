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

namespace _22._09._2023__dz_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int lenPass = 4;
        string password;

        public MainWindow()
        {
            InitializeComponent();

            password = new Random().Next(
                (int)Math.Pow(10, lenPass - 1), 
                (int)Math.Pow(10, lenPass) - 1
            ).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string button = ((Button)sender).Content.ToString();

            if (button == "C")
            {
                Answer.Text = "";
            }
            else if (button == "OK")
            {
                if (button == password) MessageBox.Show("Пароль введен верно");
                else MessageBox.Show("Пароль введен не верно");

                Answer.Text = "";
            }
            else
            {
                if (Answer.Text.Length < lenPass) Answer.Text += button;
            }
        }
    }
}

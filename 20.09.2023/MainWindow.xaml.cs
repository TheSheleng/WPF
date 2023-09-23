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

namespace _20._09._2023
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Question.Text == "") return;

            string[] answers =
            {
                "Бесспорно.",
                "По всей видимости, да.",
                "Спроси позже.",
                "Лучше не рассказывать.",
                "Сейчас нельзя предсказать.",
                "Сомнительно.",
                "Нет, никаких шансов.",
                "Определенно, да.",
                "Можешь быть уверен в этом.",
                "Мне кажется, нет.",
                "Весьма вероятно.",
                "Мой ответ — да.",
                "Мой ответ — нет.",
                "Не могу сейчас сказать.",
                "По всей видимости, нет."
            };

            Answer.Text = answers[new Random().Next(answers.Length)];   
        }
    }
}

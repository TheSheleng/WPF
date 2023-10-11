using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace _11._10._2023__dz_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SumModel SumModel = new SumModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = SumModel;

            SumModel.PropertyChanged += (sender, args) =>
            {
                this.Ress.Text = ((sender as SumModel).Num_1 + (sender as SumModel).Num_2).ToString();
            };
        } 

        
    }

    class SumModel : INotifyPropertyChanged
    {
        private float _num_1 = 0;
        private float _num_2 = 0;

        public float Num_1
        {
            get { return _num_1; }
            set
            {
                if (_num_1 != value)
                {
                    _num_1 = value;
                    OnPropertyChanged(nameof(_num_1));
                }
            }
        }
        public float Num_2
        {
            get { return _num_2; }
            set
            {
                if (_num_2 != value)
                {
                    _num_2 = value;
                    OnPropertyChanged(nameof(_num_2));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

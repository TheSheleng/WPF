using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace _1._11._2023
{
    internal class MainViewModel : DependencyObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static readonly DependencyProperty AlphaProrety
            = DependencyProperty.Register(
                "Alpha", 
                typeof(int), 
                typeof(MainViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        private static readonly DependencyProperty RedProrety
            = DependencyProperty.Register(
                "Red",
                typeof(int), 
                typeof(MainViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        private static readonly DependencyProperty GreenProrety
            = DependencyProperty.Register(
                "Green",
                typeof(int), 
                typeof(MainViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        private static readonly DependencyProperty BlueProrety
            = DependencyProperty.Register(
                "Blue", 
                typeof(int), 
                typeof(MainViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        public int Alpha
        {
            get { return (int)GetValue(AlphaProrety); }
            set { SetValue(AlphaProrety, value); }
        }

        public int Red
        {
            get { return (int)GetValue(RedProrety); }
            set { SetValue(RedProrety, value); }
        }

        public int Green
        {
            get { return (int)GetValue(GreenProrety); }
            set { SetValue(GreenProrety, value); }
        }

        public int Blue
        {
            get { return (int)GetValue(BlueProrety); }
            set { SetValue(BlueProrety, value); }
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        public ObservableCollection<Color> ColorItems { get; set; } 
            = new ObservableCollection<Color>();

        DelegateCommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(AddColor, CanAddColor);
                }

                return addCommand;
            }
        }

        private void AddColor(object obj)
        {
            ColorItems.Add(Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue));
        }

        private bool CanAddColor(object obj)
        {
            return true;
        }
    }

    internal class Model
    {
        
    }
}

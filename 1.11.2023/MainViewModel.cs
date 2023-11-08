using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace _1._11._2023
{
    internal class MainViewModel : DependencyObject
    {
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

        private static readonly DependencyProperty CurrentColorProrety
            = DependencyProperty.Register(
                "CurrentColor", 
                typeof(Brush), 
                typeof(MainViewModel),
                new PropertyMetadata(new SolidColorBrush(), OnPropertyChanged));

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

        public Brush CurrentColor
        {
            get { return (Brush)GetValue(CurrentColorProrety); }
            set { SetValue(CurrentColorProrety, value); }
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(CurrentColorProrety, new SolidColorBrush(Color.FromArgb(
                (byte)d.GetValue(AlphaProrety),
                (byte)d.GetValue(AlphaProrety),
                (byte)d.GetValue(AlphaProrety),
                (byte)d.GetValue(AlphaProrety))));
        }
    }
}

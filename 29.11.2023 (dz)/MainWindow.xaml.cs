using Microsoft.Win32;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _29._11._2023__dz_
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

        private void Button_Minimaze_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Maximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Minimized : WindowState.Maximized;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TabItem_MouseClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.PNG (*.png)|*.png|*.JPG (*.jpg)|*.jpg|Все файлы (*.*)|*.*"; 
            openFileDialog.InitialDirectory = @"C:\"; 

            bool? result = openFileDialog.ShowDialog(); 

            if (result == true)
            {
                tabControl.Items.Add(CreateTabItemWithContent(openFileDialog.FileName));
            }
        }

        public TabItem CreateTabItemWithContent(string imagePath)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = System.IO.Path.GetFileName(imagePath);

            Grid grid = new Grid();
            grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6B6793"));

            Image image = new Image();
            image.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            image.Stretch = Stretch.Uniform;
            image.MouseWheel += Image_MouseWheel;
            image.MouseDown += Image_MouseDown;
            image.MouseMove += Image_MouseMove;
            image.MouseUp += Image_MouseUp;

            TransformGroup transformGroup = new TransformGroup();
            ScaleTransform scaleTransform = new ScaleTransform();
            TranslateTransform translateTransform = new TranslateTransform();

            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);

            image.RenderTransform = transformGroup;

            grid.Children.Add(image);

            tabItem.Content = grid;

            return tabItem;
        }

        Image image = null;
        ScaleTransform scaleTransform = null;
        TranslateTransform translateTransform = null;

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tabItem = tabControl.Items[tabControl.SelectedIndex] as TabItem;
            Grid grid = (Grid)tabItem.Content;
            if (grid == null ) return;   
            if (grid.Children.Count == 0) return;

            image = (Image)grid.Children[0];
            scaleTransform = (ScaleTransform)(image.RenderTransform as TransformGroup).Children[0];
            translateTransform = (TranslateTransform)(image.RenderTransform as TransformGroup).Children[1];
        }

        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double delta = e.Delta > 0 ? 0.1 : -0.1; 

            scaleTransform.ScaleX += delta;
            scaleTransform.ScaleY += delta;

            scaleTransform.ScaleX = Math.Max(0.1, scaleTransform.ScaleX);
            scaleTransform.ScaleY = Math.Max(0.1, scaleTransform.ScaleY);

        }

        private bool isDragging = false;
        private Point startPoint;
        private Point startTranslate;

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = true;
                startPoint = e.GetPosition(this);
                image.CaptureMouse();
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPoint = e.GetPosition(this);

            if (isDragging == true)
            {
                double deltaX = currentPoint.X - startPoint.X;
                double deltaY = currentPoint.Y - startPoint.Y;

                translateTransform.X = startTranslate.X + deltaX;
                translateTransform.Y = startTranslate.Y + deltaY;
            }
            else
            {
                startPoint = currentPoint;
                startTranslate.X = translateTransform.X;
                startTranslate.Y = translateTransform.Y;
            }

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                image.ReleaseMouseCapture();
            }
        }
    }
}

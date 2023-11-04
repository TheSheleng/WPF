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

namespace _04._10._2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int MapSize = 4;
        Image[,] cells;

        public MainWindow()
        {
            InitializeComponent();

            cells = new Image[MapSize, MapSize];

            for (int y = 0; y < MapSize; y++)
                for (int x = 0; x < MapSize; x++)
                {
                    Uri uri = new Uri($"pack://application:,,,/04.10.2023;component/images/image_{x}{y}.png", UriKind.Absolute);                    
                    BitmapImage bitmapImage = new BitmapImage(uri);
                    Image image = new Image();
                    image.Source = bitmapImage;
                    image.AllowDrop = true;
                    image.MouseLeftButtonDown += image_MouseDown;
                    image.Drop += image_Drop;

                    cells[x, y] = image;

                    Grid.SetColumn(image, x);
                    Grid.SetRow(image, y);

                    grid.Children.Add(image);
                }

            mix_puzzles(25);
        }

        private void mix_puzzles(int iter)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < iter; i++)
            {
                int p1x = rnd.Next(MapSize);
                int p1y = rnd.Next(MapSize);
                int p2x = rnd.Next(MapSize);
                int p2y = rnd.Next(MapSize);

                ImageSource tempImage = cells[p1x, p1y].Source;
                cells[p1x, p1y].Source = cells[p2x, p2y].Source;
                cells[p2x, p2y].Source = tempImage;
            }
        }

        Image dragingImage = null;
        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragingImage = sender as Image; 

            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(ImageSource), image.Source);

            DragDrop.DoDragDrop(image, data, DragDropEffects.All);
        }

        private void image_Drop(object sender, DragEventArgs e)
        {
            Image image = (sender as Image);

            ImageSource droped = e.Data.GetData(typeof(ImageSource)) as ImageSource;

            if (droped != null) 
            {
                dragingImage.Source = image.Source;
                image.Source = droped;
            }
        }
    }
}

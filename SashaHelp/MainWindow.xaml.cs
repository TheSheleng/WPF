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

namespace SashaHelp
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

        Image dragingImage = null;
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragingImage = sender as Image;

            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(ImageSource), image.Source);

            DragDrop.DoDragDrop(image, data, DragDropEffects.All);
        }

        private void Image_Drop(object sender, DragEventArgs e)
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

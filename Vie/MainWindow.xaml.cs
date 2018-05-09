using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Vie
{
    static class Data   //Data transfer
    {
        public static string Path { get; set; }
        public static ScaleTransform scale = new ScaleTransform();
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Application.ResourceAssembly.GetName().Name.ToString());
            Uri url = new Uri(@Data.Path);
            BitmapImage img = new BitmapImage(url);
            //get img resolution
            short imgH, imgW, screenH, screenW;
            imgH = (short)img.PixelHeight;
            imgW = (short)img.PixelWidth;
            //get screen resolution
            screenH = (short)System.Windows.SystemParameters.PrimaryScreenHeight;
            screenW = (short)System.Windows.SystemParameters.PrimaryScreenWidth;
            //display img in window
            MainImg.Source = img;
            //Point for scale (0.5, 0.5 - on center)
            MainImg.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();  //close if click on cross
        }

        private bool get_color()
        {
            if (MainGrid.Background == Brushes.Black)
            {
                return false;
            }
            else return true;
        }

        private void set_color(bool color)
        {
            if(color)
            {
                MainGrid.Background = Brushes.White;
            }
            else MainGrid.Background = Brushes.Black;
        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            bool color;
            if ((e.Key == Key.I) && ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control))
            {
                color = get_color();
                set_color(!color);
            }
        }

        private void MainImg_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta >= 0)    //if wheel scroll from user
            {
                //increase scale
                Data.scale.ScaleX += 0.5;
                Data.scale.ScaleY += 0.5;
                TransformGroup group = new TransformGroup();
                group.Children.Add(Data.scale);
                MainImg.RenderTransform = group;
            }
            else if(e.Delta < 0)    //if wheel scroll to user
            {
                //reduce scale
                Data.scale.ScaleX -= 0.5;
                Data.scale.ScaleY -= 0.5;
                if(Data.scale.ScaleX <= 0.5 && Data.scale.ScaleY <= 0.5)
                {
                    Data.scale.ScaleX = 0.5;
                    Data.scale.ScaleY = 0.5;
                }
                TransformGroup group = new TransformGroup();
                group.Children.Add(Data.scale);
                MainImg.RenderTransform = group;
            }
        }
    }
}
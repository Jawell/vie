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
    static class Data
    {
        public static string Path { get; set; }
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
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
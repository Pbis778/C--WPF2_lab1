using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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

namespace S3WPF2
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

        void czyscPlotno()
        {
            cvRysunek.Children.Clear();
        }

        void RysujLinie(int x1, int y1, int x2, int y2, int grubosc, SolidColorBrush color)
        {
            Line myLine = new Line();
            myLine.Stroke = color;
            myLine.X1 = x1;
            myLine.Y1 = y1;
            myLine.X2 = x2;
            myLine.Y2 = y2;
            myLine.StrokeThickness = grubosc;
            cvRysunek.Children.Add(myLine);
        }

        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {
            czyscPlotno();
            RysujLinie(0, 299, 150, 150, 10, System.Windows.Media.Brushes.Black);
            RysujLinie(150, 150, 150, 299, 10, System.Windows.Media.Brushes.Yellow);
        }

        void RysujKrzyz(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int size, SolidColorBrush color)
        {
            RysujLinie(x1, y1, x2, y2, size, color);
            RysujLinie(x3, y3, x4, y4, size, color);
        }

        private void btnCross_Click(object sender, RoutedEventArgs e)
        {
            czyscPlotno();
            RysujKrzyz(150, 100, 150, 200, 100, 150, 200, 150, 12, System.Windows.Media.Brushes.Red);
            
            RysujLinie(130, 100, 170, 100, 12, System.Windows.Media.Brushes.Red);
            RysujLinie(130, 200, 170, 200, 12, System.Windows.Media.Brushes.Red);
            RysujLinie(200, 130, 200, 170, 12, System.Windows.Media.Brushes.Red);
            RysujLinie(100, 170, 100, 130, 12, System.Windows.Media.Brushes.Red);

            RysujKrzyz(125, 115, 125, 135, 115, 125, 135, 125, 6, System.Windows.Media.Brushes.Red);
            RysujKrzyz(175, 115, 175, 135, 165, 125, 185, 125, 6, System.Windows.Media.Brushes.Red);
            RysujKrzyz(125, 165, 125, 185, 115, 175, 135, 175, 6, System.Windows.Media.Brushes.Red);
            RysujKrzyz(175, 165, 175, 185, 165, 175, 185, 175, 6, System.Windows.Media.Brushes.Red);

        }

        void rysujElipse(int x1, int y1, int height, int width, SolidColorBrush color)
        {
            Ellipse elips = new Ellipse();
            elips.Stroke = color;
            elips.Width = width;
            elips.Height = height;
            cvRysunek.Children.Add(elips);
            Canvas.SetRight(elips, x1);
            Canvas.SetTop(elips, y1);
        }

        void rysujWypelnionaElipse(int x1, int y1, int x2, int y2, int r, SolidColorBrush color)
        {
            rysujElipse(100, 50, 100, 100, System.Windows.Media.Brushes.DarkGreen);

            for (int i = 0; i < 1000; i++)
            {
                Line line = new Line();
                line.Stroke = color;
                line.X1 = x1;
                line.Y1 = y1;
                line.X2 = x2;
                line.Y2 = y2;

                line.RenderTransform = new RotateTransform(5 * i, 150, 150);
                cvRysunek.Children.Add(line);
            }
        }

        private void btnElipsa_Click(object sender, RoutedEventArgs e)
        {
            czyscPlotno();
            rysujWypelnionaElipse(100, 50, 100, 100, 25, System.Windows.Media.Brushes.DarkGreen);
        }
    }
}

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

namespace Tic_Tac
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingElement(Canvas canvas, Point start, Point end)
        {
            LineGeometry lineGeometry = new LineGeometry();
            Point startPoint = start;
            Point endPoint = end;
            Path path = new Path();

            lineGeometry.StartPoint = startPoint;
            lineGeometry.EndPoint = endPoint;
            path.Stroke = Brushes.Red;
            path.StrokeThickness = 1;
            path.Data = lineGeometry;

            canvas.Children.Add(path);
        }

        private void DrawingChessX(Point location)
        {
            Point startPointOfLeft = new Point(location.X + 20, location.Y + 20);
            Point endPointOfLeft = new Point(location.X - 20, location.Y - 20);
            Point startPointOfRight = new Point(location.X - 20, location.Y + 20);
            Point endPointOfRight = new Point(location.X + 20, location.Y - 20);

            DrawingElement(ChessBoard, startPointOfLeft, endPointOfLeft);
            DrawingElement(ChessBoard, startPointOfRight, endPointOfRight);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DrawingElement(ChessBoard, new Point(0, 80), new Point(300, 80));
            DrawingElement(ChessBoard, new Point(0, 160), new Point(300, 160));
            DrawingElement(ChessBoard, new Point(100, 0), new Point(100, 300));
            DrawingElement(ChessBoard, new Point(200, 0), new Point(200, 300));
            StartButton.IsEnabled = false;
            StartButton.Visibility = Visibility.Collapsed;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            DrawingChessX(new Point(47, 38));
        }
    }
}
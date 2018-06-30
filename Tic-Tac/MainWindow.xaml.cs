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
            DrawingChessBoard(ChessBoard);
        }

        private static void DrawingChessBoard(Canvas canvas) //只能画一条直线
        {
            LineGeometry lineGeometry = new LineGeometry();
            Point startPoint = new Point(100, 0);
            Point endPoint = new Point(100, 300);
            Path path = new Path();

            lineGeometry.StartPoint = startPoint;
            lineGeometry.EndPoint = endPoint;
            path.Stroke = Brushes.Red;
            path.StrokeThickness = 1;
            path.Data = lineGeometry;

            canvas.Children.Add(path);
        }
    }
}
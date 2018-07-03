using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

            PathGeometry board = new PathGeometry();

            for (int i = 0; i < 90; i += 30)
            {
                for (int j = 0; j < 90; j += 30)
                {
                    board.AddGeometry(new RectangleGeometry(new Rect(j, i, 30, 30)));
                }
            }

            Path path = new Path();
            path.Fill = Brushes.AliceBlue;
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 1;
            path.Data = board;

            chessBoard.Children.Add(path);
        }
    }
}
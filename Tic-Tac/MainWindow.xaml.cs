using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tic_Tac
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Squre[,] _squres;
        private const int _tic = 1;
        private const int _tac = 2;
        private static int _boardStatus = _tac;
        private DispatcherTimer gameChecker = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            _squres = new Squre [3, 3];
            gameChecker.Tick += GameChecker_Tick;
            PathGeometry board = new PathGeometry();

            int id = 0;
            for (int i = 0; i < 90; i += 30)
            {
                for (int j = 0; j < 90; j += 30)
                {
                    Rect temp = new Rect(i, j, 30, 30);
                    _squres[i / 30, j / 30] = new Squre(temp, id);
                    board.AddGeometry(new RectangleGeometry(temp));
                    id++;
                }
                id += 3;
            }

            Path path = new Path
            {
                Fill = Brushes.AliceBlue,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Data = board
            };

            chessBoard.Children.Add(path);
            gameChecker.Interval = new System.TimeSpan(10);
            gameChecker.Start();
        }

        private void chessBoard_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point clickPoint = Mouse.GetPosition(e.Source as FrameworkElement);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _squres[i, j].DrawingChess(chessBoard, clickPoint, _boardStatus);

                    if (_boardStatus == _tic)
                    {
                        _boardStatus = _tac;
                    }
                    else
                    {
                        _boardStatus = _tic;
                    }

                    break;
                }
            }
        }

        private void GameChecker_Tick(object sender, System.EventArgs e)
        {
            List<int> note = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_squres[i,j].Status == _tic)
                    {
                        
                    }
                }
            }
        }
    }
}
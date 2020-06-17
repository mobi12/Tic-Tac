using System.Collections.Generic;
using System.Linq.Expressions;
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

        public MainWindow()
        {
            InitializeComponent();

            _squres = new Squre [3, 3];
            PathGeometry board = new PathGeometry();

            int id = 0;
            for (int i = 0; i < 90; i += 30)
            {
                for (int j = 0; j < 90; j += 30)
                {
                    Rect temp = new Rect(j, i, 30, 30);
                    _squres[i / 30, j / 30] = new Squre(temp, id);
                    board.AddGeometry(new RectangleGeometry(temp));
                    id++;
                }
            }

            Path path = new Path
            {
                Fill = Brushes.AliceBlue,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Data = board
            };

            chessBoard.Children.Add(path);
        }

        private void chessBoard_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point clickPoint = Mouse.GetPosition(e.Source as FrameworkElement);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_squres[i, j].SqurePoint.Contains(clickPoint))
                    {
                        _squres[i, j].DrawingChess(chessBoard, clickPoint, _boardStatus);

                        if (_boardStatus == _tac)
                        {
                            _boardStatus = _tic;
                        }
                        else if (_boardStatus == _tic)
                        {
                            _boardStatus = _tac;
                        }
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (_squres[0, i].Status == _tac)
                {
                    if (_squres[0, i].Status == _squres[1, i].Status)
                    {
                        if (_squres[2, i].Status == _squres[0, i].Status)
                        {
                            MessageBox.Show("tac win");
                        }
                    }
                }
                else if (_squres[0, i].Status == _tic)
                {
                    if (_squres[0, i].Status == _squres[1, i].Status)
                    {
                        if (_squres[2, i].Status == _squres[0, i].Status)
                        {
                            MessageBox.Show("tic win");
                        }
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                int tacCount = 0;
                int ticCount = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (_squres[i, j].Status == _tac)
                    {
                        tacCount++;
                    }
                    else if(_squres[i, j].Status == _tic)
                    {
                        ticCount++;
                    }
                }

                if (tacCount == 3)
                {
                    MessageBox.Show("tac win");
                    break;
                }
                else if (ticCount == 3)
                {
                    MessageBox.Show("tic win");
                    break;
                }
            }

            int v = 0;
            int w = 0;
            for (int i = 0; i < 3; i++)
            {
                if (_squres[i, i].Status == _tac)
                {
                    v++;
                }
                else if (_squres[i, i].Status == _tic)
                {
                    w++;
                }

                if (v == 3)
                {
                    MessageBox.Show("tac win");
                }
                else if (w == 3)
                {
                    MessageBox.Show("tic win");
                }
            }

            if (_squres[0, 2].Status == _tac && _squres[0, 2].Status == _squres[1,1].Status && _squres[2, 0].Status == _squres[0, 2].Status)
            {
                MessageBox.Show("tac win");
            }
            else if (_squres[0, 2].Status == _tic && _squres[0, 2].Status == _squres[1,1].Status && _squres[2, 0].Status == _squres[0, 2].Status)
            {
                MessageBox.Show("tic win");
            }
        }
    }
}
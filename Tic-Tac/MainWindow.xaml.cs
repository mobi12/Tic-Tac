using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        private List<Squre> squres = new List<Squre>();
        private SqureStatus boardStatus = SqureStatus.Tac;
        private DispatcherTimer gameChecker = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            gameChecker.Tick += GameChecker_Tick;
            PathGeometry board = new PathGeometry();

            for (int i = 0; i < 90; i += 30)
            {
                for (int j = 0; j < 90; j += 30)
                {
                    Rect temp = new Rect(i, j, 30, 30);
                    squres.Add(new Squre(temp));
                    board.AddGeometry(new RectangleGeometry(temp));
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
            gameChecker.Interval = new System.TimeSpan(10);
            gameChecker.Start();
        }

        private void GameChecker_Tick(object sender, System.EventArgs e)
        {
            int j = 3;
            int k = 6;
            for (int i = 0; i < 3; i++)
            {
                if (CheckTacOrTic(squres[i], squres[j + i], squres[k + i], SqureStatus.Tac) == true)
                {
                    MessageBox.Show("圈圈赢了");
                    boardStatus = SqureStatus.Win;
                    gameChecker.Stop();
                }
                else if (CheckTacOrTic(squres[i], squres[j + i], squres[k + i], SqureStatus.Tic) == true)
                {
                    MessageBox.Show("叉叉赢了");
                    boardStatus = SqureStatus.Win;
                    gameChecker.Stop();
                }
            }

            j = 1;
            k = 2;
            for (int i = 0; i < 3; i++)
            {
                if (CheckTacOrTic(squres[i], squres[i + j], squres[i + k], SqureStatus.Tac) == true)
                {
                    MessageBox.Show("圈圈赢了");
                    boardStatus = SqureStatus.Win;
                    gameChecker.Stop();
                }
                else if (CheckTacOrTic(squres[i], squres[i + 1], squres[i + 2], SqureStatus.Tic) == true)
                {
                    MessageBox.Show("叉叉赢了");
                    boardStatus = SqureStatus.Win;
                    gameChecker.Stop();
                }
            }

            if (CheckTacOrTic(squres[0], squres[4], squres[8], SqureStatus.Tac) == true ||
                CheckTacOrTic(squres[0], squres[4], squres[8], SqureStatus.Tac) == true)
            {
                MessageBox.Show("圈圈赢了");
                boardStatus = SqureStatus.Win;
                gameChecker.Stop();
            }
            else if (CheckTacOrTic(squres[6], squres[4], squres[2], SqureStatus.Tic) == true ||
                CheckTacOrTic(squres[2], squres[4], squres[6], SqureStatus.Tic) == true)
            {
                MessageBox.Show("叉叉赢了");
                boardStatus = SqureStatus.Win;
                gameChecker.Stop();
            }

            int count = 0;
            foreach (var item in squres)
            {
                if (item.Status != SqureStatus.None)
                {
                    count++;
                }
            }

            if (count == 9 && boardStatus != SqureStatus.Win)
            {
                MessageBox.Show("棋盘满了");
                gameChecker.Stop();
            }
        }

        private void chessBoard_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point clickPoint = Mouse.GetPosition(e.Source as FrameworkElement);

            foreach (var item in squres)
            {
                if (item.SqurePoint.Contains(clickPoint) && item.Status == SqureStatus.None && boardStatus == SqureStatus.Tac)
                {
                    item.DrawingTac(chessBoard);
                    boardStatus = SqureStatus.Tic;
                    break;
                }
                else if (item.SqurePoint.Contains(clickPoint) && item.Status == SqureStatus.None && boardStatus == SqureStatus.Tic)
                {
                    item.DrawingTic(chessBoard);
                    boardStatus = SqureStatus.Tac;
                    break;
                }
            }
        }

        private bool CheckTacOrTic(Squre one, Squre two, Squre three, SqureStatus status)
        {
            if (one.Status == status)
            {
                if (one.Status == two.Status && one.Status == three.Status && two.Status == three.Status)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
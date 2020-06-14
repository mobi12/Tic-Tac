using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tic_Tac
{
    public class Squre
    {
        private const int _tic = 1;
        private const int _tac = 2;

        private Rect _squrePoint;
        private int _status;
        private int _id;
        public int Status
        {
            get => _status;
        }

        public int ID
        {
            get => _id;
        } 

        public Rect SqurePoint
        {
            get
            {
                return _squrePoint;
            }
            set
            {
                _squrePoint = value;
            }
        }

        public Squre(Rect coordinate, int id)
        {
            SqurePoint = coordinate;
            _status = 0;
            _id = id;
        }

        public void DrawingChess(Canvas board, Point clickPoint, int boardStatus)
        {
            if (_squrePoint.Contains(clickPoint))
            {
                if (_status == 0 && boardStatus == 1)
                {
                    DrawingTic(board);
                }
                else if (_status == 0 && boardStatus == 2)
                {
                    DrawingTac(board);
                }
            }
        }

        private void DrawingTic(Canvas board)
        {
            PathGeometry tic = new PathGeometry();
            tic.AddGeometry(new LineGeometry(new Point(_squrePoint.Location.X + 5, _squrePoint.Location.Y + 5),
                new Point(_squrePoint.BottomRight.X - 5, _squrePoint.BottomRight.Y - 5)));
            tic.AddGeometry(new LineGeometry(new Point(_squrePoint.TopRight.X - 5, _squrePoint.TopRight.Y + 5),
                new Point(_squrePoint.BottomLeft.X + 5, _squrePoint.BottomLeft.Y - 5)));

            Path ticPath = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Data = tic
            };

            _status = _tic;
            board.Children.Add(ticPath);
        }

        private void DrawingTac(Canvas board)
        {
            Point center = new Point(_squrePoint.X + 15, _squrePoint.Y + 15);
            EllipseGeometry tac = new EllipseGeometry(center, 10, 10);

            Path tacPath = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Data = tac
            };

            _status = _tac;
            board.Children.Add(tacPath);
        }
    }
}
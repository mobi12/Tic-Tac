using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tic_Tac
{
    public class Squre
    {
        private Rect _squrePoint;

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

        private SqureStatus _status;

        public SqureStatus Status
        {
            get
            {
                return _status;
            }
        }

        public Squre(Rect coordinate)
        {
            SqurePoint = coordinate;
            _status = SqureStatus.None;
        }

        public void DrawingTic(Canvas board)
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

            _status = SqureStatus.Tic;
            board.Children.Add(ticPath);
        }

        public void DrawingTac(Canvas board)
        {
            Point center = new Point(_squrePoint.X + 15, _squrePoint.Y + 15);
            EllipseGeometry tac = new EllipseGeometry(center, 10, 10);

            Path tacPath = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Data = tac
            };

            _status = SqureStatus.Tac;
            board.Children.Add(tacPath);
        }
    }
}
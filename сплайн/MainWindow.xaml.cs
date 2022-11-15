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

namespace сплайн
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        Point point_cur;
        int index_cur;
        Polyline pol = new Polyline();
        Polyline spline = new Polyline();
        public MainWindow()
        {
            InitializeComponent();
            pol.Name = "pol";
            pol.Stroke = SystemColors.WindowFrameBrush;
            spline.Name = "spline";
            spline.Stroke = SystemColors.WindowFrameBrush;
            point_cur = new Point(-1, -1);
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (point_cur == new Point(-1, -1) && index_cur == -1)
            {
                if (pol.Points.Count < 3)
                {
                    pol.Points.Add(new Point(e.GetPosition(this).X, e.GetPosition(this).Y));
                }
                else
                {
                    pol.Points.Add(new Point(e.GetPosition(this).X, e.GetPosition(this).Y));
                    spline.Points = MakeSpline(pol.Points);
                }
                paint.Children.Clear();
                if (check.IsChecked.Value == false) paint.Children.Add(pol);
                paint.Children.Add(spline);
            }
        }
        private PointCollection MakeSpline(PointCollection newPol)
        {
            double a0, a1, a2, a3, b0, b1, b2, b3;
            Polyline newSpline = new Polyline();
            for (int i = 0; i < newPol.Count; i++)
            {
                Point p0 = newPol[i];
                Point p1 = newPol[(i + 1) % newPol.Count];
                Point p2 = newPol[(i + 2) % newPol.Count];
                Point p3 = newPol[(i + 3) % newPol.Count];
                a3 = (-p0.X + 3 * (p1.X - p2.X) + p3.X) / 6;
                a2 = (p0.X - 2 * p1.X + p2.X) / 2;
                a1 = (p2.X - p0.X) / 2;
                a0 = (p0.X + 4 * p1.X + p2.X) / 6;
                b3 = (-p0.Y + 3 * (p1.Y - p2.Y) + p3.Y) / 6;
                b2 = (p0.Y - 2 * p1.Y + p2.Y) / 2;
                b1 = (p2.Y - p0.Y) / 2;
                b0 = (p0.Y + 4 * p1.Y + p2.Y) / 6;
                for (double t = 0; t <= 1; t += 0.1)
                {
                    double x = ((a3 * t + a2) * t + a1) * t + a0;
                    double y = ((b3 * t + b2) * t + b1) * t + b0;
                    newSpline.Points.Add(new Point(x, y));
                }

            }
            return newSpline.Points;
        }
        private Polyline ClonePol(Polyline p)
        {
            Polyline newPol = new Polyline();
            foreach (var v in p.Points)
                newPol.Points.Add(v);
            return newPol;
        }
        private int CountPaint()
        {
            int count = 0;
            foreach (var v in paint.Children)
                if (v is Polyline) count++;
            return count;
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point marcker = new Point();
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (index_cur != -1)
                {
                    pol.Points[index_cur] = e.GetPosition(this);
                    marcker.X = e.GetPosition(this).X;
                    marcker.Y = e.GetPosition(this).Y;
                    spline.Points = MakeSpline(pol.Points);
                }
            }
            else
            {
                marcker = new Point(-1, -1);

                marcker = CheckMouseInPoint(marcker, e.GetPosition(this));
                point_cur = e.GetPosition(this);
            }
            paint.Children.Clear();
            if (check.IsChecked.Value == false) paint.Children.Add(pol);
            paint.Children.Add(spline);

            if (marcker != new Point(-1, -1)) EllipseAdd(marcker);
            point_cur = new Point(-1, -1);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
        private Point CheckMouseInPoint(Point marcker, Point getPosition)
        {
            Point point;
            point_cur = new Point(-1, -1);
            index_cur = -1;
            for (int i = 0; i < pol.Points.Count; i++)
            {
                point = pol.Points[i];
                if (SurroundingPoint(point, getPosition))
                {
                    marcker = point;
                    point_cur = point;
                    index_cur = i;
                    return marcker;
                }
            }
            return marcker;
        }
        private void EllipseAdd(Point marcker)
        {
            Ellipse rect;
            rect = new Ellipse();
            rect.Stroke = new SolidColorBrush(Colors.Green);
            rect.Fill = new SolidColorBrush(Colors.Transparent);
            rect.Width = 10;
            rect.Height = 10;
            Canvas.SetLeft(rect, marcker.X - 5);
            Canvas.SetTop(rect, marcker.Y - 5);
            paint.Children.Add(rect);
        }
        //Удаление обводки точки
        private void EllipseRemove()
        {
            foreach (object obj in paint.Children)
            {
                if (obj is Ellipse)
                {
                    Ellipse rect = (Ellipse)obj;
                    paint.Children.Remove(rect);
                    paint.InvalidateVisual();
                    break;
                }
            }
        }
        //Проверка окружения мыши на наличие точек
        private int SurroundingPoint(Line l, Point p)
        {
            if (Math.Abs(l.X1 - p.X) < 5 && Math.Abs(l.Y1 - p.Y) < 5) return 0;
            else
            if (Math.Abs(l.X2 - p.X) < 5 && Math.Abs(l.Y2 - p.Y) < 5) return 1;
            return -1;
        }
        private bool SurroundingPoint(Point l, Point p)
        {
            return Math.Abs(l.X - p.X) < 5 && Math.Abs(l.Y - p.Y) < 5;
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            paint.Children.Clear();
            if (check.IsChecked.Value == false) paint.Children.Add(pol);
            paint.Children.Add(spline);
        }

        private void paint_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}

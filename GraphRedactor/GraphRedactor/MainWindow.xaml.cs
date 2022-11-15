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

namespace GraphRedactor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint; //Точка для создания линий, является первой точкой линии
        string mode;        //Режим редактора
        int countLine;      //Переменная для различия линий
        List<Shape> coll;   
        Line temp;          //Временная линия для создания отрезков
        Ellipse rect;       //Круг для выделения точек
        Dictionary<Shape, bool> editColl;
        Rectangle rectTemp;
        public MainWindow()
        {
            InitializeComponent();
            currentPoint = new Point(-1, -1);
            mode = "";
            countLine = 0;
            coll = new List<Shape>();
            editColl = new Dictionary<Shape, bool>();
            rect = new Ellipse();
            paint.Children.Add(rect);
            AddTempLine();
            AddTempRect();
            EllipseAdd(new Point(-10, -10));
        }
        private void AddTempLine()
        {
            temp = new Line();
            temp.Name = "TempLine";
            temp.Stroke = new SolidColorBrush(Colors.Red);
            temp.StrokeDashCap = PenLineCap.Round;
            temp.StrokeDashArray = new DoubleCollection(new DoubleCollection { 4, 2 });
            
            paint.Children.Add(temp);
        }
        private void AddTempRect()
        {
            rectTemp = new Rectangle();
            rectTemp.Name = "TempRect";
            rectTemp.Stroke = new SolidColorBrush(Colors.Green);
            rectTemp.StrokeDashCap = PenLineCap.Round;
            rectTemp.StrokeDashArray = new DoubleCollection(new DoubleCollection { 4, 2 });
            paint.Children.Add(rectTemp);
        }
        private void EllipseAdd(System.Windows.Point marcker)
        {
            rect.Stroke = new SolidColorBrush(Colors.Red);
            rect.Fill = new SolidColorBrush(Colors.Transparent);
            rect.Width = 10;
            rect.Height = 10;
            Canvas.SetLeft(rect, marcker.X - 5);
            Canvas.SetTop(rect, marcker.Y - 5);
        }
        private void paint_MouseMove(object sender, MouseEventArgs e)
        {
            bool left = e.LeftButton == MouseButtonState.Pressed;
            bool right = e.RightButton == MouseButtonState.Pressed;
            Point nowPosition = e.GetPosition(this);
            switch (mode)
            {
                case "editPoint":
                    PaintEdit(nowPosition, left || right, !left);
                    break;
                case "createLine":
                    RemoveTempLine();
                    PaintTempLine(nowPosition, left);
                    break;
                case "mode2D":
                    Paint2D(nowPosition, left);
                    break;
            }

        }
        private void Paint2D(Point nowPosition, bool leftPress)
        {
            if (leftPress && currentPoint == new Point(-1, -1)) currentPoint = nowPosition;
        }
        private void paint_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (mode)
                {
                    case "editPoint":
                        PaintEdit(e.GetPosition(this), e.LeftButton == MouseButtonState.Pressed, true);
                        break;
                    case "createLine":
                        PaintLine(e.GetPosition(this), e.LeftButton == MouseButtonState.Pressed);
                        break;
                }
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                
                switch (mode)
                {
                    case "editPoint":
                        PaintEdit(e.GetPosition(this), e.LeftButton == MouseButtonState.Pressed, false);
                        
                        currentPoint = new Point(-1, -1);
                        break;
                    case "createLine":
                        RemoveTempLine();
                        currentPoint = new Point(-1, -1);
                        break;
                    case "mode2D":
                        foreach (var v in paint.Children)
                        {
                            if (v is Line l)
                            {
                                if (Range(currentPoint, new Point(l.X1, l.Y1), e.GetPosition(this)) &&
                                    Range(currentPoint, new Point(l.X2, l.Y2), e.GetPosition(this)))
                                {
                                    l.Stroke = new SolidColorBrush(Colors.Red);
                                }
                                else l.Stroke = SystemColors.WindowFrameBrush;
                            }
                        }
                        break;
                }
            }
        }
        private bool PointInLine(Point p1, Point p, Point p2)
        {
            return (p.X - p1.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p.Y - p1.Y) == 0
                && 0 <= (p.X - p1.X) * (p2.X - p1.X)
                && (p.X - p1.X) * (p2.X - p1.X) <= (p1.X - p2.X) * (p1.X - p2.X)
                && 0 <= (p.Y - p1.Y) * (p2.Y - p1.Y)
                && (p.Y - p1.Y)*(p2.Y - p1.Y) <= (p1.Y - p2.Y) * (p1.Y - p2.Y);
        }
        private void PaintEdit(Point nowPosition, bool mousePress, bool left)
        {
            System.Windows.Point marcker;
            if (mousePress)
            {
                marcker = new System.Windows.Point(-1, -1);
                if (editColl.Count > 0)
                    foreach(var v in editColl)
                    {
                        if(v.Key is Line l && v.Key != temp)
                        {
                            if(v.Value) { l.X1 += nowPosition.X - l.X1;
                                          l.Y1 += nowPosition.Y - l.Y1; }
                            else        { l.X2 += nowPosition.X - l.X2;
                                          l.Y2 += nowPosition.Y - l.Y2; }
                            marcker = nowPosition;
                        }
                    }
            }
            else marcker = CheckMouseInPoint(nowPosition, left); 
            EllipseRemove();
            if (marcker != new System.Windows.Point(-1, -1)) EllipseAdd(marcker);
            else if (mousePress && currentPoint == new Point(-1, -1)) currentPoint = nowPosition;
        }
        private bool Range(Point x1, Point x, Point x2)
        {
            return x1.X < x.X && x.X < x2.X && x1.Y < x.Y && x.Y < x2.Y
                || x1.X > x.X && x.X > x2.X && x1.Y > x.Y && x.Y > x2.Y
                || x1.X < x.X && x.X < x2.X && x1.Y > x.Y && x.Y > x2.Y
                || x1.X > x.X && x.X > x2.X && x1.Y < x.Y && x.Y < x2.Y;
        }
        
        private void EllipseRemove()
        {
            EllipseAdd(new Point(-10, -10));
        }
        private void PaintLine(Point point, bool f)
        {
            Point marcker = new Point(-1, -1);
            if (f) marcker = CheckMouseInPointNoEdit(point);
            
            if (currentPoint != new Point(-1, -1))
                if (marcker == new Point(-1, -1))
                {
                    AddLine(currentPoint, point);
                    currentPoint = point;
                }
                else
                {
                    AddLine(currentPoint, marcker);
                    currentPoint = marcker;
                }
            else
                if (marcker == new Point(-1, -1)) currentPoint = point;
                else currentPoint = marcker;
            
        }
        private void AddLine(Point p1, Point p2)
        {
            Line l = new Line();
            l.X1 = p1.X;
            l.Y1 = p1.Y;
            l.X2 = p2.X;
            l.Y2 = p2.Y;
            l.Name = "line_" + countLine;
            countLine++;
            l.Stroke = SystemColors.WindowFrameBrush;
            coll.Add(l);
            paint.Children.Add(l);
        }
        private void RemoveTempLine()
        {
            temp.X1 = 0;
            temp.Y1 = 0;
            temp.X2 = 0;
            temp.Y2 = 0;
        }
        
        private void PaintTempLine(Point p, bool f)
        {
            EllipseRemove();
            if (currentPoint != new Point(-1, -1))
            {
                temp.X1 = currentPoint.X;
                temp.Y1 = currentPoint.Y;
                temp.X2 = p.X;
                temp.Y2 = p.Y;
            }
            Point marcker = new Point(-1, -1);
            if (!f) marcker = CheckMouseInPointNoEdit(p);
            if (marcker != new Point(-1, -1)) EllipseAdd(marcker);
        }
        private bool SurroundingPoint(System.Windows.Point l, System.Windows.Point p)
        {
            return Math.Abs(l.X - p.X) < 5 && Math.Abs(l.Y - p.Y) < 5;
        }
        private int SurroundingPoint(System.Windows.Shapes.Line l, System.Windows.Point p)
        {
            if (Math.Abs(l.X1 - p.X) < 5 && Math.Abs(l.Y1 - p.Y) < 5) return 0;
            else
            if (Math.Abs(l.X2 - p.X) < 5 && Math.Abs(l.Y2 - p.Y) < 5) return 1;
            return -1;
        }
        private System.Windows.Point CheckMouseInPoint(System.Windows.Point getPosition, bool f)
        {
            System.Windows.Point marcker = new Point(-1,-1);
            editColl = new Dictionary<Shape, bool>();
            foreach (object obj in paint.Children)
            {
                if (obj is System.Windows.Shapes.Line l)
                {
                    switch (SurroundingPoint(l, getPosition))
                    {
                        case 0:
                            marcker = new System.Windows.Point(l.X1, l.Y1);
                            AddEditColl(l, true);
                            if (!f) return marcker;
                            break;
                        case 1:
                            marcker = new System.Windows.Point(l.X2, l.Y2);
                            AddEditColl(l, false);
                            if (!f) return marcker;
                            break;
                    }

                }
            }
            return marcker;
        }
        private System.Windows.Point CheckMouseInPointNoEdit(System.Windows.Point getPosition)
        {
            System.Windows.Point marcker = new Point(-1, -1);
            foreach (object obj in paint.Children)
            {
                if (obj is System.Windows.Shapes.Line l && l != temp)
                {
                    l = (System.Windows.Shapes.Line)obj;
                    switch (SurroundingPoint(l, getPosition))
                    {
                        case 0:
                            marcker = new System.Windows.Point(l.X1, l.Y1);
                            return marcker;
                        case 1:
                            marcker = new System.Windows.Point(l.X2, l.Y2);
                            return marcker;
                    }
                }
            }
            return marcker;
        }
        private void AddEditColl(Shape s, bool f)
        {
            if (!editColl.Contains(new KeyValuePair<Shape, bool>(s, f))) editColl.Add(s, f);
        }
        private void paint_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (mode == "mode2D")
            {
                if (currentPoint != new Point(-1, -1))
                {
                    foreach (var v in paint.Children)
                    {
                        if (v is Line l)
                        {
                            if (Range(currentPoint, new Point(l.X1, l.Y1), e.GetPosition(this)) &&
                                Range(currentPoint, new Point(l.X2, l.Y2), e.GetPosition(this)))
                            {
                                l.Stroke = new SolidColorBrush(Colors.Red);
                            }
                            else l.Stroke = SystemColors.WindowFrameBrush;
                        }
                    }
                    currentPoint = new Point(-1, -1);
                }
                
            }
        }
        private void Mode_Click(object sender, RoutedEventArgs e) { mode = (sender as Button).Name; }
    }
}
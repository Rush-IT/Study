using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace GraphRedactor
{
    class RedactorCollection
    {
        int countLine;//Переменная для различия линий
        List<Shape> lineCollection;
        List<(Shape, bool)> editCollection;

        public List<Shape> LineColl { get; }

        public RedactorCollection()
        {
            countLine = 0;
            lineCollection = new List<Shape>();
        }
        private System.Windows.Point CheckMouseInPointNoEdit(System.Windows.Point getPosition)
        {
            System.Windows.Point marcker = new Point(-1, -1);
            foreach (object obj in lineCollection)
            {
                if (obj is System.Windows.Shapes.Line l && l.Name != "TempLine")
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
        public Line AddLine(Line l)
        {
            lineCollection.Add(l);
            return l;
        }
        public (Line, Point) PaintLine(Point currentPoint, Point point, bool f)
        {
            Point marcker = new Point(-1, -1);
            if (f) marcker = CheckMouseInPointNoEdit(point);
            if (currentPoint != new Point(-1, -1))
                if (marcker == new Point(-1, -1))
                     return (AddLine(currentPoint, point), point);
                else return (AddLine(currentPoint, marcker), marcker);
            else
                if (marcker == new Point(-1, -1)) 
                     return (null, point);
                else return (null, marcker);

        }
        private Line AddLine(Point p1, Point p2)
        {
            Line l = new Line();
            l.X1 = p1.X;
            l.Y1 = p1.Y;
            l.X2 = p2.X;
            l.Y2 = p2.Y;
            l.Name = "line_" + countLine;
            countLine++;
            l.Stroke = SystemColors.WindowFrameBrush;
            lineCollection.Add(l);
            return l;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SysModelRoom
{
    class Side
    {
        public enum StatusSide { side = 1, closeDoor, openDoor, window }
        public enum StateSide { up = 1, right, down, left }
        Point first;
        Point second;
        int status;//Состояние стены | 1 - Стена  | 2 - Дверь закрытая| 3 - Дверь открытая| 4 - Окно;
        int state; //Положение стены | 1 - Верхнее| 2 - Правое        | 3 - Нижнее        | 4 - Левое;

        public Point P1 { get => first; }
        public Point P2 { get => second; }
        public int Status { get => status; set => status = value; }
        public int State { get => state; set => state = value; }
        public Side(Point mFirst, Point mSecond, int size, int mState)
        {
            first = mFirst;
            second = mSecond;
            status = (int)Side.StatusSide.side;
            state = mState;
        }
        public Side(Point p1, Point p2, int size, int mStatus, int mState)
        {
            first = new Point();
            second = new Point();
            status = mStatus;
            state = mState;
        }
        public bool CompareSide(Side s)
        {
            return (s.P1.X == P1.X)
                && (s.P1.Y == P1.Y)
                && (s.P2.X == P2.X)
                && (s.P2.Y == P2.Y);
        }
    }
}

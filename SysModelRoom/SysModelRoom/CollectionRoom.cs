using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysModelRoom
{
    class CollectionRoom
    {
        public enum Status { atmosphere = 0, side = 1, door = 2, window = 3, join = 4}
        List<List<int>> rooms;
        //List<List<Side>> sidesG;
        //List<List<Side>> sidesV;

        public CollectionRoom(int basement)
        {
            //Создание фундамента, на котором будут распологаться комнаты
            rooms = new List<List<int>>(basement);
            for (int i = 0; i < basement; i++)
            {
                rooms.Add(new List<int>());
                for (int j = 0; j < basement; j++)
                    rooms[i][j] = 0;
            }
            
            ////Все горизонтальные стены
            //sidesG = new List<List<Side>>(basement);
            //for (int i = 0; i < basement; i++)
            //    sidesG.Add(new List<Side>());
            ////Все вертикальные стены
            //sidesV = new List<List<Side>>(basement);
            //for (int i = 0; i < basement; i++)
            //    sidesV.Add(new List<Side>());
        }
        
        public bool AddRoom(int s, int i, int j) 
        {
            if (i == 0 && j == 0 && s != 4
                || i == rooms.Count - 1 && j == 0 && s != 4
                || i == 0 && j == rooms.Count - 1 && s != 4
                || i == j && j == rooms.Count - 1 && s != 4)
                return false;
            rooms[i][j] = s;
            return true;
        }
        
        //public void AddSide(Side s) { sides.Add(s); }
        public void RemoveRoom(Room r) { /*rooms.Remove(r);*/ }
        //public void RemoveSide(Side s) { sides.Remove(s); }
        public void ChangeRoom(int s, int i, int j)
        {
            //foreach (Side si in sides)
            //    if (si.CompareSide(s))
            //        si.Status = status;
        }

    }
}

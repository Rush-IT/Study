using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SysModelRoom
{
    class Room
    {
        //Состояние стен
        //1 - Стена
        //2 - Дверь закрытая
        //3 - Дверь открытая
        //4 - Окно
        int sideUp;
        int sideRight;
        int sideLower;
        int sideLeft;

        public Room()
        {
            sideUp = 1;
            sideRight = 1;
            sideLower = 1;
            sideLeft = 1;
        }
    }
}

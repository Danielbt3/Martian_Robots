using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martian_Robots.Services.Auxiliary
{
    public class Map
    {
        private Cell[,] Grid;
        public Map(int X, int Y)
        {
            Grid = new Cell[X,Y];
        }
    }
}

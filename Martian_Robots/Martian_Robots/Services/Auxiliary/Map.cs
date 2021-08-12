using System.Collections.Generic;

namespace Martian_Robots.Services.Auxiliary
{
    public class Map
    {
        public List<Cell> grid = new List<Cell>();
        private Point mapDimensions = new Point();
        public Map(int X, int Y)
        {
            mapDimensions.X = X; mapDimensions.Y = Y;

            for (int i = 0; i <= X; i++)
            {
                for (int j = 0; j <= Y; j++)
                {
                    bool isBorder = false;
                    if (i == 0 || j == 0 || i == X || j == Y)
                        isBorder = true;
                    grid.Add(new Cell(new Point(i, j), isBorder));
                }
            }
        }

        #region Get
        public Point MapDimensions => mapDimensions;
        #endregion
    }
}

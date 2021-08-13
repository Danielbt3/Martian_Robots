namespace Martian_Robots.Services.Auxiliary
{
    public class Cell
    {
        public Point cords { get; set; }
        private bool isBorder { get; set; }
        private bool hasfallen;

        public bool HasFallen
        {
            get { return hasfallen; }
            set
            {
                if (isBorder)
                {
                    hasfallen = value;
                }
            }
        }

        public Cell(Point cords, bool isBorder)
        {
            this.cords = cords;
            this.isBorder = isBorder;
        }
    }
}
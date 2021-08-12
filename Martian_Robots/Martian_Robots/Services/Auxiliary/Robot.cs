namespace Martian_Robots.Services.Auxiliary
{
    public class Robot
    {
        public Point position { get; set; }
        private Orientations orientation { get; set; }

        public Robot(Point position, Orientations orientation)
        {
            this.position = position;
            this.orientation = orientation;
        }

        public void Instruction(char letter)
        {
            switch (letter)
            {
                case 'L':
                    Rotate(-90);
                    break;
                case 'R':
                    Rotate(90);
                    break;
                case 'F':
                    Move(1);
                    break;
            }
        }

        public void MoveBack(int steps)
        {
            Move(steps);
        }

        private void Rotate(int degrees)
        {
            int result = degrees + (int)orientation;
            if (result >= 360)
                result = result - (360 * (result / 360));
            if (result < 0)
                result = 360 + (result + (-360 * (result / -360)));
            orientation = (Orientations)result;
        }

        private void Move(int steps)
        {
            switch (orientation)
            {
                case Orientations.N:
                    position.Y += steps;
                    break;
                case Orientations.E:
                    position.X += steps;
                    break;
                case Orientations.S:
                    position.Y -= steps;
                    break;
                case Orientations.W:
                    position.X -= steps;
                    break;
            }
        }

        #region Get
        public Orientations GetOrientation() => orientation;
        #endregion
    }

    public enum Orientations
    {
        N = 0,
        E = 90,
        S = 180,
        W = 270
    }
}

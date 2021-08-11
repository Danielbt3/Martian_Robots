using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martian_Robots.Services.Auxiliary
{
    public class Robot
    {
        private Point Position { get; set; }
        private Orientations Orientation { get; set; }

        public Robot(Point Position, Orientations Orientation)
        {
            this.Position = Position;
            this.Orientation = Orientation;
        }

        public void Instruction(char letter)
        {
            switch (letter)
            {
                case 'L':
                    Rotate(90);
                    break;
                case 'R':
                    Rotate(-90);
                    break;
                case 'F':
                    Move(1);
                    break;
            }
        }

        private void Rotate(int degrees)
        {
            int result = degrees + (int)Orientation;
            if (result >= 360)
                result = result - (360 * (result / 360));
            if (result <= 0)
                result = 360-(result + (-360 * (result / -360)));
            Orientation = (Orientations)result;
        }

        private void Move(int steps)
        {
            switch (Orientation)
            {
                case Orientations.N:
                    Position.Y += steps;
                    break;
                case Orientations.E:
                    Position.X += steps;
                    break;
                case Orientations.S:
                    Position.Y -= steps;
                    break;
                case Orientations.W:
                    Position.X -= steps;
                    break;
            }
        }
    }

    public enum Orientations
    {
        N = 0,
        E = 90,
        S = 180,
        W = 270
    }
}

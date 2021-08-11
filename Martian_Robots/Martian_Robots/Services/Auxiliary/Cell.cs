using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martian_Robots.Services.Auxiliary
{
    public class Cell
    {
        public Point Cords { get; set; }
        public bool IsBorder { get; set; }
        private bool hasfallen;
        public bool HasFallen
        {
            get { return hasfallen; }
            set
            {
                if (IsBorder)
                {
                    hasfallen = value;
                }
            }
        }
    }
}

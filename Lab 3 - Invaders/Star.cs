using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab_3___Invaders
{
    struct Star
    {
        public Point point;
        public Brush brush;

        public Star(Point point, Brush brush)
        {
            this.point = point;
            this.brush = brush;
        }
    }
}

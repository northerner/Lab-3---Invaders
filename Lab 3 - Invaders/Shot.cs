using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_3___Invaders
{
    class Shot
    {
        private const int moveInterval = 15;
        private const int width = 3;
        private const int height = 10;

        public Point Location { get; private set; }

        private Direction direction;
        private Rectangle boundaries;

        public Shot(Point location, Direction direction,
            Rectangle boundaries)
        {
            this.Location = location;
            this.direction = direction;
            this.boundaries = boundaries;
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.Red,
                Location.X, Location.Y, width, height);
        }

        public bool Move()
        {
            Point newLocation;
            if (direction == Direction.Down)
            {
                newLocation = new Point(Location.X, (Location.Y + moveInterval));
            }
            else //if (direction == Direction.Up)
            {
                newLocation = new Point(Location.X, (Location.Y - moveInterval));
            }
            if ((newLocation.Y < boundaries.Height) && (newLocation.Y > 0))
            {
                Location = newLocation;
                return true;
            }
            else
                return false;
        }
    }
}

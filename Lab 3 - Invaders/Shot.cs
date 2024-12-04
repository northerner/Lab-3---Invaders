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
        // Bullet Speed
        private const int moveInterval = 15;
        private const int width = 3;
        private const int height = 10;
        public int timer = 0;

        public int bombWidth = 40;
        public const int bombHeight = 40;
        public ShipType shipType;

        public Point Location { get; private set; }

        public Direction direction;
        public Rectangle boundaries;
        public bool bomb;

        public Shot(Point location, Direction direction,
            Rectangle boundaries, ShipType shipType, bool bomb)
        {
            this.Location = location;
            this.direction = direction;
            this.boundaries = boundaries;
            this.shipType = shipType;
            this.bomb = bomb;
        }

        // Bullet Creation but not hit box
        public void Draw(Graphics graphics)
        {
            if (bomb ==  false)
            {
                graphics.FillRectangle(Brushes.Red,
                Location.X, Location.Y, width, height);
            } else
            {
                graphics.FillRectangle(Brushes.Orange,
                Location.X, Location.Y, bombWidth, bombHeight);
            }
            
        }

        public bool Move()
        {
            Point newLocation;
            if (direction == Direction.Down && bomb != true)
            {
                newLocation = new Point(Location.X, (Location.Y + moveInterval));
            }
            else if(direction == Direction.Up && bomb != true)//if (direction == Direction.Up)
            {
                newLocation = new Point(Location.X, (Location.Y - moveInterval));
            } else
            {
                newLocation = Location;
                timer++;
            }

            if (timer == 25)
            {
                return false;
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

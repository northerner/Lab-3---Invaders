using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab_3___Invaders
{
    class PlayerShip
    {
        private const int horizontalInterval = 10;
        public Point Location { get; private set; }
        public Rectangle Area
        {
            get
            {
                return new Rectangle(Location, image.Size);
            }
        }
        public Bitmap image = Properties.Resources.player;
        public bool Alive;
        private Rectangle boundaries;

        public PlayerShip(Rectangle boundaries, Point location)
        {
            this.boundaries = boundaries;
            this.Location = location;
            Alive = true;
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.Left)
            {
                Point newLocation = new Point((Location.X - horizontalInterval), Location.Y);
                if ((newLocation.X < (boundaries.Width - 50)) && (newLocation.X > 0))
                    Location = newLocation;
            }
            else if (direction == Direction.Right)
            {
                Point newLocation = new Point((Location.X + horizontalInterval), Location.Y);
                if ((newLocation.X < (boundaries.Width - 50)) && (newLocation.X > 0))
                    Location = newLocation;
            }
        }

        public void Draw(Graphics graphics)
        {
            if (!Alive)
            {
                // Reset deadShipHeight and draw ship
            }
            else
            {
                graphics.DrawImage(image, Location);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_3___Invaders
{
    class Invader
    {
        private const int horizontalInterval = 10;
        private const int verticalInterval = 30;

        private Bitmap image;
        private Bitmap[] imageArray;

        public Point Location { get; private set; }

        public ShipType InvaderType { get; private set; }

        public Rectangle Area
        {
            get
            {
                return new Rectangle(Location, imageArray[0].Size);
            }
        }

        public int Score { get; private set; }

        public Invader(ShipType invaderType, Point location, int score)
        {
            this.InvaderType = invaderType;
            this.Location = location;
            this.Score = score;

            createInvaderBitmapArray();
            image = imageArray[0];
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    // Location is a struct, so new one created to keep it immutable
                    Location = new Point((Location.X + horizontalInterval), Location.Y);
                    break;
                case Direction.Left:
                    Location = new Point((Location.X - horizontalInterval), Location.Y);
                    break;
                case Direction.Down:
                    Location = new Point(Location.X, (Location.Y + verticalInterval));
                    break;
            }

        }

        public Graphics Draw(Graphics graphics, int animationCell)
        {
            Graphics invaderGraphics = graphics;
            image = imageArray[animationCell];
            try
            {
                graphics.DrawImage(image, Location);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //DEBUG red square invaders
            //graphics.FillRectangle(Brushes.Red,
            //    Location.X, Location.Y, 20, 20);
            return invaderGraphics;
        }

        private void createInvaderBitmapArray()
        {
            imageArray = new Bitmap[4];
            switch (InvaderType)
            {
                case ShipType.Bug:
                    imageArray[0] = Properties.Resources.bug1;
                    imageArray[1] = Properties.Resources.bug2;
                    imageArray[2] = Properties.Resources.bug3;
                    imageArray[3] = Properties.Resources.bug4;
                    break;
                case ShipType.Satellite:
                    imageArray[0] = Properties.Resources.satellite1;
                    imageArray[1] = Properties.Resources.satellite2;
                    imageArray[2] = Properties.Resources.satellite3;
                    imageArray[3] = Properties.Resources.satellite4;
                    break;
                case ShipType.Saucer:
                    imageArray[0] = Properties.Resources.flyingsaucer1;
                    imageArray[1] = Properties.Resources.flyingsaucer2;
                    imageArray[2] = Properties.Resources.flyingsaucer3;
                    imageArray[3] = Properties.Resources.flyingsaucer4;
                    break;
                case ShipType.Spaceship:
                    imageArray[0] = Properties.Resources.spaceship1;
                    imageArray[1] = Properties.Resources.spaceship2;
                    imageArray[2] = Properties.Resources.spaceship3;
                    imageArray[3] = Properties.Resources.spaceship4;
                    break;
                case ShipType.Star:
                    imageArray[0] = Properties.Resources.star1;
                    imageArray[1] = Properties.Resources.star2;
                    imageArray[2] = Properties.Resources.star3;
                    imageArray[3] = Properties.Resources.star4;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab_3___Invaders
{
    class Game
    {
        private Stars stars;
        private Rectangle formArea;
        private Random random;

        public Game(Random random, Rectangle formArea)
        {
            this.formArea = formArea;
            this.random = random;
            stars = new Stars(random, formArea);
        }


        public void Draw(Graphics graphics, int frame)
        {
            stars.Draw(graphics);
            
        }

        public void Twinkle()
        {
            stars.Twinkle(random);
        }

    }
}

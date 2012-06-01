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

        private int score = 0;
        private int livesLeft = 2;
        private int wave = 0;
        private int framesSkipped = 0;

        private Direction invaderDirection;
        //private List<Invader> invaders;

        //private PlayerShip playerShip;
        //private List<Shot> playerShots;
        //private List<Shot> invaderShots;

        private PointF scoreLocation;

        public Game(Random random, Rectangle formArea)
        {
            this.formArea = formArea;
            this.random = random;
            stars = new Stars(random, formArea);
            scoreLocation = new PointF((formArea.Left + 5.0F), (formArea.Top + 5.0F));

        }


        public void Draw(Graphics graphics, int frame)
        {
            graphics.FillRectangle(Brushes.Black, formArea);
            
            stars.Draw(graphics);
            //foreach (Invader invader in invaders)
            //    invader.Draw(graphics, frame);
            //playerShip.Draw(graphics);
            //foreach (Shot shot in playerShots)
            //    shot.Draw(graphics);
            //foreach (Shot shot in invaderShots)
            //    shot.Draw(graphics);

            graphics.DrawString(score.ToString(), SystemFonts.DefaultFont, Brushes.Yellow, scoreLocation);
            
        }

        public void Twinkle()
        {
            stars.Twinkle(random);
        }

        public event EventHandler GameOver;
    }
}

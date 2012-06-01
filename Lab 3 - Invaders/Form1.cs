using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab_3___Invaders
{
    public partial class Form1 : Form
    {
        public int Frame;
        private Game game;
        public Rectangle FormArea { get { return this.ClientRectangle; } }
        Random random = new Random();

        List<Keys> keysPressed = new List<Keys>();

        public bool gameOver;

        public Form1()
        {
            InitializeComponent();
            Frame = 0;
            game = new Game(random, FormArea);
            gameOver = false;
            game.GameOver +=new EventHandler(game_GameOver);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (Frame != 6)
                Frame++;
            else
                Frame = 0;
            game.Twinkle();
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //graphics.FillRectangle(Brushes.Black, this.ClientRectangle);
            game.Draw(graphics, Frame);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
                Application.Exit();
            if (gameOver)
                if (e.KeyCode == Keys.S)
                {
                    // code to reset the game
                    return;
                }
            //if (e.KeyCode == Keys.Space)
            //    game.FireShot();
            if (keysPressed.Contains(e.KeyCode))
                keysPressed.Remove(e.KeyCode);
            keysPressed.Add(e.KeyCode);
        
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysPressed.Contains(e.KeyCode))
                keysPressed.Remove(e.KeyCode);
        }

        //private void gameTimer_Tick(object sender, EventArgs e)
        //{
        //    game.Go();
        //    foreach (Keys key in keysPressed)
        //    {
        //        if (key == Keys.Left)
        //        {
        //            game.MovePlayer(Direction.Left);
        //            return;
        //        }
        //        else if (key == Keys.Right)
        //        {
        //            game.MovePlayer(Direction.Right);
        //            return;
        //        }
        //    }
        //}

        private void game_GameOver(object sender, EventArgs e)
        {
            gameTimer.Stop();
            gameOver = true;
            Invalidate();
        }


    }
}

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

        public Form1()
        {
            InitializeComponent();
            Frame = 0;
            game = new Game(random, FormArea);
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
            graphics.FillRectangle(Brushes.Black, this.ClientRectangle);
            game.Draw(graphics, Frame);
            
        }
    }
}

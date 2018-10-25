using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace SnakeNooob
{
    public partial class Form1 : Form
    {
        const int H = 9;
        const int W = 9;
        const int S = 40;

        Position mins = new Position(3, 4);
        List<Position> snakeParts = new List<Position>();


        public Form1()
        {
            InitializeComponent();
            snakeParts.Add(new Position(5, 5));
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            for (int i = 0; i < 10; i++)
                graphics.DrawLine(Pens.Green, i * S, 0, i * S, Box.Height);

            for (int i = 0; i < 10; i++)
                graphics.DrawLine(Pens.Green, 0, i * S, Box.Width, i * S);

            graphics.DrawLine(Pens.DarkRed, S * 0, 0, S * 0, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, S * 0, Box.Width, S * 0);
            graphics.DrawLine(Pens.DarkRed, S * 9, 0, S * 9, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, 9 * S, Box.Width, 9 * S);


            Random rand = new Random();
            mins.X = rand.Next(0, W);
            mins.Y = rand.Next(0, H);

            graphics.FillEllipse(Brushes.Firebrick, mins.X * S, mins.Y * S, S, S);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Box.Refresh();
        }

        private bool IsHeadOnBody()
        {
            for (int i = 0; i < snakeParts.Count; i++)
            {
                if (snakeParts[2] == snakeParts[i])
                    return true;
            }
            
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
 
        }
    }
}

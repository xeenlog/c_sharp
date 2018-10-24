using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace SnakeNooob
{
    public partial class Form1 : Form
    {
        const int H = 30;
        const int W = 50;
        const int S = 20;

        Position food = new Position(9, 9);
        Position speed = new Position(0, 0);
        List<Position> snakeParts = new List<Position>();


        public Form1()
        {
            InitializeComponent();
            snakeParts.Add(new Position(5, 5));
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            for (int i = 0; i < 51; i++)
                graphics.DrawLine(Pens.Green, i * S, 0, i * S, Box.Height);

            for (int i = 0; i < 31; i++)
                graphics.DrawLine(Pens.Green, 0, i * S, Box.Width, i * S);

            graphics.DrawLine(Pens.DarkRed, S * 0, 0, S * 0, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, S * 0, Box.Width, S * 0);
            graphics.DrawLine(Pens.DarkRed, S * 50, 0, S * 50, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, 30 * S, Box.Width, 30 * S);
            graphics.DrawLine(Pens.DarkRed, S * 25, 0, S * 25, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, 15 * S, Box.Width, 15 * S);

            for (var i = 0; i < snakeParts.Count; i++)
            {
                graphics.FillEllipse(Brushes.DarkViolet, snakeParts[i].X * S, snakeParts[i].Y * S, S, S);
            }

            graphics.FillEllipse(Brushes.Firebrick, food.X * S, food.Y * S, S, S);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (speed.X == 0 && speed.Y == 0)
                return;

            if (snakeParts.Contains(snakeParts[0] + speed))
            {
                snakeParts.Clear();
                snakeParts.Add(new Position(5, 5));
                return;
            }
            
            snakeParts.Insert(0, snakeParts[0] + speed);

            if (snakeParts[0].X > W - 1)
                snakeParts[0].X = 0;
            if (snakeParts[0].X < 0)
                snakeParts[0].X = W - 1;
            if (snakeParts[0].Y > H - 1)
                snakeParts[0].Y = 0;
            if (snakeParts[0].Y < 0)
                snakeParts[0].Y = H - 1;

            if (snakeParts[0].X == food.X && snakeParts[0].Y == food.Y)
            {
                Random rand = new Random();
                food.X = rand.Next(0, W);
                food.Y = rand.Next(0, H);
            }

            else
            {
                snakeParts.RemoveAt(snakeParts.Count - 1);
            }

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
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (!(speed.X == 1 && snakeParts.Count >= 2))
                {
                    speed.X = -1;
                    speed.Y = 0;
                }
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (!(speed.X == -1 && snakeParts.Count >= 2))
                {
                    speed.X = 1;
                    speed.Y = 0;
                }
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (!(speed.Y == -1 && snakeParts.Count >= 2))
                {
                    speed.Y = 1;
                    speed.X = 0;
                }
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (!(speed.Y == 1 && snakeParts.Count >= 2))
                {
                    speed.Y = -1;
                    speed.X = 0;
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                speed.Y = 0;
                speed.X = 0;
            }
        }
    }
}

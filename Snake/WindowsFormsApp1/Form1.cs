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
        const int S = 20; //размер клетки в пикселях

        Position golova = new Position(0, 0);
        Position food = new Position(9, 9);
        Position speed = new Position(0, 0);
        readonly List<Position> snakeParts = new List<Position>();


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

            foreach (Position snakePart in snakeParts)
            for (int i = 0; i < 31; i++)
                graphics.FillEllipse(Brushes.DarkViolet, snakeParts[0].X * S, snakeParts[0].Y * S, S, S);

            graphics.FillEllipse(Brushes.Firebrick, food.X * S, food.Y * S, S, S);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            golova += speed;
            snakeParts.Insert(1, item: new Position(1, 1));
            snakeParts.RemoveAt(1 - 1);

            if (golova.X > W - 1)
                golova.X = 0;
            if (golova.X < 0)
                golova.X = W - 1;
            if (golova.Y > H - 1)
                golova.Y = 0;
            if (golova.Y < 0)
                golova.Y = H - 1;

            if (golova.X == food.X && golova.Y == food.Y)
            {
                Random rand = new Random();
                food.X = rand.Next(0, W);
                food.Y = rand.Next(0, H);
            }

            Box.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                snakeParts.Insert(0, item: new Position(golova.X - 1, golova.Y));
             // speed.X = -1;
             // speed.Y = 0;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                speed.X = 1;
                speed.Y = 0;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                speed.Y = 1;
                speed.X = 0;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                speed.Y = -1;
                speed.X = 0;
            }

            if (e.KeyCode == Keys.Space)
            {
                speed.Y = 0;
                speed.X = 0;
            }
        }
    }
}

using System.Windows.Forms;
using System.Drawing;
using System;

namespace SnakeNooob
{
    public partial class Form1 : Form
    {
        const int CellSize = 20;

        Position golova = new Position(0, 0);

        Position food = new Position(0, 0);

        Position speed = new Position(0, 0);

        public Form1()
        {
            InitializeComponent();
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;


            for (int i = 0; i < 51; i++)
                graphics.DrawLine(Pens.Green, i * CellSize, 0, i * CellSize, Box.Height);

            for (int i = 0; i < 31; i++)
                graphics.DrawLine(Pens.Green, 0, i * CellSize, Box.Width, i * CellSize);

            graphics.DrawLine(Pens.DarkRed, CellSize * 0, 0, CellSize * 0, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, CellSize * 0, Box.Width, CellSize * 0);
            graphics.DrawLine(Pens.DarkRed, CellSize * 50, 0, CellSize * 50, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, 30 * CellSize, Box.Width, 30 * CellSize);
            graphics.DrawLine(Pens.DarkRed, CellSize * 25, 0, CellSize * 25, Box.Height);
            graphics.DrawLine(Pens.DarkRed, 0, 15 * CellSize, Box.Width, 15 * CellSize);

            graphics.FillEllipse(Brushes.DarkViolet, golova.X * CellSize, golova.Y * CellSize, CellSize, CellSize);
            graphics.FillEllipse(Brushes.Firebrick, food.X * CellSize, food.Y * CellSize, CellSize, CellSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            golova += speed;

            if (golova.X > 49)
                golova.X = 0;
            if (golova.X < 0)
                golova.X = 49;
            if (golova.Y > 29)
                golova.Y = 0;
            if (golova.Y < 0)
                golova.Y = 29;

            if (golova.X == food.X && golova.Y == food.Y)
            {
                Random rand = new Random();
                food.X = rand.Next(0, 50);
                food.Y = rand.Next(0, 30);
            }

            Box.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                speed.X = -1;
                speed.Y = 0;
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

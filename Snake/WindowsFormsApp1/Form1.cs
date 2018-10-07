using System.Windows.Forms;
using System.Drawing;
using System;

namespace SnakeNooob
{
    public partial class Form1 : Form
    {
        const int CellSize = 20;

        int golovaX = 0;
        int golovaY = 0;

        int foodX = 49;
        int foodY = 29;

        int golovaXSpeed = 0;
        int golovaYSpeed = 0;

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

            graphics.FillEllipse(Brushes.DarkViolet, golovaX * CellSize, golovaY * CellSize, CellSize, CellSize);
            graphics.FillEllipse(Brushes.Firebrick, foodX * CellSize, foodY * CellSize, CellSize, CellSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            golovaX += golovaXSpeed;
            golovaY += golovaYSpeed;

            if (golovaX > 49)
                golovaX = 0;
            if (golovaX < 0)
                golovaX = 49;
            if (golovaY > 29)
                golovaY = 0;
            if (golovaY < 0)
                golovaY = 29;

            if (golovaX == foodX && golovaY == foodY)
            {
                Random rand = new Random();
                foodX = rand.Next(0, 50);
                foodY = rand.Next(0, 30);
            }

            Box.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                golovaXSpeed = -1;
                golovaYSpeed = 0;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                golovaXSpeed = 1;
                golovaYSpeed = 0;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                golovaYSpeed = 1;
                golovaXSpeed = 0;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                golovaYSpeed = -1;
                golovaXSpeed = 0;
            }

            if (e.KeyCode == Keys.Space)
            {
                golovaYSpeed = 0;
                golovaXSpeed = 0;
            }
        }
    }
}

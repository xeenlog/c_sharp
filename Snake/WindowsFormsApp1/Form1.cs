using System.Windows.Forms;
using System.Drawing;
using System;

namespace SnakeNooob
{
    public partial class Form1 : Form
    {
        const int CellSize = 20;

        int golX = CellSize;
        int golY = CellSize;

        int foodX = CellSize * 5;
        int foodY = CellSize * 5;

        int golXSpeed = CellSize * 0;
        int golYSpeed = CellSize * 0;


        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;


            for (int i = 0; i < 51; i++)
            {
                graphics.DrawLine(Pens.DarkRed, i * CellSize, 0, i * CellSize, Box.Height);
            }

            for (int i = 0; i < 31; i++)
            {
                graphics.DrawLine(Pens.DarkRed, 0, i * CellSize, Box.Width, i * CellSize);
            }

            graphics.FillEllipse(Brushes.Brown, golX, golY, CellSize, CellSize);
            graphics.FillEllipse(Brushes.DarkBlue, foodX, foodY, CellSize, CellSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            golX += golXSpeed * CellSize;
            golY += golYSpeed * CellSize;

            if (golX > CellSize * 49)
                golX = CellSize * 0;
            if (golX < CellSize * 0)
                golX = CellSize * 49;
            if (golY > CellSize * 29)
                golY = CellSize * 0;
            if (golY < CellSize * 0)
                golY = CellSize * 29;

            if (golX == foodX && golY == foodY)
            {
                // int r = rand.Next(0, 50);
                // int t = rand.Next(0, 30);
                foodX = golX + CellSize;
                foodY = golY + CellSize;
            }

            foodX = golX;
            foodY = golY + CellSize;

            Box.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                golXSpeed = -1;
                golYSpeed = 0;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                golXSpeed = 1;
                golYSpeed = 0;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                golYSpeed = 1;
                golXSpeed = 0;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                golYSpeed = -1;
                golXSpeed = 0;
            }

            if (e.KeyCode == Keys.Space)
            {
                golYSpeed = 0;
                golXSpeed = 0;
            }
        }
    }
}

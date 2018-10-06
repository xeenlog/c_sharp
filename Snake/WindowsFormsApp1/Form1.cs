// + // 1. Одноклеточная змейка двигалась по таймеру
// + // 2. Разлиновку сделать круче, ну "типа" строго 80х50, чтобы красивые клеточки, без хвостиков
// + // 3. Змейка должна двигаться строго по клеточкам, не вылазить за пределы клеточек
// + // 4. Змейка — прямоугольник (круг, на усмотрение) закрашенный размером с клетку разлиновки
// + // 5. Клавиши меняют направление движения
// + // 6. Если выходим за пределы 80х50, то телепортировать в центр поля (40, 25)
// _________________________________________________________________________________________________
//   Новое задание ЕДА:
// + // 1. Создавать в случайной клетке 1 еду. Объявляешь в классе(не локальную переменную) поле: private Random Random = new Random(); (рядом с GolYSpeed) А потом Random.Next… изучаешь методы рандома. Еда другого цвета.
// + // 2. Если голова змейки встает в клетку с едой, еда перемещается в другое случайное место(змейка съела еду, но пока не выросла)
// + // 3. Управление через WASD должно работать наравне с стрелочками.
// + // 4. Надо перевести позиции и движение с абсолютных пикселей в клетки.
//    Типа координаты змейки и еды задавать индексом клетки, например (15, 23). Змейка движется на 1 клетку за 1 тик таймера(скорость таймера подрегулировать, чтобы не часто было).
//   Для этого cellSize надо будет вывести в поле класса.Ну и просто, если мы в 5-й клетке по горизонтали, то только в момент отрисовки будет перевод в пиксели. 5*cellSize пиксель по горизонтали где надо рисовать змейку.
//   Так же с учётом границ не по пикселям, а типа превысили кол-во клеток в поле (51 и 31 вроде вывести в поле класса)


using System.Windows.Forms;
using System.Drawing;
using System;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int cellSize = 20;

        int GolX = cellSize;
        int GolY = cellSize;

        int FoodX = cellSize * 5;
        int FoodY = cellSize * 5;

        int GolXSpeed = cellSize * 0;
        int GolYSpeed = cellSize * 0;


        System.Random rand = new Random();

        static void Mai(string[] args)
        {
            int[] mas = new int[10];
            mas[0] = 4;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;


            for (int i = 0; i < 51; i++)
            {
            graphics.DrawLine(Pens.DarkRed, i * cellSize, 0, i * cellSize, Box.Height);
            }
            for (int i = 0; i < 31; i++)
            {
            graphics.DrawLine(Pens.DarkRed, 0, i * cellSize, Box.Width, i * cellSize);
            }
            graphics.FillEllipse(Brushes.Brown, GolX, GolY, cellSize, cellSize);
            graphics.FillEllipse(Brushes.DarkBlue, FoodX, FoodY, cellSize, cellSize);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            GolX += GolXSpeed * cellSize;
            GolY += GolYSpeed * cellSize;

            if (GolX > cellSize * 49)
                GolX = cellSize * 0;
            if (GolX < cellSize * 0)
                GolX = cellSize * 49;
            if (GolY > cellSize * 29)
                GolY = cellSize * 0;
            if (GolY < cellSize * 0)
                GolY = cellSize * 29;

            if (GolX == FoodX && GolY == FoodY)
            {
               // int r = rand.Next(0, 50);
               // int t = rand.Next(0, 30);
                FoodX = GolX + cellSize;
                FoodY = GolY + cellSize;
            }

            FoodX = GolX ;
            FoodY = GolY + cellSize;

            Box.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
              GolXSpeed = -1;
              GolYSpeed = 0;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
              GolXSpeed = 1;
              GolYSpeed = 0;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
              GolYSpeed = 1;
              GolXSpeed = 0;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
              GolYSpeed = -1;
              GolXSpeed = 0;
            }
            if (e.KeyCode == Keys.Space)
            {
              GolYSpeed = 0;
              GolXSpeed = 0;
            }
        }
    }   
}

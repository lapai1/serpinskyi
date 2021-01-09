using System;
using System.Drawing;
using System.Windows.Forms;

namespace serpinskyi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int p ; //порядок кривой
        int lx = 5, ly = 5; //определяем значения, дающие направление,в котором должна рисоваться кривая
        //Графический курсор устанавливаем в начальную точку
        int X = 250, Y = 50;
        // Функция DrawPart рисует линию из точки (X,Y) к новой точке и сохраняет координаты точки в переменных X и Y.
        private void DrawPart(Graphics g, int lx, int ly)
        {
            g.DrawLine(Pens.Black, X, Y, X + lx, Y + ly);
            X = X + lx;
            Y = Y + ly;
        }
        //  Кривую Гильберта можно получить путем
        //  соединения элементов а,b,с и d.
        //  Каждый элемент строит
        //  соответствующая функция.
        // Рекурсивно берем четыре маленькие кривые Гильберта и соединяем их линиями.
        // Процедуры рисования четырех разновидностей кривых Гильберта(направленных в разные стороны)
        void a(int i, Graphics g)
        {
            if (i > 0)
            {
                a(i - 1, g);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart(g, 0, ly);
                b(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart(g, +lx, 0);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart(g, 0, ly);
                d(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart(g, +lx, 0);
                a(i - 1, g);
            }
        }
        void b(int i, Graphics g)
        {
            if (i > 0)
            {
                b(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                c(i - 1, g);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart(g, 0, ly);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                a(i - 1, g);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart(g, 0, ly);
                b(i - 1, g);
            }
        }
        void c(int i, Graphics g)
        {
            if (i > 0)
            {
                c(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart(g, 0, -ly);
                d(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart(g, 0, -ly);
                b(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                c(i - 1, g);
            }
        }
        void d(int i, Graphics g)
        {
            if (i > 0)
            {
                d(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart(g, +lx, 0);
                a(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart(g, 0, -ly);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart(g, lx, 0);
                c(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart(g, 0, -ly);
                d(i - 1, g);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(textBox1.Text);
            textBox1.Clear();
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox2.Handle);
            //вызываем функцию рисования фрактала
            a(p, g); DrawPart(g, 0, ly);
            b(p, g); DrawPart(g, -lx, 0);
            c(p, g); DrawPart(g, 0, -ly);
            d(p, g); DrawPart(g, lx, 0);
        }
    }
}

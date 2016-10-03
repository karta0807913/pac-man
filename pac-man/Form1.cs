using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man
{
    public partial class Form1 : Form
    {
        private Engine_2D engine;
        private const int objectWidth = 40;
        private const int objectHeight = 40;
        Player player;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new Engine_2D(pictureBox1,
                pictureBox1.Size.Width, pictureBox1.Size.Height,
                new Size(objectWidth, objectHeight), this);
            player = new Player(engine, new Point(1, 1));

            Bitmap bmp = new Bitmap("./staticImg.png");
            for(int row = 0; row < pictureBox1.Size.Width / objectWidth; ++row)
            {
                StaticObject staticObject = new StaticObject(
                    engine, new Point(row, 0), bmp);
            }

            for (int row = 0; row < pictureBox1.Size.Width / objectWidth; ++row)
            {
                StaticObject staticObject = new StaticObject(
                    engine, new Point(row, pictureBox1.Size.Height / objectHeight - 1), bmp);
            }

            for (int column = 1; column < pictureBox1.Size.Height / objectHeight - 1; ++column)
            {
                StaticObject staticObject = new StaticObject(
                    engine, new Point(0, column), bmp);
            }

            for (int column = 1; column < pictureBox1.Size.Height / objectHeight - 1; ++column)
            {
                StaticObject staticObject = new StaticObject(
                    engine, new Point(pictureBox1.Size.Width / objectWidth - 1, column), bmp);
            }
        }
    }
}

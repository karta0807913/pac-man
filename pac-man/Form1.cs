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
        Player player;
        public Form1()
        {
            InitializeComponent();
            engine = new Engine_2D(pictureBox1, 
                pictureBox1.Size.Width, pictureBox1.Size.Height, 
                new Size(40, 40), this);
            player = new Player(engine, new Point(0, 0));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

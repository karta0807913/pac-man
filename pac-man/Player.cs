using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac_man
{

    class Player : GameObject
    {
        public Player(Engine_2D engine, Point point) : base(engine, point)
        {
            engine.addGameObject(this);
            Bitmap bmp = new Bitmap(40, 40);
            for(int row = 0; row < 40; ++row)
            {
                for(int column = 0; column < 40; ++column)
                {
                    bmp.SetPixel(column, row, Color.Wheat);
                }
            }
            setImg(bmp);
        }

        public override void Update()
        {
            if (inputKey(System.Windows.Forms.Keys.W))
            {
                Point point = getPoint();
                translate(point.X, point.Y - 1);
            }
            else if (inputKey(System.Windows.Forms.Keys.S))
            {
                Point point = getPoint();
                translate(point.X, point.Y + 1);
            }
            if (inputKey(System.Windows.Forms.Keys.A))
            {
                Point point = getPoint();
                translate(point.X - 1, point.Y);
            }
            else if (inputKey(System.Windows.Forms.Keys.D))
            {
                Point point = getPoint();
                translate(point.X + 1, point.Y);
            }
        }
    }
}

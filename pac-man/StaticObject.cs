using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac_man
{
    class StaticObject : GameObject
    {
        public StaticObject(Engine_2D engine, Point point, Bitmap bmp) : base(engine, point)
        {
            setStatic(true);
            setTag("Static_Object");
            setImg(bmp);
            engine.addGameObject(this);
        }
    }
}

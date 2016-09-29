using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man
{
    class GameObject
    {
        public GameObject(Engine_2D engine, Point point)
        {
            sourceImg = null;
            priority = 0;
            tag = "";
            visable = true;
            this.engine = engine;
            staticObject = true;
            this.point = point;
        }

        public virtual void Update()
        {

        }

        public virtual void collisionTrigger(GameObject obj)
        {

        }

        public String getTag()
        {
            return tag;
        }

        public void setTag(String newTag)
        {
            tag = newTag;
        }

        public int getPriority()
        {
            return priority;
        }

        public void setPriority(int priority)
        {
            this.priority = priority;
        }

        public bool isVisable()
        {
            return visable;
        }

        public void setVisable(bool vis)
        {
            visable = vis;
        }

        public void setImg(Bitmap bitmap)
        {
            sourceImg = bitmap;
        }

        public Bitmap getImg()
        {
            return sourceImg;
        }

        public GameObject Clone()
        {
            GameObject gameObject = new GameObject(engine, point);
            gameObject.visable = visable;
            gameObject.sourceImg = sourceImg;
            return gameObject;
        }

        public bool isStatic()
        {
            return staticObject;
        }

        public void setStatic(bool boolean)
        {
            this.staticObject = boolean;
        }

        public bool inputKey(Keys keyCode)
        {
            return engine.inputKey(keyCode);
        }

        public Point getPoint()
        {
            return point;
        }

        public bool translate(int x, int y)
        {
            bool boolean;
            if (boolean = engine.translate(this, x, y))
            {
                point.X = x;
                point.Y = y;
            }
            return boolean;
        }

        private bool visable;
        private bool staticObject;
        private int priority;
        private String tag;
        private Bitmap sourceImg;
        private Point point;
        private Engine_2D engine;
    }
}

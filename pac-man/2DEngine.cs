using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man
{
    class Engine_2D
    {

        private List<GameObject> GB_List;
        private List<Point> changedPoint;
        private Painting painting;
        private PictureBox pictureBox;
        private ScreenManager screenManager;
        private Size areaSize;
        private Timer engine_Timer;
        private const int timer_clock = 100;
        private List<Keys> keyList;
        private static Color[][] color;

        public Engine_2D(PictureBox pictureBox, int picX, int picY, 
            Size areaSize, Form form)
        {
            this.pictureBox = pictureBox;
            this.areaSize = areaSize;

            painting = new Painting(picX, picY, areaSize);

            GB_List = new List<GameObject>();

            changedPoint = new List<Point>();

            keyList = new List<Keys>();

            screenManager = new ScreenManager(picX / areaSize.Width, picY / areaSize.Height);

            engine_Timer = new Timer();
            engine_Timer.Interval = timer_clock;
            engine_Timer.Tick += new System.EventHandler(this.Update);
            engine_Timer.Enabled = true;
            
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;

            color = new Color[areaSize.Height][];
            for(int row = 0; row < areaSize.Height; ++row)
            {
                color[row] = new Color[areaSize.Width];
                for(int column = 0; column < areaSize.Width; ++column)
                {
                    color[row][column] = Color.Black;
                }
            }

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyList.IndexOf(e.KeyCode) == -1)
                keyList.Add(e.KeyCode);
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            keyList.Remove(e.KeyCode);
        }

        public bool inputKey(Keys key)
        {
            return keyList.IndexOf(key) != -1;
        }

        private void Update(object sender, EventArgs e)
        {
            foreach(GameObject obj in GB_List)
            {
                obj.Update();
            }
            foreach(GameObject obj in GB_List)
            {
                foreach(GameObject gameObject in screenManager.collisionObject(obj))
                {
                    if (obj.getPriority() >= gameObject.getPriority())
                        obj.collisionTrigger(gameObject);
                }
            }
            foreach(Point point in changedPoint)
            {
                List<GameObject> tmp = screenManager.getTargetList(point.X, point.Y);
                if (tmp.Count != 0)
                {
                    foreach (GameObject obj in screenManager.getTargetList(point.X, point.Y))
                    {
                        painting.drowObject(obj);
                    }
                }
                else
                    painting.drowArea(point.X * areaSize.Width, point.Y * areaSize.Width,
                                        (point.X + 1) * areaSize.Width,
                                        (point.Y + 1) * areaSize.Height,
                                        color);
            }
            changedPoint.Clear();
            pictureBox.Image = painting.returnBitmap();
        }

        public void addGameObject(GameObject obj)
        {
            if (obj != null && checkPoint(obj) && checkBitmap(obj))
            {
                if (!screenManager.addGameObject(obj))
                    throw new Exception();
                GB_List.Add(obj);
                changedPoint.Add(obj.getPoint());
            }
        }

        private bool checkPoint(GameObject obj)
        {
            Point tmpPoint = obj.getPoint();
            return !(tmpPoint.X < 0 || tmpPoint.Y < 0);
        }

        private bool checkBitmap(GameObject obj)
        {
            Bitmap tmpBitmap = obj.getImg();
            if (tmpBitmap == null)
                return true;

            return !(tmpBitmap.Size.Width < areaSize.Width || tmpBitmap.Size.Height < areaSize.Height);
        }

        public bool translate(GameObject obj, int x, int y)
        {
            if(screenManager.moveObject(obj, x, y))
            {
                changedPoint.Add(obj.getPoint());
                changedPoint.Add(new Point(x, y));
                return true;
            }
            return false;
        }
    }
}

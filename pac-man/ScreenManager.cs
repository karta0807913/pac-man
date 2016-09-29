using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac_man
{
    class ScreenManager
    {
        public ScreenManager(int xSize, int ySize)
        {
            screenObject = new List<GameObject>[ySize][];

            for(int row = 0; row < ySize; ++row)
            {
                screenObject[row] = new List<GameObject>[xSize];
                for(int column = 0; column < xSize; ++column)
                {
                    screenObject[row][column] = new List<GameObject>();
                }
            }
        }

        public bool addGameObject(GameObject obj)
        {
            Point tmpPoint = obj.getPoint();
            if (screenObject[tmpPoint.Y][tmpPoint.X].IndexOf(obj) != -1)
                return false;

            screenObject[tmpPoint.Y][tmpPoint.X].Add(obj);

            return true;
        }

        public bool moveObject(GameObject obj, int x, int y)
        {
            Point tmpPoint = obj.getPoint();
            if (y < 0 || x < 0 || x >= screenObject[0].Length || y >= screenObject.Length)
                return false;
            if (obj.isStatic() == true && screenObject[y][x].Count != 0)
                return false;
            if (screenObject[tmpPoint.Y][tmpPoint.X].IndexOf(obj) == -1)
                return false;
            if (screenObject[y][x].Count != 0 && screenObject[y][x].First().isStatic())
            {
                screenObject[y][x].First().collisionTrigger(obj);
                return false;
            }

            screenObject[tmpPoint.Y][tmpPoint.X].Remove(obj);
            screenObject[y][x].Add(obj);
            return true;
        }

        public List<GameObject> collisionObject(GameObject obj)
        {
            Point tmpPoint = obj.getPoint();

            List<GameObject> tmp = new List<GameObject>();
            foreach (GameObject gameObject in screenObject[tmpPoint.Y][tmpPoint.X])
            {
                if(gameObject != obj)
                    tmp.Add(gameObject);
            }
            return tmp;
        }

        public List<GameObject> getTargetList(int x, int y)
        {
            return screenObject[y][x];
        }

        private List<GameObject>[][] screenObject;
    }
}

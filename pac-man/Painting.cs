using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac_man
{
    class Painting
    {
        public Painting(int x, int y, Size areaSize)
        {
            bitmap = new Bitmap(x, y);
            this.areaSize = areaSize;
        }

        public bool drowObject(GameObject obj)
        {
            Bitmap tmpBitmap = obj.getImg();
            Point tmpPoint = obj.getPoint();
            Color[][] color = new Color[areaSize.Height][];

            if (tmpBitmap == null)
            {
                for (int row = 0; row < areaSize.Height; ++row)
                {
                    color[row] = new Color[areaSize.Width];
                    for (int column = 0; column < areaSize.Width; ++column)
                    {
                        color[row][column] = Color.Black;
                    }
                }
            }
            else
            {
                for (int row = 0; row < areaSize.Height; ++row)
                {
                    color[row] = new Color[areaSize.Width];
                    for (int column = 0; column < areaSize.Width; ++column)
                    {
                        color[row][column] = tmpBitmap.GetPixel(column, row);
                    }
                }
            }
            return drowArea(tmpPoint.X * areaSize.Width, 
                                tmpPoint.Y * areaSize.Width,
                                (tmpPoint.X + 1) * areaSize.Width,
                                (tmpPoint.Y + 1) * areaSize.Height, color);
        }

        public bool drowArea(int startX, int startY, int endX, int endY, Color[][] color)
        {
            if (startX > endX || startY > endY ||
                endX > bitmap.Size.Width || endY > bitmap.Size.Height
                || color == null)
                return false;

            for (int row = startY; row < endY; ++row)
            {
                for (int column = startX; column < endX; ++column)
                {
                    bitmap.SetPixel(column, row, color[row - startY][column - startX]);
                }
            }

            return true;
        }

        public Bitmap returnBitmap()
        {
            return bitmap;
        }

        private Bitmap bitmap;
        private Size areaSize;
    }
}

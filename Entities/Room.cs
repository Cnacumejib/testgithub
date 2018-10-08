using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CalcMeToo.Room;

namespace CalcMeToo
{
    public class Room
    {
        int id;
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        int xPickUp = 0;
        int yPickUp = 0;

        Color color = Color.Red;
        List<Device> devices;

        public Room(int id)
        {
            this.id = id;
            x1 = 0;
            y1 = 0;
            x2 = 0;
            y2 = 0;
            color = Color.Blue;
            devices = new List<Device>();
        }

        public Room(int id, int xLeft, int yTop, int xRight, int yDown, Color color)
        {
            this.id = id;
            x1 = Math.Min(xLeft, xRight);
            y1 = Math.Min(yTop, yDown);
            x2 = Math.Max(xLeft, xRight);
            y2 = Math.Max(yTop, yDown);
            this.color = color;
            devices = new List<Device>();
        }
        
        public int Width
        {
            get
            {
                return Math.Abs(x1 - x2);
            }
        }

        public int Height
        {
            get
            {
                return Math.Abs(y1 - y2);
            }
        }

        public bool HasInside(int x, int y)
        {
            if (x >= x1 && x <= x2 && y >= y1 && y <= y2)
            {
                xPickUp = x - x1;
                yPickUp = y - y1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasInside(Point point)
        {            
            return HasInside(point.X, point.Y);
        }

        public IEnumerable<Point> GetVertexes()
        {
            List<Point> list = new List<Point>();
            list.Add(new Point(x1, y1));
            list.Add(new Point(x2, y1));
            list.Add(new Point(x2, y2));
            list.Add(new Point(x1, y2));
            return (list as IEnumerable<Point>);
        }

        public void SetColor(Color newColor)
        {            
            this.color=newColor;
        }

        public void NormilizeXY()
        {
            int temp;
            if (x2 < x1)
            {
                temp = x1;
                x1 = x2;
                x2 = temp;
            }

            if (y2 < y1)
            {
                temp = y1;
                y1 = y2;
                y2 = temp;
            }
        }

        public void SetPosition1(int xLeft, int yTop)
        {
            /*xLeft -= xPickUp;
            yTop -= yPickUp;
            if (xLeft < 0) xLeft = 0;
            if (yTop < 0) yTop = 0;
            x2 = xLeft + x2 - x1;
            y2 = yTop + y2 - y1;*/
            x1 = xLeft;
            y1 = yTop;
        }

        public void SetPosition1(Point point)
        {
            x1 = point.X;
            y1 = point.Y;
        }

        public void SetPosition2(int xRight, int yDown)
        {
            /*
            if (xRight < x1)
            {
                x1 = xRight;
            }
            else
            {
                x2 = xRight;
            }

            if (yDown < y1)
            {
                y1 = yDown;
            }
            else
            {
                y2 = yDown;
            }*/

            x2 = xRight;
            y2 = yDown;

        }

        public void SetPosition2(Point point)
        {
            x2 = point.X;
            y2 = point.Y;
        }

        public Point GetPosition1()
        {
            return new Point(x1, y1);
        }

        public Point GetPosition2()
        {
            return new Point(x2, y2);
        }

        public void SetSize(int width, int height)
        {
            x2 = x1 + Math.Abs(width);
            y2 = y1 + Math.Abs(height);
        }

        public void DrawAt(ref Bitmap bitmap)
        {
            if(color==Color.Transparent)
            {
                return;
            }

            Graphics fig = Graphics.FromImage(bitmap);
            Pen pen = new Pen(color, 2);
            fig.DrawLine(pen, x1, y1, x2, y1);
            fig.DrawLine(pen, x2, y1, x2, y2);
            fig.DrawLine(pen, x2, y2, x1, y2);
            fig.DrawLine(pen, x1, y1, x1, y2);
            foreach (Device device in devices)
            {
                device.Draw(ref bitmap, x1, y1);
            }
        }

        public Bitmap DrawNew( Bitmap bitmap)
        {
            if (color == Color.Transparent)
            {
                return bitmap;
            }
            Graphics fig = Graphics.FromImage(bitmap);
            Pen pen = new Pen(color, 2);
            fig.DrawLine(pen, x1, y1, x2, y1);
            fig.DrawLine(pen, x2, y1, x2, y2);
            fig.DrawLine(pen, x2, y2, x1, y2);
            fig.DrawLine(pen, x1, y1, x1, y2);
            foreach (Device device in devices)
            {
                device.Draw(ref bitmap, x1, y1);
            }
            return bitmap;
        }
    }
}

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcMeToo
{
    class Device
    {
        int id;
        int lineId = -1;
        int X { get; set; }
        int Y { get; set; }
        string Type { get; set; }
        string Status { get; set; }

        public Device(int id, int x, int y)
        {
            this.id = id;
            X = x;
            Y = y;
            Type = "plug";
            Status = "nested";
        }

        public Device(int id, int x, int y, string type, string status)
        {
            this.id = id;
            X = x;
            Y = y;
            Type = type;
            Status = status;
        }

        public void SetPosition1(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public void SetLineId(int lineId)
        {
            this.lineId = lineId;
        }

        public void Draw(ref Bitmap bitmap, int parentX, int parentY)
        {
            Graphics fig = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Blue);

            fig.DrawEllipse(pen, X, Y, parentX + X + 5, parentY + Y + 5);
        }
}
}

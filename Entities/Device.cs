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
        int X { get; set; }
        int Y { get; set; }
        string Type { get; set; }
        string Status { get; set; }

        public Device(int x, int y)
        {
            X = x;
            Y = y;
            Type = "plug";
            Status = "nested";
        }
        public Device(int x, int y, string type, string status)
        {
            X = x;
            Y = y;
            Type = type;
            Status = status;
        }

        public void Draw(ref Bitmap bitmap, int parentX, int parentY)
        {
            Graphics fig = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Blue);

            fig.DrawEllipse(pen, X, Y, parentX + X + 5, parentY + Y + 5);
        }
}
}

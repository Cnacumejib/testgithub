using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entities
{
    class Shear
    {
        int x = 0;
        int y = 0;
        int quadrant = 1;
        int type = 0;

        public Shear()
        {
        }

        public bool IsInside()
        {
            return false;
        }

        public void Draw(ref Bitmap bitmap, Color parentColor)
        {
            if(parentColor==Color.Blue)
            {

            }
            else
            {

            }
        }

        public void SetSize(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetType(int type)
        {
            this.type = type;
        }

        public void SetQuadrant(int quadrant)
        {
            this.quadrant = ((quadrant-1) % 4)+1;
        }
    }
}

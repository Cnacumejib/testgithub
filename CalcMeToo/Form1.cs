using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace CalcMeToo
{
    public partial class Form1 : Form
    {
        private string action = "idle";
    //    private Point firstPoint;
        private Space space;
      //  private Room showRoom;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            space = new Space(MainDraw.Width, MainDraw.Height, 50);
        }

        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            if (btnNewRoom.ForeColor==Color.Black)
            {
                btnNewRoom.ForeColor = Color.Blue;
                action = "point_new_room";
                space.AddNewRoom();
            }
            else
            {
                btnNewRoom.ForeColor = Color.Black;
                action = "idle";
                space.CancelNewRoom();
            }
        }

        private void MainDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (action == "point_new_room" && space.MoveSelectedRoom(e.X, e.Y))
            {
                action = "resize_new_room";
            }

      /*      if (action == "point_selected_room" && space.MoveSelectedRoom(e.X, e.Y))
            {
                action = "idle";
                
            }
            */
        }

        private void MainDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (action == "resize_new_room" && space.SizeSelectedRoom(e.X, e.Y))
            {
                //Math.Min(firstPoint.x, e.x), Math.Min(firstPoint.Y, e.Y), Math.Abs(firstPoint.x - e.x), Math.Abs(firstPoint.Y - e.Y)
                space.SaveNewRoom();
                action = "idle";
                btnNewRoom.ForeColor = Color.Black;
                MainDraw.Image = space.GetBitmap();
            }
        }

        private void MainDraw_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X:{e.X.ToString()} Y:{e.Y.ToString()}";
            if (action=="idle")
            {
                return;
            }

                    
             if(action == "resize_new_room")
            {
                space.SizeSelectedRoom(e.X, e.Y);
            }

            if (e.Button == MouseButtons.Left && action == "point_new_room" && space.MoveSelectedRoom(e.X, e.Y))
            {
                action = "resize_new_room";
            }

            MainDraw.Image = space.GetBitmap();
        }

        private void MainDraw_MouseClick(object sender, MouseEventArgs e)
        {
            if(space.SelectRoomAtPosition(e.X,e.Y))
            {
                action = "edit_selected_room";
            }
        }
    }
}

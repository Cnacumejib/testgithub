using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcMeToo
{
    public class Space
    {
        int roomCounter = 0;
        int deviceCounter = 0;
        int lineCounter = 0;

        int GridStep { get; set; }

        int Scale { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Status { get; set; }

        List<Room> rooms = new List<Room>();
        Room selectedRoom;// = new Room(-1);
        Bitmap bitmap;

        public Space()
        {
            X = 0;
            Y = 0;
            Width = 1100;
            Height = 700;
            GridStep = 50;
            DrawBitmap();
        }

        public Space(int width, int height, int gridStep)
        {
            X = 0;
            Y = 0;
            Width = Math.Min(Math.Max(width, 500), 3000);
            Height = Math.Min(Math.Max(height, 400), 2100);
            GridStep = Math.Min(Math.Max(gridStep, 20), 500);
            DrawBitmap();
        }

        public Point NormilizeXY(int x, int y)
        {
            if (x < 0)
            {
                x = 0;
            }

            if (y < 0)
            {
                y = 0;
            }

            if (x >= Width)
            {
                x = Width-1;
            }

            if (y >= Height)
            {
                y = Height-1;
            }
            return new Point(x, y);
        }

        public void AddNewRoom()
        {
            roomCounter++;
            selectedRoom = new Room(roomCounter);
        }

        public bool SelectRoomAtPosition(int x, int y)
        {
            foreach (Room room in rooms)
            {
                if(room.HasInside(x,y))
                {
                    selectedRoom = room;
                    room.SetColor(Color.Brown); //Transparent
                    selectedRoom.SetColor(Color.Blue);
                    DrawBitmap();
                    return true;
                }
            }

            return false;
        }
        
        public void SaveNewRoom()
        {
            selectedRoom.SetColor(Color.Gray);
            rooms.Add(selectedRoom);
            selectedRoom = null;
            DrawBitmap();
        }

        public void CancelNewRoom()
        {
            selectedRoom = null;
        }

        public bool MoveSelectedRoom(int x, int y)
        {
            if (selectedRoom == null)
            {
                return false;
            }

            Point oldXY1 = selectedRoom.GetPosition1();
            selectedRoom.SetPosition1(x, y);
            if (SelectedRoomHasCrossing())
            {
                selectedRoom.SetPosition1(oldXY1);
                return false;
            }

            return true;
        }

        public bool SizeSelectedRoom(int x, int y)
        {
            if (selectedRoom == null)
            {
                return false;
            }

            Point oldXY2 = selectedRoom.GetPosition2();
            selectedRoom.SetPosition2(x, y);
            if (SelectedRoomHasCrossing())
            {
                selectedRoom.SetPosition2(oldXY2);
                return false;
            }

            return true;
        }

        public Bitmap GetBitmap()
        {
            if(selectedRoom==null)
            {
                return bitmap;
            }
          
        //  return selectedRoom.DrawNew(bitmap);
            return selectedRoom.DrawNew(bitmap.Clone() as Bitmap);
         /*   Rectangle dd = new Rectangle();
            dd.Contains()*/
        }

        public bool IsEmptyAt(int x, int y)
        {
            foreach (Room room in rooms)
            {
                if (room.HasInside(x, y))
                {
                    return false;
                }
            }

            return true;
        }

        public bool SelectedRoomHasCrossing()
        {
            foreach (Room room in rooms)
            {
                foreach (var vertex in selectedRoom.GetVertexes())
                {
                    if (room.HasInside(vertex.X, vertex.Y))
                    {
                        return true;
                    }
                }

                foreach (var vertex in room.GetVertexes())
                {
                    if (selectedRoom.HasInside(vertex.X, vertex.Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /*
        public bool HasCrossing(Room testRoom)
        {
            foreach (Room room in rooms)
            {
                foreach (var vertex in testRoom.GetVertexes())
                {
                    if (room.HasInside(vertex.X, vertex.Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        */

        private void DrawBitmap()
        {
            bitmap = new Bitmap(Width, Height);
            DrawGrid(ref bitmap);
            foreach (Room room in rooms)
            {
                room.DrawAt(ref bitmap);
            }
        }

        private void DrawGrid(ref Bitmap bitmap)
        {
            Graphics fig = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.LightGray);

            for (int x = 0; x < Width; x = x + GridStep)
            {
                fig.DrawLine(pen, x, 0, x, Height-1);
            }

            for (int y = 0; y < Height; y = y + GridStep)
            {
                fig.DrawLine(pen, 0, y, Width-1, y);
            }
        }
    }
}

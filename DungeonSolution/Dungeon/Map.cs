using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Cells { get; set; }
        public int CellWidth { get; set; }
        public int CellHeight { get; set; }
        public int CellsSpace { get; set; }
        public int RoomNumber { get; set; }
        public Texture2D CellTexture { get; set; }
        public Color NoRoomColor { get; set; }
        public Color RoomColor { get; set; }
        public List<Room> LstRooms { get; set; }

        public Map(int pHeight, int pWidth, int pRoomNumber)
        {
            Height = pHeight;
            Width = pWidth;
            CellWidth = 34;
            CellHeight = 13;
            CellsSpace = 5;
            Cells = new int[Height, Width];
            NoRoomColor = new Color(50, 50, 50);
            RoomColor = new Color(255, 255, 255);
            RoomNumber = pRoomNumber;

            for (int line = 0; line < Height; line++)
            {
                for (int column = 0; column < Width; column++)
                {
                    Cells[line, column] = 0;
                }
            }

            GenereDungeon();

            foreach (Room room in LstRooms)
            {
                Cells[room.Line, room.Column] = 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int line = 0; line < Height; line++)
            {
                for (int column = 0; column < Width; column++)
                {
                    Vector2 position;
                    int x;
                    int y;

                    x = column * CellWidth + column * CellsSpace;
                    y = line * CellHeight + line * CellsSpace;

                    position = new Vector2(x, y);

                    if (Cells[line, column] == 0)
                    {
                        spriteBatch.Draw(CellTexture, position, NoRoomColor);
                    }
                    else if (Cells[line, column] == 1)
                    {
                        spriteBatch.Draw(CellTexture, position, RoomColor);
                    }
                }
            }

        }

        public void GenereDungeon()
        {
            Random rnd = new Random();
            int line = rnd.Next(0, Height);
            int column = rnd.Next(0, Width);
            LstRooms = new List<Room>();

            LstRooms.Add(new Room(line, column));
            
        }
    }
}

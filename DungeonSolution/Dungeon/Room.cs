using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Room
    { 
        public int Line { get; set; }
        public int Column { get; set; }
        public bool IsOpen { get; set; }

        public Room(int pLine, int pColumn)
        {
            Line = pLine;
            Column = pColumn;
            IsOpen = false;
        }
    }
}

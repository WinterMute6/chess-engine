using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    class Board
    {
        private static string columns = "abcdefgh";
        public List<Cell> cells = new Cell[64].ToList();
        public Board()
        {
            for (int i = 0; i < 64; i++)
            {
                cells[i] = new Cell();
                cells[i].Number = i;
            }
        }
        public Cell GetCell(char column, int row)
        {
            var columnIndex = columns.IndexOf(column);
            var cellIndex = (row - 1) * 8 + columnIndex;
            return cells[cellIndex];
        }
    }
}


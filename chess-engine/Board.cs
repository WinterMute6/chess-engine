using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    public class Board
    {
        private static string columns = "abcdefgh";
        public Board()
        {
            for (int i = 0; i < 64; i++)
            {
                Cells[i] = new Cell(this);
                Cells[i].Number = i;
            }
        }
        public List<Cell> Cells { get; } = new Cell[64].ToList();
        public static int PositionToNumber(char column, int row)
        {
            return (row * 8) - 1 - (7 - ("abcdefgh".IndexOf(column))); 
        }
        public Cell Cell(char column, int row)
        {
            var columnIndex = columns.IndexOf(column);
            var cellIndex = (row - 1) * 8 + columnIndex;
            return Cells[cellIndex];
        }
        public List<Move> GetAvailableMoves(Piece piece)
        {
            return piece.GetAvailableMoves();
        }
        public void ResetBoard()
        {
            foreach (var col in "abcdefgh")
            {
                this.Cell(col, 2).Piece = new Pawn(Color.White);
                this.Cell(col, 7).Piece = new Pawn(Color.Black);
            }

            this.Cell('a', 1).Piece = new Rook(Color.White);
            this.Cell('h', 1).Piece = new Rook(Color.White);
            this.Cell('a', 8).Piece = new Rook(Color.Black);
            this.Cell('h', 8).Piece = new Rook(Color.Black);
            
            this.Cell('b', 1).Piece = new Knight(Color.White);
            this.Cell('g', 1).Piece = new Knight(Color.White);
            this.Cell('b', 8).Piece = new Knight(Color.Black);
            this.Cell('g', 8).Piece = new Knight(Color.Black);
            
            this.Cell('c', 1).Piece = new Bishop(Color.White);
            this.Cell('f', 1).Piece = new Bishop(Color.White);
            this.Cell('c', 8).Piece = new Bishop(Color.Black);
            this.Cell('f', 8).Piece = new Bishop(Color.Black);
            
            this.Cell('d', 1).Piece = new Queen(Color.White);
            this.Cell('d', 8).Piece = new Queen(Color.Black);

            this.Cell('e', 1).Piece = new King(Color.White);
            this.Cell('e', 8).Piece = new King(Color.Black);
        }
    }
}


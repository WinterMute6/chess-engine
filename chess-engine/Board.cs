using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    public class Board
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
        public List<Move> GetAvailableMoves(Piece piece)
        {
            var availableMoves = new List<Move>();
            if (piece.Color == Color.White)
            {
                switch (piece.Figure)
                {
                    case Figure.Pawn:
                        if (!piece.Cell.IsLeftEdge && this.cells[piece.Cell.Number + 7].Piece != null && this.cells[piece.Cell.Number + 7].Piece.Color == Color.Black)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 7 });

                        if (!piece.Cell.IsRightEdge && this.cells[piece.Cell.Number + 9].Piece != null && this.cells[piece.Cell.Number + 9].Piece.Color == Color.Black)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 9 });

                        if (this.cells[piece.Cell.Number + 8].Piece != null)
                            break;
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 8 });
                        if (this.cells[piece.Cell.Number + 16].Piece != null)
                            break;
                        if (piece.Cell.Number <= 15)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 16 });

                        break;
                }
            }
            else
            {
                switch (piece.Figure)
                {
                    case Figure.Pawn:
                        if (!piece.Cell.IsLeftEdge && this.cells[piece.Cell.Number - 9].Piece != null && this.cells[piece.Cell.Number - 9].Piece.Color == Color.White)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 9 });

                        if (!piece.Cell.IsRightEdge && this.cells[piece.Cell.Number - 7].Piece != null && this.cells[piece.Cell.Number - 7].Piece.Color == Color.White)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 7 });

                        if (this.cells[piece.Cell.Number - 8].Piece != null)
                            break;
                        availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 8 });
                        if (this.cells[piece.Cell.Number - 16].Piece != null)
                            break;
                        if (piece.Cell.Number >= 48)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 16 });
                        break;
                }
            }
            return availableMoves;
        }
        public void ResetBoard()
        {
            foreach (var col in "abcdefgh")
            {
                this.GetCell(col, 2).Piece = new Piece(Color.White, Figure.Pawn);
                this.GetCell(col, 7).Piece = new Piece(Color.Black, Figure.Pawn);
            }



            this.GetCell('a', 1).Piece = new Piece(Color.White, Figure.Rook);
            this.GetCell('h', 1).Piece = new Piece(Color.White, Figure.Rook);
            this.GetCell('a', 8).Piece = new Piece(Color.Black, Figure.Rook);
            this.GetCell('h', 8).Piece = new Piece(Color.Black, Figure.Rook);
            
            this.GetCell('b', 1).Piece = new Piece(Color.White, Figure.Knight);
            this.GetCell('g', 1).Piece = new Piece(Color.White, Figure.Knight);
            this.GetCell('b', 8).Piece = new Piece(Color.Black, Figure.Knight);
            this.GetCell('g', 8).Piece = new Piece(Color.Black, Figure.Knight);
            
            this.GetCell('c', 1).Piece = new Piece(Color.White, Figure.Bishop);
            this.GetCell('f', 1).Piece = new Piece(Color.White, Figure.Bishop);
            this.GetCell('c', 8).Piece = new Piece(Color.Black, Figure.Bishop);
            this.GetCell('f', 8).Piece = new Piece(Color.Black, Figure.Bishop);
            
            this.GetCell('d', 1).Piece = new Piece(Color.White, Figure.Queen);
            this.GetCell('d', 8).Piece = new Piece(Color.Black, Figure.Queen);
            this.GetCell('e', 1).Piece = new Piece(Color.White, Figure.King);
            this.GetCell('e', 8).Piece = new Piece(Color.Black, Figure.King);
        }
    }
}


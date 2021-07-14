using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    public class Board
    {
        private static string columns = "abcdefgh";
        public List<Cell> listOfCells = new Cell[64].ToList();
        public Board()
        {
            for (int i = 0; i < 64; i++)
            {
                listOfCells[i] = new Cell();
                listOfCells[i].Number = i;
            }
        }
        public Cell Cell(char column, int row)
        {
            var columnIndex = columns.IndexOf(column);
            var cellIndex = (row - 1) * 8 + columnIndex;
            return listOfCells[cellIndex];
        }
        public List<Move> GetAvailableMoves(Piece piece)
        {
            return piece.GetAvailableMoves(this);
            var availableMoves = new List<Move>();

            /*int moveUp1;
            int moveUp2;
            int moveUpLeft;
            int moveUpRight;
            bool white;
            
            if (piece.Color == Color.White)
            {
                white = true;
                moveUp1 = 1;
                moveUp2 = 2;
                moveUpLeft = 7;
                moveUpRight = 9;
            }
            else
            {
                white = false;
                moveUp1 = -1;
                moveUp2 = -2;
                moveUpLeft = -7;
                moveUpRight = -9;
            }

            var leftEdge = white ? piece.Cell.IsLeftEdge : piece.Cell.IsRightEdge;
            var rightEdge = white ? piece.Cell.IsRightEdge : piece.Cell.IsLeftEdge;

            switch(piece.Figure)
            {
                case Figure.Pawn:
                    if (!leftEdge && this.listOfCells[piece.Cell.Number + moveUpLeft].Piece != null && this.listOfCells[piece.Cell.Number + moveUpLeft].Piece.Color == Color.Black)
                        availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + moveUpLeft });

                    if (!rightEdge && this.listOfCells[piece.Cell.Number + moveUpRight].Piece != null && this.listOfCells[piece.Cell.Number + moveUpRight].Piece.Color == Color.Black)
                        availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + moveUpRight });

                    if (this.listOfCells[piece.Cell.Number + moveUp1].Piece != null)
                        break;

                    availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + moveUp1 });

                    if (this.listOfCells[piece.Cell.Number + moveUp2].Piece != null)
                        break;

                    if (piece.Cell.Number <= 15)
                        availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + moveUp2 });
                    break;
            }*/
            
            if (piece.Color == Color.White)
            {
                switch (piece.Figure)
                {
                    case Figure.Pawn:

                        if (!piece.Cell.IsLeftEdge && this.listOfCells[piece.Cell.Number + 7].Piece != null && this.listOfCells[piece.Cell.Number + 7].Piece.Color == Color.Black)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 7 });

                        if (!piece.Cell.IsRightEdge && this.listOfCells[piece.Cell.Number + 9].Piece != null && this.listOfCells[piece.Cell.Number + 9].Piece.Color == Color.Black)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 9 });

                        if (this.listOfCells[piece.Cell.Number + 8].Piece != null)
                            break;
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 8 });
                        if (this.listOfCells[piece.Cell.Number + 16].Piece != null)
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
                        if (!piece.Cell.IsLeftEdge && this.listOfCells[piece.Cell.Number - 9].Piece != null && this.listOfCells[piece.Cell.Number - 9].Piece.Color == Color.White)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 9 });

                        if (!piece.Cell.IsRightEdge && this.listOfCells[piece.Cell.Number - 7].Piece != null && this.listOfCells[piece.Cell.Number - 7].Piece.Color == Color.White)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 7 });

                        if (this.listOfCells[piece.Cell.Number - 8].Piece != null)
                            break;
                        availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 8 });
                        if (this.listOfCells[piece.Cell.Number - 16].Piece != null)
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
                this.Cell(col, 2).Piece = new Pawn(Color.White);
                this.Cell(col, 7).Piece = new Pawn(Color.Black);
            }

            this.Cell('a', 1).Piece = new Piece(Color.White, Figure.Rook);
            this.Cell('h', 1).Piece = new Piece(Color.White, Figure.Rook);
            this.Cell('a', 8).Piece = new Piece(Color.Black, Figure.Rook);
            this.Cell('h', 8).Piece = new Piece(Color.Black, Figure.Rook);
            
            this.Cell('b', 1).Piece = new Piece(Color.White, Figure.Knight);
            this.Cell('g', 1).Piece = new Piece(Color.White, Figure.Knight);
            this.Cell('b', 8).Piece = new Piece(Color.Black, Figure.Knight);
            this.Cell('g', 8).Piece = new Piece(Color.Black, Figure.Knight);
            
            this.Cell('c', 1).Piece = new Piece(Color.White, Figure.Bishop);
            this.Cell('f', 1).Piece = new Piece(Color.White, Figure.Bishop);
            this.Cell('c', 8).Piece = new Piece(Color.Black, Figure.Bishop);
            this.Cell('f', 8).Piece = new Piece(Color.Black, Figure.Bishop);
            
            this.Cell('d', 1).Piece = new Piece(Color.White, Figure.Queen);
            this.Cell('d', 8).Piece = new Piece(Color.Black, Figure.Queen);

            this.Cell('e', 1).Piece = new Piece(Color.White, Figure.King);
            this.Cell('e', 8).Piece = new Piece(Color.Black, Figure.King);
        }
    }
}


using System.Collections.Generic;

namespace chess_engine
{
    public class Pawn : Piece
    {
        public Pawn(Color color) : base(color, Figure.Pawn)
        {
        }

        override public List<Move> GetAvailableMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();

            if (this.Color == Color.White)
            {
                if (!this.Cell.IsLeftEdge && board.Cells[this.Cell.Number + 7].IsOccupied && board.Cells[this.Cell.Number + 7].Piece.Color == Color.Black)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 7 });

                if (!this.Cell.IsRightEdge && board.Cells[this.Cell.Number + 9].IsOccupied && board.Cells[this.Cell.Number + 9].Piece.Color == Color.Black)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 9 });

                if (board.Cells[this.Cell.Number + 8].IsEmpty)
                {

                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 8 });
                    if (board.Cells[this.Cell.Number + 16].IsEmpty)
                    {
                        if (this.Cell.Number <= 15)
                            availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 16 });
                    }
                }
                
            }
            else
            {
                if (!this.Cell.IsLeftEdge && board.Cells[this.Cell.Number - 9].IsOccupied && board.Cells[this.Cell.Number - 9].Piece.Color == Color.White)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 9 });

                if (!this.Cell.IsRightEdge && board.Cells[this.Cell.Number - 7].IsOccupied && board.Cells[this.Cell.Number - 7].Piece.Color == Color.White)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 7 });

                if (board.Cells[this.Cell.Number - 8].IsEmpty)
                {
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 8 });
                    if (board.Cells[this.Cell.Number - 16].IsEmpty)
                    {
                        if (this.Cell.Number >= 48)
                            availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 16 });
                    }
                }
            }
            return availableMoves;
        }
    }
        
}


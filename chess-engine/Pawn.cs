using System.Collections.Generic;

namespace chess_engine
{
    public class Pawn : Piece
    {
        public Pawn(Color color) : base(color, Figure.Pawn)
        {

        }
        public override bool IsFirstMove()
        {
            if (this.Color == Color.White)
                return (new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15 }).Contains(this.Cell.Number);
            else
                return (new List<int>() { 48, 49, 50, 51, 52, 53, 54, 55 }).Contains(this.Cell.Number);
        }
        override public List<Move> GetAvailableMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();
            
            if (!LeftEdge() && board.Cells[MoveUpLeft(1)].IsOccupied && IsOppositeColor(board.Cells[MoveUpLeft(1)].Piece.Color))
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpLeft(1) });
                
            if (!RightEdge() && board.Cells[MoveUpRight(1)].IsOccupied && IsOppositeColor(board.Cells[MoveUpRight(1)].Piece.Color))
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpRight(1) });

            if (board.Cells[MoveUp(1)].IsEmpty)
            {
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(1) });
                if (board.Cells[MoveUp(2)].IsEmpty)
                {
                    if (IsFirstMove())
                        availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(2) });
                }
            }
            return availableMoves;
        }
    }
        
}


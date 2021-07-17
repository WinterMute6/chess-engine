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
            var firstMove = new List<int>();
            
            int moveUp;
            int moveDown;
            int moveUpLeft;
            int moveUpRight;
            int moveDownLeft;
            int moveDownRight;
            
            if (this.Color == Color.White)
            {
                firstMove = new List<int>() {8,9,10,11,12,13,14,15};
                moveUp = 8;
                moveDown = -8;
                moveUpLeft = 7;
                moveUpRight = 9;
                moveDownLeft = -9;
                moveDownRight = -7;
            }
            else
            {
                firstMove = new List<int>() {48,49,50,51,52,53,54,55};
                moveUp = -8;
                moveDown = 8;
                moveUpLeft = -7;
                moveUpRight = -9;
                moveDownLeft = 9;
                moveDownRight = 7;
            }

            var leftEdge = this.Color == Color.White ? this.Cell.IsLeftEdge : this.Cell.IsRightEdge;
            var rightEdge = this.Color == Color.White ? this.Cell.IsRightEdge : this.Cell.IsLeftEdge;

            var board = this.Cell.Board;
            var availableMoves = new List<Move>();
            
            if (!leftEdge && board.Cells[this.Cell.Number + moveUpLeft].IsOccupied && IsOppositeColor(board.Cells[this.Cell.Number + moveUpLeft].Piece.Color))
                availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + moveUpLeft });

            if (!rightEdge && board.Cells[this.Cell.Number + moveUpRight].IsOccupied && IsOppositeColor(board.Cells[this.Cell.Number + moveUpRight].Piece.Color))
                availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + moveUpRight });

            if (board.Cells[this.Cell.Number + moveUp].IsEmpty)
            {
                availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + moveUp });
                if (board.Cells[this.Cell.Number + (moveUp * 2)].IsEmpty)
                {
                    if (firstMove.Contains(this.Cell.Number))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + (moveUp * 2) });
                }
            }
            return availableMoves;
        }
    }
        
}


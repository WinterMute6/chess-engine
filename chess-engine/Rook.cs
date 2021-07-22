using System;
using System.Collections.Generic;


namespace chess_engine
{
    public class Rook : Piece
    {
        public Rook(Color color) : base(color, Figure.Rook) { }

        public override bool IsFirstMove()
        {
            if (this.Color == Color.White)
                return (new List<int>() { 0, 7 }).Contains(this.Cell.Number);
            else
                return (new List<int>() { 56, 63 }).Contains(this.Cell.Number);
        }

        public override List<Move> GetAvailableMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();
            int offset = 0;
            // Check for moves in up direction 
            while (!IsTopEdge(MoveUp(offset)))
            {
                offset++;
                if (board.Cells[MoveUp(offset)].IsOccupied)
                {
                    if (IsOppositeColor(board.Cells[MoveUp(offset)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(offset) });
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(offset) });
            }
            // Check for moves in down direcion
            offset = 0;
            while (!IsBottomEdge(MoveDown(offset)))
            {
                offset++;
                if (board.Cells[MoveDown(offset)].IsOccupied)
                {
                    if (IsOppositeColor(board.Cells[MoveDown(offset)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDown(offset) });
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDown(offset) });
            }
            // Check for moves in right direction
            offset = 0;
            while (!IsRightEdge(MoveRight(offset)))
            {
                offset++;
                if (board.Cells[MoveRight(offset)].IsOccupied)
                {
                    if (IsOppositeColor(board.Cells[MoveRight(offset)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = MoveRight(offset) });
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveRight(offset) });
            }
            // Check for moves in left direction
            offset = 0;
            while (!IsLeftEdge(MoveLeft(offset)))
            {
                offset++;
                if (board.Cells[MoveLeft(offset)].IsOccupied)
                {
                    if (IsOppositeColor(board.Cells[MoveLeft(offset)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = MoveLeft(offset) });
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveLeft(offset) });
            }
            return availableMoves;
        }
    }
}


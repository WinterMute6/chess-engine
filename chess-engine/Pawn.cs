using System;
using System.Collections.Generic;

namespace chess_engine
{
    public class Pawn : Piece
    { 
        public Pawn(Color color) : base(color, Figure.Pawn){}
        public override bool IsFirstMove()
        {
            if (this.Color == Color.White)
                return (new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15 }).Contains(this.Cell.Number);
            else
                return (new List<int>() { 48, 49, 50, 51, 52, 53, 54, 55 }).Contains(this.Cell.Number);        }
        public override List<Move> GetAvailableMoves()
        {
            return GetPawnMoves();
        }
    }
}


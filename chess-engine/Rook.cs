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

        protected override List<Move> GetPieceAvailableMoves()
        {
            return base.GetRookMoves();
        }
    }
}


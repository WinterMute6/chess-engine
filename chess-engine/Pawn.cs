using System;
using System.Collections.Generic;

namespace chess_engine
{
    public class Pawn : Piece
    {
        protected override int GetPieceValue()
        {
            return PawnValue;
        }
        public Pawn(Color color) : base(color, Figure.Pawn){}
        public override bool IsFirstMove()
        {
            if (this.Color == Color.White)
                return this.Cell.Number > 7 && this.Cell.Number < 16;
            else
                return this.Cell.Number > 47 && this.Cell.Number < 56;
        }
        protected override IEnumerable<Move> GetPieceAvailableMoves()
        {
            return GetPawnMoves();
        }
    }
}


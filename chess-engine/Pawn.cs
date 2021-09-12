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
            /*            if (this.Color == Color.White)
                            return (new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15 }).Contains(this.Cell.Number);
                        else
                            return (new List<int>() { 48, 49, 50, 51, 52, 53, 54, 55 }).Contains(this.Cell.Number);        
            */
            if (this.Color == Color.White)
                return this.Cell.Number<=15 && this.Cell.Number >= 8;
            else
                return this.Cell.Number >= 48 && this.Cell.Number <= 55; 

        }
        protected override IEnumerable<Move> GetPieceAvailableMoves()
        {
            return GetPawnMoves();
        }
    }
}


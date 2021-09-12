using System.Collections.Generic;


namespace chess_engine
{
    public class Bishop : Piece
    {
        protected override int GetPieceValue()
        {
            return BishopValue;
        }
        public Bishop(Color color) : base(color, Figure.Bishop) { }

        protected override IEnumerable<Move> GetPieceAvailableMoves()
        {
            return GetBishopMoves();
        }
    }
}


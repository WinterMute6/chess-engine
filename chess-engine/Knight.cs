using System.Collections.Generic;


namespace chess_engine
{
    public class Knight : Piece
    {
        protected override int GetPieceValue()
        {
            return KnightValue;
        }
        public Knight(Color color) : base(color, Figure.Knight) { }

        protected override IEnumerable<Move> GetPieceAvailableMoves()
        {
            return GetKnightMoves();
            
        }
    }
}


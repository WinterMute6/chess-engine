using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    public class Queen : Piece
    {
        protected override int GetPieceValue()
        {
            return QueenValue;
        }
        public Queen(Color color) : base(color, Figure.Queen) { }

        protected override IEnumerable<Move> GetPieceAvailableMoves()
        {
            return GetRookMoves().Concat(GetBishopMoves());
        }
    }
}


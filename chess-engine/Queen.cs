using System.Collections.Generic;


namespace chess_engine
{
    public class Queen : Piece
    {
        public Queen(Color color) : base(color, Figure.Queen) { }

        protected override List<Move> GetPieceAvailableMoves()
        {

            var queenMoves = GetRookMoves();
            queenMoves.AddRange(GetBishopMoves());
            return queenMoves;
        }
    }
}


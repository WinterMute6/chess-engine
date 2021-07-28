using System.Collections.Generic;


namespace chess_engine
{
    public class Bishop : Piece
    {
        public Bishop(Color color) : base(color, Figure.Bishop) { }

        protected override List<Move> GetPieceAvailableMoves()
        {
            return GetBishopMoves();
        }
    }
}


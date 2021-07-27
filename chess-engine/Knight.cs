using System.Collections.Generic;


namespace chess_engine
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(color, Figure.Knight) { }

        public override List<Move> GetAvailableMoves()
        {
            return GetKnightMoves();
            
        }
    }
}


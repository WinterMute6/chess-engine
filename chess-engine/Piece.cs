using System.Collections.Generic;

namespace chess_engine
{
    class Piece
    {
        private Color _color;
        private Figure _figure;

        public Piece(Color color, Figure figure)
        {
            _color = color;
            _figure = figure;
        }

        public List<Move> AvailableMoves { get; set; }
    }
}


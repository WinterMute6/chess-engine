using System.Collections.Generic;

namespace chess_engine
{
    class Piece
    {
        private string Name
        {
            get
            {
            return $"{_color} {_figure}";
            }
        }
        private Color _color;
        private Figure _figure;
        public Cell Cell {get; set;}
        public Piece(Color color, Figure figure)
        {
            _color = color;
            _figure = figure;
        }

        public List<Move> AvailableMoves { get; set; }
    }
}


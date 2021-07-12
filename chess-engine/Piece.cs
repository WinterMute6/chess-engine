using System.Collections.Generic;

namespace chess_engine
{
    class Piece
    {
        public string Figure
        {
            get
            {
            return $"{_figure}";
            }
        }
        public string Color
        {
            get
            {
                return $"{_color}";
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


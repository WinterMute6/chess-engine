using System.Collections.Generic;

namespace chess_engine
{
    public class Piece
    {
        private Color _color;
        
        public Color Color
        {
            get
            {
                return _color;
            }
        }
        public Figure Figure { get; set; }
        public Cell Cell { get; set;}
        public Piece(Color color, Figure figure)
        {
            _color = color;
            Figure = figure;
        }
    }
}


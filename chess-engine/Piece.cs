using System;
using System.Collections.Generic;

namespace chess_engine
{
    public class Piece
    {
        private Color _color;
        public virtual bool IsFirstMove() => false;
        
        public bool RightEdge()
        {
            if (this.Color == Color.White)
                return this.Cell.IsRightEdge;
            else
                return this.Cell.IsLeftEdge;
        }
        public bool LeftEdge()
        {
            if (this.Color == Color.White)
                return this.Cell.IsLeftEdge;
            else
                return this.Cell.IsRightEdge;
        }
        public int MoveUp(int iterant)
        {
            return this.Cell.Number + (8 * iterant) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveUpLeft(int iterant)
        {
            return this.Cell.Number + (7 * iterant) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveUpRight(int iterant)
        {
            return this.Cell.Number + (9 * iterant) * (this.Color == Color.White ? 1 : -1);
        }
        public bool IsOppositeColor(Color color)
        {
            return color == this.Color ? false : true;
        }
        public Color Color
        {
            get{ return _color; }
        }
        public Figure Figure { get; set; }
        public Cell Cell { get; set;}
        public Piece(Color color, Figure figure)
        {
            _color = color;
            Figure = figure;
        }
        public virtual List<Move> GetAvailableMoves()
        {
            throw new Exception("Should not be called");
        }
    }
        
}


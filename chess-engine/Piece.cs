using System;
using System.Collections.Generic;

namespace chess_engine
{
    public class Piece
    {
        private Color _color;
        public List<int> PawnFirstMove()
        {
            if (this.Color == Color.White)
                return new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15 };
            else
                return new List<int>() { 48, 49, 50, 51, 52, 53, 54, 55 };
        }
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
            if (this.Color == Color.White)
                return this.Cell.Number + (8 * iterant);
            else
                return this.Cell.Number - (8 * iterant);
        }
        public int MoveUpLeft(int iterant)
        {
            if (this.Color == Color.White)
                return this.Cell.Number + (7 * iterant);
            else
                return this.Cell.Number - (7 * iterant);
        }
        public int MoveUpRight(int iterant)
        {
            if (this.Color == Color.White)
                return this.Cell.Number + (9 * iterant);
            else
                return this.Cell.Number - (9 * iterant);
        }
        public bool IsOppositeColor(Color color)
        {
            if (color == this.Color)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

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

        public virtual List<Move> GetAvailableMoves()
        {
            throw new Exception("Should not be called");
            //return new List<Move>();
        }
    }
        
}


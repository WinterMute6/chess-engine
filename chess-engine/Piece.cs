using System;
using System.Collections.Generic;

namespace chess_engine
{
    public class Piece
    {
        private Color _color;
        public virtual bool IsFirstMove() => false;
        public bool IsBottomEdge()
        {
            return this.Color == Color.White ? this.Cell.IsBottomEdge : this.Cell.IsTopEdge;
        }
        public bool IsBottomEdge(int cellNumber)
        {
            var topNum = new List<int>() { 56, 57, 58, 59, 60, 61, 62, 63 };
            var bottomNum = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            return (this.Color == Color.White ? bottomNum : topNum).Contains(cellNumber);
        }
        public bool IsTopEdge()
        {
            return this.Color == Color.White ? this.Cell.IsTopEdge : this.Cell.IsBottomEdge;
        }
        public bool IsTopEdge(int cellNumber)
        {
            var topNum = new List<int>() { 56, 57, 58, 59, 60, 61, 62, 63 };
            var bottomNum = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            return (this.Color == Color.White ? topNum : bottomNum).Contains(cellNumber);
        }
        public bool IsRightEdge()
        {
            return this.Color == Color.White ? this.Cell.IsRightEdge : this.Cell.IsLeftEdge;

        }
        public bool IsRightEdge(int cellNumber)
        {
            var leftNum = new List<int>() { 0, 8, 16, 24, 32, 40, 48, 56 };
            var rightNum = new List<int>() { 7, 15, 23, 31, 39, 47, 55, 63 };
            return (this.Color == Color.White ? rightNum : leftNum).Contains(cellNumber);
        }
        public bool IsLeftEdge()
        {
            return this.Color == Color.White ? this.Cell.IsLeftEdge : this.Cell.IsRightEdge;
        }
        public bool IsLeftEdge(int cellNumber)
        {
            var leftNum = new List<int>() { 0, 8, 16, 24, 32, 40, 48, 56 };
            var rightNum = new List<int>() { 7, 15, 23, 31, 39, 47, 55, 63 };
            return (this.Color == Color.White ? leftNum : rightNum).Contains(cellNumber);
        }
        public int MoveRight(int offset)
        {
            return this.Cell.Number + (1 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveLeft(int offset)
        {
            return this.Cell.Number + (1 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int MoveUp(int offset)
        {
            return this.Cell.Number + (8 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveDown(int offset)
        {
            return this.Cell.Number + (8 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int MoveUpLeft(int offset)
        {
            return this.Cell.Number + (7 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveUpRight(int offset)
        {
            return this.Cell.Number + (9 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveDownLeft(int offset)
        {
            return this.Cell.Number + (9 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int MoveDownRight(int iterant)
        {
            return this.Cell.Number + (7 * iterant) * (this.Color == Color.White ? -1 : 1);
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


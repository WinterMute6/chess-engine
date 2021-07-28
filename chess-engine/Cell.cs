using System.Collections.Generic;

namespace chess_engine
{
    /// <summary>
    /// Board Cell .
    /// </summary>
    public class Cell
    {
        public Cell(Board board)
        {
            this.board = board;
        }
        public Board Board { get { return board; } }
        public bool IsLeftEdge
        {
            get { return Number % 8 == 0; }
        }
        public bool IsRightEdge
        {
            get
            {
                return (Number + 1) % 8 == 0;
            }
        }
        public bool IsTopEdge
        {
            get
            {
                var topNum = new List<int>() { 56, 57, 58, 59, 60, 61, 62, 63 };
                return topNum.Contains(Number);
            }
        }
        public bool IsBottomEdge
        {
            get
            {
                var bottomNum = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
                return bottomNum.Contains(Number);
            }
        }
        public int Number { get; set; }
        private Piece _piece;
        private readonly Board board;

        public Piece Piece {
            get { return _piece; }
            set { value.Cell = this; _piece = value; }
        }
        public void RemovePiece()
        {
            _piece.Cell = null;
            _piece = null;
        }
        public bool IsEmpty
        {
            get
            {
                return Piece == null;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return Piece != null;
            }
        }
        public (char, int) Position
        {
            get
            {
                return ("abcdefgh"[this.Number % 8], this.Number / 8 + 1);
            }
        }
    }
}


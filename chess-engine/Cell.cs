using System.Collections.Generic;

namespace chess_engine
{
    /// <summary>
    /// Board Cell .
    /// </summary>
    public class Cell
    {

        private static int[][][] PawnMoves = new[] {
            new[] {  // white
                new[]{1 }, // 0
                new[]{1 }, // 1
                new[]{1 }, // 2
                new[]{1 }, // 3
                new[]{1 }, // 4
                new[]{1 }, // 5
                new[]{1 }, // 6
                new[]{1 }, // 7
                new[]{1 }, // 8
                new[]{1 }  // 9 - 63
            },
            new[] {  // black
                new[] {1 }, //0
                new[]{1 } // 1
            }
        };                     
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
                //var topNum = new List<int>() { 56, 57, 58, 59, 60, 61, 62, 63 };
                //return topNum.Contains(Number);
                return Number >= 56;
            }
        }
        public bool IsBottomEdge
        {
            get
            {
                //var bottomNum = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
                //return bottomNum.Contains(Number);
                return Number <= 7;
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


using System;
using System.Collections.Generic;

namespace chess_engine
{
    public class Piece
    {

        private Color _color;
        public virtual bool IsFirstMove() => false;

        public Piece(Color color, Figure figure)
        {
            _color = color;
            Figure = figure;
        }
        public List<Move> GetKnightMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();

            // this.Cell.Number modifications to be put in separate functions

            while (!(IsLeftEdge(MoveUpLeft(0)) || IsTopEdge(MoveUpLeft(0))))
            {
                if (!IsLeftEdge(MoveUpLeft(1)))
                {
                    if (board.Cells[DoubleLeftUp(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleLeftUp(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleLeftUp(1) });
                }
                if (!IsTopEdge(MoveUpLeft(1)))
                {
                    if (board.Cells[DoubleUpLeft(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleUpLeft(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleUpLeft(1) });
                }
                break;
            }
            while (!(IsTopEdge(MoveUpRight(0)) || IsRightEdge(MoveUpRight(0))))
            {
                if (!IsRightEdge(MoveUpRight(1)))
                {
                    if (board.Cells[DoubleRightUp(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleRightUp(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleRightUp(1) });
                }
                if (!IsTopEdge(MoveUpRight(1)))
                {
                    if (board.Cells[DoubleUpRight(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleUpRight(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleUpRight(1) });
                }
                break;
            }
            while (!(IsRightEdge(MoveDownRight(0)) || IsBottomEdge(MoveDownRight(0))))
            {
                if (!IsBottomEdge(MoveDownRight(1)))
                {
                    if (board.Cells[DoubleDownRight(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleDownRight(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleDownRight(1) });
                }
                if (!IsRightEdge(MoveDownRight(1)))
                {
                    if (board.Cells[DoubleRightDown(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleRightDown(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleRightDown(1) });
                }
                break;
            }
            while (!(IsBottomEdge(MoveDownLeft(0)) || IsLeftEdge(MoveDownLeft(0))))
            {
                if (!IsLeftEdge(MoveDownLeft(1)))
                {
                    if (board.Cells[DoubleLeftDown(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleLeftDown(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleLeftDown(1) });
                }
                if (!IsBottomEdge(MoveDownLeft(1)))
                {
                    if (board.Cells[DoubleDownLeft(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleDownLeft(1)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = DoubleDownLeft(1) });
                }
                break;
            }
            return availableMoves;
        }
        internal List<Move> GetBishopMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();
            var offset = 0;
            /*
            bool Condition(int direction, int _offset)
            {
                switch(direction)
                {
                    case 1:
                        return !(IsLeftEdge(MoveUpLeft(_offset)) || IsTopEdge(MoveUpLeft(_offset)));
                    case 2:
                        return !(IsTopEdge(MoveUpRight(_offset)) || IsRightEdge(MoveUpRight(_offset)));
                    case 3:
                        return !(IsRightEdge(MoveDownRight(_offset)) || IsBottomEdge(MoveDownRight(_offset)));
                    case 4:
                        return !(IsBottomEdge(MoveDownLeft(_offset)) || IsLeftEdge(MoveDownLeft(_offset)));
                    default:
                        return false;
                }
            }
            int CellLocation(int direction, int _offset)
            {
                switch(direction)
                {
                    case 1:
                        return MoveUpLeft(_offset);
                    case 2:
                        return MoveUpRight(_offset);
                    case 3:
                        return MoveDownRight(_offset);
                    case 4:
                        return MoveDownLeft(_offset);
                    default:
                        return 0;
                }
            }
            for (int i = 1; i < 5; i++)
            {
                int offset = 0;
                while (Condition(i, offset))
                {
                    offset++;
                    if (board.Cells[CellLocation(i, offset)].IsEmpty || IsOppositeColor(board.Cells[CellLocation(i, offset)].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = CellLocation(i, offset)});
                    if (board.Cells[CellLocation(i, offset)].IsOccupied) break;
                }
            }
            */

            while (!(IsLeftEdge(MoveUpLeft(offset)) || IsTopEdge(MoveUpLeft(offset))))
            {
                offset++;
                if (board.Cells[MoveUpLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpLeft(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpLeft(offset) });
                if (board.Cells[MoveUpLeft(offset)].IsOccupied) break;
            }
            offset = 0;
            while (!(IsTopEdge(MoveUpRight(offset)) || IsRightEdge(MoveUpRight(offset))))
            {
                offset++;
                if (board.Cells[MoveUpRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpRight(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpRight(offset) });
                if (board.Cells[MoveUpRight(offset)].IsOccupied) break;
            }
            offset = 0;
            while (!(IsRightEdge(MoveDownRight(offset)) || IsBottomEdge(MoveDownRight(offset))))
            {
                offset++;
                if (board.Cells[MoveDownRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDownRight(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDownRight(offset) });
                if (board.Cells[MoveDownRight(offset)].IsOccupied) break;
            }
            offset = 0;
            while (!(IsBottomEdge(MoveDownLeft(offset)) || IsLeftEdge(MoveDownLeft(offset))))
            {
                offset++;
                if (board.Cells[MoveDownLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDownLeft(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDownLeft(offset) });
                if (board.Cells[MoveDownLeft(offset)].IsOccupied) break;
            }
            return availableMoves;
        }
        public List<Move> GetRookMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();
            int offset = 0;
            // Check for moves in up direction 
            while (!IsTopEdge(MoveUp(offset)))
            {
                offset++;
                if (board.Cells[MoveUp(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUp(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(offset) });
                if (board.Cells[MoveUp(offset)].IsOccupied) break;
            }
            // Check for moves in down direcion
            offset = 0;
            while (!IsBottomEdge(MoveDown(offset)))
            {
                offset++;
                if (board.Cells[MoveDown(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDown(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDown(offset) });
                if (board.Cells[MoveDown(offset)].IsOccupied) break;
            }
            // Check for moves in right direction
            offset = 0;
            while (!IsRightEdge(MoveRight(offset)))
            {
                offset++;
                if (board.Cells[MoveRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveRight(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveRight(offset) });
                if (board.Cells[MoveRight(offset)].IsOccupied) break;
            }
            // Check for moves in left direction
            offset = 0;
            while (!IsLeftEdge(MoveLeft(offset)))
            {
                offset++;
                if (board.Cells[MoveLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveLeft(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveLeft(offset) });
                if (board.Cells[MoveLeft(offset)].IsOccupied) break;
            }
            return availableMoves;
        }
        public int DoubleDownRight(int offset)
        {
            return this.Cell.Number + (15 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int DoubleDownLeft(int offset)
        {
            return this.Cell.Number + (17 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int DoubleLeftDown(int offset)
        {
            return this.Cell.Number + (10 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int DoubleLeftUp(int offset)
        {
            return this.Cell.Number + (6 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleUpLeft(int offset)
        {
            return this.Cell.Number + (15 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleUpRight(int offset)
        {
            return this.Cell.Number + (17 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleRightUp(int offset)
        {
            return this.Cell.Number + (10 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleRightDown(int offset)
        {
            return this.Cell.Number + (6 * offset) * (this.Color == Color.White ? -1 : 1);
        }
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
       
        public virtual List<Move> GetAvailableMoves()
        {
            throw new Exception("Should not be called");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    public class King : Piece
    {
        protected override int GetPieceValue()
        {
            return KingValue;
        }
        public King(Color color) : base(color, Figure.King) { }
        public bool IsUnderCheck()
        {
            var board = this.Cell.Board;

            return GetRookMoves().Any(x => board.Cells[x.To].Piece is Rook || board.Cells[x.To].Piece is Queen) ||
                GetBishopMoves().Any(x => board.Cells[x.To].Piece is Bishop || board.Cells[x.To].Piece is Queen) ||
                GetKnightMoves().Any(x => board.Cells[x.To].Piece is Knight) ||
                GetKingMoves().Any(x => board.Cells[x.To].Piece is King) ||
                IsPawnCheck();
        }

        private bool IsPawnCheck()
        {
            var board = this.Cell.Board;
            if (IsTopEdge())
                return false;
            if (IsRightEdge())
                return board.Cells[MoveUpLeft(1)].IsOccupied
                    && IsOppositeColor(board.Cells[MoveUpLeft(1)].Piece.Color)
                    && board.Cells[MoveUpLeft(1)].Piece is Pawn;
            if (IsLeftEdge())
                return board.Cells[MoveUpRight(1)].IsOccupied
                    && IsOppositeColor(board.Cells[MoveUpRight(1)].Piece.Color)
                    && board.Cells[MoveUpRight(1)].Piece is Pawn; 
            return  board.Cells[MoveUpLeft(1)].IsOccupied
                    && IsOppositeColor(board.Cells[MoveUpLeft(1)].Piece.Color)
                    && board.Cells[MoveUpLeft(1)].Piece is Pawn
                 ||
                     board.Cells[MoveUpRight(1)].IsOccupied
                     && IsOppositeColor(board.Cells[MoveUpRight(1)].Piece.Color)
                     && board.Cells[MoveUpRight(1)].Piece is Pawn; 
        }

        protected override IEnumerable<Move> GetPieceAvailableMoves()
        {
            return GetKingMoves();
        }
    }
}


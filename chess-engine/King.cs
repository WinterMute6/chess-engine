using System;
using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    public class King : Piece
    {
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
            return  !IsLeftEdge() 
                        && board.Cells[MoveUpLeft(1)].IsOccupied 
                        && IsOppositeColor(board.Cells[MoveUpLeft(1)].Piece.Color) 
                        && board.Cells[MoveUpLeft(1)].Piece is Pawn
                ||
                    !IsRightEdge() 
                        && board.Cells[MoveUpRight(1)].IsOccupied 
                        && IsOppositeColor(board.Cells[MoveUpRight(1)].Piece.Color) 
                        && board.Cells[MoveUpRight(1)].Piece is Pawn;
        }

        protected override List<Move> GetPieceAvailableMoves()
        {
            return GetKingMoves();
        }
    }
}


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
                GetKnightMoves().Any(x => board.Cells[x.To].Piece is Knight);
        }
        public override List<Move> GetAvailableMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();
            
            // Check for moves in up direction 
            while (!IsTopEdge(MoveUp(0)))
            {
                
                if (board.Cells[MoveUp(1)].IsEmpty || IsOppositeColor(board.Cells[MoveUp(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(1) });
                break;
            }
            // Check for moves in down direcion
            
            while (!IsBottomEdge(MoveDown(0)))
            {
                
                if (board.Cells[MoveDown(1)].IsEmpty || IsOppositeColor(board.Cells[MoveDown(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDown(1) });
                break;
            }
            // Check for moves in right direction
            
            while (!IsRightEdge(MoveRight(0)))
            {
                
                if (board.Cells[MoveRight(1)].IsEmpty || IsOppositeColor(board.Cells[MoveRight(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveRight(1) });
                break;
            }
            // Check for moves in left direction
            
            while (!IsLeftEdge(MoveLeft(0)))
            {
                
                if (board.Cells[MoveLeft(1)].IsEmpty || IsOppositeColor(board.Cells[MoveLeft(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveLeft(1) });
                break;
            }
            // Check For Moves in MoveUpLeft direction
            
            while (!(IsLeftEdge(MoveUpLeft(0)) || IsTopEdge(MoveUpLeft(0))))
            {
                
                if (board.Cells[MoveUpLeft(1)].IsEmpty || IsOppositeColor(board.Cells[MoveUpLeft(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpLeft(1) });
                break;
            }
            // Check for moves in the MoveUpRight direction
            
            while (!(IsTopEdge(MoveUpRight(0)) || IsRightEdge(MoveUpRight(0))))
            {
                
                if (board.Cells[MoveUpRight(1)].IsEmpty || IsOppositeColor(board.Cells[MoveUpRight(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpRight(1) });
                break;
            }
            // Check for moves in the MoveDownRight direction 
            
            while (!(IsRightEdge(MoveDownRight(0)) || IsBottomEdge(MoveDownRight(0))))
            {
                
                if (board.Cells[MoveDownRight(1)].IsEmpty || IsOppositeColor(board.Cells[MoveDownRight(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDownRight(1) });
                break;
            }
            // Check for moves in the MoveDownLeft direction
            
            while (!(IsBottomEdge(MoveDownLeft(0)) || IsLeftEdge(MoveDownLeft(0))))
            {
                
                if (board.Cells[MoveDownLeft(1)].IsEmpty || IsOppositeColor(board.Cells[MoveDownLeft(1)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDownLeft(1) });
                break;
            }
            return availableMoves;
        }
    }
}


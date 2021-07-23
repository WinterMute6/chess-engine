using System.Collections.Generic;


namespace chess_engine
{
    public class Queen : Piece
    {
        public Queen(Color color) : base(color, Figure.Queen) { }

        public override List<Move> GetAvailableMoves()
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
            // Check For Moves in MoveUpLeft direction
            offset = 0;
            while (!(IsLeftEdge(MoveUpLeft(offset)) || IsTopEdge(MoveUpLeft(offset))))
            {
                offset++;
                if (board.Cells[MoveUpLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpLeft(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpLeft(offset) });
                if (board.Cells[MoveUpLeft(offset)].IsOccupied) break;
            }
            // Check for moves in the MoveUpRight direction
            offset = 0;
            while (!(IsTopEdge(MoveUpRight(offset)) || IsRightEdge(MoveUpRight(offset))))
            {
                offset++;
                if (board.Cells[MoveUpRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpRight(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpRight(offset) });
                if (board.Cells[MoveUpRight(offset)].IsOccupied) break;
            }
            // Check for moves in the MoveDownRight direction 
            offset = 0;
            while (!(IsRightEdge(MoveDownRight(offset)) || IsBottomEdge(MoveDownRight(offset))))
            {
                offset++;
                if (board.Cells[MoveDownRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDownRight(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDownRight(offset) });
                if (board.Cells[MoveDownRight(offset)].IsOccupied) break;
            }
            // Check for moves in the MoveDownLeft direction
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
    }
}


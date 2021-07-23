using System.Collections.Generic;


namespace chess_engine
{
    public class Bishop : Piece
    {
        public Bishop(Color color) : base(color, Figure.Bishop) { }

        public override List<Move> GetAvailableMoves()
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
            
            while ( !(IsLeftEdge( MoveUpLeft(offset) ) || IsTopEdge( MoveUpLeft(offset) )) )
            {
                offset++;
                if (board.Cells[MoveUpLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpLeft(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpLeft(offset) });
                if (board.Cells[MoveUpLeft(offset)].IsOccupied) break;
            }
            offset = 0;
            while ( !(IsTopEdge(MoveUpRight(offset)) || IsRightEdge( MoveUpRight(offset) )) )
            {
                offset++;
                if (board.Cells[MoveUpRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpRight(offset)].Piece.Color))
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUpRight(offset) });
                if (board.Cells[MoveUpRight(offset)].IsOccupied) break;
            }
            offset = 0;
            while (! (IsRightEdge( MoveDownRight(offset) ) ||  IsBottomEdge( MoveDownRight(offset) )) )
            {
                offset++;
                if (board.Cells[MoveDownRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDownRight(offset)].Piece.Color))                
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDownRight(offset) });               
                if (board.Cells[MoveDownRight(offset)].IsOccupied) break;
            }
            offset = 0;
            while ( !(IsBottomEdge( MoveDownLeft(offset) ) || IsLeftEdge( MoveDownLeft(offset) )) )
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


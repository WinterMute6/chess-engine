using System.Collections.Generic;


namespace chess_engine
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(color, Figure.Knight) { }

        public override List<Move> GetAvailableMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();

            // this.Cell.Number modifications to be put in separate functions

            while (!(IsLeftEdge(MoveUpLeft(0)) || IsTopEdge(MoveUpLeft(0))))
            {
                if (!IsLeftEdge(MoveUpLeft(1)))
                {
                    if (board.Cells[this.Cell.Number + 6].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number + 6].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number + 6) });
                }
                if (!IsTopEdge(MoveUpLeft(1)))
                {
                    if (board.Cells[this.Cell.Number + 15].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number + 15].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number + 15) });
                }
                break;
            }
            while (!(IsTopEdge( MoveUpRight(0) ) || IsRightEdge( MoveUpRight(0) )))
            {
                if (!IsRightEdge(MoveUpRight(1)))
                {
                    if (board.Cells[this.Cell.Number + 10].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number + 10].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number + 10) });
                }
                if (!IsTopEdge(MoveUpRight(1)))
                {
                    if (board.Cells[this.Cell.Number + 17].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number + 17].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number + 17) });
                }
                break;
            }
            while (!(IsRightEdge( MoveDownRight(0) ) || IsBottomEdge( MoveDownRight(0) )))
            {
                if (!IsBottomEdge(MoveDownRight(1)))
                {
                    if (board.Cells[this.Cell.Number -15].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number - 15].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number - 15) });
                }
                if (!IsRightEdge(MoveDownRight(1)))
                {
                    if (board.Cells[this.Cell.Number - 6].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number -6].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number - 6) });
                }
                break;
            }
            while (!(IsBottomEdge( MoveDownLeft(0) ) || IsLeftEdge( MoveDownLeft(0) )))
            {
                if (!IsLeftEdge(MoveDownLeft(1)))
                {
                    if (board.Cells[this.Cell.Number - 10].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number - 10].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number - 10) });
                }
                if (!IsBottomEdge(MoveDownLeft(1)))
                {
                    if (board.Cells[this.Cell.Number - 17].IsEmpty || IsOppositeColor(board.Cells[this.Cell.Number - 17].Piece.Color))
                        availableMoves.Add(new Move { From = this.Cell.Number, To = (this.Cell.Number - 17) });
                }
                break;
            }
            return availableMoves;
        }
    }
}


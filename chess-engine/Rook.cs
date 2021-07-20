using System.Collections.Generic;


namespace chess_engine
{
    public class Rook : Piece
    {
        public Rook(Color color) : base(color, Figure.Rook) { }

        public override bool IsFirstMove()
        {
            if (this.Color == Color.White)
                return (new List<int>() { 0, 7 }).Contains(this.Cell.Number);
            else
                return (new List<int>() { 56, 63 }).Contains(this.Cell.Number);
        }

        public override List<Move> GetAvailableMoves()
        {
            var board = this.Cell.Board;
            var availableMoves = new List<Move>();

            for (int i = 1; i < 100; i++)
            {
                if (board.Cells[MoveUp(i)].IsOccupied && IsOppositeColor(board.Cells[MoveUp(i)].Piece.Color))
                {
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(i) });
                    break;
                }
                if (board.Cells[MoveUp(i)].IsOccupied)
                {
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveUp(i) });
            }
            for (int i = 1; i < 100; i++)
            {
                if (board.Cells[MoveDown(i)].IsOccupied && IsOppositeColor(board.Cells[MoveDown(i)].Piece.Color))
                {
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDown(i) });
                    break;
                }
                if (board.Cells[MoveDown(i)].IsOccupied)
                {
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveDown(i) });
            }
            for (int i = 1; i < 100; i++)
            {
                if (board.Cells[MoveRight(i)].IsOccupied && IsOppositeColor(board.Cells[MoveRight(i)].Piece.Color))
                {
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveRight(i) });
                    break;
                }
                if (board.Cells[MoveRight(i)].IsOccupied)
                {
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveRight(i) });
            }
            for (int i = 1; i < 100; i++)
            {
                if (board.Cells[MoveLeft(i)].IsOccupied && IsOppositeColor(board.Cells[MoveLeft(i)].Piece.Color))
                {
                    availableMoves.Add(new Move { From = this.Cell.Number, To = MoveLeft(i) });
                    break;
                }
                if (board.Cells[MoveLeft(i)].IsOccupied)
                {
                    break;
                }
                availableMoves.Add(new Move { From = this.Cell.Number, To = MoveLeft(i) });
            }

            return availableMoves;
        }
    }
}


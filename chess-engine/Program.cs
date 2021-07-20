using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace chess_engine
{
    public class Program
    {
        static void Main(string[] args)
        {

            var expectedMoves = new List<Move>() { new Move { From = 8, To = 16 } };
            Console.WriteLine($"{expectedMoves}");

            var board = new Board();

            var a8 = board.Cell('a', 8).Number;

            board.ResetBoard();

            var cell = board.Cell('h', 8);
            board.Cell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            var whiteMoves = board.GetAvailableMoves(board.Cells[8].Piece);
            var blackMoves = board.GetAvailableMoves(board.Cells[49].Piece);
        }
    }

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
                do
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
                while (board.Cells[MoveUp(i)].IsEmpty);
            }
            return availableMoves;
        }
    }

    public class Move
    {
        
        public int From { get; set; }
        public int To { get; set; }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Move) && ((Move)obj).From == this.From && ((Move)obj).To == this.To;
        }
        public override int GetHashCode()
        {
            return To*100+From;
        }
    }
}


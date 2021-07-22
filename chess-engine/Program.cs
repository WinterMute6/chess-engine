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

    public  class Queen : Piece
    {
        public Que
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


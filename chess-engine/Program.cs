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
            
            
            var board = new Board();

            var a8 = board.Cell('a', 8).Number;

            board.ResetBoard();

            var cell = board.Cell('h', 8);
            board.Cell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            var whiteMoves = board.GetAvailableMoves(board.listOfCells[8].Piece);
            var blackMoves = board.GetAvailableMoves(board.listOfCells[49].Piece);
        }
    }



    public class Move
    {
        
        public int From { get; set; }
        public int To { get; set; }
        
    }
}


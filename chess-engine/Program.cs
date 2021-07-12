using System;
using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var board = new Board();
            SetupBoard(board);
            var cell = board.GetCell('h', 8);


        }

       /* public static void GetAvailableMoves(Board board)
        {
            foreach (Cell cell in board)
            {
                switch()
                {


                    break;
                }
            }
        }*/

        public static void SetupBoard(Board board)
        {
            foreach (var col in "abcdefgh")
            {
                board.GetCell(col, 2).Piece = new Piece(Color.White, Figure.Pawn);
                board.GetCell(col, 7).Piece = new Piece(Color.Black, Figure.Pawn);
            }

            board.GetCell('a', 1).Piece = new Piece(Color.White, Figure.Rook);
            board.GetCell('h', 1).Piece = new Piece(Color.White, Figure.Rook);
            board.GetCell('a', 8).Piece = new Piece(Color.Black, Figure.Rook);
            board.GetCell('h', 8).Piece = new Piece(Color.Black, Figure.Rook);

            board.GetCell('b', 1).Piece = new Piece(Color.White, Figure.Knight);
            board.GetCell('g', 1).Piece = new Piece(Color.White, Figure.Knight);
            board.GetCell('b', 8).Piece = new Piece(Color.Black, Figure.Knight);
            board.GetCell('g', 8).Piece = new Piece(Color.Black, Figure.Knight);

            board.GetCell('c', 1).Piece = new Piece(Color.White, Figure.Bishop);
            board.GetCell('f', 1).Piece = new Piece(Color.White, Figure.Bishop);
            board.GetCell('c', 8).Piece = new Piece(Color.Black, Figure.Bishop);
            board.GetCell('f', 8).Piece = new Piece(Color.Black, Figure.Bishop);

            board.GetCell('d', 1).Piece = new Piece(Color.White, Figure.Queen);
            board.GetCell('d', 8).Piece = new Piece(Color.Black, Figure.Queen);
            board.GetCell('e', 1).Piece = new Piece(Color.White, Figure.King);
            board.GetCell('e', 8).Piece = new Piece(Color.Black, Figure.King);
        }


    }



    class Move
    {
        public Cell From { get; set; }
        public Cell To { get; set; }
    }
}


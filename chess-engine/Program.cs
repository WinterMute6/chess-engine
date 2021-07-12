using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            board.GetCell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            var whiteMoves = GetAvailableMoves(board.cells[8].Piece, board);
            var blackMoves = GetAvailableMoves(board.cells[49].Piece, board);

        }

        public static List<Move> GetAvailableMoves(Piece piece, Board board)
        {
            var availableMoves = new List<Move>();
            if (piece.Color == Color.White)
            {
                switch (piece.Figure)
                {
                    case Figure.Pawn:
                        if (piece.Cell.Number % 8 != 0 && board.cells[piece.Cell.Number + 7].Piece != null && board.cells[piece.Cell.Number + 7].Piece.Color == Color.Black)
                            availableMoves.Add(new Move {From = piece.Cell.Number, To = piece.Cell.Number + 7 });

                        if (piece.Cell.Number+1 % 8 != 0 && board.cells[piece.Cell.Number + 9].Piece != null && board.cells[piece.Cell.Number + 9].Piece.Color == Color.Black)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 9 });

                        if (board.cells[piece.Cell.Number + 8].Piece != null)
                            break;
                        availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 8 });
                        if (board.cells[piece.Cell.Number + 16].Piece != null)
                            break;
                        if (piece.Cell.Number <= 15)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number + 16 });
                        
                        break;
                }
            }
            else
            {
                switch (piece.Figure)
                {
                    case Figure.Pawn:
                        if (piece.Cell.Number % 8 != 0 && board.cells[piece.Cell.Number - 7].Piece != null && board.cells[piece.Cell.Number - 7].Piece.Color == Color.White)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 7 });

                        if (piece.Cell.Number - 1 % 8 != 0 && board.cells[piece.Cell.Number - 9].Piece != null && board.cells[piece.Cell.Number - 9].Piece.Color == Color.White)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 9 });

                        if (board.cells[piece.Cell.Number - 8].Piece != null)
                            break;
                        availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 8});
                        if (board.cells[piece.Cell.Number - 16].Piece != null)
                            break;
                        if (piece.Cell.Number >= 48)
                            availableMoves.Add(new Move { From = piece.Cell.Number, To = piece.Cell.Number - 16});
                        break;
                }
            }
            return availableMoves;

        }

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
        
        public int From { get; set; }
        public int To { get; set; }
        
    }
}


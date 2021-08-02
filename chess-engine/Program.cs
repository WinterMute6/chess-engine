using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace chess_engine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var allNodes = new List<Node>();
            var board = new Board();
            board.PuzzleTwo();
            Node root = new Node();
            root.Level = 0;
            root.Board = board;
            BuildBranches(root, 3);
        }
        public static void BuildBranches(Node parent, int maxLevel)
        {
            if (parent.Level > maxLevel)
                return;
            var moves = AllMoves(parent.Board);
            if (moves.Count() == 0)
            {
                if ((parent.Board.Cells.Where(x => x.Piece is King && x.Piece.Color == parent.Board.Turn) as King).IsUnderCheck())
                {
                    parent.Score = parent.Board.Turn == Color.White? 1 : -1;
                    Console.WriteLine("CheckMate");
                    return;
                }
                var winner = parent.Board.Turn == Color.White ? Color.Black : Color.White;
                Console.WriteLine("StaleMate, No winner.");
                return;
            }
            foreach(Move move in moves)
            {
                var childNode = new Node(parent);
                childNode.Move = move;
                var rollbackData = parent.Board.ApplyMove(move);
                BuildBranches(childNode, maxLevel);
                childNode.Board.RollbackMove(rollbackData);
            }
            parent.Score = parent.Board.Turn == Color.White ? parent.Children.Max(x => x.Score) : parent.Children.Min(x => x.Score);
        }
        public static List<Move> AllMoves(Board board, Color? color = null)
        {
            return board.Cells.Where(x => x.Piece != null && x.Piece.Color == color.GetValueOrDefault(board.Turn))
                .SelectMany(x => x.Piece.GetAvailableMoves()).ToList();
        }
        public class Node
        {
            public int Score { get; set; } = 0;
          /*public int Score
            {
                get
                {
                    if (Board.Cells[Move.To].Piece != null)
                    {
                        if (Board.Cells[Move.To].Piece is Pawn)
                            return 1;
                        if (Board.Cells[Move.To].Piece is Knight)
                            return 3;
                        if (Board.Cells[Move.To].Piece is Bishop)
                            return 3;
                        if (Board.Cells[Move.To].Piece is Rook)
                            return 5;
                        if (Board.Cells[Move.To].Piece is Queen)
                            return 9;
                        return 0;
                    }
                    else
                        return 0;
                }
            }*/
            public static long Counter = 0;
            public Node()
            {

            }
            public Node(Node parent)
            {
                parent.Children.Add(this);
                Level = parent.Level + 1;
                Board = parent.Board;
                Counter++;
                if(Counter % 100000 == 0)
                    Console.WriteLine( DateTime.Now +" : " + Counter);
            }
            public List<Node> Children { get; set; } = new List<Node>();
            public int Level { get; set; }
            public Board Board { get; set; }
            public Move Move { get; set; }
        }
    }
    public class Move 
    {
        public int From { get; set; }
        public int To { get; set; }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Move) && ((Move)obj).From == From && ((Move)obj).To == To;
        }
        public override int GetHashCode()
        {
            return To*100+From;
        }
    }
}


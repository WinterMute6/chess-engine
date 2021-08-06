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
            var board = new Board();
            board.PuzzleTwo();
            var pathway = new List<Node>();
            Node root = new Node();

            root.Level = 1;
            root.Board = board;
            
            BuildBranches(root, 4);
           

        }
        public static void BuildBranches(Node parent, int maxLevel)
        {
            if (parent.Level > maxLevel)
                return;
            
            var moves = AllMoves(parent.Board);
             
            if (moves.Count() == 0)
            {
                var king = parent.Board.Cells.SingleOrDefault(x => x.Piece != null && x.Piece is King && x.Piece.Color == parent.Board.Turn)?.Piece as King;
                if (king.IsUnderCheck())
                {
                    parent.Score = parent.Board.Turn == Color.White ? -1 : 1;
                    var winner = parent.Board.Turn == Color.White ? Color.Black : Color.White;
                    Console.WriteLine($"CheckMate, {winner} is the winner");
                    return;
                }
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
            public int Score { get; set; }
           
            public static long Counter = 0;
            public Node() 
            {   
                //Score = GetScore();
            }

            public Node(Node parent)
            {
                parent.Children.Add(this);
                Level = parent.Level + 1;
                Board = parent.Board;
                Counter++;
                if(Counter % 500 == 0)
                    Console.WriteLine( DateTime.Now +" : " + Counter);
            }
            private int GetScore()
            {
                if (Board.Cells[Move.To].Piece != null)
                    return (Board.Turn == Color.White ? 1 : -1) * (Board.Cells[Move.To].Piece.GetValue() - Board.Cells[Move.From].Piece.GetValue());
                return 0;
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
            return To * 100 + From;
        }
        public static bool operator == (Move a, Move b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Move a, Move b)
        {
            return !a.Equals(b);
        }
    }
}


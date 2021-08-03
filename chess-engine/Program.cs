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
            board.PuzzleThree();
            
            Node root = new Node();

            root.Level = 0;
            root.Board = board;
            
            BuildBranches(root, 4);

            var firstWhiteMove = root.Children.Single(x => x.Move == new Move { From = board.Cell('c', 5).Number, To = board.Cell('a', 6).Number });
            var firstBlackMove = firstWhiteMove.Children.Single(x => x.Move == new Move { From = board.Cell('b', 8).Number, To = board.Cell('b', 7).Number });
            var secondWhitekMove = firstBlackMove.Children.Single(x => x.Move == new Move { From = board.Cell('b', 5).Number, To = board.Cell('d', 7).Number });
            var secondBlackMove = secondWhitekMove.Children.Single(x => x.Move == new Move { From = board.Cell('b', 7).Number, To = board.Cell('a', 6).Number });
            var thirdWhiteMove = secondBlackMove.Children.Single(x => x.Move == new Move { From = board.Cell('b', 4).Number, To = board.Cell('b', 5).Number });
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
                    parent.Score = parent.Board.Turn == Color.Black? 1 : -1;
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
                if(childNode.Score != 0)
                {
                    var childScore = childNode.Score;
                }
                childNode.Board.RollbackMove(rollbackData);
            }
            
            var minScore = parent.Children.Min(x => x.Score);
            var maxScore = parent.Children.Max(x => x.Score);

            if (minScore != 0 || maxScore != 0)
            {
                Console.WriteLine($"not zero, Level: {parent.Level}");
            }

                parent.Score = parent.Board.Turn == Color.Black ? parent.Children.Min(x => x.Score) : parent.Children.Max(x => x.Score);
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


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
            board.WhiteMateInTwo5();
            var pathway = new List<Node>();
            Node root = new Node();
            root.Level = 1;
            root.Board = board;
            BuildBranches(root, 4);
            char fromColumn;
            int fromRow;
            char toColumn;
            int toRow;
            var currentLevel = root;
            while (true)
            {
                currentLevel = GetNextMove(currentLevel);
                Console.WriteLine($"My move is {board.Cells[currentLevel.Move.From].Piece} from {board.Cells[currentLevel.Move.From].Position}  to {board.Cells[currentLevel.Move.To].Position}.");
                board.PlayMove(currentLevel.Move);
                var king = currentLevel.Board.Cells.SingleOrDefault(x => x.Piece != null && x.Piece is King && x.Piece.Color == currentLevel.Board.Turn)?.Piece as King;
                if (king.IsUnderCheck())
                {
                    if (currentLevel.Children.Count() == 0)
                    {
                        var winner = currentLevel.Board.Turn == Color.White ? Color.Black : Color.White;
                        Console.WriteLine($"Check mate, {winner} is the winner!");
                        break;
                    }
                    Console.WriteLine("Check");
                }
                while (true)
                {
                    while (true)
                    {
                        Console.WriteLine("Please enter the piece Column location you wish to move from:");
                        var column = Console.ReadLine();
                        char col;

                        if (Char.TryParse(column, out col))
                        {
                            var charList = new List<Char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                            if (charList.Contains(col))
                            {
                                fromColumn = col;
                                break;
                            }
                            Console.WriteLine("Column is not within the bounds of the chess board.");
                            continue;
                        }
                        Console.WriteLine("Invalid Column specifiaction type, must be a letter.");
                    }
                    while (true)
                    {
                        Console.WriteLine("Please enter the piece Row location you wish to move from:");
                        var row = Console.ReadLine();
                        int number;
                        if (Int32.TryParse(row, out number))
                        {
                            if (number <= 8 && number >= 1)
                            {
                                fromRow = number;
                                break;
                            }
                            Console.WriteLine("Row is not within the bounds of the chess board.");
                            continue;
                        }
                        Console.WriteLine("Invalid Row specification type, must be a number.");
                    }
                    if (currentLevel.Board.Cells[Board.PositionToNumber(fromColumn, fromRow)].Piece == null)
                    {
                        Console.WriteLine("There is no chess piece in that location, pick another location.");
                        continue; 
                    }
                    while (true)
                    {
                        Console.WriteLine("Please enter the piece Column location you wish to move to:");
                        var column = Console.ReadLine();
                        char col;

                        if (Char.TryParse(column, out col))
                        {
                            var charList = new List<Char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                            if (charList.Contains(col))
                            {
                                toColumn = col;
                                break;
                            }
                            Console.WriteLine("Column is not within the bounds of the chess board.");
                            continue;
                        }
                        Console.WriteLine("Invalid Column specifiaction type, must be a letter.");
                    }
                    while (true)
                    {
                        Console.WriteLine("Please enter the piece Row location you wish to move to:");
                        var row = Console.ReadLine();
                        int number;
                        if (Int32.TryParse(row, out number))
                        {
                            if (number <= 8 && number >= 1)
                            {
                                toRow = number;
                                break;
                            }
                            Console.WriteLine("Row is not within the bounds of the chess board.");
                            continue;
                        }
                        Console.WriteLine("Invalid Row specification type, must be a number.");
                    }
                    if (currentLevel.Children.Where(x => x.Move.From == Board.PositionToNumber(fromColumn, fromRow) 
                        && x.Move.To == Board.PositionToNumber(toColumn, toRow)).SingleOrDefault() == null 
                        && king.IsUnderCheck())
                    { Console.WriteLine("Illegal Move, your king is still under check. Pick another move."); continue; }
                    currentLevel = currentLevel.Children.Where(x => x.Move.From == Board.PositionToNumber(fromColumn, fromRow) && x.Move.To == Board.PositionToNumber(toColumn, toRow)).SingleOrDefault();
                    break;
                }
                
                if (currentLevel.Children == null)
                {
                    king = currentLevel.Board.Cells.SingleOrDefault(x => x.Piece != null && x.Piece is King && x.Piece.Color != currentLevel.Board.Turn)?.Piece as King;
                    if (king.IsUnderCheck())
                    {
                        var winner = currentLevel.Board.Turn;
                        Console.WriteLine($"CheckMate, {winner} is the winner!");
                        break;
                    }
                    Console.WriteLine("Stalemate, no winner");
                    break;
                }
                currentLevel.Board.PlayMove(currentLevel.Move);
            }
            Node GetNextMove(Node node)
            {
                return Random(node.Children.Where(x => x.Score == (board.Turn == Color.White ? node.Children.Max(y => y.Score) : node.Children.Min(y => y.Score))).ToList());
            }
            Node Random(List<Node> nodeList)
            {
                var random = new System.Random();
                int index = random.Next(nodeList.Count);
                return nodeList[index];
            }
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
                using (parent.Board.With(move))
                {
                    BuildBranches(childNode, maxLevel);
                }
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
            return (obj is Move) && ((Move)obj).From == From && ((Move)obj).To == To;
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


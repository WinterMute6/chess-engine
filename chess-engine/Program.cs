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
            board.IsPartialBoard = true;
            board.Cell('a', 2).Piece = new Pawn(Color.White);
            var moves = board.GetAvailableMoves(board.Cell('a', 2).Piece).ToArray();
            Console.WriteLine("end");

            /*var board = new Board();
            board.WhiteMateInTwo1();
            Node root = new Node();
            root.Level = 1;
            root.Board = board;
            var timeStart = DateTime.Now;
            BuildBranches(root, 4);
            var timeEnd = DateTime.Now;
            var lengthSeconds = new TimeSpan(timeEnd.Ticks - timeStart.Ticks).TotalSeconds;
            Console.WriteLine(lengthSeconds);
            var currentLevel = root;
            while (true)
            {
                currentLevel = GetNextMove(currentLevel);
                Console.WriteLine($"My move is {board.Cells[currentLevel.Move.From].Piece} from {board.Cells[currentLevel.Move.From].Position}  to {board.Cells[currentLevel.Move.To].Position}.");
                board.PlayMove(currentLevel.Move);
                if (GameOver(currentLevel))
                    break;
                var king = currentLevel.Board.Cells.SingleOrDefault(x => x.Piece != null && x.Piece is King && x.Piece.Color == currentLevel.Board.Turn)?.Piece as King;
                while (true)
                {
                    Console.WriteLine("Enter ther coordinates of your move, for example: b2d4");
                    var move = Console.ReadLine(); 
                    var columnList = new List<Char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                    var rowList = new List<Char> { '1', '2', '3', '4', '5', '6', '7', '8' };
                    if (!columnList.Contains(move[0]) || !columnList.Contains(move[2]))
                    { Console.WriteLine("A column is not within the bounds of the chess board."); continue; }
                            
                    if (!rowList.Contains(move[1]) || !rowList.Contains(move[3]))
                    { Console.WriteLine("A row is not within the bounds of the chess board."); continue; }

                    if (currentLevel.Board.Cells[Board.PositionToNumber(move[0], Convert.ToInt32(move[1].ToString()))].Piece == null)
                    { Console.WriteLine("There is no chess piece to move, pick another location."); continue; }

                    if (currentLevel.Children.Where(x => x.Move.From == Board.PositionToNumber(move[0], Convert.ToInt32(move[1].ToString()))
                    && x.Move.To == Board.PositionToNumber(move[2], Convert.ToInt32(move[3].ToString()))).SingleOrDefault() == null
                    || king.IsUnderCheck())
                    { Console.WriteLine("Illegal Move and/or your king is still under check. Pick another move."); continue; }

                    currentLevel = currentLevel.Children.Where(x => x.Move.From == Board.PositionToNumber(move[0], Convert.ToInt32(move[1].ToString())) && x.Move.To == Board.PositionToNumber(move[2], Convert.ToInt32(move[3].ToString()))).SingleOrDefault();
                    break;
                }
                currentLevel.Board.PlayMove(currentLevel.Move);
                if (GameOver(currentLevel))
                    break;
            }
            bool GameOver(Node _currentLevel)
            {
                var king = _currentLevel.Board.Cells.SingleOrDefault(x => x.Piece != null && x.Piece is King && x.Piece.Color == _currentLevel.Board.Turn)?.Piece as King;
                if (_currentLevel.Children.Count == 0)
                {
                    var winner = _currentLevel.Board.Turn == Color.White ? Color.Black : Color.White;
                    if (king.IsUnderCheck())
                    {
                        Console.WriteLine($"Gameover, {winner} won win checkmate.");
                        return true;
                    }
                    Console.WriteLine($"Stalemate, no winner.");
                    return true;
                }
                return false;
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
            }*/
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
                    //Console.WriteLine($"CheckMate, {winner} is the winner");
                    return;
                }
                //Console.WriteLine("StaleMate, No winner.");
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
                //if(Counter % 500 == 0)
                    //Console.WriteLine( DateTime.Now +" : " + Counter);
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


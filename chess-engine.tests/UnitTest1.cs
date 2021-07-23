using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
namespace chess_engine.tests
{
    [TestClass]
    public class BlackQueenMovesTests
    {
        /// <summary>
        /// Given a Black Queen on D4 
        /// And 8 black pawns on B2,B4,B6,D2,D6,F2,F4,F6
        /// Black queen on D4 has 8 available moves
        /// </summary>
        [TestMethod()]
        public void QueenFromD4To8Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3)}
            };
            board.Cell('d', 2).Piece = new Pawn(Color.Black);
            board.Cell('b', 2).Piece = new Pawn(Color.Black);
            board.Cell('b', 4).Piece = new Pawn(Color.Black);
            board.Cell('b', 6).Piece = new Pawn(Color.Black);
            board.Cell('d', 6).Piece = new Pawn(Color.Black);
            board.Cell('f', 6).Piece = new Pawn(Color.Black);
            board.Cell('f', 4).Piece = new Pawn(Color.Black);
            board.Cell('f', 2).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Queen(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given A Black queen on D4
        /// And 8 White pawns on B2,B4,B6,D2,D6,F2,F4,F6
        /// White queen on D4 has 16 available moves
        /// </summary>
        [TestMethod()]
        public void QueenFromD4To16Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3)},

                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6)},
            };
            board.Cell('d', 2).Piece = new Pawn(Color.White);
            board.Cell('b', 2).Piece = new Pawn(Color.White);
            board.Cell('b', 4).Piece = new Pawn(Color.White);
            board.Cell('b', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 6).Piece = new Pawn(Color.White);
            board.Cell('f', 6).Piece = new Pawn(Color.White);
            board.Cell('f', 4).Piece = new Pawn(Color.White);
            board.Cell('f', 2).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Queen(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given A black queen on D4 
        /// 4 white pawns on B2,B4,B6,D6
        /// 4 black pawns on C3,C4,C5,D5
        /// Black queen on D4 has 14 available moves
        /// </summary>
        [TestMethod()]
        public void QueenFromD4To14Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',1)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',7)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',1)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',8)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3)}
            };
            board.Cell('c', 3).Piece = new Pawn(Color.Black);
            board.Cell('c', 4).Piece = new Pawn(Color.Black);
            board.Cell('c', 5).Piece = new Pawn(Color.Black);
            board.Cell('d', 5).Piece = new Pawn(Color.Black);
            board.Cell('b', 2).Piece = new Pawn(Color.White);
            board.Cell('b', 4).Piece = new Pawn(Color.White);
            board.Cell('b', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Queen(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black queen on D4
        /// 4 black pawns on E3,E4,E5,D3
        /// 4 white pawns on F2,F4,F6,D2
        /// Black queen on D4 has 13 available moves
        /// </summary>
        [TestMethod()]
        public void QueenFromD4To13Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',7)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',8)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',7)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',1)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',4)}
            };
            board.Cell('e', 3).Piece = new Pawn(Color.Black);
            board.Cell('e', 4).Piece = new Pawn(Color.Black);
            board.Cell('e', 5).Piece = new Pawn(Color.Black);
            board.Cell('d', 3).Piece = new Pawn(Color.Black);
            board.Cell('f', 2).Piece = new Pawn(Color.White);
            board.Cell('f', 4).Piece = new Pawn(Color.White);
            board.Cell('f', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 2).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Queen(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }
    [TestClass]
    public class WhiteQueenMoveTests
    {
        /// <summary>
        /// Given a White Queen on D4 
        /// And 8 white pawns on B2,B4,B6,D2,D6,F2,F4,F6
        /// White queen on D4 has 8 available moves
        /// </summary>
        [TestMethod()]
        public void QueenFromD4To8Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3)}
            };
            board.Cell('d', 2).Piece = new Pawn(Color.White);
            board.Cell('b', 2).Piece = new Pawn(Color.White);
            board.Cell('b', 4).Piece = new Pawn(Color.White);
            board.Cell('b', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 6).Piece = new Pawn(Color.White);
            board.Cell('f', 6).Piece = new Pawn(Color.White);
            board.Cell('f', 4).Piece = new Pawn(Color.White);
            board.Cell('f', 2).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Queen(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given A white queen on D4
        /// And 8 black pawns on B2,B4,B6,D2,D6,F2,F4,F6
        /// White queen on D4 has 16 available moves
        /// </summary>
        [TestMethod()]
        public void QueenFromD4To16Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3)},

                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6)},
            };
            board.Cell('d', 2).Piece = new Pawn(Color.Black);
            board.Cell('b', 2).Piece = new Pawn(Color.Black);
            board.Cell('b', 4).Piece = new Pawn(Color.Black);
            board.Cell('b', 6).Piece = new Pawn(Color.Black);
            board.Cell('d', 6).Piece = new Pawn(Color.Black);
            board.Cell('f', 6).Piece = new Pawn(Color.Black);
            board.Cell('f', 4).Piece = new Pawn(Color.Black);
            board.Cell('f', 2).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Queen(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        [TestMethod()]
        public void QueenFromD4To14Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',1)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',7)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',1)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',8)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3)}
            };
            board.Cell('c', 3).Piece = new Pawn(Color.White);
            board.Cell('c', 4).Piece = new Pawn(Color.White);
            board.Cell('c', 5).Piece = new Pawn(Color.White);
            board.Cell('d', 5).Piece = new Pawn(Color.White);
            board.Cell('b', 2).Piece = new Pawn(Color.Black);
            board.Cell('b', 4).Piece = new Pawn(Color.Black);
            board.Cell('b', 6).Piece = new Pawn(Color.Black);
            board.Cell('d', 6).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Queen(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        [TestMethod()]
        public void QueenFromD4To()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',7)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('d',8)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',7)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',4)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',1)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',4)}
            };
            board.Cell('e', 3).Piece = new Pawn(Color.White);
            board.Cell('e', 4).Piece = new Pawn(Color.White);
            board.Cell('e', 5).Piece = new Pawn(Color.White);
            board.Cell('d', 3).Piece = new Pawn(Color.White);
            board.Cell('f', 2).Piece = new Pawn(Color.Black);
            board.Cell('f', 4).Piece = new Pawn(Color.Black);
            board.Cell('f', 6).Piece = new Pawn(Color.Black);
            board.Cell('d', 2).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Queen(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }


    [TestClass]
    public class BlackBishopMovesTests
    {
        /// <summary>
        /// Given a black bishop on D4 
        /// A black pawn on F2 
        /// A white pawn on F6 
        /// Black bishop on D4 has 9 available Moves
        /// </summary>
        [TestMethod()]
        public void BlackBishopFromD4To9Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',7) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',1) }
            };
            board.Cell('f', 6).Piece = new Pawn(Color.White);
            board.Cell('f', 2).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Bishop(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black bishop on D4
        /// A black pawn on B2
        /// A white pawn on F2
        /// Black bishop on D4 has 10 available moves 
        /// </summary>
        [TestMethod()]
        public void BlackBishopFromD4To10Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',7) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',7) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',8) }
            };
            board.Cell('b', 2).Piece = new Pawn(Color.Black);
            board.Cell('f', 2).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Bishop(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
        /// <summary>
        /// Given a black bishop on D4 
        /// A white pawn on B2 
        /// A black pawn on B6 
        /// Black bishop on D4 has 10 available moves 
        /// </summary>
        [TestMethod()]
        public void BlackBishopFromD4To10Available2()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',1) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',7) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',8) }
            };
            board.Cell('b', 2).Piece = new Pawn(Color.White);
            board.Cell('b', 6).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Bishop(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black bishop on D4 
        /// A white pawn on B6 
        /// A black pawn on F6 
        /// Black bishop on D4 has 9 available moves 
        /// </summary>
        [TestMethod()]
        public void BlackBishopFromD4To9Available2()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',1) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',1) }
            };
            board.Cell('f', 6).Piece = new Pawn(Color.Black);
            board.Cell('b', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Bishop(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }

    [TestClass]
    public class WhiteBishopMovesTests
    {
        /// <summary>
        /// Given a white bishop on D4
        /// A black pawn on B2
        /// A white pawn on F2
        /// White Bishop on D4 has 10 available moves
        /// </summary>
        [TestMethod()]
        public void WhiteBishopFromD4To10Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',7) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',8) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',7) }
            };
            board.Cell('b', 2).Piece = new Pawn(Color.Black);
            board.Cell('f', 2).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Bishop(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a white bishop on D4
        /// A white pawn on B2
        /// A black pawn on B6
        /// White bishop on D4 has 10 available moves
        /// </summary>
        [TestMethod()]
        public void WhiteBishopFromD4To10Available2()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',7) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('h',8) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',1) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6) }
            };
            board.Cell('b', 2).Piece = new Pawn(Color.White);
            board.Cell('b', 6).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Bishop(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a white bishop on D4
        /// A white pawn on B6
        /// A black pawn on F6
        /// White bishop on D4 has 9 available moves
        /// </summary>
        [TestMethod()]
        public void WhiteBishopFromD4To9Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',6) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',1) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('g',1) }
            };
            board.Cell('f', 6).Piece = new Pawn(Color.Black);
            board.Cell('b', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Bishop(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a White Bishop on D4
        /// A white pawn on F6
        /// A black pawn on F2
        /// White Bishop on D4 has 9 available moves
        /// </summary>
        [TestMethod()]
        public void WhiteBishopFromD4To9Available2()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',2) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',5) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',7) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('a',1) },
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',6) }
            };
            board.Cell('f', 2).Piece = new Pawn(Color.Black);
            board.Cell('f', 6).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Bishop(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

    }

    [TestClass]
    public class WhiteRookMovesTests
    {
        /// <summary>
        /// Given an empty board
        /// a white rook on D3
        /// a white pawn on G3
        /// and a black rook on D5
        /// White rook on D3 should have 7 available moves 
        /// </summary>
        [TestMethod()]
        public void WhiteRookFromD3To7Available()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('b',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('a',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',4) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',5) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('f',3) }
            };
            board.Cell('d', 3).Piece = new Rook(Color.White);
            board.Cell('d', 5).Piece = new Rook(Color.Black);
            board.Cell('g', 3).Piece = new Pawn(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 3).Piece);

            var extraMoves = actualMoves.Except(expectedMoves);
            var movesNotFound = expectedMoves.Except(actualMoves);

            expectedMoves.Except(actualMoves);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given an empty board 
        /// A white rook on D3 
        /// A white pawn on D1
        /// A white pawn on C3
        /// And a black rook on G3
        /// White rook on D3 should have 9 available moves
        /// </summary>
        [TestMethod()]
        public void WhiteRookFromD3To9Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',2) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',8) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',7) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',6) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',4) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',5) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('f',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('g',3) }
            };
            board.Cell('d', 1).Piece = new Pawn(Color.White);
            board.Cell('c', 3).Piece = new Pawn(Color.White);
            board.Cell('g', 3).Piece = new Rook(Color.Black);
            board.Cell('d', 3).Piece = new Rook(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 3).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given an empty board
        /// A White rook on D3
        /// A white pawn on D4
        /// A white pawn on B3
        /// And a black rook on D2
        /// White rook on D6 has 6 available moves
        /// </summary>
        [TestMethod()]
        public void WhiteRookFromD3To6Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('c',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',2) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('e',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('f',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('g',3) },
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('h',3) },
            };
            board.Cell('d', 3).Piece = new Rook(Color.White);
            board.Cell('d', 2).Piece = new Rook(Color.Black);
            board.Cell('b', 3).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Pawn(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 3).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        [TestMethod()]
        public void WhiteRookFromD3To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('c',3)},
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',4)},
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',2)},
                new Move {From = Board.PositionToNumber('d',3), To = Board.PositionToNumber('d',1)}
            };
            board.Cell('c', 3).Piece = new Rook(Color.Black);
            board.Cell('d', 5).Piece = new Pawn(Color.White);
            board.Cell('e', 3).Piece = new Pawn(Color.White);
            board.Cell('d', 3).Piece = new Rook(Color.White);


            var actualMoves = board.GetAvailableMoves(board.Cell('d', 3).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }

    [TestClass]
    public class WhitePawnMovesTests
    {
        /// <summary>
        /// Given a white pawn on E2
        /// And black pawn on E3
        /// Pawn on E2 should have no available moves
        /// </summary>
        [TestMethod()]
        public void WhitePawnFromE2()
        {
            //Arrange
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>();
            board.Cell('e', 3).Piece = new Piece(Color.Black, Figure.Pawn);

            //Act
            var actualMoves = board.GetAvailableMoves(board.Cell('e', 2).Piece);

            //Assert
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given A2 is on the left edge
        /// Given B2 is neither on the left or right edge
        /// Given H2 is on the right edge
        /// 
        /// A2 should be True for left edge and false for right edge
        /// B2 should be False either way
        /// H2 should be False for left edge and true for right edge
        /// </summary>
        [TestMethod()]
        public void WhitePawnFromH2()
        {
            //Arrange
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>();
            board.Cell('g', 3).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('h', 3).Piece = new Piece(Color.Black, Figure.Pawn);

            //Act
            var actualMoves = board.GetAvailableMoves(board.Cell('h', 2).Piece);

            //Assert
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given a black pawn on A7
        /// A white pawn on A6
        /// And a white pawn on B6
        /// The black pawn on A7 should have only one available move
        /// </summary>
        [TestMethod()]
        public void WhitePawnFromD2ToC3D3D4E3()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>() {
                new Move{From = 11, To = 18},
                new Move{From = 11, To = 19},
                new Move{From = 11, To = 27},
                new Move{From = 11, To = 20}
            };
            board.Cell('c', 3).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('e', 3).Piece = new Piece(Color.Black, Figure.Pawn);

            // Act
            var actualMoves = board.GetAvailableMoves(board.Cell('d', 2).Piece);

            // Assert
            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given a white pawn on A2
        /// A black piece on A4
        /// A white piece on B3
        /// The White pawn has 1 available move to A3
        /// </summary>
        [TestMethod()]
        public void WhitePawnFromA2ToA3()
        {
            // Arrange
            var board = new Board();
            var expectedMoves = new List<Move>() { new Move { From = 8, To = 16 } };
            board.ResetBoard();

            // Act
            board.Cell('a', 4).Piece = new Pawn(Color.Black);
            board.Cell('b', 3).Piece = new Pawn(Color.White);
            var actualMoves = board.GetAvailableMoves(board.Cell('a', 2).Piece);

            // Assert
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given a white pawn on F2
        /// A black pawn on E3
        /// A white pawn on F4
        /// And A White pawn on G3
        /// White pawn on F2 should have 2 available moves
        /// </summary>
        [TestMethod()]
        public void WhitePawnFromF2ToE3F3()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>() {
                new Move{From = 13,To = 20},
                new Move{From = 13,To = 21}
            };
            board.Cell('e', 3).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('f', 4).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('g', 3).Piece = new Piece(Color.White, Figure.Pawn);

            // Act
            var actualMoves = board.GetAvailableMoves(board.Cells[13].Piece);

            // Assert
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
        }

        /// <summary>
        /// Given that a white pawn is on B2
        /// And a black piece is on C3
        /// And a white pawn on B3 
        /// White pawn on B2 has one available move to C3
        /// </summary>
        [TestMethod()]
        public void WhitePawnFromB2ToC3()
        {
            // Arrange
            var board = new Board();
            var expectedMoves = new List<Move>() { new Move { From = 9, To = 18 } };
            board.ResetBoard();
            board.Cell('c', 3).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('b', 3).Piece = new Piece(Color.White, Figure.Pawn);

            // Act
            var actualMoves = board.GetAvailableMoves(board.Cell('b', 2).Piece);

            // Assert
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given a white pawn on A2
        /// A white pawn on A3
        /// A white pawn on B3
        /// And a black pawn on H2
        /// White pawn on A2 has no available moves
        /// </summary>
        [TestMethod()]
        public void WhitePawnFromA2()
        {
            var board = new Board();
            var expectedMoves = new List<Move>();
            board.ResetBoard();
            board.Cell('a', 3).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('b', 3).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('h', 2).Piece = new Piece(Color.Black, Figure.Pawn);
            var actualMoves = board.GetAvailableMoves(board.Cell('a', 2).Piece);
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        [TestMethod()]
        public void WhitePawnFromA3ToA4()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>()
            {
                new Move{From = Board.PositionToNumber('a',3), To = Board.PositionToNumber('a',4)}
            };
            board.Cell('a', 3).Piece = new Pawn(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('a', 3).Piece);
            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }
    [TestClass]

    public class BlackKnightMovesTests
    {
        /// <summary>
        /// Given A black knight on D4
        /// and eight white pawns on B5,C6,B3,C2,E6,F5,E2,F3
        /// white knight on D4 has eight available moves
        /// </summary>
        [TestMethod]
        public void BlackKnightFromD4To8Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',5)},
            };
            board.Cell('b', 3).Piece = new Pawn(Color.White);
            board.Cell('b', 5).Piece = new Pawn(Color.White);
            board.Cell('c', 2).Piece = new Pawn(Color.White);
            board.Cell('c', 6).Piece = new Pawn(Color.White);
            board.Cell('e', 2).Piece = new Pawn(Color.White);
            board.Cell('e', 6).Piece = new Pawn(Color.White);
            board.Cell('f', 5).Piece = new Pawn(Color.White);
            board.Cell('f', 3).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Knight(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black knight on D4 
        /// and eight black pawns on B5,C6,B3,C2,E6,F5,E2,F3
        /// White knight has zero available moves
        /// </summary>
        [TestMethod]
        public void BlackKnightFromD4To0Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>();
            board.Cell('b', 3).Piece = new Pawn(Color.Black);
            board.Cell('b', 5).Piece = new Pawn(Color.Black);
            board.Cell('c', 2).Piece = new Pawn(Color.Black);
            board.Cell('c', 6).Piece = new Pawn(Color.Black);
            board.Cell('e', 2).Piece = new Pawn(Color.Black);
            board.Cell('e', 6).Piece = new Pawn(Color.Black);
            board.Cell('f', 5).Piece = new Pawn(Color.Black);
            board.Cell('f', 3).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Knight(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black knight on G2
        /// and no other pieces on the board
        /// White knight on G2 has 4 available moves
        /// </summary>
        [TestMethod]
        public void BlackKnightFromG2To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('e',1)},
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('e',3)},
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('f',4)},
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('h',4)},
            };
            board.Cell('g', 2).Piece = new Knight(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('g', 2).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black knight on B2
        /// an empty board
        /// White knight on B2 has 4 available moves
        /// </summary>
        [TestMethod]
        public void BlackKnightFromB2To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('d',1)},
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('a',4)},
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('c',4)},
            };
            board.Cell('b', 2).Piece = new Knight(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('b', 2).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black knight on B7
        /// an empty board
        /// White knight on B7 has 4 available moves
        /// </summary>
        [TestMethod]
        public void BlackKnightFromB7To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('a',5)},
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('d',6)},
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('d',8)},
            };
            board.Cell('b', 7).Piece = new Knight(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('b', 7).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a Black knight on G7
        /// an empty board
        /// White knight on G7 has 4 available moves
        /// </summary>
        [TestMethod]
        public void BlackKnightFromG7To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('e',8)},
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('e',6)},
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('f',5)},
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('h',5)},
            };
            board.Cell('g', 7).Piece = new Knight(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('g', 7).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }
    [TestClass]
    public class WhiteKnightMovesTests
    {
        /// <summary>
        /// Given A white knight on D4
        /// and eight black pawns on B5,C6,B3,C2,E6,F5,E2,F3
        /// white knight on D4 has eight available moves
        /// </summary>
        [TestMethod]
        public void WhiteKnightFromD4To8Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',5)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('b',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('c',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',2)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('e',6)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',3)},
                new Move {From = Board.PositionToNumber('d',4), To = Board.PositionToNumber('f',5)},
            };
            board.Cell('b', 3).Piece = new Pawn(Color.Black);
            board.Cell('b', 5).Piece = new Pawn(Color.Black);
            board.Cell('c', 2).Piece = new Pawn(Color.Black);
            board.Cell('c', 6).Piece = new Pawn(Color.Black);
            board.Cell('e', 2).Piece = new Pawn(Color.Black);
            board.Cell('e', 6).Piece = new Pawn(Color.Black);
            board.Cell('f', 5).Piece = new Pawn(Color.Black);
            board.Cell('f', 3).Piece = new Pawn(Color.Black);
            board.Cell('d', 4).Piece = new Knight(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a white knight on D4 
        /// and eight white pawns on B5,C6,B3,C2,E6,F5,E2,F3
        /// White knight has zero available moves
        /// </summary>
        [TestMethod]
        public void WhiteKnightFromD4To0Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>();
            board.Cell('b', 3).Piece = new Pawn(Color.White);
            board.Cell('b', 5).Piece = new Pawn(Color.White);
            board.Cell('c', 2).Piece = new Pawn(Color.White);
            board.Cell('c', 6).Piece = new Pawn(Color.White);
            board.Cell('e', 2).Piece = new Pawn(Color.White);
            board.Cell('e', 6).Piece = new Pawn(Color.White);
            board.Cell('f', 5).Piece = new Pawn(Color.White);
            board.Cell('f', 3).Piece = new Pawn(Color.White);
            board.Cell('d', 4).Piece = new Knight(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('d', 4).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a white knight on G2
        /// and no other pieces on the board
        /// White knight on G2 has 4 available moves
        /// </summary>
        [TestMethod]
        public void WhiteKnightFromG2To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('e',1)},
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('e',3)},
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('f',4)},
                new Move {From = Board.PositionToNumber('g',2), To = Board.PositionToNumber('h',4)},
            };
            board.Cell('g', 2).Piece = new Knight(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('g', 2).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a white knight on B2
        /// an empty board
        /// White knight on B2 has 4 available moves
        /// </summary>
        [TestMethod]
        public void WhiteKnightFromB2To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('d',1)},
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('d',3)},
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('a',4)},
                new Move {From = Board.PositionToNumber('b', 2), To = Board.PositionToNumber('c',4)},
            };
            board.Cell('b', 2).Piece = new Knight(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('b', 2).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a white knight on B7
        /// an empty board
        /// White knight on B7 has 4 available moves
        /// </summary>
        [TestMethod]
        public void WhiteKnightFromB7To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('a',5)},
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('c',5)},
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('d',6)},
                new Move {From = Board.PositionToNumber('b', 7), To = Board.PositionToNumber('d',8)},
            };
            board.Cell('b', 7).Piece = new Knight(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('b', 7).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a white knight on G7
        /// an empty board
        /// White knight on G7 has 4 available moves
        /// </summary>
        [TestMethod]
        public void WhiteKnightFromG7To4Available()
        {
            var board = new Board();
            var expectedMoves = new List<Move>()
            {
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('e',8)},
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('e',6)},
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('f',5)},
                new Move {From = Board.PositionToNumber('g', 7), To = Board.PositionToNumber('h',5)},
            };
            board.Cell('g', 7).Piece = new Knight(Color.White);

            var actualMoves = board.GetAvailableMoves(board.Cell('g', 7).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }
    
    [TestClass]
    public class BlackPawnMovesTests
    {
        /// <summary>
        /// Given a black pawn on H7
        /// A white pawn on H5
        /// And a black pawn G6
        /// Black pawn on H7 should have 1 available move to H6
        /// </summary>
        [TestMethod()]
        public void BlackPawnFromH7ToH6()
        {
            //Arrange
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>()
            {
                new Move{From = 55, To = 47}
            };
            board.Cell('h', 5).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('g', 6).Piece = new Piece(Color.Black, Figure.Pawn);

            //Act
            var actualMoves = board.GetAvailableMoves(board.Cell('h', 7).Piece);

            //Assert
            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            //Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            //Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given a black pawn on G7
        /// A black pawn on G6
        /// And a white pawn on F6
        /// Black pawn on G7 should have 1 available move to F6
        /// </summary>
        [TestMethod()]
        public void BlackPawnFromG7ToF6()
        {
            //Arrange
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>()
            {
                new Move{From = 54, To = 45}
            };
            board.Cell('g', 6).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('f', 6).Piece = new Piece(Color.White, Figure.Pawn);

            //Act
            var actualMoves = board.GetAvailableMoves(board.Cell('g', 7).Piece);

            //Assert
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given a black pawn on E7
        /// A white pawn on F6 
        /// And a white pawn on D6
        /// Black pawn on E7 should have 4 available moves to F6,E5,E6, and D6
        /// </summary>
        [TestMethod()]
        public void BlackPawnFromE7toF6E5E6D6()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>()
            {
                new Move{From = 52, To = 45},
                new Move{From = 52, To = 44},
                new Move{From = 52, To = 36},
                new Move{From = 52, To = 43}
            };
            board.Cell('f', 6).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('d', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var actualMoves = board.GetAvailableMoves(board.Cell('e', 7).Piece);
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black pawn D7
        /// And a white pawn on D6
        /// Black pawn on D7 has no available moves
        /// </summary>
        [TestMethod()]
        public void BlackPawnFromD7()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>();
            board.Cell('d', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var actualMoves = board.GetAvailableMoves(board.Cell('d', 7).Piece);
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given a black pawn on C7
        /// a white pawn on D6
        /// a black pawn on C5
        /// and a black pawn on B6
        /// Black pawn on C7 has 2 available moves to D6 and C6
        /// </summary>
        [TestMethod()]
        public void BlackPawnFromC7ToD6C6()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>()
            {
                new Move{From = 50, To = 43},
                new Move{From = 50, To = 42}
            };
            board.Cell('d', 6).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('c', 5).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('b', 6).Piece = new Piece(Color.Black, Figure.Pawn);
            var actualMoves = board.GetAvailableMoves(board.Cell('c', 7).Piece);
            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a Black pawn on A7
        /// A black pawn on B6
        /// And a white pawn on A6
        /// black pawn on A7 has no available moves
        /// </summary>
        [TestMethod()]
        public void BlackPawnFromA7()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>();
            board.Cell('b', 6).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('a', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var actualMoves = board.GetAvailableMoves(board.Cell('a', 7).Piece);
            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        /// <summary>
        /// Given a black pawn on H7
        /// And a white pawn on A7
        /// Black pawn on H7 should have no available moves
        /// </summary>
        [TestMethod()]
        public void BlackPawnFromH7()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>();
            board.Cell('h', 6).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('g', 6).Piece = new Piece(Color.Black, Figure.Pawn);
            board.Cell('a', 7).Piece = new Piece(Color.White, Figure.Pawn);

            var actualMoves = board.GetAvailableMoves(board.Cell('h', 7).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }

        [TestMethod()]
        public void BlackPawnFromH6ToH5()
        {
            var board = new Board();
            board.ResetBoard();
            var expectedMoves = new List<Move>()
            {
                new Move{From = Board.PositionToNumber('h',6), To = Board.PositionToNumber('h',5)}
            };
            board.Cell('h', 6).Piece = new Pawn(Color.Black);

            var actualMoves = board.GetAvailableMoves(board.Cell('h', 6).Piece);

            Assert.AreEqual(0, actualMoves.Except(expectedMoves).Count());
            Assert.AreEqual(0, expectedMoves.Except(actualMoves).Count());
        }
    }
}

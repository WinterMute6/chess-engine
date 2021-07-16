using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
namespace chess_engine.tests
{
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
            actualMoves.Except(expectedMoves);
            expectedMoves.Except(actualMoves);
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


}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
namespace chess_engine.tests
{
    [TestClass]
    public class PawnMovesTests
    {
        /// <summary>
        /// Given a black pawn on A7
        /// A white pawn on H5
        /// And a white pawn on A6
        /// The black pawn has 0 available moves
        /// </summary>
        [TestMethod()]
        public void PawnOnOppositeEdgeTest()
        {
            //Arrange
            var board = new Board();
            board.ResetBoard();

            //Act
            board.Cell('h', 5).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('a', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var blackMoves = board.GetAvailableMoves(board.Cells[48].Piece);

            //Assert
            Assert.AreEqual(0, blackMoves.Count());
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
        public void EdgeTests()
        {
            //Arrange
            var board = new Board();

            //Act
            var a2 = board.Cell('a', 2);
            var b2 = board.Cell('b', 2);
            var h2 = board.Cell('h', 2);
            //Assert
            Assert.IsTrue(a2.IsLeftEdge);
            Assert.IsFalse(a2.IsRightEdge);

            Assert.IsFalse(b2.IsLeftEdge);
            Assert.IsFalse(b2.IsRightEdge);

            Assert.IsFalse(h2.IsLeftEdge);
            Assert.IsTrue(h2.IsRightEdge);
        }

        /// <summary>
        /// Given a black pawn on A7
        /// A white pawn on A6
        /// And a white pawn on B6
        /// The black pawn on A7 should have only one available move
        /// </summary>
        [TestMethod()]
        public void PawnFromA7ToB6()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();

            // Act
            //var cell = board.GetCell('h', 8);
            //board.GetCell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            board.Cell('b', 6).Piece = new Piece(Color.White, Figure.Pawn);
            board.Cell('a', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var blackMoves = board.GetAvailableMoves(board.Cell('a',7).Piece);


            // Assert
            Assert.AreEqual(1, blackMoves.Count());
        }

        /// <summary>
        /// Given a white pawn on A2
        /// A black piece on A4
        /// A white piece on B3
        /// The White pawn has 1 available move to A3
        /// </summary>
        [TestMethod()]
        public void PawnFromA2ToA3()
        {
            // Arrange
            var board = new Board();
            var expectedMoves = new List<Move>() { new Move { From = 8, To = 16 } };
            
            board.ResetBoard();

            // Act
            //var cell = board.GetCell('h', 8);
            //board.GetCell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            board.Cell('a', 4).Piece = new Pawn(Color.Black);
            board.Cell('b', 3).Piece = new Pawn(Color.White);
            var actualMoves = board.GetAvailableMoves(board.Cell('a',2).Piece);

            // Assert
            //Assert.AreEqual(1, actualMoves.Count());
            //Assert.AreSame(expectedMoves, actualMoves);

            //Assert.IsTrue(expectedMoves.All(x => actualMoves.Contains(x)));
            Assert.IsTrue(actualMoves.Except(expectedMoves).Count() == 0);
            Assert.IsTrue(expectedMoves.Except(actualMoves).Count() == 0);
        }

        /// <summary>
        /// Given the black pawn is on a7
        /// And a white pawn is on a6
        /// And no white pieces on b6
        /// Then the black pawn has no available moves
        /// </summary>
        [TestMethod()]
        public void BlackPawnMovesFromA7()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();

            // Act
            board.Cell('a', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var blackMoves = board.GetAvailableMoves(board.Cells[48].Piece);

            // Assert
            Assert.AreEqual(0, blackMoves.Count());

        }

        /// <summary>
        /// Given the white pawn is on a2
        /// And a black pawn is on a3
        /// And no black pieces on b3
        /// The white pawn has no available moves
        /// </summary>
        [TestMethod()]
        public void WhitePawnMovesFromA2()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();

            // Act
            //var cell = board.GetCell('h', 8);
            //board.GetCell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            board.Cell('a', 3).Piece = new Piece(Color.White, Figure.Pawn);
            var whiteMoves = board.GetAvailableMoves(board.Cells[8].Piece);
      
            // Assert
            Assert.AreEqual(0, whiteMoves.Count());
        }

        /// <summary>
        /// Given that a white pawn is on A3
        /// And a black piece is on a4
        /// And no black pieces on B3
        /// White pawn has 1 available move
        /// </summary>
        [TestMethod()]
        public void GetAvailable()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();



            // Act
            //var cell = board.Cell('h', 8);
            board.Cell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            var whiteMoves = board.GetAvailableMoves(board.Cell('a',2).Piece);
            //var blackMoves = board.GetAvailableMoves(board.listOfCells[49].Piece);



            // Assert
            Assert.AreEqual(1, whiteMoves.Count());
            //Assert.AreEqual(2, blackMoves.Count());
        }
    }
    
}

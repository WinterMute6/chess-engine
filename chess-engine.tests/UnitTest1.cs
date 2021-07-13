using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
namespace chess_engine.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void EdgeTests()
        {
            //Arrange
            var board = new Board();

            //Act
            var a2 = board.GetCell('a', 2);
            var b2 = board.GetCell('b', 2);
            var h2 = board.GetCell('h', 2);
            //Assert
            Assert.IsTrue(a2.IsLeftEdge);
            Assert.IsFalse(a2.IsRightEdge);

            Assert.IsFalse(b2.IsLeftEdge);
            Assert.IsFalse(b2.IsRightEdge);

            Assert.IsFalse(h2.IsLeftEdge);
            Assert.IsTrue(h2.IsRightEdge);
        }
        [TestMethod()]
        public void PawnFromA7ToB6()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();

            // Act
            //var cell = board.GetCell('h', 8);
            //board.GetCell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            board.GetCell('b', 6).Piece = new Piece(Color.White, Figure.Pawn);
            board.GetCell('a', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var blackMoves = board.GetAvailableMoves(board.GetCell('a',7).Piece);


            // Assert
            Assert.AreEqual(1, blackMoves.Count());
        }

        /// <summary>
        /// Given a white pawn on A2
        /// A black piece on A3
        /// A black piece on B3
        /// The White pawn has 1 available move
        /// </summary>

        [TestMethod()]
        public void PawnFromA2ToB3()
        {
            // Arrange
            var board = new Board();
            board.ResetBoard();

            // Act
            //var cell = board.GetCell('h', 8);
            //board.GetCell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            board.GetCell('a', 3).Piece = new Piece(Color.Black, Figure.Pawn);
            board.GetCell('b', 3).Piece = new Piece(Color.Black, Figure.Pawn);
            var whiteMoves = board.GetAvailableMoves(board.cells[8].Piece);

            // Assert
            Assert.AreEqual(1, whiteMoves.Count());
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
            board.GetCell('a', 6).Piece = new Piece(Color.White, Figure.Pawn);
            var blackMoves = board.GetAvailableMoves(board.cells[48].Piece);

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
            board.GetCell('a', 3).Piece = new Piece(Color.White, Figure.Pawn);
            var whiteMoves = board.GetAvailableMoves(board.cells[8].Piece);
      
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
            var cell = board.GetCell('h', 8);
            board.GetCell('a', 4).Piece = new Piece(Color.White, Figure.Rook);
            var whiteMoves = board.GetAvailableMoves(board.cells[8].Piece);
            var blackMoves = board.GetAvailableMoves(board.cells[49].Piece);



            // Assert
            Assert.AreEqual(1, whiteMoves.Count());
            Assert.AreEqual(2, blackMoves.Count());
        }
    }
    
}

using System;
using System.Collections.Generic;

namespace chess_engine
{
    public class Piece
    {
        private Color _color;
        
        public Color Color
        {
            get
            {
                return _color;
            }
        }
        public Figure Figure { get; set; }
        public Cell Cell { get; set;}
        public Piece(Color color, Figure figure)
        {
            _color = color;
            Figure = figure;
        }

        public virtual List<Move> GetAvailableMoves(Board board)
        {
            throw new Exception("Should not be called");
            //return new List<Move>();
        }
    }

    public class Pawn : Piece
    {
        public Pawn(Color color) : base(color, Figure.Pawn)
        {
        }

        override public List<Move> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Move>();

            if (this.Color == Color.White)
            {
                if (!this.Cell.IsLeftEdge && board.listOfCells[this.Cell.Number + 7].IsOccupied && board.listOfCells[this.Cell.Number + 7].Piece.Color == Color.Black)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 7 });

                if (!this.Cell.IsRightEdge && board.listOfCells[this.Cell.Number + 9].IsOccupied && board.listOfCells[this.Cell.Number + 9].Piece.Color == Color.Black)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 9 });

                if (board.listOfCells[this.Cell.Number + 8].IsEmpty)
                {

                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 8 });
                    if (board.listOfCells[this.Cell.Number + 16].IsEmpty)
                    {
                        if (this.Cell.Number <= 15)
                            availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number + 16 });
                    }
                }
                
            }
            else
            {
                if (!this.Cell.IsLeftEdge && board.listOfCells[this.Cell.Number - 9].IsOccupied && board.listOfCells[this.Cell.Number - 9].Piece.Color == Color.White)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 9 });

                if (!this.Cell.IsRightEdge && board.listOfCells[this.Cell.Number - 7].IsOccupied && board.listOfCells[this.Cell.Number - 7].Piece.Color == Color.White)
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 7 });

                if (board.listOfCells[this.Cell.Number - 8].IsEmpty)
                {
                    availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 8 });
                    if (board.listOfCells[this.Cell.Number - 16].IsEmpty)
                    {
                        if (this.Cell.Number >= 48)
                            availableMoves.Add(new Move { From = this.Cell.Number, To = this.Cell.Number - 16 });
                    }
                }
            }
            return availableMoves;
        }
    }
        
}


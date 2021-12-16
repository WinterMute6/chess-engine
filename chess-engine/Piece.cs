using System;
using System.Collections.Generic;
using System.Linq;

namespace chess_engine
{
    public abstract class Piece
    {
        public int PawnValue = 1;
        public int KnightValue = 3;
        public int BishopValue = 3;
        public int RookValue = 5;
        public int QueenValue = 9;
        public int KingValue = 15;

        private Color _color;
        public virtual bool IsFirstMove() => false;

        public Piece(Color color, Figure figure)
        {
            _color = color;
            Figure = figure;
        }
        public IEnumerable<Move> GetKingMoves()
        {
            var board = this.Cell.Board;
            //var availableMoves = new List<Move>();


            // Check for moves in up direction 
            if (!IsTopEdge(this.Cell.Number))
            {

                if (board.Cells[MoveUp(1)].IsEmpty || IsOppositeColor(board.Cells[MoveUp(1)].Piece.Color))
                    yield return new Move { From = this.Cell.Number, To = MoveUp(1) };
            }
            // Check for moves in down direcion

            if (!IsBottomEdge(this.Cell.Number))
            {

                if (board.Cells[MoveDown(1)].IsEmpty || IsOppositeColor(board.Cells[MoveDown(1)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveDown(1) });
            }
            // Check for moves in right direction

            if (!IsRightEdge(this.Cell.Number))
            {

                if (board.Cells[MoveRight(1)].IsEmpty || IsOppositeColor(board.Cells[MoveRight(1)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveRight(1) });
            }
            // Check for moves in left direction

            if (!IsLeftEdge(this.Cell.Number))
            {

                if (board.Cells[MoveLeft(1)].IsEmpty || IsOppositeColor(board.Cells[MoveLeft(1)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveLeft(1) });
                
            }
            // Check For Moves in MoveUpLeft direction

            if (!(IsLeftEdge(this.Cell.Number) || IsTopEdge(this.Cell.Number)))
            {

                if (board.Cells[MoveUpLeft(1)].IsEmpty || IsOppositeColor(board.Cells[MoveUpLeft(1)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveUpLeft(1) });
                
            }
            // Check for moves in the MoveUpRight direction

            if (!(IsTopEdge(this.Cell.Number) || IsRightEdge(this.Cell.Number)))
            {

                if (board.Cells[MoveUpRight(1)].IsEmpty || IsOppositeColor(board.Cells[MoveUpRight(1)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveUpRight(1) });
                
            }
            // Check for moves in the MoveDownRight direction 

            if (!(IsRightEdge(this.Cell.Number) || IsBottomEdge(this.Cell.Number)))
            {

                if (board.Cells[MoveDownRight(1)].IsEmpty || IsOppositeColor(board.Cells[MoveDownRight(1)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveDownRight(1) });
                
            }
            // Check for moves in the MoveDownLeft direction

            if (!(IsBottomEdge(this.Cell.Number) || IsLeftEdge(this.Cell.Number)))
            {

                if (board.Cells[MoveDownLeft(1)].IsEmpty || IsOppositeColor(board.Cells[MoveDownLeft(1)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveDownLeft(1) });
                
            }
            //var itemsToRemove = availableMoves.Where(x => board.Cells[x.To].Piece is King).ToList();

            
        }

       // public IEnumerable<Move> GetPawnMoves()

        public IEnumerable<Move> GetPawnMovesOld()
        {
            var board = this.Cell.Board;
            //var availableMoves = new List<Move>();
            if (IsTopEdge() || IsBottomEdge())
                yield break;

            if (!IsLeftEdge() && board.Cells[MoveUpLeft(1)].IsOccupied && IsOppositeColor(board.Cells[MoveUpLeft(1)].Piece.Color))
                yield return (new Move { From = this.Cell.Number, To = MoveUpLeft(1) });

            if (!IsRightEdge() && board.Cells[MoveUpRight(1)].IsOccupied && IsOppositeColor(board.Cells[MoveUpRight(1)].Piece.Color))
                yield return (new Move { From = this.Cell.Number, To = MoveUpRight(1) });

            if (board.Cells[MoveUp(1)].IsEmpty)
            {
                yield return (new Move { From = this.Cell.Number, To = MoveUp(1) });
                if (IsFirstMove() && board.Cells[MoveUp(2)].IsEmpty)
                {
                    yield return (new Move { From = this.Cell.Number, To = MoveUp(2) });
                }
            }
            
        }
        //public IEnumerable<Move> GetPawnMovesNew()

        public IEnumerable<Move> GetPawnMoves()
        {
            //List<Move> moves = new List<Move>();
            var board = Cell.Board;
            var currentPosition = Cell.Number;
            const int RegularMoves = 0;
            const int TakeMoves = 1;

            var regularMoves = Rules.PawnMoves[(int)Color][currentPosition][RegularMoves];
            var takeMoves = Rules.PawnMoves[(int)Color][currentPosition][TakeMoves];


            foreach (var potentialMove in regularMoves)
            {
                if (!board.Cells[potentialMove].IsEmpty)
                {
                    break;
                }
                yield return new Move { From = currentPosition, To = potentialMove };
                //moves.Add(new Move { From = currentPosition, To = position });
            }

            foreach (var potentialMove in takeMoves)
            {
                if(board.Cells[potentialMove].IsOccupied && board.Cells[potentialMove].Piece.IsOppositeColor(Color))
                {
                    yield return new Move { From = currentPosition, To = potentialMove };
                    //moves.Add(new Move { From = currentPosition, To = position });
                }
            }
            //return moves;
        }


        public IEnumerable<Move> GetKnightMoves()
        {
            var board = this.Cell.Board;
            //var availableMoves = new List<Move>();

            // this.Cell.Number modifications to be put in separate functions

            while (!(IsLeftEdge(MoveUpLeft(0)) || IsTopEdge(MoveUpLeft(0))))
            {
                if (!IsLeftEdge(MoveUpLeft(1)))
                {
                    if (board.Cells[DoubleLeftUp(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleLeftUp(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleLeftUp(1) });
                }
                if (!IsTopEdge(MoveUpLeft(1)))
                {
                    if (board.Cells[DoubleUpLeft(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleUpLeft(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleUpLeft(1) });
                }
                break;
            }
            while (!(IsTopEdge(MoveUpRight(0)) || IsRightEdge(MoveUpRight(0))))
            {
                if (!IsRightEdge(MoveUpRight(1)))
                {
                    if (board.Cells[DoubleRightUp(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleRightUp(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleRightUp(1) });
                }
                if (!IsTopEdge(MoveUpRight(1)))
                {
                    if (board.Cells[DoubleUpRight(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleUpRight(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleUpRight(1) });
                }
                break;
            }
            while (!(IsRightEdge(MoveDownRight(0)) || IsBottomEdge(MoveDownRight(0))))
            {
                if (!IsBottomEdge(MoveDownRight(1)))
                {
                    if (board.Cells[DoubleDownRight(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleDownRight(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleDownRight(1) });
                }
                if (!IsRightEdge(MoveDownRight(1)))
                {
                    if (board.Cells[DoubleRightDown(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleRightDown(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleRightDown(1) });
                }
                break;
            }
            while (!(IsBottomEdge(MoveDownLeft(0)) || IsLeftEdge(MoveDownLeft(0))))
            {
                if (!IsLeftEdge(MoveDownLeft(1)))
                {
                    if (board.Cells[DoubleLeftDown(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleLeftDown(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleLeftDown(1) });
                }
                if (!IsBottomEdge(MoveDownLeft(1)))
                {
                    if (board.Cells[DoubleDownLeft(1)].IsEmpty || IsOppositeColor(board.Cells[DoubleDownLeft(1)].Piece.Color))
                        yield return (new Move { From = this.Cell.Number, To = DoubleDownLeft(1) });
                }
                break;
            }
        }

        public IEnumerable<Move> GetBishopMoves()
        {
            var board = Cell.Board;
            var currentPosition = Cell.Number;
            var directions = Rules.BishopMoves[currentPosition];
            foreach (var direction in directions)
            {
                foreach (var potentialMove in direction)
                {
                    if (board.Cells[potentialMove].IsEmpty)
                    {
                        yield return new Move { From = currentPosition, To = potentialMove };
                        continue;
                    }
                    else if (board.Cells[potentialMove].Piece.IsOppositeColor(Color))
                    {
                        yield return new Move { From = currentPosition, To = potentialMove };
                    }
                    break;
                }
            }
        }
        internal IEnumerable<Move> GetBishopMovesOld()
        {
            var board = this.Cell.Board;
            //var availableMoves = new List<Move>();
            var offset = 0;
           
            while (!(IsLeftEdge(MoveUpLeft(offset)) || IsTopEdge(MoveUpLeft(offset))))
            {
                offset++;
                if (board.Cells[MoveUpLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpLeft(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveUpLeft(offset) });
                if (board.Cells[MoveUpLeft(offset)].IsOccupied) break;
            }
            offset = 0;
            while (!(IsTopEdge(MoveUpRight(offset)) || IsRightEdge(MoveUpRight(offset))))
            {
                offset++;
                if (board.Cells[MoveUpRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUpRight(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveUpRight(offset) });
                if (board.Cells[MoveUpRight(offset)].IsOccupied) break;
            }
            offset = 0;
            while (!(IsRightEdge(MoveDownRight(offset)) || IsBottomEdge(MoveDownRight(offset))))
            {
                offset++;
                if (board.Cells[MoveDownRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDownRight(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveDownRight(offset) });
                if (board.Cells[MoveDownRight(offset)].IsOccupied) break;
            }
            offset = 0;
            while (!(IsBottomEdge(MoveDownLeft(offset)) || IsLeftEdge(MoveDownLeft(offset))))
            {
                offset++;
                if (board.Cells[MoveDownLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDownLeft(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveDownLeft(offset) });
                if (board.Cells[MoveDownLeft(offset)].IsOccupied) break;
            }
            
        }

        public IEnumerable<Move> GetRookMoves()
        {
            var board = Cell.Board;
            var currentPosition = Cell.Number;
            var directions = Rules.RookMoves[currentPosition];
            foreach(var direction in directions)
            {
                foreach (var potentialMove in direction)
                {
                    if (board.Cells[potentialMove].IsEmpty)
                    {
                        yield return new Move { From = currentPosition, To = potentialMove };
                        continue;
                    }
                    else if (board.Cells[potentialMove].Piece.IsOppositeColor(Color))
                    {
                        yield return new Move { From = currentPosition, To = potentialMove };
                    }
                    break;
                }
            }
        }
        public IEnumerable<Move> GetRookMovesOld()
        {
            var board = this.Cell.Board;
            //var availableMoves = new List<Move>();
            int offset = 0;
            // Check for moves in up direction 
            while (!IsTopEdge(MoveUp(offset)))
            {
                offset++;
                if (board.Cells[MoveUp(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveUp(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveUp(offset) });
                if (board.Cells[MoveUp(offset)].IsOccupied) break;
            }
            // Check for moves in down direcion
            offset = 0;
            while (!IsBottomEdge(MoveDown(offset)))
            {
                offset++;
                if (board.Cells[MoveDown(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveDown(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveDown(offset) });
                if (board.Cells[MoveDown(offset)].IsOccupied) break;
            }
            // Check for moves in right direction
            offset = 0;
            while (!IsRightEdge(MoveRight(offset)))
            {
                offset++;
                if (board.Cells[MoveRight(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveRight(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveRight(offset) });
                if (board.Cells[MoveRight(offset)].IsOccupied) break;
            }
            // Check for moves in left direction
            offset = 0;
            while (!IsLeftEdge(MoveLeft(offset)))
            {
                offset++;
                if (board.Cells[MoveLeft(offset)].IsEmpty || IsOppositeColor(board.Cells[MoveLeft(offset)].Piece.Color))
                    yield return (new Move { From = this.Cell.Number, To = MoveLeft(offset) });
                if (board.Cells[MoveLeft(offset)].IsOccupied) break;
            }
             
        }

        protected IEnumerable<Move> Validate(IEnumerable<Move> moves)
        {

            
            // get the board

            // for each move apply the move

            // find my king

            // is my king in check? - bad move - my king is not in check - keep the move

            // roll back the move

            // next move
            //var validMoves = new List<Move>();
            var board = this.Cell.Board;
            foreach (var move in moves)
            {
                using (board.With(move))
                {

                    var myKing = board.Cells.SingleOrDefault(c => c.IsOccupied && c.Piece is King && !c.Piece.IsOppositeColor(this.Color))?.Piece as King;
                    if (myKing == null && !board.IsPartialBoard)
                    {
                        throw new Exception("No king on board!!!!");
                    }
                    if (myKing == null)
                    {
                        yield return move;
                    }
                    else if (!myKing.IsUnderCheck())
                    {
                        yield return move;
                    }
                }
                
            }
            //var invalidMoves = moves.Except(validMoves).ToArray();
            
        }
        public int DoubleDownRight(int offset)
        {
            return this.Cell.Number + (15 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int DoubleDownLeft(int offset)
        {
            return this.Cell.Number + (17 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int DoubleLeftDown(int offset)
        {
            return this.Cell.Number + (10 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int DoubleLeftUp(int offset)
        {
            return this.Cell.Number + (6 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleUpLeft(int offset)
        {
            return this.Cell.Number + (15 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleUpRight(int offset)
        {
            return this.Cell.Number + (17 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleRightUp(int offset)
        {
            return this.Cell.Number + (10 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int DoubleRightDown(int offset)
        {
            return this.Cell.Number + (6 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public bool IsBottomEdge()
        {
            return this.Color == Color.White ? this.Cell.IsBottomEdge : this.Cell.IsTopEdge;
        }
        public bool IsBottomEdge(int cellNumber)
        {
            //var topNum = new List<int>() { 56, 57, 58, 59, 60, 61, 62, 63 };
            //var bottomNum = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            //return (this.Color == Color.White ? bottomNum : topNum).Contains(cellNumber);
            return (this.Color == Color.White ? cellNumber <= 7 : cellNumber >= 56);
        }
        public bool IsTopEdge()
        {
            return this.Color == Color.White ? this.Cell.IsTopEdge : this.Cell.IsBottomEdge;
        }
        public bool IsTopEdge(int cellNumber)
        {
            //var topNum = new List<int>() { 56, 57, 58, 59, 60, 61, 62, 63 };
            //var bottomNum = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            //return (this.Color == Color.White ? topNum : bottomNum).Contains(cellNumber);
            return (this.Color == Color.White ? cellNumber >= 56 : cellNumber <= 7);
        }
        public bool IsRightEdge()
        {
            return this.Color == Color.White ? this.Cell.IsRightEdge : this.Cell.IsLeftEdge;

        }
        public bool IsRightEdge(int cellNumber)
        {
            //var leftNum = new List<int>() { 0, 8, 16, 24, 32, 40, 48, 56 };
            //var rightNum = new List<int>() { 7, 15, 23, 31, 39, 47, 55, 63 };
            return this.Color == Color.White ? (cellNumber + 1)%8 == 0 : cellNumber%8 == 0;
        }
        public bool IsLeftEdge()
        {
            return this.Color == Color.White ? this.Cell.IsLeftEdge : this.Cell.IsRightEdge;
        }
        public bool IsLeftEdge(int cellNumber)
        {
            //var leftNum = new List<int>() { 0, 8, 16, 24, 32, 40, 48, 56 };
            //var rightNum = new List<int>() { 7, 15, 23, 31, 39, 47, 55, 63 };
            return this.Color == Color.White ? cellNumber % 8 == 0 : (cellNumber + 1) % 8 == 0;
        }
        public int MoveRight(int offset)
        {
            return this.Cell.Number + (1 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveLeft(int offset)
        {
            return this.Cell.Number + (1 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int MoveUp(int offset)
        {
            return this.Cell.Number + (8 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveDown(int offset)
        {
            return this.Cell.Number + (8 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int MoveUpLeft(int offset)
        {
            return this.Cell.Number + (7 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveUpRight(int offset)
        {
            return this.Cell.Number + (9 * offset) * (this.Color == Color.White ? 1 : -1);
        }
        public int MoveDownLeft(int offset)
        {
            return this.Cell.Number + (9 * offset) * (this.Color == Color.White ? -1 : 1);
        }
        public int MoveDownRight(int iterant)
        {
            return this.Cell.Number + (7 * iterant) * (this.Color == Color.White ? -1 : 1);
        }
        public bool IsOppositeColor(Color color)
        {
            return color == this.Color ? false : true;
        }
        public Color Color
        {
            get{ return _color; }
        }
        public Figure Figure { get; set; }
        public Cell Cell { get; set;}
       
        public IEnumerable<Move> GetAvailableMoves()
        {
            return Validate(GetPieceAvailableMoves());
        }

        protected abstract IEnumerable<Move> GetPieceAvailableMoves();

        public int GetValue()
        {
            return GetPieceValue();
        }

        protected abstract int GetPieceValue();
    }
}


namespace chess_engine
{
    /// <summary>
    /// Board Cell .
    /// </summary>
    public class Cell
    {
        public bool IsLeftEdge
        {
            get { return Number % 8 == 0; }
        }
        public bool IsRightEdge
        {
            get
            {
                return (Number + 1) % 8 == 0;
            }
        }
        public int Number { get; set; }
        private Piece _piece;
        public Piece Piece {
            get { return _piece; }
            set { value.Cell = this; _piece = value; }
        }
        public (char, int) Position
        {
            get
            {
                return ("abcdefgh"[this.Number % 8], this.Number / 8 + 1);
            }
        }
    }
}


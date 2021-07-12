namespace chess_engine
{
    /// <summary>
    /// Board Cell .
    /// </summary>
    class Cell
    {

        public int Number { get; set; }
        private Piece _piece;
        public Piece Piece { get { return _piece; } set { value.Cell = this; _piece = value; } }
        public (char, int) Position
        {
            get
            {
                return ("abcdefgh"[this.Number % 8], this.Number / 8 + 1);
            }
        }
    }
}


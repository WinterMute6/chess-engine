namespace chess_engine
{
    /// <summary>
    /// Board Cell .
    /// </summary>
    class Cell
    {

        public int Number { get; set; }

        public Piece Piece { get; set; }
        public (char, int) Position
        {
            get
            {
                return ("abcdefgh"[this.Number % 8], this.Number / 8 + 1);
            }

                
        }

    }
}


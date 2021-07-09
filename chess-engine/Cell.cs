namespace chess_engine
{
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


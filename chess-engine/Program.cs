using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace chess_engine
{
    public class Program
    {
         void Main(string[] args)
        {
            var board = new Board();
            board.ResetBoard();
            BuildTree();


          
        }

        public void BuildTree()
        {
            /*var board = new Board();
            board.ResetBoard();
            foreach (Cell cell in board)*/
        }
    }

    
    public class Move
    {
        
        public int From { get; set; }
        public int To { get; set; }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Move) && ((Move)obj).From == this.From && ((Move)obj).To == this.To;
        }
        public override int GetHashCode()
        {
            return To*100+From;
        }
    }
}


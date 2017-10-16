using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    public class Board
    {
        public string[,] GameBoard { get; set; } = new string[19, 19];
        public Board()
        {

        }
        public Board(string[,] board)
        {

        }
    }
}

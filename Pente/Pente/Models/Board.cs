using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    public class Board
    {
        public string[,] GameBoard { get; set; }
        public int rowCount;
        public int colCount;
        public Board()
        {
            GameBoard = new string[19, 19];
            rowCount = 19;
            colCount = 19;
            initBoard();
        }
        public Board(int rows, int cols)
        {
            GameBoard = new string[rows, cols];
            rowCount = rows;
            colCount = cols;
            initBoard();
        }

        private void initBoard()
        {
            for (int j = 0; j < rowCount; j++)
            {
                for (int k = 0; k < colCount; k++)
                {
                    GameBoard[j, k] = " ";
                }
            }
        }
    }
}

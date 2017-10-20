using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    public class Board
    {
        public Cell[,] GameBoard { get; set; }
        public int rowCount = 10;
        public int colCount = 10;
        public Board()
        {
            GameBoard = new Cell[rowCount, colCount];
            initBoard();
        }
        public Board(int rows, int cols)
        {
            GameBoard = new Cell[rows, cols];
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
                    GameBoard[j, k] = new Cell();
                }
            }
        }
    }
}

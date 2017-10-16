using Pente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.GameProcesses
{
    public class GameRules
    {
        /// <summary>
        /// Checks legality of moves with Tournament Rules.
        /// </summary>
        /// <param name="board">Gets the board to check current stone placement. </param>
        /// <param name="move">The players attempted move. </param>
        /// <returns>Whether or not the move is legal. </returns>
        public static bool IsMoveLegal(Board board, int[] move, int turnCount)
        {
            if(turnCount == 1 && move[0] == 9 && move[1] == 9)
            {
                return true;
            }
            else if (turnCount == 3 && (move[1] < 7 || move[1] > 11) )
            {
                return IsMoveLegal(board, move);
            }
            else if (turnCount == 3 && (move[0] < 7 || move[0] > 11))
            {
                return IsMoveLegal(board, move);
            }
            return IsMoveLegal(board, move);
        }
        /// <summary>
        /// Checks legality of moves. 
        /// </summary>
        /// <param name="board">Gets the board to check current stone placement. </param>
        /// <param name="move">The players attempted move. </param>
        /// <returns>Whether or not the move is legal. </returns>
        public static bool IsMoveLegal(Board board, int[] move)
        {
            if(move[0] > 18 || move[1] > 18 || move[0] < 0 || move[1] < 0)
            {
                return false;
            }
            else if (board.GameBoard[move[1],move[0]] == "X" || board.GameBoard[move[1], move[0]] == "Y")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void RemovePieces(Player currentPlayer, Board board, int[] move)
        {
            //up
            if (move[0] > 3)
            {
                //Check if legalToremove
                //remove
                //if
                    //remove
            }
            //upright
            if (move[0] > 3)
            {
                if (move[1] < 16)
                {

                }
            }
            //right
            //downRight
            //down
            //downLeft
            //left
            //upLeft
        }
        //public static bool gameOver()
        //public static void checkBoard()
    }
}

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
            int rowMiddle = board.rowCount / 2;
            int colMiddle = board.colCount / 2;
            if (turnCount == 1 && move[0] == rowMiddle && move[1] == colMiddle)
            {
                return true;
            }
            else if (turnCount == 3 && (move[1] >= colMiddle - 2 && move[1] <= colMiddle + 2) )
            {
                if(move[0] < rowMiddle - 2 || move[0] > rowMiddle + 2)
                {
                    return IsMoveLegal(board, move);
                }
                else
                {
                    return false;
                }

            }
            else if (turnCount == 3 && (move[1] < colMiddle - 2 || move[1] > colMiddle + 2))
            {
                if(move[0] >= rowMiddle - 2 && move[0] <= rowMiddle + 2)
                {
                    return IsMoveLegal(board, move); 
                }
                else
                {
                    return false;
                }
            }
            else if(turnCount > 3 || turnCount == 2)
            {
                return IsMoveLegal(board, move);
            } 
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// Checks legality of moves. 
        /// </summary>
        /// <param name="board">Gets the board to check current stone placement. </param>
        /// <param name="move">The players attempted move. </param>
        /// <returns>Whether or not the move is legal. </returns>
        public static bool IsMoveLegal(Board board, int[] move)
        {
            if(move[0] > board.rowCount - 1 || move[1] > board.colCount - 1 || move[0] < 0 || move[1] < 0)
            {
                return false;
            }
            else if (board.GameBoard[move[0],move[1]].TokenXY == "X" || board.GameBoard[move[0], move[1]].TokenXY == "Y")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Removes Pairs if present.
        /// </summary>
        /// <param name="currentPlayer">Current player</param>
        /// <param name="board">Game board</param>
        /// <param name="move">Coordinate pair of this turn's move.</param>
        public static void RemovePieces(Player currentPlayer, Board board, int[] move)
        {
            string player = "" + currentPlayer.pieceChar;
            int row = move[0];
            int col = move[1];

            //up
            if (move[0] > 2)
            {
                //up
                if (board.GameBoard[row - 1, col].TokenXY != player && board.GameBoard[row - 1, col].TokenXY != " ")
                {
                    if (board.GameBoard[row - 2, col].TokenXY != player && board.GameBoard[row - 2, col].TokenXY != " ")
                    {
                        if (board.GameBoard[row - 3, col].TokenXY == player)
                        {
                            board.GameBoard[row - 1, col].TokenXY = " ";
                            board.GameBoard[row - 2, col].TokenXY = " ";
                            currentPlayer.Captures++;
                        }
                    }
                }
                //up right
                if (move[1] < board.colCount - 3)
                {
                    if (board.GameBoard[row - 1, col + 1].TokenXY != player && board.GameBoard[row - 1, col + 1].TokenXY != " ")
                    {
                        if (board.GameBoard[row - 2, col + 2].TokenXY != player && board.GameBoard[row - 2, col + 2].TokenXY != " ")
                        {
                            if (board.GameBoard[row - 3, col + 3].TokenXY == player)
                            {
                                board.GameBoard[row - 1, col + 1].TokenXY = " ";
                                board.GameBoard[row - 2, col + 2].TokenXY = " ";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                //up left
                if (move[1] > 2)
                {
                    if (board.GameBoard[row - 1, col - 1].TokenXY != player && board.GameBoard[row - 1, col - 1].TokenXY != " ")
                    {
                        if (board.GameBoard[row - 2, col - 2].TokenXY != player && board.GameBoard[row - 2, col - 2].TokenXY != " ")
                        {
                            if (board.GameBoard[row - 3, col - 3].TokenXY == player)
                            {
                                board.GameBoard[row - 1, col - 1].TokenXY = " ";
                                board.GameBoard[row - 2, col - 2].TokenXY = " ";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                
            }

            //right
            if (move[1] < board.colCount - 3)
            {
                if (board.GameBoard[row, col + 1].TokenXY != player && board.GameBoard[row, col + 1].TokenXY != " ")
                {
                    if (board.GameBoard[row, col + 2].TokenXY != player && board.GameBoard[row, col + 2].TokenXY != " ")
                    {
                        if (board.GameBoard[row, col + 3].TokenXY == player)
                        {
                            board.GameBoard[row, col + 1].TokenXY = " ";
                            board.GameBoard[row, col + 2].TokenXY = " ";
                            currentPlayer.Captures++;
                        }

                    }
                }
            }

            //left
            if (move[1] > 2)
            {
                if (board.GameBoard[row, col - 1].TokenXY != player && board.GameBoard[row, col - 1].TokenXY != " ")
                {
                    if (board.GameBoard[row, col - 2].TokenXY != player && board.GameBoard[row, col - 2].TokenXY != " ")
                    {
                        if (board.GameBoard[row, col - 3].TokenXY == player)
                        {
                            board.GameBoard[row, col - 1].TokenXY = " ";
                            board.GameBoard[row, col - 2].TokenXY = " ";
                            currentPlayer.Captures++;
                        }

                    }
                }
            }
            //down
            if (move[0] < board.rowCount - 3)
            {
                //down
                if (board.GameBoard[row + 1, col].TokenXY != player && board.GameBoard[row + 1, col].TokenXY != " ")
                {
                    if (board.GameBoard[row + 2, col].TokenXY != player && board.GameBoard[row + 2, col].TokenXY != " ")
                    {
                        if (board.GameBoard[row + 3, col].TokenXY == player)
                        {
                            board.GameBoard[row + 1, col].TokenXY = " ";
                            board.GameBoard[row + 2, col].TokenXY = " ";
                            currentPlayer.Captures++;
                        }
                    }
                }
                //down right
                if (move[1] < board.colCount - 3)
                {
                    if (board.GameBoard[row + 1, col + 1].TokenXY != player && board.GameBoard[row + 1, col + 1].TokenXY != " ")
                    {
                        if (board.GameBoard[row + 2, col + 2].TokenXY != player && board.GameBoard[row + 2, col + 2].TokenXY != " ")
                        {
                            if (board.GameBoard[row + 3, col + 3].TokenXY == player)
                            {
                                board.GameBoard[row + 1, col + 1].TokenXY = " ";
                                board.GameBoard[row + 2, col + 2].TokenXY = " ";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                //down left
                if (move[1] > 2)
                {
                    if (board.GameBoard[row + 1, col - 1].TokenXY != player && board.GameBoard[row + 1, col - 1].TokenXY != " ")
                    {
                        if (board.GameBoard[row + 2, col - 2].TokenXY != player && board.GameBoard[row + 2, col - 2].TokenXY != " ")
                        {
                            if (board.GameBoard[row + 3, col - 3].TokenXY == player)
                            {
                                board.GameBoard[row + 1, col - 1].TokenXY = " ";
                                board.GameBoard[row + 2, col - 2].TokenXY = " ";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Checks if the game is over according to certain criteria:
        /// -If the current player has 5 or more captured pairs.
        /// -If current player has a row of 5 stones.
        /// -If the board is completely filled.
        /// </summary>
        /// <param name="player">Current Player</param>
        /// <param name="board">Game board</param>
        /// <returns>Whether or not the game is over according to the criteria.</returns>
        public static bool GameOver(Player player, Board board)
        {
            bool isOver = false;
            if(player.Captures >= 5)
            {
                //PopUp Window display winner
                player.hasWon = true;
                isOver = true;
            }
            else
            {
                for (int j = 0; j < board.rowCount; j++)
                {
                    for (int k = 0; k < board.colCount; k++)
                    {
                        int[] move = { j, k };
                        isOver = CheckBoardFor5(player, board, move);
                        if (isOver)
                        {
                            //PopUp Window that displays the winner
                            k = board.colCount + 1;
                            j = board.rowCount + 1;
                        }
                    }
                }
            }
            if (CheckIfBoardIsFull(board)) {
                isOver = true;
                //Pop up Window display that there is no winner
            }

            return isOver;
        }
        /// <summary>
        /// Checking for any rows of 5 or more stones of the same color.
        /// </summary>
        /// <param name="currentPlayer">Current player</param>
        /// <param name="board">Game Board</param>
        /// <param name="move">Coordinate pair of this turn's move.</param>
        /// <returns>Whether or not there is a row of 5 or more on the board.</returns>
        public static bool CheckBoardFor5(Player currentPlayer, Board board, int[] move)
        {
            string player = "" + currentPlayer.pieceChar;
            int row = move[0];
            int col = move[1];
            bool found5 = false;

            //up
            if (move[0] > 4)
            {
                //up
                if (board.GameBoard[row - 1, col].TokenXY == player)
                {
                    if (board.GameBoard[row - 2, col].TokenXY == player)
                    {
                        if (board.GameBoard[row - 3, col].TokenXY == player)
                        {
                            if (board.GameBoard[row - 4, col].TokenXY == player)
                            {
                                found5 = true;
                            }
                        }
                    }
                }
                //up right
                if (move[1] < board.colCount - 5)
                {
                    if (board.GameBoard[row - 1, col + 1].TokenXY == player)
                    {
                        if (board.GameBoard[row - 2, col + 2].TokenXY == player)
                        {
                            if (board.GameBoard[row - 3, col + 3].TokenXY == player)
                            {
                                if(board.GameBoard[row - 4, col + 4].TokenXY == player)
                                {
                                    found5 = true;
                                }
                            }
                        }
                    }
                }
                //up left
                if (move[1] > 4)
                {
                    if (board.GameBoard[row - 1, col - 1].TokenXY == player)
                    {
                        if (board.GameBoard[row - 2, col - 2].TokenXY == player)
                        {
                            if (board.GameBoard[row - 3, col - 3].TokenXY == player)
                            {
                                if (board.GameBoard[row - 4, col - 4].TokenXY == player)
                                {
                                    found5 = true;
                                }
                            }
                        }
                    }
                }
                //remove
            }

            //right
            if (move[1] < board.colCount - 5)
            {
                if (board.GameBoard[row, col + 1].TokenXY == player)
                {
                    if (board.GameBoard[row, col + 2].TokenXY == player)
                    {
                        if (board.GameBoard[row, col + 3].TokenXY == player)
                        {
                            if (board.GameBoard[row, col + 4].TokenXY == player)
                            {
                                found5 = true;
                            }
                        }

                    }
                }
            }

            //left
            if (move[1] > 4)
            {
                if (board.GameBoard[row, col - 1].TokenXY == player)
                {
                    if (board.GameBoard[row, col - 2].TokenXY == player)
                    {
                        if (board.GameBoard[row, col - 3].TokenXY == player)
                        {
                            if (board.GameBoard[row, col - 4].TokenXY == player)
                            {
                                found5 = true;
                            }
                        }

                    }
                }
            }
            //down
            if (move[0]< board.rowCount - 5)
            {
                //down
                if (board.GameBoard[row + 1, col].TokenXY == player)
                {
                    if (board.GameBoard[row + 2, col].TokenXY == player)
                    {
                        if (board.GameBoard[row + 3, col].TokenXY == player)
                        {
                            if (board.GameBoard[row + 4, col].TokenXY == player)
                            {
                                found5 = true;
                            }
                        }
                    }
                }
                //down right
                if (move[1] < board.colCount - 5)
                {
                    if (board.GameBoard[row + 1, col + 1].TokenXY == player)
                    {
                        if (board.GameBoard[row + 2, col + 2].TokenXY == player)
                        {
                            if (board.GameBoard[row + 3, col + 3].TokenXY == player)
                            {
                                if (board.GameBoard[row + 4, col + 4].TokenXY == player)
                                {
                                    found5 = true;
                                }
                            }
                        }
                    }
                }
                //down left
                if (move[1] > 4)
                {
                    if (board.GameBoard[row + 1, col - 1].TokenXY == player)
                    {
                        if (board.GameBoard[row + 2, col - 2].TokenXY == player)
                        {
                            if (board.GameBoard[row + 3, col - 3].TokenXY == player)
                            {
                                if (board.GameBoard[row + 4, col - 4].TokenXY == player)
                                {
                                    found5 = true;
                                }
                            }
                        }
                    }
                }
            }
            return found5;
        }
        /// <summary>
        /// Checks if board has been filled
        /// </summary>
        /// <param name="board"></param>
        /// <returns>true if board has no strings with a single space</returns>
        private static bool CheckIfBoardIsFull(Board board)
        {
            bool isFull = true;

            for (int j = 0; j < board.rowCount; j++)
            {
                for (int k = 0; k < board.colCount; k++)
                {
                    if(board.GameBoard[j, k].TokenXY == "" || board.GameBoard[j, k].TokenXY == " ")
                    {
                        isFull = false;
                        k = board.colCount + 1;
                        j = board.rowCount + 1;
                    }
                }
            }

            return isFull;
        }
    }
}

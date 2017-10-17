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
            else if (board.GameBoard[move[0],move[1]] == "X" || board.GameBoard[move[0], move[1]] == "Y")
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
            string player = "" + currentPlayer.pieceChar;
            int row = move[0];
            int col = move[1];

            //up
            if (move[0] > 2)
            {
                //Check if legalToremove
                if (board.GameBoard[row - 1, col] != player && board.GameBoard[row - 1, col] != "")
                {
                    if (board.GameBoard[row - 2, col] != player && board.GameBoard[row - 2, col] != "")
                    {
                        if (board.GameBoard[row - 3, col] == player)
                        {
                            board.GameBoard[row - 1, col] = "";
                            board.GameBoard[row - 2, col] = "";
                            currentPlayer.Captures++;
                        }
                    }
                }
                //if
                if (move[1] < board.colCount - 3)
                {
                    if (board.GameBoard[row - 1, col + 1] != player && board.GameBoard[row - 1, col + 1] != "")
                    {
                        if (board.GameBoard[row - 2, col + 2] != player && board.GameBoard[row - 2, col + 2] != "")
                        {
                            if (board.GameBoard[row - 3, col + 3] == player)
                            {
                                board.GameBoard[row - 1, col + 1] = "";
                                board.GameBoard[row - 2, col + 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                if (move[1] > 2)
                {
                    if (board.GameBoard[row - 1, col - 1] != player && board.GameBoard[row - 1, col - 1] != "")
                    {
                        if (board.GameBoard[row - 2, col - 2] != player && board.GameBoard[row - 2, col - 2] != "")
                        {
                            if (board.GameBoard[row - 3, col - 3] == player)
                            {
                                board.GameBoard[row - 1, col - 1] = "";
                                board.GameBoard[row - 2, col - 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                //remove
            }

            //right
            if (move[1] < board.colCount - 3)
            {
                if (board.GameBoard[row, col + 1] != player && board.GameBoard[row, col + 1] != "")
                {
                    if (board.GameBoard[row, col + 2] != player && board.GameBoard[row, col + 2] != "")
                    {
                        if (board.GameBoard[row, col + 3] == player)
                        {
                            board.GameBoard[row, col + 1] = "";
                            board.GameBoard[row, col + 2] = "";
                            currentPlayer.Captures++;
                        }

                    }
                }
            }

            //left
            if (move[1] > 2)
            {
                if (board.GameBoard[row, col - 1] != player && board.GameBoard[row, col - 1] != "")
                {
                    if (board.GameBoard[row, col - 2] != player && board.GameBoard[row, col - 2] != "")
                    {
                        if (board.GameBoard[row, col - 3] == player)
                        {
                            board.GameBoard[row, col - 1] = "";
                            board.GameBoard[row, col - 2] = "";
                            currentPlayer.Captures++;
                        }

                    }
                }
            }
            //down
            if (move[0] < board.rowCount - 3)
            {
                //Check if legalToremove
                if (board.GameBoard[row + 1, col] != player && board.GameBoard[row + 1, col] != "")
                {
                    if (board.GameBoard[row + 2, col] != player && board.GameBoard[row + 2, col] != "")
                    {
                        if (board.GameBoard[row + 3, col] == player)
                        {
                            board.GameBoard[row + 1, col] = "";
                            board.GameBoard[row + 2, col] = "";
                            currentPlayer.Captures++;
                        }
                    }
                }
                //if
                if (move[1] < board.colCount - 3)
                {
                    if (board.GameBoard[row + 1, col + 1] != player && board.GameBoard[row + 1, col + 1] != "")
                    {
                        if (board.GameBoard[row + 2, col + 2] != player && board.GameBoard[row + 2, col + 2] != "")
                        {
                            if (board.GameBoard[row + 3, col + 3] == player)
                            {
                                board.GameBoard[row + 1, col + 1] = "";
                                board.GameBoard[row + 2, col + 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                if (move[1] > 2)
                {
                    if (board.GameBoard[row + 1, col - 1] != player && board.GameBoard[row + 1, col - 1] != "")
                    {
                        if (board.GameBoard[row + 2, col - 2] != player && board.GameBoard[row + 2, col - 2] != "")
                        {
                            if (board.GameBoard[row + 3, col - 3] == player)
                            {
                                board.GameBoard[row + 1, col - 1] = "";
                                board.GameBoard[row + 2, col - 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
            }
        }

        public static bool GameOver(Player player, Board board)
        {
            bool isOver = false;
            if(player.Captures >= 5)
            {
                //PopUp Window display winner
                player.hasWon = true;
                isOver = true;
            }
            else if (){

            }
            else
            {

            }

            return isOver;
        }

        public static bool CheckBoardFor5(Player currentPlayer, Board board, int[] move)
        {
            string player = "" + currentPlayer.pieceChar;
            int row = move[0];
            int col = move[1];
            bool found5 = false;

            //up
            if (move[0] > 4)
            {
                //Check if legalToremove
                if (board.GameBoard[row - 1, col] != player && board.GameBoard[row - 1, col] != "")
                {
                    if (board.GameBoard[row - 2, col] != player && board.GameBoard[row - 2, col] != "")
                    {
                        if (board.GameBoard[row - 3, col] == player)
                        {
                            board.GameBoard[row - 1, col] = "";
                            board.GameBoard[row - 2, col] = "";
                            currentPlayer.Captures++;
                        }
                    }
                }
                //if
                if (move[1] < board.colCount - 3)
                {
                    if (board.GameBoard[row - 1, col + 1] != player && board.GameBoard[row - 1, col + 1] != "")
                    {
                        if (board.GameBoard[row - 2, col + 2] != player && board.GameBoard[row - 2, col + 2] != "")
                        {
                            if (board.GameBoard[row - 3, col + 3] == player)
                            {
                                board.GameBoard[row - 1, col + 1] = "";
                                board.GameBoard[row - 2, col + 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                if (move[1] > 2)
                {
                    if (board.GameBoard[row - 1, col - 1] != player && board.GameBoard[row - 1, col - 1] != "")
                    {
                        if (board.GameBoard[row - 2, col - 2] != player && board.GameBoard[row - 2, col - 2] != "")
                        {
                            if (board.GameBoard[row - 3, col - 3] == player)
                            {
                                board.GameBoard[row - 1, col - 1] = "";
                                board.GameBoard[row - 2, col - 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                //remove
            }

            //right
            if (move[1] < board.colCount - 3)
            {
                if (board.GameBoard[row, col + 1] != player && board.GameBoard[row, col + 1] != "")
                {
                    if (board.GameBoard[row, col + 2] != player && board.GameBoard[row, col + 2] != "")
                    {
                        if (board.GameBoard[row, col + 3] == player)
                        {
                            board.GameBoard[row, col + 1] = "";
                            board.GameBoard[row, col + 2] = "";
                            currentPlayer.Captures++;
                        }

                    }
                }
            }

            //left
            if (move[1] > 2)
            {
                if (board.GameBoard[row, col - 1] != player && board.GameBoard[row, col - 1] != "")
                {
                    if (board.GameBoard[row, col - 2] != player && board.GameBoard[row, col - 2] != "")
                    {
                        if (board.GameBoard[row, col - 3] == player)
                        {
                            board.GameBoard[row, col - 1] = "";
                            board.GameBoard[row, col - 2] = "";
                            currentPlayer.Captures++;
                        }

                    }
                }
            }
            //down
            if (move[0] < board.rowCount - 3)
            {
                //Check if legalToremove
                if (board.GameBoard[row + 1, col] != player && board.GameBoard[row + 1, col] != "")
                {
                    if (board.GameBoard[row + 2, col] != player && board.GameBoard[row + 2, col] != "")
                    {
                        if (board.GameBoard[row + 3, col] == player)
                        {
                            board.GameBoard[row + 1, col] = "";
                            board.GameBoard[row + 2, col] = "";
                            currentPlayer.Captures++;
                        }
                    }
                }
                //if
                if (move[1] < board.colCount - 3)
                {
                    if (board.GameBoard[row + 1, col + 1] != player && board.GameBoard[row + 1, col + 1] != "")
                    {
                        if (board.GameBoard[row + 2, col + 2] != player && board.GameBoard[row + 2, col + 2] != "")
                        {
                            if (board.GameBoard[row + 3, col + 3] == player)
                            {
                                board.GameBoard[row + 1, col + 1] = "";
                                board.GameBoard[row + 2, col + 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
                if (move[1] > 2)
                {
                    if (board.GameBoard[row + 1, col - 1] != player && board.GameBoard[row + 1, col - 1] != "")
                    {
                        if (board.GameBoard[row + 2, col - 2] != player && board.GameBoard[row + 2, col - 2] != "")
                        {
                            if (board.GameBoard[row + 3, col - 3] == player)
                            {
                                board.GameBoard[row + 1, col - 1] = "";
                                board.GameBoard[row + 2, col - 2] = "";
                                currentPlayer.Captures++;
                            }
                        }
                    }
                }
            }
            return found5;
        }
    }
}

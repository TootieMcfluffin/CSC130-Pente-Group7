using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pente;

namespace PenteTests
{
    [TestClass]
    public class PenteTests
    {
        Pente.Models.Board testBoard;
        Pente.Models.Player testPlayer;
        Pente.MainWindow testWindow;

        [TestInitialize]
        public void TestIntitialize()
        {
            testBoard = new Pente.Models.Board();
            testPlayer = new Pente.Models.Player("Dubya", Pente.Enums.PlayerOrderEnum.PLAYER2);
            testPlayer.pieceChar = 'X';
        }

        //Tests for the IsMoveLegal method
        [TestMethod]
        public void IsMoveLegalTest_ShouldReturnValidMove()
        {
            int[] testMove = new int[] { 2, 5 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.IsMoveLegal(testBoard, testMove));
        }

        [TestMethod]
        public void IsMoveLegalTest_ShouldReturnInvalidMoveInBounds()
        {
            int[] testMove = new int[] { 2, 5 };

            testBoard.GameBoard[2, 5] = "X";

            Assert.IsFalse(Pente.GameProcesses.GameRules.IsMoveLegal(testBoard, testMove));
        }

        [TestMethod]
        public void IsMoveLegalTest_ShouldReturnInvalidMoveOutOfBounds()
        {
            int[] testMove = new int[] { -2, -5 };
                        
            Assert.IsFalse(Pente.GameProcesses.GameRules.IsMoveLegal(testBoard, testMove));
        }

        //Tests for the RemovePieces method
        [TestMethod]
        public void RemovePiecesTest_NothingToRemove_ShouldReturnInvalid()
        {
            testBoard.GameBoard[0, 0] = "X";
            testBoard.GameBoard[0, 1] = "Y";
            testBoard.GameBoard[0, 2] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 0] = "X";
            tempBoard.GameBoard[0, 1] = "Y";
            tempBoard.GameBoard[0, 2] = "Y";

            int[] testMove = { 0, 4 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            for(int i = 0; i < 19; i++)
            {
                for(int j = 0; j < 19; j++)
                {
                    Assert.AreEqual(testBoard.GameBoard[i, j], tempBoard.GameBoard[i, j]);
                }
            }
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveUp_ShouldReturnValid()
        {
            testBoard.GameBoard[3, 0] = "X";
            testBoard.GameBoard[1, 0] = "Y";
            testBoard.GameBoard[2, 0] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[3, 0] = "X";
            tempBoard.GameBoard[1, 0] = "Y";
            tempBoard.GameBoard[2, 0] = "Y";

            int[] testMove = { 0, 0 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[1, 0], tempBoard.GameBoard[1, 0]);
            Assert.AreNotEqual(testBoard.GameBoard[2, 0], tempBoard.GameBoard[2, 0]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDown_ShouldReturnValid()
        {
            testBoard.GameBoard[0, 0] = "X";
            testBoard.GameBoard[1, 0] = "Y";
            testBoard.GameBoard[2, 0] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 0] = "X";
            tempBoard.GameBoard[1, 0] = "Y";
            tempBoard.GameBoard[2, 0] = "Y";

            int[] testMove = { 3, 0 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            for (int i = 0; i < 19; i++)
            Assert.AreNotEqual(testBoard.GameBoard[1, 0], tempBoard.GameBoard[1, 0]);
            Assert.AreNotEqual(testBoard.GameBoard[2, 0], tempBoard.GameBoard[2, 0]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[0, 3] = "X";
            testBoard.GameBoard[0, 2] = "Y";
            testBoard.GameBoard[0, 1] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 3] = "X";
            tempBoard.GameBoard[0, 2] = "Y";
            tempBoard.GameBoard[0, 1] = "Y";

            int[] testMove = { 0, 0 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[0, 2], tempBoard.GameBoard[0, 2]);
            Assert.AreNotEqual(testBoard.GameBoard[0, 1], tempBoard.GameBoard[0, 1]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveRight_ShouldReturnValid()
        {
            testBoard.GameBoard[0, 0] = "X";
            testBoard.GameBoard[0, 1] = "Y";
            testBoard.GameBoard[0, 2] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 0] = "X";
            tempBoard.GameBoard[0, 1] = "Y";
            tempBoard.GameBoard[0, 2] = "Y";

            int[] testMove = { 0, 3 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[0, 1], tempBoard.GameBoard[0, 1]);
            Assert.AreNotEqual(testBoard.GameBoard[0, 2], tempBoard.GameBoard[0, 2]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalUpLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[4, 4] = "Y";
            testBoard.GameBoard[3, 3] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5] = "X";
            tempBoard.GameBoard[4, 4] = "Y";
            tempBoard.GameBoard[3, 3] = "Y";

            int[] testMove = { 2, 2 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            for (int i = 0; i < 19; i++)
            Assert.AreNotEqual(testBoard.GameBoard[4, 4], tempBoard.GameBoard[4, 4]);
            Assert.AreNotEqual(testBoard.GameBoard[3, 3], tempBoard.GameBoard[3, 3]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalUpRight_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[4, 6] = "Y";
            testBoard.GameBoard[3, 7] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5] = "X";
            tempBoard.GameBoard[4, 6] = "Y";
            tempBoard.GameBoard[3, 7] = "Y";

            int[] testMove = { 2, 8 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[4, 6], tempBoard.GameBoard[4, 6]);
            Assert.AreNotEqual(testBoard.GameBoard[3, 7], tempBoard.GameBoard[3, 7]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalDownLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[6, 4] = "Y";
            testBoard.GameBoard[7, 3] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5] = "X";
            tempBoard.GameBoard[6, 4] = "Y";
            tempBoard.GameBoard[7, 3] = "Y";

            int[] testMove = { 8, 2 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[6, 4], tempBoard.GameBoard[6, 4]);
            Assert.AreNotEqual(testBoard.GameBoard[7, 3], tempBoard.GameBoard[7, 3]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalDownRight_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[6, 6] = "Y";
            testBoard.GameBoard[7, 7] = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5] = "X";
            tempBoard.GameBoard[6, 6] = "Y";
            tempBoard.GameBoard[7, 7] = "Y";

            int[] testMove = { 8, 8 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[6, 6], tempBoard.GameBoard[6, 6]);
            Assert.AreNotEqual(testBoard.GameBoard[7, 7], tempBoard.GameBoard[7, 7]);
        }

        //Tests for CheckBoardFor5 method
        [TestMethod]
        public void CheckBoardFor5_ShouldReturnInvalid()
        {
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[6, 6] = "X";
            testBoard.GameBoard[7, 7] = "X";

            int[] testMove = { 8, 8 };

            Assert.IsFalse(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalDownRight_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 4] = "X";
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[6, 6] = "X";
            testBoard.GameBoard[7, 7] = "X";

            int[] testMove = { 8, 8 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalDownLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[6, 4] = "X";
            testBoard.GameBoard[7, 3] = "X";
            testBoard.GameBoard[8, 2] = "X";

            int[] testMove = { 9, 1 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalUpRight_ShouldReturnValid()
        {
            testBoard.GameBoard[7, 2] = "X";
            testBoard.GameBoard[6, 3] = "X";
            testBoard.GameBoard[5, 4] = "X";
            testBoard.GameBoard[4, 5] = "X";

            int[] testMove = { 3, 6 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalUpLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[7, 7] = "X";
            testBoard.GameBoard[6, 6] = "X";
            testBoard.GameBoard[5, 5] = "X";
            testBoard.GameBoard[4, 4] = "X";

            int[] testMove = { 3, 3 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckUp_ShouldReturnValid()
        {
            testBoard.GameBoard[7, 4] = "X";
            testBoard.GameBoard[6, 4] = "X";
            testBoard.GameBoard[5, 4] = "X";
            testBoard.GameBoard[4, 4] = "X";

            int[] testMove = { 3, 4 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDown_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 4] = "X";
            testBoard.GameBoard[5, 4] = "X";
            testBoard.GameBoard[6, 4] = "X";
            testBoard.GameBoard[7, 4] = "X";

            int[] testMove = { 8, 4 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 7] = "X";
            testBoard.GameBoard[4, 6] = "X";
            testBoard.GameBoard[4, 5] = "X";
            testBoard.GameBoard[4, 4] = "X";

            int[] testMove = { 4, 3 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckRight_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 4] = "X";
            testBoard.GameBoard[4, 5] = "X";
            testBoard.GameBoard[4, 6] = "X";
            testBoard.GameBoard[4, 7] = "X";

            int[] testMove = { 4, 8 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }


        //Tests for the GameOver method
        [TestMethod]
        public void GameOverTest_NoWinsBoardNotFull_ShouldReturnInvalid()
        {
            bool expectedValue = false;
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_VerticalWinBoardNotFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            testBoard.GameBoard[0, 0] = "X";
            testBoard.GameBoard[1, 0] = "X";
            testBoard.GameBoard[2, 0] = "X";
            testBoard.GameBoard[3, 0] = "X";
            testBoard.GameBoard[4, 0] = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_HorizontalWinBoardNotFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            testBoard.GameBoard[0, 0] = "X";
            testBoard.GameBoard[0, 1] = "X";
            testBoard.GameBoard[0, 2] = "X";
            testBoard.GameBoard[0, 3] = "X";
            testBoard.GameBoard[0, 4] = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_LeftToRightDiagonalWinBoardNotFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            testBoard.GameBoard[4, 0] = "X";
            testBoard.GameBoard[3, 1] = "X";
            testBoard.GameBoard[2, 2] = "X";
            testBoard.GameBoard[1, 3] = "X";
            testBoard.GameBoard[0, 4] = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_RightToLeftDiagonalWinBoardNotFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            testBoard.GameBoard[0, 0] = "X";
            testBoard.GameBoard[1, 1] = "X";
            testBoard.GameBoard[2, 2] = "X";
            testBoard.GameBoard[3, 3] = "X";
            testBoard.GameBoard[4, 4] = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_NoWinsBoardIsFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            bool flipped = true;
            for (int i = 0; i < 19; i++)
            {
                if (i % 2 == 0)
                {
                    if (flipped == false)
                    {
                        flipped = true;
                    }
                    else
                    {
                        flipped = false;
                    }
                }
                for (int j = 0; j < 19; j++)
                {
                    if (flipped)
                    {
                        if (j % 2 == 0)
                        {
                            testBoard.GameBoard[i, j] = "Y";
                        }
                        else
                        {
                            testBoard.GameBoard[i, j] = "X";
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            testBoard.GameBoard[i, j] = "X";

                        }
                        else
                        {
                            testBoard.GameBoard[i, j] = "Y";
                        }
                    }
                }
            }
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_FivePiecesCaptured_ShouldReturnValid()
        {
            testPlayer.Captures = 5;
            Assert.IsTrue(Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard));
        } 
        
        //GUI Testing
        //[TestMethod]
        //public void PlayButtonTest_WindowChangedState_ShouldReturnValid()
        //{
        //    testWindow = new Pente.MainWindow();
        //    Pente.MainWindow testWindow2 = new Pente.MainWindow();
        //    testWindow.Source().Play_Click();
        //}
    }
}

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
            testBoard.GameBoard[2, 5].TokenXY = "X";

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
            testBoard.GameBoard[0, 0].TokenXY = "X";
            testBoard.GameBoard[0, 1].TokenXY = "Y";
            testBoard.GameBoard[0, 2].TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 0].TokenXY = "X";
            tempBoard.GameBoard[0, 1].TokenXY = "Y";
            tempBoard.GameBoard[0, 2].TokenXY = "Y";

            int[] testMove = { 0, 4 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            for(int i = 0; i < testBoard.rowCount; i++)
            {
                for(int j = 0; j < testBoard.colCount; j++)
                {
                    Assert.AreEqual(testBoard.GameBoard[i, j].TokenXY, tempBoard.GameBoard[i, j].TokenXY);
                }
            }
        }

        [TestMethod]
        public void RemovePiecesTest_CanRemoveUp_ShouldReturnValid()
        {
            testBoard.GameBoard[3, 0].TokenXY = "X";
            testBoard.GameBoard[1, 0] .TokenXY = "Y";
            testBoard.GameBoard[2, 0] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[3, 0].TokenXY = "X";
            tempBoard.GameBoard[1, 0] .TokenXY = "Y";
            tempBoard.GameBoard[2, 0] .TokenXY = "Y";

            int[] testMove = { 0, 0 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[1, 0], tempBoard.GameBoard[1, 0]);
            Assert.AreNotEqual(testBoard.GameBoard[2, 0], tempBoard.GameBoard[2, 0]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDown_ShouldReturnValid()
        {
            testBoard.GameBoard[0, 0].TokenXY = "X";
            testBoard.GameBoard[1, 0] .TokenXY = "Y";
            testBoard.GameBoard[2, 0] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 0].TokenXY = "X";
            tempBoard.GameBoard[1, 0] .TokenXY = "Y";
            tempBoard.GameBoard[2, 0] .TokenXY = "Y";

            int[] testMove = { 3, 0 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            for (int i = 0; i < 19; i++)
            Assert.AreNotEqual(testBoard.GameBoard[1, 0], tempBoard.GameBoard[1, 0]);
            Assert.AreNotEqual(testBoard.GameBoard[2, 0], tempBoard.GameBoard[2, 0]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[0, 3].TokenXY = "X";
            testBoard.GameBoard[0, 2] .TokenXY = "Y";
            testBoard.GameBoard[0, 1] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 3].TokenXY = "X";
            tempBoard.GameBoard[0, 2] .TokenXY = "Y";
            tempBoard.GameBoard[0, 1] .TokenXY = "Y";

            int[] testMove = { 0, 0 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[0, 2], tempBoard.GameBoard[0, 2]);
            Assert.AreNotEqual(testBoard.GameBoard[0, 1], tempBoard.GameBoard[0, 1]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveRight_ShouldReturnValid()
        {
            testBoard.GameBoard[0, 0].TokenXY = "X";
            testBoard.GameBoard[0, 1] .TokenXY = "Y";
            testBoard.GameBoard[0, 2] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[0, 0].TokenXY = "X";
            tempBoard.GameBoard[0, 1] .TokenXY = "Y";
            tempBoard.GameBoard[0, 2] .TokenXY = "Y";

            int[] testMove = { 0, 3 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[0, 1], tempBoard.GameBoard[0, 1]);
            Assert.AreNotEqual(testBoard.GameBoard[0, 2], tempBoard.GameBoard[0, 2]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalUpLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[4, 4] .TokenXY = "Y";
            testBoard.GameBoard[3, 3] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5].TokenXY = "X";
            tempBoard.GameBoard[4, 4] .TokenXY = "Y";
            tempBoard.GameBoard[3, 3] .TokenXY = "Y";

            int[] testMove = { 2, 2 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            for (int i = 0; i < 19; i++)
            Assert.AreNotEqual(testBoard.GameBoard[4, 4], tempBoard.GameBoard[4, 4]);
            Assert.AreNotEqual(testBoard.GameBoard[3, 3], tempBoard.GameBoard[3, 3]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalUpRight_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[4, 6] .TokenXY = "Y";
            testBoard.GameBoard[3, 7] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5].TokenXY = "X";
            tempBoard.GameBoard[4, 6] .TokenXY = "Y";
            tempBoard.GameBoard[3, 7] .TokenXY = "Y";

            int[] testMove = { 2, 8 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[4, 6], tempBoard.GameBoard[4, 6]);
            Assert.AreNotEqual(testBoard.GameBoard[3, 7], tempBoard.GameBoard[3, 7]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalDownLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[6, 4] .TokenXY = "Y";
            testBoard.GameBoard[7, 3] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5].TokenXY = "X";
            tempBoard.GameBoard[6, 4] .TokenXY = "Y";
            tempBoard.GameBoard[7, 3] .TokenXY = "Y";

            int[] testMove = { 8, 2 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[6, 4], tempBoard.GameBoard[6, 4]);
            Assert.AreNotEqual(testBoard.GameBoard[7, 3], tempBoard.GameBoard[7, 3]);
        }
        [TestMethod]
        public void RemovePiecesTest_CanRemoveDiagonalDownRight_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[6, 6] .TokenXY = "Y";
            testBoard.GameBoard[7, 7] .TokenXY = "Y";

            Pente.Models.Board tempBoard = new Pente.Models.Board();
            tempBoard.GameBoard[5, 5].TokenXY = "X";
            tempBoard.GameBoard[6, 6] .TokenXY = "Y";
            tempBoard.GameBoard[7, 7] .TokenXY = "Y";

            int[] testMove = { 8, 8 };
            Pente.GameProcesses.GameRules.RemovePieces(testPlayer, testBoard, testMove);
            Assert.AreNotEqual(testBoard.GameBoard[6, 6], tempBoard.GameBoard[6, 6]);
            Assert.AreNotEqual(testBoard.GameBoard[7, 7], tempBoard.GameBoard[7, 7]);
        }

        //Tests for CheckBoardFor5 method
        [TestMethod]
        public void CheckBoardFor5_ShouldReturnInvalid()
        {
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[6, 6].TokenXY = "X";
            testBoard.GameBoard[7, 7].TokenXY = "X";

            int[] testMove = { 8, 8 };

            Assert.IsFalse(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalDownRight_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 4].TokenXY = "X";
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[6, 6].TokenXY = "X";
            testBoard.GameBoard[7, 7].TokenXY = "X";

            int[] testMove = { 8, 8 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalDownLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[6, 4].TokenXY = "X";
            testBoard.GameBoard[7, 3].TokenXY = "X";
            testBoard.GameBoard[8, 2].TokenXY = "X";

            int[] testMove = { 9, 1 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalUpRight_ShouldReturnValid()
        {
            testBoard.GameBoard[7, 2].TokenXY = "X";
            testBoard.GameBoard[6, 3].TokenXY = "X";
            testBoard.GameBoard[5, 4].TokenXY = "X";
            testBoard.GameBoard[4, 5].TokenXY = "X";

            int[] testMove = { 3, 6 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDiagonalUpLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[7, 7].TokenXY = "X";
            testBoard.GameBoard[6, 6].TokenXY = "X";
            testBoard.GameBoard[5, 5].TokenXY = "X";
            testBoard.GameBoard[4, 4].TokenXY = "X";

            int[] testMove = { 3, 3 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckUp_ShouldReturnValid()
        {
            testBoard.GameBoard[7, 4].TokenXY = "X";
            testBoard.GameBoard[6, 4].TokenXY = "X";
            testBoard.GameBoard[5, 4].TokenXY = "X";
            testBoard.GameBoard[4, 4].TokenXY = "X";

            int[] testMove = { 3, 4 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckDown_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 4].TokenXY = "X";
            testBoard.GameBoard[5, 4].TokenXY = "X";
            testBoard.GameBoard[6, 4].TokenXY = "X";
            testBoard.GameBoard[7, 4].TokenXY = "X";

            int[] testMove = { 8, 4 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckLeft_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 7].TokenXY = "X";
            testBoard.GameBoard[4, 6].TokenXY = "X";
            testBoard.GameBoard[4, 5].TokenXY = "X";
            testBoard.GameBoard[4, 4].TokenXY = "X";

            int[] testMove = { 4, 3 };

            Assert.IsTrue(Pente.GameProcesses.GameRules.CheckBoardFor5(testPlayer, testBoard, testMove));
        }

        [TestMethod]
        public void CheckBoardFor5_CheckRight_ShouldReturnValid()
        {
            testBoard.GameBoard[4, 4].TokenXY = "X";
            testBoard.GameBoard[4, 5].TokenXY = "X";
            testBoard.GameBoard[4, 6].TokenXY = "X";
            testBoard.GameBoard[4, 7].TokenXY = "X";

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
            testBoard.GameBoard[0, 0].TokenXY = "X";
            testBoard.GameBoard[1, 0].TokenXY = "X";
            testBoard.GameBoard[2, 0].TokenXY = "X";
            testBoard.GameBoard[3, 0].TokenXY = "X";
            testBoard.GameBoard[4, 0].TokenXY = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_HorizontalWinBoardNotFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            testBoard.GameBoard[0, 0].TokenXY = "X";
            testBoard.GameBoard[0, 1].TokenXY = "X";
            testBoard.GameBoard[0, 2].TokenXY = "X";
            testBoard.GameBoard[0, 3].TokenXY = "X";
            testBoard.GameBoard[0, 4].TokenXY = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_LeftToRightDiagonalWinBoardNotFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            testBoard.GameBoard[4, 0].TokenXY = "X";
            testBoard.GameBoard[3, 1].TokenXY = "X";
            testBoard.GameBoard[2, 2].TokenXY = "X";
            testBoard.GameBoard[1, 3].TokenXY = "X";
            testBoard.GameBoard[0, 4].TokenXY = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_RightToLeftDiagonalWinBoardNotFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            testBoard.GameBoard[0, 0].TokenXY = "X";
            testBoard.GameBoard[1, 1].TokenXY = "X";
            testBoard.GameBoard[2, 2].TokenXY = "X";
            testBoard.GameBoard[3, 3].TokenXY = "X";
            testBoard.GameBoard[4, 4].TokenXY = "X";
            bool actualValue = Pente.GameProcesses.GameRules.GameOver(testPlayer, testBoard);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void GameOverTest_NoWinsBoardIsFull_ShouldReturnValid()
        {
            bool expectedValue = true;
            bool flipped = true;
            for (int i = 0; i < testBoard.rowCount; i++)
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
                for (int j = 0; j < testBoard.colCount; j++)
                {
                    if (flipped)
                    {
                        if (j % 2 == 0)
                        {
                            testBoard.GameBoard[i, j] .TokenXY = "Y";
                        }
                        else
                        {
                            testBoard.GameBoard[i, j].TokenXY = "X";
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            testBoard.GameBoard[i, j].TokenXY = "X";

                        }
                        else
                        {
                            testBoard.GameBoard[i, j] .TokenXY = "Y";
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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pente;

namespace PenteTests
{
    [TestClass]
    public class PenteTests
    {
        Pente.Models.Board testBoard;

        [TestInitialize]
        public void TestIntitialize()
        {
            testBoard = new Pente.Models.Board();
        }

        //Tests for the IsMoveLegalTest
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

        //Tests for the GameOver Method
        //[TestMethod]
        //public void GameOverTest_NoWinsBoardNotFull_ShouldReturnInvalid()
        //{
        //    bool expectedValue = false;
        //    bool actualValue = Pente.GameProcesses.GameRules.GameOver(testBoard);
        //    Assert.AreEqual(expectedValue, actualValue);
        //}
        //[TestMethod]
        //public void GameOverTest_VerticalWinBoardNotFull_ShouldReturnValid()
        //{
        //    bool expectedValue = false;
        //    testBoard.GameBoard[0, 0] = "X";
        //    testBoard.GameBoard[1, 0] = "X";
        //    testBoard.GameBoard[2, 0] = "X";
        //    testBoard.GameBoard[3, 0] = "X";
        //    testBoard.GameBoard[4, 0] = "X";
        //    bool actualValue = Pente.GameProcesses.GameRules.GameOver(testBoard);
        //    Assert.AreEqual(expectedValue, actualValue);
        //}
        //[TestMethod]
        //public void GameOverTest_HorizontalWinBoardNotFull_ShouldReturnValid()
        //{
        //    bool expectedValue = false;
        //    testBoard.GameBoard[0, 0] = "X";
        //    testBoard.GameBoard[0, 1] = "X";
        //    testBoard.GameBoard[0, 2] = "X";
        //    testBoard.GameBoard[0, 3] = "X";
        //    testBoard.GameBoard[0, 4] = "X";
        //    bool actualValue = Pente.GameProcesses.GameRules.GameOver(testBoard);
        //    Assert.AreEqual(expectedValue, actualValue);
        //}
        //[TestMethod]
        //public void GameOverTest_LeftToRightDiagonalWinBoardNotFull_ShouldReturnValid()
        //{
        //    bool expectedValue = false;
        //    testBoard.GameBoard[4, 0] = "X";
        //    testBoard.GameBoard[3, 1] = "X";
        //    testBoard.GameBoard[2, 2] = "X";
        //    testBoard.GameBoard[1, 3] = "X";
        //    testBoard.GameBoard[0, 4] = "X";
        //    bool actualValue = Pente.GameProcesses.GameRules.GameOver(testBoard);
        //    Assert.AreEqual(expectedValue, actualValue);
        //}
        //[TestMethod]
        //public void GameOverTest_RightToLeftDiagonalWinBoardNotFull_ShouldReturnValid()
        //{
        //    bool expectedValue = false;
        //    testBoard.GameBoard[0, 0] = "X";
        //    testBoard.GameBoard[1, 1] = "X";
        //    testBoard.GameBoard[2, 2] = "X";
        //    testBoard.GameBoard[3, 3] = "X";
        //    testBoard.GameBoard[4, 4] = "X";
        //    bool actualValue = Pente.GameProcesses.GameRules.GameOver(testBoard);
        //    Assert.AreEqual(expectedValue, actualValue);
        //}
        //[TestMethod]
        //public void GameOverTest_NoWinsBoardIsFull_ShouldReturnValid()
        //{
        //    bool expectedValue = false;
        //    bool flipped = true;
        //    for (int i = 0; i < 19; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            if(flipped == false)
        //            {
        //                flipped = true;
        //            }
        //            else
        //            {
        //                flipped = false;
        //            }
        //        }
        //        for (int j = 0; j < 19; j++)
        //        {
        //            if(flipped)
        //            {
        //                if(j % 2 == 0)
        //                {
        //                    testBoard.GameBoard[i, j] = "Y";
        //                }
        //                else
        //                {
        //                    testBoard.GameBoard[i, j] = "X";
        //                }
        //            }
        //            else
        //            {
        //                if (j % 2 == 0)
        //                {
        //                    testBoard.GameBoard[i, j] = "X";
                            
        //                }
        //                else
        //                {
        //                    testBoard.GameBoard[i, j] = "Y";
        //                }
        //            }                    
        //        }
        //    }
        //    bool actualValue = Pente.GameProcesses.GameRules.GameOver(testBoard);
        //    Assert.AreEqual(expectedValue, actualValue);

        //}
    }
}

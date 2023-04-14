using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CsharpCodingExercises.codewars.com._5kyu.TicTacToe_Checker
{
    public class TicTacToe
    {
        /*
        5kyu - Tic-Tac-Toe Checker https://www.codewars.com/kata/525caa5c1bf619d28c000335/train/csharp
        If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is solved, 
        wouldn't we? Our goal is to create a function that will check that for us!

        Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 
        1 if it is an "X", or 2 if it is an "O", like so:

        [[0, 0, 1],
         [0, 1, 2],
         [2, 1, 0]]

        We want our function to return:

        -1 if the board is not yet finished AND no one has won yet (there are empty spots),
        1 if "X" won,
        2 if "O" won,
        0 if it's a cat's game (i.e. a draw).
        You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
         */
        public int IsSolved(int[,] board)
        {
            //check rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i,0] == board[i,1] && board[ i , 1] == board[i , 2])
                {
                    if (board[i, 0] == 1)
                    {
                        return 1;
                    }
                    else if (board[i, 0] == 2)
                    {
                        return 2;
                    }
                }

            }

            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[0,i] == board[1, i] && board[1, i] == board[2,i] )
                {
                    if (board[0, i] == 1)
                    {
                        return 1;
                    }
                    else if (board[0, i] == 2)
                    {
                        return 2;
                    }
                }
            }

            //check diagonals
            if (board[0,0] == board[1,1] && board[1,1] == board[2,2])
            {
                if (board[0, 0] == 1)
                {
                    return 1;
                }
                else if (board[0, 0] == 2)
                {
                    return 2;
                }
            }

            if (board[0,2] == board[1,1] && board[1,1] == board[2,0])
            {
                if (board[0, 2] == 1)
                {
                    return 1;
                }
                else if (board[0, 2] == 2)
                {
                    return 2;
                }
            }

            //check if there are any empty spots
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j] == 0)
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }
    }

    [TestFixture]
    public class TicTacToeTest
    {
        private TicTacToe tictactoe = new TicTacToe();

        [Test]
        public void test1()
        {
            int[,] board = new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } };
            Assert.AreEqual(1, tictactoe.IsSolved(board));
        }
    }
}

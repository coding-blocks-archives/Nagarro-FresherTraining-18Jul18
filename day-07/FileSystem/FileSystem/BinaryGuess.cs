using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class BinaryGuess
    {
        public static int minBoards(int[] board, int numPainters)
        {
            int begValue = 0;
            // TODO
            // int maxValue = Enumerable.Aggregate<int>()
            int maxValue = board.Sum();

            int bestAns = maxValue;

            while(begValue <= maxValue)
            {
                int guess = (begValue + maxValue) / 2;
                bool status = simulate(board, numPainters, guess);
                if (status == true)
                {
                    bestAns = guess;
                    maxValue = guess - 1;
                }
                else
                {
                    // guess was too small
                    begValue = guess + 1;
                }
            }
            return bestAns;
        }

        static bool simulate(int[] boards, int numPainters, int guess)
        {
            int numOfPaintersReq = 1;
            int unitsAllocatedSoFar = 0;

            for(int i = 0; i < boards.Length; ++i)
            {
                int curBoard = boards[i];
                if (unitsAllocatedSoFar + curBoard <= guess)
                {
                    unitsAllocatedSoFar = unitsAllocatedSoFar + curBoard;
                }
                else
                {
                    // the current board cannot be allocated to current Painter
                    ++numOfPaintersReq;
                    if (numOfPaintersReq > numPainters) return false; // painter are less
                    if (curBoard <= guess)
                    {
                        unitsAllocatedSoFar = curBoard;
                    }
                    else
                    {
                        return false;   // guess is small...need to increase that
                    }

                }
            }
            return true;
        }

        public static void main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] board = new int[n];
            InputArray(board);
            int numPainters = int.Parse(Console.ReadLine());
            int ans = minBoards(board, numPainters);
            Console.WriteLine(ans);
        }

        public static void InputArray(int[] arr)
        {
            // TODO make a template 
            String[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = int.Parse(input[i]);
            }
        }
    }
}

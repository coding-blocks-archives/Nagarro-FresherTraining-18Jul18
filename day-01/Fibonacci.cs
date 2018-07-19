using System;

namespace day_01
{
    class Fibonacci
    {
        static int counter = 0;
        public static void RecMain()
        {
            // int n = int.Parse(Console.ReadLine());
            // int ans = fibRec(n);
            // Console.WriteLine(ans);

            // printIncreasing(n);
            // printDecreasing(n);

            // int[] arr = new int[n];
            // Program.InputArray(arr);
            // bubbleSort(arr, 0);
            // Program.OutputArray(arr);

            // String inputStr = Console.ReadLine();
            // char[] decisionSoFar = new char[inputStr.Length];
            // counter = 0;
            // printPermutations(inputStr.ToCharArray(), 0, decisionSoFar, 0);

            int n = int.Parse(Console.ReadLine());
            int[,] board = new int[n,n];
            // how to input board rows using foreach
            Program.InputMatrix(board);
            State status =  solveSudoku(board, 0, 0);
            if (status == State.SUCCESS){
                Program.PrintMatrix(board);
            }
            else {
                Console.WriteLine("Sorry Dude...Can't Solve your sudoku. Neither you can ;-)");
            }
        }
        static int fibRec(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            int prevFib = fibRec(n - 1);
            int superPrev = fibRec(n - 2);
            return prevFib + superPrev;
        }

        static void printIncreasing(int n)
        {
            if (n <= 0) return;
            printIncreasing(n - 1);
            Console.Write(n + " ");
        }

        static void printDecreasing(int n)
        {
            if (n <= 0) return;
            printDecreasing(n - 1);
            Console.Write(n + " ");
        }
        static void bubbleSort(int[] arr, int beginIdx)
        {
            if (beginIdx == arr.Length)
            {
                // no elements in the array...so nothing to sort
                return;
            }

            bubbleSort(arr, beginIdx + 1);
            if (beginIdx + 1 < arr.Length && arr[beginIdx] > arr[beginIdx + 1])
            {
                int tmp = arr[beginIdx];
                arr[beginIdx] = arr[beginIdx + 1];
                arr[beginIdx + 1] = tmp;
                bubbleSort(arr, beginIdx + 1);
            }
        }

        static void printPermutations(char[] inputArr, int beginIdx, char[] decisionSoFar, int idxForDecision)
        {
            if (beginIdx >= inputArr.Length)
            {
                ++counter;
                Console.Write(counter + " ");
                Console.WriteLine(decisionSoFar);
                return;
            }

            char[] originalInput = new char[inputArr.Length];
            Array.Copy(inputArr, originalInput, inputArr.Length);

            for (int i = beginIdx; i < inputArr.Length; ++i)
            {
                // swap
                char tmp = originalInput[i];
                originalInput[i] = originalInput[beginIdx];
                originalInput[beginIdx] = tmp;

                // print Permutations
                decisionSoFar[idxForDecision] = originalInput[beginIdx];

                for (int j = beginIdx; j < inputArr.Length; ++j)
                {
                    inputArr[j] = originalInput[j];
                }

                printPermutations(inputArr, beginIdx + 1, decisionSoFar, idxForDecision + 1);
            }
        }

        enum State { SUCCESS, FAILURE };

        static bool canPlace(int[,] board, int curRow, int curCol, int numToPlace){
            for(int x = 0; x < board.GetLength(0); ++x){
                if (board[curRow, x] == numToPlace) return false;   // check along row
                if (board[x, curCol] == numToPlace) return false;
            }

            // how to make rootN Const 
            int rootN = (int)Math.Sqrt(1.0 * board.GetLength(0));
            int boxStartRow = curRow - curRow % rootN;
            int boxStartCol = curCol - curCol % rootN;

            for(int r = boxStartRow; r < boxStartRow + rootN; ++r){
                for(int c = boxStartCol; c < boxStartCol + rootN; ++c){
                    if (board[r, c] == numToPlace) return false;
                }
            }

            return true;
        }

        static State solveSudoku(int[,] board, int curRow, int curCol){
            // if out of rows, i.e. all upper rows are already filled
            if (curRow == board.GetLength(0)){
                return State.SUCCESS;
            }

            // if out of cols, start with a fresh row
            if (curCol == board.GetLength(0)){
                State statusOfBoardFrmNextRow = solveSudoku(board, curRow + 1, 0);
                return statusOfBoardFrmNextRow;
            }

            // this line No implies that I am on a correct cell within the board
            if (board[curRow, curCol] != 0){
                // its a fixed cell :)...Nothing to do for me
                State statusOfBoardFrmNextCell = solveSudoku(board, curRow, curCol + 1);
                return statusOfBoardFrmNextCell;
            }

            // NOW, this is something I have to work upon
            for(int num = 1; num <= board.GetLength(0); ++num){
                bool check = canPlace(board, curRow, curCol, num);
                if (check == true){
                    // I can place num at cell with coordinates (curRow, curCol)
                    board[curRow, curCol] = num;
                    State statusOfRemBoard = solveSudoku(board, curRow, curCol + 1);
                    if (statusOfRemBoard == State.SUCCESS){
                        // Bingo!!! I have solved the board...nothing to do now
                        return State.SUCCESS;
                    }
                    else {
                        // The potential number which I placed is wrong. Some other potential number should come
                        board[curRow, curCol] = 0;
                    }
                }
            }
            return State.FAILURE;
        }
    }
}
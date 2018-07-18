using System;

namespace day_01
{
    class Fibonacci
    {
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
        
            String inputStr = Console.ReadLine();
            char[] decisionSoFar = new char[inputStr.Length + 1];
            printPermutations(inputStr.ToCharArray(), 0, decisionSoFar, 0);
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
            if (beginIdx >= inputArr.Length){
                Console.WriteLine(decisionSoFar);
                return;
            }

            char[] originalInput = new char[inputArr.Length];
            Array.Copy(originalInput, inputArr, inputArr.Length);

            for (int i = beginIdx; i < inputArr.Length; ++i)
            {
                // swap
                char tmp = originalInput[i];
                originalInput[i] = originalInput[beginIdx];
                originalInput[beginIdx] = tmp;
                Array.Copy(inputArr, originalInput, inputArr.Length);
                // print Permutations
                decisionSoFar[idxForDecision] = inputArr[beginIdx];
                printPermutations(inputArr, beginIdx + 1, decisionSoFar, idxForDecision + 1);   
            }
        }
    }
}
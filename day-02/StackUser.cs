using Adapter;
using System;
using System.Collections.Generic;

// TODO create a generic method without a generic class
namespace AdapterUser
{
    public class StackUser
    {
        public static void insertAtBottom<T>(MyStack<T> stk, T elementToInsert)
        {
            if (stk.Count == 0)
            {
                stk.Push(elementToInsert);
                return;
            }
            T topObj = stk.Top(); stk.Pop();
            insertAtBottom(stk, elementToInsert);
            stk.Push(topObj);
        }

        public static void reverseStack<T>(MyStack<T> stk)
        {
            if (stk.Count == 0)
            {
                return;
            }

            T topObj = stk.Top(); stk.Pop();
            reverseStack(stk);
            insertAtBottom(stk, topObj);
        }

        public static int findHistogramArea(int[] bar)
        {
            int bestArea = 0;
            Stack<int> heightStk = new Stack<int>();
            Stack<int> idxStk = new Stack<int>();

            for (int curIdx = 0; curIdx <= bar.Length; ++curIdx)
            {
                int curBarHeight = curIdx == bar.Length ? -1 : bar[curIdx]; // sentinel
                int indexToBePushed = curIdx;

                while (heightStk.Count != 0 && heightStk.Peek() >= curBarHeight)
                {
                    // it means curBarHeight is the limit of whatever is kept at Top
                    int lengthOfRec = curIdx - idxStk.Peek();
                    int curArea = heightStk.Peek() * lengthOfRec;
                    bestArea = Math.Max(curArea, bestArea);
                    indexToBePushed = idxStk.Peek();
                    heightStk.Pop(); idxStk.Pop();
                }
                idxStk.Push(indexToBePushed);
                heightStk.Push(curBarHeight);
            }
            return bestArea;
        }

        public static void main()
        {
            // MyStack<int> stkInt = new MyStack<int>();

            // stkInt.Push(1);
            // stkInt.Push(2);
            // MyStack<int> stkInt2 = new MyStack<int>(stkInt);

            // while(true){
            //     try
            //     {
            //         Console.WriteLine(stkInt.Top());
            //         stkInt.Pop();
            //     }
            //     catch (System.IndexOutOfRangeException e){
            //         Console.WriteLine(e.Message);
            //         break;
            //     }
            // }

            // Console.WriteLine(stkInt2.Top());

            // MyStack<string> stkString = new MyStack<string>();
            // stkString.Push("apple"); 
            // Console.WriteLine(stkString.Top());

            // MyStack<int> stkInt = new MyStack<int>();
            // stkInt.Push(1);
            // stkInt.Push(2);
            // stkInt.Push(3);
            // reverseStack<int>(stkInt);

            // while (stkInt.Count != 0)
            // {
            //     Console.WriteLine(stkInt.Top());
            //     stkInt.Pop();
            // }
            // Stack is reversed

            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            day_02.Program.InputArray(arr);
            int bestArea = findHistogramArea(arr);
            Console.WriteLine(bestArea);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class PrintAllSubarrays
    {
        public static void main()
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            InputArray(arr);
            PrintAllSubarraysWith0Sum(arr);
        }

        static public void PrintAllSubarraysWith0Sum(int[] arr)
        {
            Dictionary<int, List<int>> sumIdx = new Dictionary<int, List<int>>();
            int sumFrmBeg = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                sumFrmBeg += arr[i];
                if (sumFrmBeg == 0)
                {
                    Console.WriteLine("0 to " + i);
                }

                if (sumIdx.ContainsKey(sumFrmBeg))
                {
                    var curList = sumIdx[sumFrmBeg];
                    foreach (var idx in curList){
                       Console.WriteLine(idx + 1 + " to " + i);
                    }
                }
                
                if (sumIdx.ContainsKey(sumFrmBeg) == false)
                {
                    // this is the first idx that has sumFrmIdx equal to the sum upto idx i
                    // so we need to create a list
                    sumIdx.Add(sumFrmBeg, new List<int>());
                }
                sumIdx[sumFrmBeg].Add(i);
            }
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

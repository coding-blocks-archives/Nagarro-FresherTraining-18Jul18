using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            //KnightMove.main();
            GraphUser.main();


            Console.ReadLine();
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

using System;

namespace day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci.RecMain();
        }

        public static void InputArray(int[] arr){
            // TODO make a template 
            String[] input = Console.ReadLine().Split(' ');
            for(int i = 0; i < arr.Length; ++i){
                arr[i] = int.Parse(input[i]);
            }
        }

        public static void OutputArray(int[] arr){
            // TODO make a template 
            for(int i = 0; i < arr.Length; ++i){
                Console.Write(arr[i] + " ");
            }
        }
    }
}

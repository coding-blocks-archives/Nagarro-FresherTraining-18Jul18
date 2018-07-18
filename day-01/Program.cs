using System;

namespace day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fibonacci.RecMain();
            // GenericProgramming.main();
            Sort.main();
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

        public static void InputMatrix(int[,] mat){     // mat[2, 3]
            String[] linesInFile = System.IO.File.ReadAllLines("in.txt");
            for(int r = 0; r < mat.GetLength(0); ++r){
                String[] curLine = linesInFile[r].Split(' ');
                for(int c = 0; c < mat.GetLength(1); ++c){
                    mat[r, c] = int.Parse(curLine[c]);
                }
            }
        }

        public static void PrintMatrix(int[,] mat){
             for(int r = 0; r < mat.GetLength(0); ++r){
                for(int c = 0; c < mat.GetLength(1); ++c){
                    Console.Write(mat[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

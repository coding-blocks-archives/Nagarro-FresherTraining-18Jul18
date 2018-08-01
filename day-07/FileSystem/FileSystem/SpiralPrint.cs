using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class SpiralPrint
    {
        public static void SpiralPrinting(char[,] mat, int rowDim, int colDim)
        {
            int startRow = 0;
            int endRow = rowDim - 1;
            int startCol = 0;
            int endCol = colDim - 1;
            int numElementToBePrinted = rowDim * colDim;
            int elementsPrintedSoFar = 0;

            while(elementsPrintedSoFar < numElementToBePrinted)
            {
                // print startRow
                for(int c = startCol; elementsPrintedSoFar < numElementToBePrinted && c <= endCol; ++c)
                {
                    Console.Write(mat[startRow, c] + " ");
                    ++elementsPrintedSoFar;
                }
                ++startRow;

                // print endCol
                for(int r = startRow; elementsPrintedSoFar < numElementToBePrinted && r <= endRow; ++r)
                {
                    Console.Write(mat[r, endCol] + " ");
                    ++elementsPrintedSoFar;
                }
                --endCol;

                // print endRow
                for(int c = endCol; elementsPrintedSoFar < numElementToBePrinted && c >= startCol; --c)
                {
                    Console.Write(mat[endRow, c] + " ");
                    ++elementsPrintedSoFar;
                }
                --endRow;


                // print startCol
                for(int r = endRow; elementsPrintedSoFar < numElementToBePrinted && r >= startRow; --r)
                {
                    Console.Write(mat[r, startCol] + " ");
                    ++elementsPrintedSoFar;
                }
                ++startCol;
            }
        }

        public static void main()
        {
            int rDim, cDim;
            rDim = int.Parse(Console.ReadLine());
            cDim = int.Parse(Console.ReadLine());
            char[,] mat = new char[rDim, cDim];

            InputMatrix(mat);
            SpiralPrinting(mat, rDim, cDim);
        }

        public static void InputMatrix(char[,] mat)
        {     // mat[2, 3]
            for (int r = 0; r < mat.GetLength(0); ++r)
            {
                String linesInFile = Console.ReadLine();
                string[] curLine = linesInFile.Split(' ');
                for (int c = 0; c < mat.GetLength(1); ++c)
                {
                    mat[r, c] = char.Parse(curLine[c]);
                }
            }
        }
    }
}

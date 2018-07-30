using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_Miscellaneous
{
    class KnightMove
    {

        public static void main()
        {
            int[] srcCoord = new int[2];
            int[] destCoord = new int[2];
            Program.InputArray(srcCoord);
            Program.InputArray(destCoord);

            int movesReq = MinMovesByKnight(srcCoord, destCoord);
            Console.WriteLine(movesReq);
        }

        public static int MinMovesByKnight(int[] src, int[] dest)
        {
            int[,] movesBoard = new int[8, 8];
            bool[,] visited = new bool[8, 8];

            movesBoard[src[0], src[1]] = 0;
            visited[src[0], src[1]] = true;

            Queue<int> rowQue = new Queue<int>();
            Queue<int> colQue = new Queue<int>();
            rowQue.Enqueue(src[0]);
            colQue.Enqueue(src[1]);

            int[] rowDir = { -2, -1, +1, +2, +2, +1, -1, -2 };
            int[] colDir = { +1, +2, +2, +1, -1, -2, -2, -1 };

            while (rowQue.Count != 0)
            {
                // I have some coordinates process
                int curX = rowQue.Dequeue();
                int curY = colQue.Dequeue();

                if (curX == dest[0] && curY == dest[1])
                {
                    return movesBoard[curX, curY];
                }

                // push all unvisited into the queue
                for(int iDir = 0; iDir < 8; ++iDir)
                {
                    int nextX = curX + rowDir[iDir];
                    int nextY = curY + colDir[iDir];
                    if (nextX >= 0 && nextX < 8 &&
                        nextY >= 0 && nextY < 8 &&
                        visited[nextX, nextY] == false)
                    {
                        visited[nextX, nextY] = true;
                        movesBoard[nextX, nextY] = movesBoard[curX, curY] + 1;
                        rowQue.Enqueue(nextX);
                        colQue.Enqueue(nextY);
                    }
                }
            }
            return - 1;
        }
    }
}

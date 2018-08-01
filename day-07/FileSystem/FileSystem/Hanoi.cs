using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Hanoi
    {
        public static void PrintHanoiSteps(int nDisc, char src, char dest, char helper)
        {
            if (nDisc == 0)
            {
                return;
            }

            PrintHanoiSteps(nDisc - 1, src, helper, dest);
            Console.WriteLine(nDisc + " : " + src + " " + dest);
            PrintHanoiSteps(nDisc - 1, helper, dest, src);
            
        }
        public static void main()
        {
            int nDisc = int.Parse(Console.ReadLine());
            PrintHanoiSteps(nDisc, 'A', 'B', 'C');
        }
    }
}

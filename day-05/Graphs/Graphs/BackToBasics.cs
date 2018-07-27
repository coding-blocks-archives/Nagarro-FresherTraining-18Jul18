using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class BackToBasics
    {
        public static void main()
        {
            int a = 5 / 9;
            int b = (int)(5.0 / 9.0);
            double c = 5 / 9;
            double d = 5.0 / 9.0;
            double e = 5 / 9.0;
            int f = (int)(5 / 9.0);
            double g = 1 + 1 / 3.0;

            Console.WriteLine("a = " + a); 
            Console.WriteLine("b = " + b); 
            Console.WriteLine("c = " + c); 
            Console.WriteLine("d = " + d); 
            Console.WriteLine("e = " + e); 
            Console.WriteLine("f = " + f); 
            Console.WriteLine("g = " + g);

            int x = 2;
            int y = x++ + ++x;
            Console.WriteLine("y = " + y);

            //int p = 2;
            //int q = x++++;
            //int r = ++++q;
            //Console.WriteLine(q + " " + r);

            int p = 10 % 7 * 2;
            int q = 10 * 7 % 2;
            Console.WriteLine(p + " " + q);

        }
    }
}

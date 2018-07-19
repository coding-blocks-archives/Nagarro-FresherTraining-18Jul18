using Adapter;
using System;

namespace AdapterUser
{
    public class StackUser
    {
        public static void main(){
            MyStack<int> stkInt = new MyStack<int>();

            stkInt.Push(1);
            stkInt.Push(2);

            while(true){
                try
                {
                    Console.WriteLine(stkInt.Top());
                    stkInt.Pop();
                }
                catch (System.IndexOutOfRangeException e){
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }
    }
}
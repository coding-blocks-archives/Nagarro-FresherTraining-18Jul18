using System;
using System.Collections.Generic;

// TODO Check what is Add<T>
namespace Adapter
{
    class MyStack<T>
    {
        LinkedList<T> list;
        public int Count { get; private set; }

        public MyStack()
        {
            list = new LinkedList<T>();
            Count = 0;
        }

        public void Push(T obj){
            list.AddLast(obj);
            ++Count;
        }

        public T Top(){
            try
            {
                if (list.Count == 0){
                    throw new System.IndexOutOfRangeException();
                }
                return list.Last.Value;
            }
            catch(System.IndexOutOfRangeException){
                Console.WriteLine("Index out of Bound");
                return default(T);
            }
        }

        public void Pop()
        {
            if (list.Count == 0){
                throw new System.IndexOutOfRangeException("Stack is empty dude!!");
            }
            --Count;
            list.RemoveLast();
        }
    }
}
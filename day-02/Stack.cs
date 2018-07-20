using System;
using System.Collections.Generic;

// Check what is Add<T> : Interface
namespace Adapter
{
    public class MyStack<T>
    {
        LinkedList<T> list;
        ICollection<T> ptr;
        public int Count { get; private set; }

        public MyStack()
        {
            list = new LinkedList<T>();
            ptr = list;
            Count = 0;
        }

        public MyStack(MyStack<T> fromStk){
            list = new LinkedList<T>(fromStk.list);
            Count = 0;   
        }


        public void Push(T obj){
            // list.AddLast(obj);
            // explicit means that the interface methods are public in interface only
            ptr.Add(obj);
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
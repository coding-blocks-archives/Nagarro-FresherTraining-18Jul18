using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_Miscellaneous
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> list;
        int sze;

        private int parent(int idx) { return idx >> 1; }
        private int left(int idx) { return (idx << 1); }
        private int right(int idx) { return (idx << 1) + 1; }
        private void Swap(T a, T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public PriorityQueue()
        {
            list = new List<T>();
            sze = 0;
            list.Add(default(T));
        }

        public void Push(T x)
        {
            list.Add(x);
            ++sze;
            int curIdx = sze;

            //while (parent(curIdx) >= 1 && list[curIdx] < list[parent(curIdx)])

            while (parent(curIdx) >= 1)
            {
                T element1 = list[curIdx];
                T element2 = list[parent(curIdx)];
                if (element1.CompareTo(element2) < 0)
                {
                    Swap(list[curIdx], list[parent(curIdx)]);
                    curIdx = parent(curIdx);
                }
                else
                {
                    break;
                }
            }
        }

        public void Pop()
        {
            if (sze == 0) return;

            Swap(list[1], list[sze]);
            list.RemoveAt(sze);
            --sze;
            heapify(1);
        }

        private void heapify(int curIdx)
        {
            int minIdx = curIdx;
            if (left(curIdx) <= sze)
            {
                T element1 = list[left(curIdx)];
                T element2 = list[curIdx];
                if (element1.CompareTo(element2) < 0)
                {
                    minIdx = left(curIdx);
                }
            }


            if (right(curIdx) <= sze) {
                T element1 = list[right(curIdx)];
                T element2 = list[minIdx];
                if (element1.CompareTo(element2) < 0)

                {
                    minIdx = right(curIdx);
                }
            }
            if (curIdx != minIdx)
            {
                // swapping is required
                Swap(list[curIdx], list[minIdx]);
                heapify(minIdx);
            }
        }

        public T Top()
        {
            if (sze == 0)
            {
                throw new Exception("Stack is empty");
            }
            return list[1];
        }

        public int Count()
        {
            return sze;
        }
    }
}

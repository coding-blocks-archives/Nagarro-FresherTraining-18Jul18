
namespace Container {
    public class PriorityQueue{
        List<int> list;
        int sze;

        private int parent(int idx){ return idx >> 1; }
        private int left(int idx)  { return (idx << 1); }
        private int right(int idx) { return (idx << 1) + 1;}
        private void Swap(ref int a, ref int b){
            int tmp = a;
            a = b;
            b = tmp;
        }

        public PriorityQueue(){
            list = new List<int>();
            sze = 0;
            list.Add(-1);
        }

        public void Push(int x){
            list.Add(x);
            ++sze;
            int curIdx = sze;

            while(parent(curIdx) >= 1 && list[curIdx] < list[parent(curIdx)]){
                Swap(list[curIdx], list[parent(curIdx)]);
                curIdx = parent(curIdx);
            }
        }

        public void Pop(){
            if (sze == 0) return;

            Swap(list[1], list[sze]);
            list.RemoveAt(sze);
            --sze;
            heapify(1);
        } 

        private void heapify(int curIdx){
            int minIdx = curIdx;
            if (left(curIdx) <= sze && list[left(curIdx)] < list[curIdx]){
                minIdx = left(curIdx);
            }

            if (right(curIdx) <= sze && list[right(curIdx)] < list[minIdx]){
                minIdx = right(curIdx);
            }

            if (curIdx != minIdx){
                // swapping is required
                Swap(list[curIdx], list[minIdx]);
                heapify(minIdx);    
            }
        }

        public int Top(){
            if (sze == 0) return -1;
            return list[1];
        }
    } 

    public class PQUser{
        public static void main(){
            PriorityQueue Q = new PriorityQueue();
            Q.Push(1);
            Q.Push(2);
            Console.WriteLine(Q.Top());
            Q.Pop();
            Q.Push(-2);
            Console.WriteLine(Q.Top());
            Q.Pop();
            Q.Push(20);
            Console.WriteLine(Q.Top());
            Q.Pop();
            Q.Push(12);
            Console.WriteLine(Q.Top());
            Console.WriteLine(Q.Top());
            Q.Push(28);
            Console.WriteLine(Q.Top());
            Q.Pop();
            Q.Pop();
            Q.Pop();
            Console.WriteLine(Q.Top());
        }
    }
}
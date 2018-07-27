using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Node
    {
        public string key;         // key
        public string value;        // value

        public Node(string name, string value)
        {
            this.key = name;
            this.value = value;
        }
    }

    class MyHashTable
    {
        private List<LinkedList<Node>> table;
        int capacity;
        int numOfItems;
        private static int PRIME = 7;

        public MyHashTable()
        {
            capacity = PRIME;
            numOfItems = 0;
            table = new List<LinkedList<Node>>();
            SetList();
        }

        private void SetList()
        {
            for(int i = 0; i < capacity; ++i)
            {
                table.Add(new LinkedList<Node>());
            }
        }

        public void insert(string key, string value)
        {
            Node curNode = new Node(key, value);
            InsertNodeIntoTable(curNode);
            ++numOfItems;

            if (LoadFactor() > 0.7)
            {
                Rehash();
            }
        }

        private void InsertNodeIntoTable(Node nodeToInsert)
        {
            int idxToInsertAt = getIndex(nodeToInsert.key);
            LinkedList<Node> listToInsert = table[idxToInsertAt];
            listToInsert.AddFirst(nodeToInsert);
        }

        private int getIndex(string key)
        {
            int ans = 0;
            int mul = 1;
            for(int i = 0; i < key.Length; ++i)
            {
                char curChar = key[i];
                int curDigInBase27 = curChar - 'a';
                int curTerm = (curDigInBase27 % capacity) * (mul % capacity) % capacity;
                mul = (mul % capacity) * (27 % capacity) % capacity;
                ans += curTerm; ans %= capacity;
            }
            return ans;
        }

        double LoadFactor()
        {
            return 1.0 * numOfItems / capacity;
        }

        void Rehash()
        {
            Console.WriteLine("Rehashing is being when numOfItems is " + numOfItems + 
                ". Current Cap "+ capacity);
            
            var oldTable = table;
            int oldCapacity = capacity;
            capacity = 2 * capacity;
            table = new List<LinkedList<Node>>(capacity);
            SetList();

            for(int idx = 0; idx < oldCapacity; ++idx)
            {
                var curList = oldTable[idx];
                while(curList.Count != 0)
                {
                    Node curNode = curList.ElementAt(0);
                    curList.RemoveFirst();
                    InsertNodeIntoTable(curNode);
                }
            }
            oldTable = null;    // explicitly..not required
        }

        public void PrintTable()
        {
           for(int idx = 0; idx < capacity; ++idx)
            {
                Console.Write(idx + "\t: ");
                foreach (Node curNode in table[idx])
                {
                    Console.Write(curNode.key + "(" + curNode.value + ")" + "-->");
                }
                Console.WriteLine();
            }
        }

    }

    class HashMain
    {
        public static void main()
        {
            MyHashTable h = new MyHashTable();
            h.insert("abc", "123");
            h.insert("efg", "123");
            h.insert("hij", "123");
            h.insert("klm", "123");
            h.insert("abcx", "123");
            h.insert("efgx", "123");
            h.insert("hijx", "123");
            h.PrintTable();
        }
    }
}

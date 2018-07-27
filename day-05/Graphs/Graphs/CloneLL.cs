using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class ListNode
    {
        public int data;
        public ListNode random;
        public ListNode next;

        public ListNode(int d)
        {
            data = d;
            next = null;
        }
    }

    class CloneLL
    {
        public static ListNode Create()
        {
            int x;
            ListNode head = null;
            ListNode tail = null;

            while (true)
            {
                x = int.Parse(Console.ReadLine());
                if (x == -1) break;
                ListNode curNode = new ListNode(x);
                if (head == null)
                {
                    // list is empty. curList will become the head
                    head = curNode;
                    tail = curNode;
                }
                else
                {
                    tail.next = curNode;
                    tail = tail.next;
                }

            }
            return head;
        }

        public static void PrintList(ListNode head)
        {
            ListNode curNode = head;
            while (curNode != null)
            {
                Console.Write(curNode.data + "(" + (curNode.random != null ? curNode.random.data : 0) +
                              ")-->");
                curNode = curNode.next;
            }
            Console.WriteLine();
        }

        public static ListNode CloneLinkedList(ListNode head)
        {
            Dictionary<ListNode, ListNode> mapping = new Dictionary<ListNode, ListNode>();

            ListNode curNodeOriginal = head;
            ListNode cloneHead = null;
            ListNode cloneTail = null;

            while(curNodeOriginal != null)
            {
                ListNode cloneCorrespondingToCurNode = new ListNode(curNodeOriginal.data * 10);
                if (cloneHead == null)
                {
                    // this is the first node in the cloned ll
                    cloneHead = cloneTail = cloneCorrespondingToCurNode;
                }
                else
                {
                    cloneTail.next = cloneCorrespondingToCurNode;
                    cloneTail = cloneTail.next;
                }

                // register the mapping in the dictionary

                mapping.Add(curNodeOriginal, cloneCorrespondingToCurNode);
                curNodeOriginal = curNodeOriginal.next;
            }

            // print Map for demonstration purposes
            PrintMap(mapping);

            ListNode curNodeClone = cloneHead;
            /*ListNode*/ curNodeOriginal = head;
            while(curNodeClone != null)
            {
                if (curNodeOriginal.random != null)
                {
                    curNodeClone.random = mapping[curNodeOriginal.random];
                }
                else
                {
                    curNodeClone.random = null;
                }
                curNodeOriginal = curNodeOriginal.next;
                curNodeClone = curNodeClone.next;
            }
            return cloneHead;
        }

        static void PrintMap(Dictionary<ListNode, ListNode> map)
        {
            Console.WriteLine("-----Mapping begins------\n");
            for (int i = 0; i < map.Count; ++i)
            {
                var curElement = map.ElementAt(i);
                Console.WriteLine(curElement.Key.data + "-->" + curElement.Value.data);
            }
            Console.WriteLine("-----Mapping ends------\n");
        }

        public static void CloneLLMain()
        {
            ListNode head = Create();
            head.random = head.next.next;                         // 1    3
            head.next.random = head.next;                         // 2    2
            head.next.next.random = head.next.next.next.next;     // 3    5
            head.next.next.next.random = head.next;               // 4    2
            head.next.next.next.next.random = null;               // 5    NULL

            ListNode newClonedHead = CloneLinkedList(head);
            PrintList(head);
            PrintList(newClonedHead);


        }
    }
    
}

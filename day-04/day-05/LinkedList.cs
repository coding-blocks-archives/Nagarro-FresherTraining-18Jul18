using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_05
{
    class ListNode
    {
        public int data;
        public ListNode next;

        public ListNode(int d)
        {
            data = d;
            next = null;
        }
    }
    class LinkedList
    {
        public static void MainLL()
        {
            ListNode head = LinkedList.Create();
            LinkedList.PrintList(head);

            //head = LinkedList.ReverseLL(head);
            //LinkedList.PrintList(head);

            //head = LinkedList.ReverseLLIter(head);
            //LinkedList.PrintList(head);

            //head = LinkedList.BubbleSort(head);
            //LinkedList.PrintList(head);

            //var ans = DetectCycle(head) == null;
            //head.next.next.next.next.next = head.next.next;
            //Console.WriteLine(ans);

            head.next.next.next.next.next = head.next.next;
            var meetingPt = DetectCycle(head);
            RemoveCycle(head, meetingPt);
            LinkedList.PrintList(head);



        }

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
                Console.Write(curNode.data + "-->");
                curNode = curNode.next;
            }
            Console.WriteLine();
        }

        public static ListNode ReverseLL(ListNode head)
        {
            if (head == null || head.next == null)
            {
                // nothing to do
                return head;
            }

            ListNode startOfRemList = head.next;
            startOfRemList = ReverseLL(startOfRemList);
            head.next.next = head;
            head.next = null;
            return startOfRemList;
        }

        public static ListNode ReverseLLIter(ListNode head)
        {
            ListNode curNode = head;
            ListNode prevNode = null; 

            while (curNode != null)
            {
                ListNode ahead = curNode.next;
                curNode.next = prevNode;
                prevNode = curNode;
                curNode = ahead;
            }
            return prevNode;
        }


        public static int LengthLL(ListNode head)
        {
            if (head == null) return 0;
            return 1 + LengthLL(head.next);
        }

        public static ListNode BubbleSort(ListNode head)
        {
            int totalNodes = LengthLL(head);

            for(int noOfNodesSet = 0; noOfNodesSet < totalNodes; ++noOfNodesSet)
            {
                // subIteration 
                // set the ith Max Node at its correct position
                ListNode curNode = head;
                ListNode prevNode = null;
                
                while(curNode != null && curNode.next != null)
                {
                    ListNode ahead = curNode.next;
                    if (curNode.data > ahead.data)
                    {
                        // swap is required
                        if (curNode == head)
                        {
                            curNode.next = ahead.next;
                            ahead.next = curNode;
                            head = ahead;
                            prevNode = ahead;
                        }
                        else
                        {
                            // this applies swap is req but curNode is not head
                            curNode.next = ahead.next;
                            ahead.next = curNode;
                            prevNode.next = ahead;
                            prevNode = ahead;
                            //ahead = curNode.next; // ...not required since ahead is assigned in every iteration
                        }
                    }
                    else
                    {
                        // swap is not required
                        // let's move ahead
                        prevNode = curNode;
                        curNode = ahead;
                    }
                }

            }
            return head;
        }

        public static ListNode DetectCycle(ListNode head)
        {
            // Get. Set.
            ListNode slow = head;
            ListNode fast = head;
            // GO.
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) { return fast; }
            }
            return null;
        }

        public static void RemoveCycle(ListNode head, ListNode meetingPt)
        {
            ListNode start = head;
            while(start.next != meetingPt.next)
            {
                start = start.next;
                meetingPt = meetingPt.next;
            }

            meetingPt.next = null;
        }
    }
}

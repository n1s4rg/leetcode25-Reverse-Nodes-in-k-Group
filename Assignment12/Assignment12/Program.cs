using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Team members
 
    Abhiroop Singh Abhiroop Singh
    Danish Danish
    Nisarg Kumar Ashokbhai Prajapati
    Deep ParkashKumar Vagehla
    Syed, Samiuddin
    Waghmare, Abhijeet Shekhar
 
 */

namespace Assignment12
{
    public class LinkedListNode
    {
        public int val;
        public LinkedListNode next;
        public LinkedListNode(int val = 0, LinkedListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        public static LinkedListNode reverseLinkedList(LinkedListNode head, int k)
        {
            //find the length of list 
            if (head == null || head.next == null || k == 1)
            {
                return head;
            }

            int length = LengthOfList(head);
            int groupsToReverse = length / k;

            LinkedListNode prevListTail = head;
            LinkedListNode curr = head;

            LinkedListNode resultHead = null;

            while (groupsToReverse > 0)
            {
                LinkedListNode prev = null;
                LinkedListNode next = null;
                LinkedListNode currentListHead = curr;
                int numberOfNodesVisited = 0;
                while (numberOfNodesVisited < k)
                {
                    next = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = next;
                    numberOfNodesVisited++;
                }

                if (resultHead == null)
                {
                    resultHead = prev;
                }
                else
                {
                    prevListTail.next = prev;
                    prevListTail = currentListHead;
                }
                groupsToReverse--;
            }

            prevListTail.next = curr;

            return resultHead;
        }

        public static int LengthOfList(LinkedListNode head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }

            return length;
        }

        static void Main(string[] args)
        {
            //input
            LinkedListNode one = new LinkedListNode(1);
            LinkedListNode two = new LinkedListNode(2);
            LinkedListNode three = new LinkedListNode(3);
            LinkedListNode four = new LinkedListNode(4);
            LinkedListNode five = new LinkedListNode(5);
            one.next = two;
            two.next = three;
            three.next = four;
            four.next = five;

            int k = 2;
            LinkedListNode head = reverseLinkedList(one, k);
            
            //printing linkedlist
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            Console.ReadLine();
        }
    }
}
